using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class BehaviorCriteriaRepository : Repository<BehaviorCriteria>, IBehaviorCriteriaRepository
    {
        public BehaviorCriteriaRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
