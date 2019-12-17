using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class BehaviorEvaluateRepository : Repository<BehaviorEvaluate>, IBehaviorEvaluateRepository
    {
        public BehaviorEvaluateRepository(AppreciationContext context) : base(context)
        {

        }
    }
}
