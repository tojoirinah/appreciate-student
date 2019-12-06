using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class UserRoleRepository : ReadOnlyRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }

}
