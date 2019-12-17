using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Tests
{
    public class ReadOnlyRepositoryTest<T> : IReadOnlyRepository<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected IList<T> _table;

        public ReadOnlyRepositoryTest(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _table = unitOfWork.Repository<T>();
        }

        protected virtual IQueryable<T> Query(string[] arrays = null)
        {
            var query = _table.AsQueryable<T>();

            return query;


        }

        public async Task<IEnumerable<T>> GetAllAsync(string[] arrays = null)
        {
            return await Task.Run(() => Query(arrays).ToList<T>());
        }
    }
}
