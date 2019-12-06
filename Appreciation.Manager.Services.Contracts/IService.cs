using Appreciation.Manager.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task RemoveAsync(T entity);
        Task AddOrUpdateAsync(T entity);
        Task Completed();
    }
}
