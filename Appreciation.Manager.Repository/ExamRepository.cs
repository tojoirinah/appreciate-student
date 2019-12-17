using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppreciationContext context) : base(context)
        {

        }
    }
}
