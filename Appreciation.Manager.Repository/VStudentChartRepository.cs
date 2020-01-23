using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VStudentChartRepository : Repository<VStudentChart>, IVStudentChartRepository
    {
        public VStudentChartRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
