using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class UserNoteService : Service<UserNote>, IUserNoteService
    {
        protected readonly IRepository<UserNote> _repository;
        protected readonly ISubjectService _subjectService;
        protected readonly IExamService _examService;
        protected readonly IUserEvaluateService _userEvaluateService;

        public UserNoteService(IUnitOfWork unitOfWork,
            ISubjectService subjectService,
            IExamService examService,
            IUserEvaluateService userEvaluateService) : base(unitOfWork)
        {
            _repository = _unitOfWork.Repository<UserNote>();
            _subjectService = subjectService;
            _examService = examService;
            _userEvaluateService = userEvaluateService;
        }

        public async Task AddAsync(UserNote entity)
        {
            await _subjectService.AddOrUpdateAsync(entity.Matiere);
            await _examService.AddOrUpdateAsync(entity.ControlContinu);
            await _userEvaluateService.AddOrUpdateAsync(entity.Evaluate);
            await _repository.AddOrUpdateAsync(entity);
        }

        public async Task<IEnumerable<UserNote>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "Matiere", "ControlContinu", "Evaluate" });
        }

        public async Task<UserNote> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "Matiere", "ControlContinu", "Evaluate" });
        }

        public async Task RemoveAsync(UserNote entity)
        {
            await _subjectService.RemoveAsync(entity.Matiere);
            await _examService.RemoveAsync(entity.ControlContinu);
            await _userEvaluateService.RemoveAsync(entity.Evaluate);
            await _repository.RemoveAsync(entity);
        }

        public async Task AddOrUpdateAsync(UserNote entity)
        {
            await _subjectService.AddOrUpdateAsync(entity.Matiere);
            await _examService.AddOrUpdateAsync(entity.ControlContinu);
            await _userEvaluateService.AddOrUpdateAsync(entity.Evaluate);
            await _repository.AddOrUpdateAsync(entity);
        }
    }
}
