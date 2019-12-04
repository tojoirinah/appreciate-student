using Appreciation.Manager.Infrastructure;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IUnitOfWork
    {
        AppreciationContext Context { get; }

        Task CommitAsync();

        Task RollbackAsync();
    }
}
