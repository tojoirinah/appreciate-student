using Appreciation.Manager.Infrastructure;
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
        public Repository(AppreciationContext unitOfWork) : base(unitOfWork)
        // public Repository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public async Task<T> GetByIdAsync(long id, string[] arrays = null)
        {
            return await Task.Run(() => Query(arrays).FirstOrDefault(x => x.Id == id));
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
                    //  _table.Attach(entity);
                    //  _unitOfWork.Context.Entry(entity).State = EntityState.Modified;

                    var entry = _context.Entry<T>(entity);

                    if (entry.State == EntityState.Detached)
                    {
                        var set = _context.Set<T>();
                        T attachedEntity = set.Local.SingleOrDefault(e => e.Id == entity.Id);  // You need to have access to key

                        if (attachedEntity != null)
                        {
                            var attachedEntry = _context.Entry(attachedEntity);
                            attachedEntry.CurrentValues.SetValues(entity);
                        }
                        else
                        {
                            entry.State = EntityState.Modified; // This should attach entity
                        }
                    }

                });
            }
            else
            {
                await Task.Run(() =>
                {
                    entity.DateCreated = DateTime.Now;
                    _table.Add(entity);
                });
            }

        }


    }
}
