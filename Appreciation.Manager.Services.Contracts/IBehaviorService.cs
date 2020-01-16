using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IBehaviorService : IServiceReadOnly<Behavior>
    {
        Task<IEnumerable<VBehavior>> GetAllViewAsync();
    }
}
