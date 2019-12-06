using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class NoteCriteriaRepository : Repository<NoteCriteria>, INoteCriteriaRepository
    {
        public NoteCriteriaRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
