using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
