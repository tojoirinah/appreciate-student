using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VNoteEvaluateRepository : Repository<VNoteEvaluate>, IVNoteEvaluateRepository
    {
        public VNoteEvaluateRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
