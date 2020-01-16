using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VExamRepository : Repository<VExam>, IVExamRepository
    {
        public VExamRepository(AppreciationContext context) : base(context)
        {
        }

    }
}
