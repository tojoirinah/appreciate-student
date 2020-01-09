using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : BaseEntity
    {
        public Repository(AppreciationContext context) : base(context)
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

        public async virtual Task<IEnumerable<T>> GetAllDataAsync(Expression<Func<T, bool>> filter, string[] arrays = null)
        {
            return await Task.Run(() =>
            {

                if (filter == null) throw new ArgumentNullException(nameof(filter),
                                      $"The parameter filter can not be null");

                var query = _table.Where(filter);
                if (arrays != null)
                {
                    foreach (string propertyName in arrays)
                        query = query.Include(propertyName);

                }
                return query.ToList();
            });
        }

        public async virtual Task<T> GetDataAsync(Expression<Func<T, bool>> filter, string[] arrays = null)
        {
            return await Task.Run(() =>
            {
                if (filter == null) throw new ArgumentNullException(nameof(filter),
                                          $"The parameter filter can not be null");

                var query = _table.Where(filter);
                if (arrays != null)
                {
                    foreach (string propertyName in arrays)
                        query = query.Include(propertyName);

                }
                return query.FirstOrDefault();
            });
        }

        public virtual async Task<IEnumerable<T>> ExecWithStoreProcedure(string query, params object[] parameters)
        {

            return await Task.Run(() => _context.Database.SqlQuery<T>(query, parameters).ToList());
        }

        public async Task ExecuteNonQuery(string query, params object[] parameters)
        {
            await Task.Run(() => _context.Database.ExecuteSqlCommand(query, parameters));
        }
    }
}
