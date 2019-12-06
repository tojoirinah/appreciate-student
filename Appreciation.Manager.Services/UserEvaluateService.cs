using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;

namespace Appreciation.Manager.Services
{
    public class UserEvaluateService : Service<UserEvaluate>, IUserEvaluateService
    {
        public UserEvaluateService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
