using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public AppreciationContext Context { get; }

        public UnitOfWork(AppreciationContext context)
        {
            if (Context == null)
            {
                Context = context;
            }
        }
        public async Task CommitAsync()
        {
            try
            {
                if (Context != null && !Context.IsDisposed)
                {
                    await Context.SaveChangesAsync();
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                Dispose();
                throw ex;
            }
        }

        public async Task RollbackAsync()
        {
            await Task.Run(() => Dispose());
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
