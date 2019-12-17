using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class UserRoleService : ServiceReadOnly<UserRole>, IUserRoleService
    {
        public UserRoleService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public async override Task<IEnumerable<UserRole>> GetAllAsync()
        {
            string key = typeof(UserRole).FullName;
            return await GetOrCreateAsync(key, _repository.GetAllAsync);
        }
    }
}
