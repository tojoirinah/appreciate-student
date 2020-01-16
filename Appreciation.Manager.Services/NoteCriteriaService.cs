using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class NoteCriteriaService : ServiceReadOnly<NoteCriteria>, INoteCriteriaService
    {
        private readonly IVNoteCriteriaService _vService;
        public NoteCriteriaService(IMapper mapper, IUnitOfWork unitOfWork, IVNoteCriteriaService vService) : base(unitOfWork, mapper)
        {
            _vService = vService;
        }

        public async override Task<IEnumerable<NoteCriteria>> GetAllAsync()
        {
            string key = typeof(NoteCriteria).FullName;
            return await GetOrCreateAsync(key, _repository.GetAllAsync);
        }

        public async Task<IEnumerable<VNoteCriteria>> GetAllViewAsync()
        {
            return await _vService.GetAllAsync();
        }
    }
}
