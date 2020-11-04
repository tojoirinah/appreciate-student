using System.Collections.Generic;
using System.Threading.Tasks;

using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Exceptions;
using Appreciation.Manager.Services.Contracts.Mappers;

using AutoMapper;

namespace Appreciation.Manager.Services
{
    public class NoteEvaluateService : Service<NoteEvaluate>, INoteEvaluateService
    {
        protected readonly IVNoteEvaluateService _vService;
        public NoteEvaluateService(IUnitOfWork unitOfWork, IMapper mapper, IVNoteEvaluateService vService) : base(unitOfWork, mapper)
        {
            _vService = vService;
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddNoteEvaluateRequest))
                throw new ConversionTypeNotAllowedException();

            AddNoteEvaluateRequest rq = (AddNoteEvaluateRequest)request;
            var item = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateNoteEvaluateRequest))
                throw new ConversionTypeNotAllowedException();

            UpdateNoteEvaluateRequest req = (UpdateNoteEvaluateRequest)request;
            NoteEvaluate item = await _repository.GetByIdAsync(req.Id);
            if (item == null)
                throw new EntityNotFoundException<NoteEvaluate>();

            req.ProjectTo(item);

            await _repository.AddOrUpdateAsync(item);
        }

        public async override Task<IEnumerable<NoteEvaluate>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "NoteCriteria" });
        }

        public async override Task<IEnumerable<NoteEvaluate>> GetPageAsync(int page, int pageSize)
        {
            return await _repository.GetPageAsync(page, pageSize, new string[] { "NoteCriteria" });
        }

        public async override Task<NoteEvaluate> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "NoteCriteria" });
        }

        public async Task<IEnumerable<VNoteEvaluate>> SearchNoteEvaluate(NoteEvaluateSearchRequest request)
        {
            return await _vService.SearchNoteEvaluate(request);
        }
    }
}
