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
        public BehaviorService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {

        }

        public async override Task<IEnumerable<Behavior>> GetAllAsync()
        {
            string key = typeof(Behavior).FullName;
            return await GetOrCreateAsync(key, _repository.GetAllAsync);
        }
    }
}
