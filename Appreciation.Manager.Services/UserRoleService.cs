using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class UserRoleService : Service<UserRole>, IUserRoleService
    {
        protected IUserRoleRepository _repository;
        public UserRoleService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async virtual Task<IEnumerable<UserRole>> GetAllAsync()
        {
            string key = typeof(UserRole).FullName;
            return await GetOrCreateAsync(key, _unitOfWork.Repository<UserRole>().GetAllAsync);
        }
    }
}
