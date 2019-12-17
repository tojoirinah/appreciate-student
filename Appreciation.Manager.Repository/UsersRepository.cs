using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        public UsersRepository(AppreciationContext context) : base(context)
        {

        }

        public async Task<Users> GetUserName(string username)
        {
            return await _table.FirstOrDefaultAsync(itm => itm.UserName == username);
        }
    }
}
