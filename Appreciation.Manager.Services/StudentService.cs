using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        protected IRepository<Student> _repository;
        protected readonly IUserService _userService;
        protected readonly IStudentSchoolYearService _studentSchoolYearService;

        public StudentService(IUnitOfWork unitOfWork, IUserService userService, IStudentSchoolYearService studentSchoolYearService) : base(unitOfWork)
        {
            _repository = _unitOfWork.Repository<Student>();
            _userService = userService;
            _studentSchoolYearService = studentSchoolYearService;
        }

        public async Task AddAsync(Student entity)
        {
            // update user
            await _userService.AddOrUpdateAsync(entity.User);
            // update student
            await _repository.AddOrUpdateAsync(entity);
        }

        public async override Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "User", "User.Role", "Notes", "Notes.Matiere", "Notes.ControlContinu", "Notes.Evaluate" });
        }

        public async override Task<Student> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "User", "User.Role", "Notes", "Notes.Matiere", "Notes.ControlContinu", "Notes.Evaluate" });
        }

        public async override Task RemoveAsync(Student entity)
        {
            // remove user
            await _userService.RemoveAsync(entity.User);

            // remove all note StudentSchoolYear
            await _studentSchoolYearService.RemoveAllStudentSchoolYearByStudentId(entity.Id);

            // remove student
            await _repository.RemoveAsync(entity);
        }

        public async override Task AddOrUpdateAsync(Student entity)
        {
            // set role
            entity.User.RoleId = (int)RoleEnum.Student;
            // add user
            await _userService.AddOrUpdateAsync(entity.User);
            // add student
            await _repository.AddOrUpdateAsync(entity);
        }
    }
}
