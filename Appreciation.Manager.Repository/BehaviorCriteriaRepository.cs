using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class BehaviorCriteriaRepository : Repository<BehaviorCriteria>, IBehaviorCriteriaRepository
    {
        public BehaviorCriteriaRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
