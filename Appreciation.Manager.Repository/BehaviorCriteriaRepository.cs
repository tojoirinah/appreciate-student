using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class BehaviorCriteriaRepository : Repository<BehaviorCriteria>, IBehaviorCriteriaRepository
    {
        public BehaviorCriteriaRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
