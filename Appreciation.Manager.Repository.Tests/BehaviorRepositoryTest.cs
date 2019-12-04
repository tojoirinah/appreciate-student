using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository.Tests
{
    public class BehaviorRepositoryTest : RepositoryTest<Behavior>, IBehaviorRepository
    {
        public BehaviorRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
