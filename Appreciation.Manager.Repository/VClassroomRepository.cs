using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class VClassroomRepository : Repository<VClassroom>, IVClassroomRepository
    {
        public VClassroomRepository(AppreciationContext context) : base(context)
        {
        }
    }
}
