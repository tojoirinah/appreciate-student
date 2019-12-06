using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class StudentService : Service<Student>, IStudentService
    {
        protected IRepository<Student> _repository;
        protected readonly IUserService _userService;
        protected readonly IUserNoteService _userNoteService;

        public StudentService(IUnitOfWork unitOfWork,  IUserService userService, IUserNoteService userNoteService) : base(unitOfWork)
        {
            _repository = _unitOfWork.Repository<Student>();
            _userService = userService;
            _userNoteService = userNoteService;
        }

        public async Task AddAsync(Student entity)
        {
            await _userService.AddOrUpdateAsync(entity.User);
            if (entity.Notes != null)
            {
                foreach (var note in entity.Notes)
                {
                    await _userNoteService.AddOrUpdateAsync(note);
                }
            }

            await _repository.AddOrUpdateAsync(entity);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "User", "User.Role", "Notes", "Notes.Matiere", "Notes.ControlContinu", "Notes.Evaluate" });
        }

        public async Task<Student> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "User", "User.Role", "Notes", "Notes.Matiere", "Notes.ControlContinu", "Notes.Evaluate" });
        }

        public async Task RemoveAsync(Student entity)
        {
            await _userService.RemoveAsync(entity.User);
            if (entity.Notes != null)
            {
                foreach (var note in entity.Notes)
                {
                    await _userNoteService.RemoveAsync(note);
                }
            }
            await _repository.RemoveAsync(entity);
        }

        public async Task AddOrUpdateAsync(Student entity)
        {
            // set role
            entity.User.RoleId = (int)RoleEnum.Student;
            await _userService.AddOrUpdateAsync(entity.User);
            if (entity.Notes != null)
            {
                foreach (var note in entity.Notes)
                {
                    await _userNoteService.AddOrUpdateAsync(note);
                }
            }
            await _repository.AddOrUpdateAsync(entity);
        }
    }
}
