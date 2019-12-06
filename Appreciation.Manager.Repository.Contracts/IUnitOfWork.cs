using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IUnitOfWork
    {
        AppreciationContext Context { get; }

        Task CommitAsync();

        Task RollbackAsync();

        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
