using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _table;
        protected readonly AppreciationContext _context;

        public ReadOnlyRepository(AppreciationContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        protected virtual IQueryable<T> Query(string[] arrays = null)
        {
            var query = _table.AsQueryable<T>();
            if (arrays != null)
            {
                foreach (string propertyName in arrays)
                    query = query.Include(propertyName);

            }
            return query;


        }

        public async Task<IEnumerable<T>> GetAllAsync(string[] arrays = null)
        {
            return await Query(arrays).ToListAsync();
        }

    }
}
