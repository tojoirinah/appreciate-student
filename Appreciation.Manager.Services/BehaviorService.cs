using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class BehaviorService : ServiceReadOnly<Behavior>, IBehaviorService
    {
        private readonly IVBehaviorService _vService;
        public BehaviorService(IMapper mapper, IUnitOfWork unitOfWork, IVBehaviorService vService) : base(unitOfWork, mapper)
        {
            _vService = vService;
        }

        public async override Task<IEnumerable<Behavior>> GetAllAsync()
        {
            string key = typeof(Behavior).FullName;
            return await GetOrCreateAsync(key, _repository.GetAllAsync);
        }

        public async Task<IEnumerable<VBehavior>> GetAllViewAsync()
        {
            return await _vService.GetAllAsync();
        }
    }
}
