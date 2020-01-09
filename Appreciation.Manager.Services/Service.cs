using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public abstract class Service<T> : ServiceReadOnly<T>, IService<T> where T : BaseEntity
    {

        protected Service(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public abstract Task AddAsync(object request);

        public abstract Task UpdateAsync(object request);

        public async virtual Task RemoveAsync(long id)
        {
            await Task.Run(() =>
            {
                var item = _repository.GetByIdAsync(id);
                if (item != null)
                    _repository.RemoveAsync(item.Result);
            });
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }
    }

    public class BaseService : IBaseService
    {
        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CommitAsync()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _unitOfWork.RollbackAsync();
        }
    }

    public class ServiceReadOnly<T> : BaseService, IServiceReadOnly<T> where T : BaseEntity
    {
        protected readonly IMapper _mapper;

        private readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        protected IRepository<T> _repository;

        public ServiceReadOnly(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
            _repository = _unitOfWork.Repository<T>();
        }

        protected async Task<IEnumerable<T>> GetOrCreateAsync(string key, Func<string[], Task<IEnumerable<T>>> createItem, string[] arrays = null)
        {

            IEnumerable<T> cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = await createItem(arrays);

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSize(11024)//Size amount
                               //Priority on removing when reaching size limit (memory pressure)
                .SetPriority(CacheItemPriority.High)
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromDays(7))
                // Remove from cache after this time, regardless of sliding expiration
                .SetAbsoluteExpiration(TimeSpan.FromDays(7));

                // Save data in cache.
                _cache.Set(key, cacheEntry, cacheEntryOptions);
            }
            return cacheEntry;

        }


        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async virtual Task<T> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }

}
