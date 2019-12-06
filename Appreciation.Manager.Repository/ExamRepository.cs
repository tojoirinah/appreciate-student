using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
