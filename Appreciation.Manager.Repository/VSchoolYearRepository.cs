using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VSchoolYearRepository : Repository<VSchoolYear>, IVSchoolYearRepository
    {
        public VSchoolYearRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
