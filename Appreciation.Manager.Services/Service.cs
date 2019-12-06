using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected IUnitOfWork _unitOfWork;
        private MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<IEnumerable<T>> GetOrCreateAsync(string key, Func<string[],Task<IEnumerable<T>>> createItem)
        {

            IEnumerable<T> cacheEntry;
            if (!_cache.TryGetValue(key, out cacheEntry))// Look for cache key.
            {
                // Key not in cache, so get data.
                cacheEntry = await createItem(null);

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
            return await _unitOfWork.Repository<T>().GetAllAsync();
        }

        public async virtual Task<T> GetByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync(id);
        }

        public async virtual Task RemoveAsync(T entity)
        {
            await _unitOfWork.Repository<T>().RemoveAsync(entity);
        }

        public async virtual Task AddOrUpdateAsync(T entity)
        {
            await _unitOfWork.Repository<T>().AddOrUpdateAsync(entity);
        }

        public async Task Complete()
        {
            await _unitOfWork.CommitAsync();
        }

        public async Task Completed()
        {
            try
            {
                await _unitOfWork.CommitAsync();
            }
            catch(Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw ex;
            }
        }
    }

}
