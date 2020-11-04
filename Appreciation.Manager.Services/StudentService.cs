using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Mappers;
using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Appreciation.Manager.Services.Contracts.Exceptions;
using System.Data;
using System.Data.SqlClient;

namespace Appreciation.Manager.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        protected readonly IUsersService _userService;
        protected readonly IStudentExamService _studentSchoolYearService;
        protected readonly IVStudentService _vService;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper, IUsersService userService, IStudentExamService studentSchoolYearService, IVStudentService viewStudentService) : base(unitOfWork, mapper)
        {
            _userService = userService;
            _studentSchoolYearService = studentSchoolYearService;
            _vService = viewStudentService;
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddStudentRequest))
                throw new ConversionTypeNotAllowedException();

            AddStudentRequest rq = (AddStudentRequest)request;
            var std = rq.ProjectTo(_mapper, RoleEnum.Student);

            // update student
            await _repository.AddOrUpdateAsync(std);
        }

        public async override Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "User", "User.Role", "AnneeScolaire", "ClassRoom" });
        }

        public async override Task<IEnumerable<Student>> GetPageAsync(int page, int pageSize)
        {
            return await _repository.GetPageAsync(page, pageSize, new string[] { "User", "User.Role", "AnneeScolaire", "ClassRoom" });
        }

        public async override Task<Student> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "User", "User.Role", "AnneeScolaire", "ClassRoom" });
        }

        public async override Task RemoveAsync(long id)
        {
            var student = await _repository.GetByIdAsync(id);

            // remove user
            await _userService.RemoveAsync(student.User.Id);

            // remove all note StudentSchoolYear
            //  await _studentSchoolYearService.RemoveAllStudentSchoolYearByStudentId(student.Id);

            // remove student
            await _repository.RemoveAsync(student);
        }

        public async Task<IEnumerable<VStudent>> SearchStudent(StudentSearchRequest request)
        {
            return await _vService.SearchStudent(request);
        }

        public override async Task UpdateAsync(object request)
        {
            if (!(request is UpdateInformationStudentRequest))
                throw new ConversionTypeNotAllowedException();

            UpdateInformationStudentRequest req = (UpdateInformationStudentRequest)request;
            Student std = await _repository.GetByIdAsync(req.Id);
            if (std == null)
                throw new EntityNotFoundException<Student>();

            req.ProjectTo(std);

            await _repository.AddOrUpdateAsync(std);

        }

        public async Task AddListAsync(List<AddStudentRequest> request)
        {
            if(request.Any())
            {
                var stds = request.ProjectTo(_mapper, RoleEnum.Student);

                // update student
                await _repository.AddOrUpdateListAsync(stds);
            }
        }

        public async Task<string> ImportDatas(List<ImportStudentRequest> request)
        {
            await Task.Run(async () =>
            {
                if (request == null || !request.Any())
                    throw new Exception("No data to import");

                DataTable dt = GetStudentAppreciationDatatable(request);
                var studentParameter = new SqlParameter
                {
                    ParameterName = "student",
                    Direction = ParameterDirection.Input,
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.StudentAppreciation",
                    Value = dt
                };


                int result  = await _repository.ExecuteNonQuery("dbo.sp_ImportDatas @student", studentParameter);
                //return result.Result;
                return $"{result}  students imported";
            });
            return "No data found";
        }

        private DataTable GetStudentAppreciationDatatable(List<ImportStudentRequest> request)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Genre", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("SchoolYear", typeof(string));
            dt.Columns.Add("ClassNumber", typeof(string));

            foreach (var student in request)
            {
                dt.Rows.Add(student.Genre, student.LastName, student.FirstName, student.SchoolYear, student.ClassRoom);
            }

            return dt;
        }
    }
}
