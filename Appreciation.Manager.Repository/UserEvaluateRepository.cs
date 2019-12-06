using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class UserEvaluateRepository : Repository<UserEvaluate>, IUserEvaluateRepository
    {
        public UserEvaluateRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
