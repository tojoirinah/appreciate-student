using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IServiceReadOnly<T> : IBaseService where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);

    }

    public interface IService<T> : IServiceReadOnly<T> where T : BaseEntity
    {
        Task RemoveAsync(long id);
        Task AddAsync(object request);
        Task UpdateAsync(object request);
    }

    public interface IBaseService
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
