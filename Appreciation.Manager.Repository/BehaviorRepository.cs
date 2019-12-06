using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class BehaviorRepository : Repository<Behavior>, IBehaviorRepository
    {
        public BehaviorRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
