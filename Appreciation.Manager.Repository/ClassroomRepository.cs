using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class ClassroomRepository : Repository<Classroom>, IClassroomRepository
    {
        public ClassroomRepository(AppreciationContext context) : base(context)
        {

        }
    }
}
