using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : BaseEntity
    {
        public Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
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
                    _table.Attach(entity);
                    _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
                });
            }
            else
            {
                await AddAsync(entity);
            }

        }
    }
}
