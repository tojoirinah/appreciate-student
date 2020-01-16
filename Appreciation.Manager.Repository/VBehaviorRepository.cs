using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VBehaviorRepository : Repository<VBehavior>, IVBehaviorRepository
    {
        public VBehaviorRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
