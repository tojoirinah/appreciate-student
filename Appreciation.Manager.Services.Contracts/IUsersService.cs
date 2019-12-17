using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IUsersService : IService<Users>
    {

        Task<Users> Login(AuthenticationRequest auth);

        Task UpdatePasswordUsers(UpdatePasswordUsersRequest request);

    }
}
