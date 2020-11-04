using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Exceptions;
using Appreciation.Manager.Services.Contracts.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class BehaviorEvaluateService : Service<BehaviorEvaluate>, IBehaviorEvaluateService
    {
        private readonly IVBehaviorEvaluateService _vService;
        public BehaviorEvaluateService(IMapper mapper, IUnitOfWork unitOfWork, IVBehaviorEvaluateService service) : base(unitOfWork, mapper)
        {
            _vService = service;
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddBehaviorEvaluateRequest))
                throw new ConversionTypeNotAllowedException();

            AddBehaviorEvaluateRequest rq = (AddBehaviorEvaluateRequest)request;
            var item = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateBehaviorEvaluateRequest))
                throw new ConversionTypeNotAllowedException();

            UpdateBehaviorEvaluateRequest req = (UpdateBehaviorEvaluateRequest)request;
            BehaviorEvaluate item = await _repository.GetByIdAsync(req.Id);
            if (item == null)
                throw new EntityNotFoundException<BehaviorEvaluate>();

            req.ProjectTo(item);

            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task<IEnumerable<BehaviorEvaluate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "Behavior", "NoteCriteria" });
        }

        public async override Task<IEnumerable<BehaviorEvaluate>> GetPageAsync(int page, int pageSize)
        {
            return await _repository.GetPageAsync(page, pageSize, new string[] { "Behavior", "NoteCriteria" });
        }

        public async override Task<BehaviorEvaluate> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "Behavior", "NoteCriteria" });
        }

        public async Task<IEnumerable<VBehaviorEvaluate>> SearchBehaviorEvaluate(BehaviorEvaluateSearchRequest request)
        {
            return await _vService.SearchBehaviorEvaluate(request);
        }
    }
}
