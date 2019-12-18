using Appreciation.Manager.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id, string[] arrays = null);
        Task RemoveAsync(T entity);
        Task AddOrUpdateAsync(T entity);
        Task<T> GetDataAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllDataAsync(Expression<Func<T, bool>> filter);

        Task<IEnumerable<T>> ExecWithStoreProcedure(string query, params object[] parameters);

        Task ExecuteNonQuery(string query, params object[] parameters);
    }
}
