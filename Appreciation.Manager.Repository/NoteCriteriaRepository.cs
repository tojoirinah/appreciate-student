using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class NoteCriteriaRepository : Repository<NoteCriteria>, INoteCriteriaRepository
    {
        public NoteCriteriaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
