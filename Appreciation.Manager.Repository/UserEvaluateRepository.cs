using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class UserEvaluateRepository : Repository<UserEvaluate>, IUserEvaluateRepository
    {
        public UserEvaluateRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
