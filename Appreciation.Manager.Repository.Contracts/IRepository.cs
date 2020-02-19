using Appreciation.Manager.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id, string[] arrays = null);
        Task RemoveAsync(T entity);
        Task RemoveAsync(long id);
        Task AddOrUpdateAsync(T entity);
        Task AddOrUpdateListAsync(List<T> entities);
        Task<T> GetDataAsync(Expression<Func<T, bool>> filter, string[] arrays = null);
        Task<IEnumerable<T>> GetAllDataAsync(Expression<Func<T, bool>> filter, string[] arrays = null);
        Task<IEnumerable<T>> GetDataListPageAsync(Expression<Func<T, bool>> filter, int page, int pageSize, string[] arrays = null);

        Task<IEnumerable<T>> ExecWithStoreProcedure(string query, params object[] parameters);

        Task ExecuteNonQuery(string query, params object[] parameters);
    }
}
