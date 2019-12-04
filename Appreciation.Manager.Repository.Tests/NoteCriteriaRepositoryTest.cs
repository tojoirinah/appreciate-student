using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository.Tests
{
    public class NoteCriteriaRepositoryTest : RepositoryTest<NoteCriteria>, INoteCriteriaRepository
    {
        public NoteCriteriaRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
