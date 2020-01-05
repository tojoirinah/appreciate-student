using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                throw new Exception("Convert type not allowed");

            AddStudentRequest rq = (AddStudentRequest)request;
            var std = rq.ProjectTo(_mapper);
            std.User = rq.User.ProjectTo(_mapper, RoleEnum.Student);

            // update student
            await _repository.AddOrUpdateAsync(std);
        }

        public async override Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "User", "User.Role", "AnneeScolaire", "ClassRoom" });
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
            await _studentSchoolYearService.RemoveAllStudentSchoolYearByStudentId(student.Id);

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
                throw new Exception("Convert type not allowed");

            UpdateInformationStudentRequest req = (UpdateInformationStudentRequest)request;
            Student std = await _repository.GetByIdAsync(req.Id);
            if (std == null)
                throw new Exception("Student not found");

            req.ProjectTo(std);

            await _repository.AddOrUpdateAsync(std);

        }
    }
}
