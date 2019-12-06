using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;

namespace Appreciation.Manager.Services
{
    public class SubjectService : Service<Subject>, ISubjectService
    {
        public SubjectService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
