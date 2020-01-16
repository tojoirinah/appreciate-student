using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VNoteCriteriaRepository : Repository<VNoteCriteria>, IVNoteCriteriaRepository
    {
        public VNoteCriteriaRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
