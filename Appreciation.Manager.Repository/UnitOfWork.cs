using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppreciationContext Context { get; }
        private Hashtable _repositories;

        public UnitOfWork(AppreciationContext context)
        {
            if (Context == null)
                Context = context;
        }
        public async Task CommitAsync()
        {
            try
            {
                // await Context.SaveChangesAsync();
                Context.SaveChanges();
                await Dispose();
            }
            catch (Exception ex)
            {
                await Dispose();
                throw ex;
            }
        }

        public async Task RollbackAsync()
        {
            await Task.Run(() => Dispose());
        }

        public async Task Dispose()
        {
            Context.Dispose();
            // Context = null;
            GC.SuppressFinalize(this);
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;
            if (_repositories.ContainsKey(type))
            {
                return (IRepository<TEntity>)_repositories[type];
            }
            var repositoryType = typeof(Repository<>);
            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), Context));
            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
