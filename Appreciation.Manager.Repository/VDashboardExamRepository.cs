using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VDashboardExamRepository : Repository<VDashboardExam>, IVDashboardExamRepository
    {
        public VDashboardExamRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
