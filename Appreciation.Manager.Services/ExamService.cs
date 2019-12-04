using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;

namespace Appreciation.Manager.Services
{
    public class ExamService : Service<Exam>, IExamService
    {
        public ExamService(IUnitOfWork unitOfWork, IExamRepository repository) : base(unitOfWork, repository)
        {

        }
    }
}
