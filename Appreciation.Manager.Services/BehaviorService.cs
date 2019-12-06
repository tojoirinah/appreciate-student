using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;

namespace Appreciation.Manager.Services
{
    public class BehaviorService : Service<Behavior>, IBehaviorService
    {
        public BehaviorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
