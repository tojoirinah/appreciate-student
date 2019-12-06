using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Infrastructure;

namespace Appreciation.Manager.Repository
{
    public class UserNoteRepository : Repository<UserNote>, IUserNoteRepository
    {
        public UserNoteRepository(AppreciationContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
