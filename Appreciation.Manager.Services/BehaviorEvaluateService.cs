using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class BehaviorEvaluateService : Service<BehaviorEvaluate>, IBehaviorEvaluateService
    {

        public BehaviorEvaluateService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddBehaviorEvaluateRequest))
                throw new Exception("Convert type not allowed");

            AddBehaviorEvaluateRequest rq = (AddBehaviorEvaluateRequest)request;
            var item = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateBehaviorEvaluateRequest))
                throw new Exception("Convert type not allowed");

            UpdateBehaviorEvaluateRequest req = (UpdateBehaviorEvaluateRequest)request;
            BehaviorEvaluate item = await _repository.GetByIdAsync(req.Id);
            if (item == null)
                throw new Exception("Behavior evaluate not found");

            req.ProjectTo(item);

            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task<IEnumerable<BehaviorEvaluate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "Behavior", "NoteCriteria" });
        }

        public async override Task<BehaviorEvaluate> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "Behavior", "NoteCriteria" });
        }
    }
}
