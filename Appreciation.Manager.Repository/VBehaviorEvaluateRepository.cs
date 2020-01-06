using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VBehaviorEvaluateRepository : Repository<VBehaviorEvaluate>, IVBehaviorEvaluateRepository
    {
        public VBehaviorEvaluateRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
