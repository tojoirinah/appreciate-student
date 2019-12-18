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
    public class NoteEvaluateService : Service<NoteEvaluate>, INoteEvaluateService
    {
        public NoteEvaluateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddNoteEvaluateRequest))
                throw new Exception("Convert type not allowed");

            AddNoteEvaluateRequest rq = (AddNoteEvaluateRequest)request;
            var item = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateNoteEvaluateRequest))
                throw new Exception("Convert type not allowed");

            UpdateNoteEvaluateRequest req = (UpdateNoteEvaluateRequest)request;
            NoteEvaluate item = await _repository.GetByIdAsync(req.Id);
            if (item == null)
                throw new Exception("Behavior evaluate not found");

            req.ProjectTo(item);

            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task<IEnumerable<NoteEvaluate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "NoteCriteria" });
        }

        public async override Task<NoteEvaluate> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "NoteCriteria" });
        }
    }
}
