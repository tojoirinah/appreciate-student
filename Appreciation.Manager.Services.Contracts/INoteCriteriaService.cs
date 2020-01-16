using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface INoteCriteriaService : IServiceReadOnly<NoteCriteria>
    {
        Task<IEnumerable<VNoteCriteria>> GetAllViewAsync();
    }
}
