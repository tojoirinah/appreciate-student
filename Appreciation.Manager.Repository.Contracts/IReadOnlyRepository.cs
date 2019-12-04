using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(string[] arrays = null);
    }
}
