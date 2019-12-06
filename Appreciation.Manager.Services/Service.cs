using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class Service<T> : IService<T> where T : BaseEntity
    {
        protected IUnitOfWork _unitOfWork;
        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
