using Appreciation.Manager.Infrastructure.Models;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetUserName(string username);
    }
}
