using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Tests
{
    public class RepositoryTest<T> : ReadOnlyRepositoryTest<T>, IRepository<T> where T : BaseEntity
    {
        public RepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<T> GetByIdAsync(Guid id, string[] arrays = null)
        {
            return await Task.Run(() => Query(arrays).FirstOrDefault());
        }



        private async Task AddAsync(T entity)
        {
            await Task.Run(() => _table.Add(entity));
        }

        public async Task RemoveAsync(T entity)
        {
            var item = _table.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                await Task.Run(() => _table.Remove(item));
            }
        }

        public async Task AddOrUpdateAsync(T entity)
        {
            var item = _table.FirstOrDefault(i => i.Id == entity.Id);
            if (item != null)
            {
                await Task.Run(() =>
                {
                    _table.Remove(item);
                    _table.Add(entity);

                });
            }
            else
            {
                await AddAsync(entity);
            }

        }
    }
}
