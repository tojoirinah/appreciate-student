using Appreciation.Manager.Infrastructure.Models;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id, string[] arrays = null);
        Task RemoveAsync(T entity);
        Task AddOrUpdateAsync(T entity);
    }
}
