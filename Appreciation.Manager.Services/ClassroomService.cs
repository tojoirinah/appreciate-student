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
    public class ClassroomService : Service<Classroom>, IClassroomService
    {
        private readonly IVClassroomService _vService;
        public ClassroomService(IMapper mapper, IUnitOfWork unitOfWork, IVClassroomService vService) : base(unitOfWork, mapper)
        {
            _vService = vService;
        }

        public async override Task<IEnumerable<Classroom>> GetAllAsync()
        {
            return await _repository.GetAllDataAsync(x => !x.SchoolYear.IsClosed, new string[] { "SchoolYear" });
        }

        public async override Task<IEnumerable<Classroom>> GetPageAsync(int page, int pageSize)
        {
            return await _repository.GetDataListPageAsync(x => !x.SchoolYear.IsClosed, page, pageSize, new string[] { "Behavior", "NoteCriteria" });
        }

        public async override Task<Classroom> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "SchoolYear" });
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddClassroomRequest))
                throw new ConversionTypeNotAllowedException();

            AddClassroomRequest rq = (AddClassroomRequest)request;
            var cr = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(cr);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateClassroomRequest))
                throw new ConversionTypeNotAllowedException();

            UpdateClassroomRequest req = (UpdateClassroomRequest)request;

            Classroom cr = await _repository.GetByIdAsync(req.Id);
            if (cr == null)
                throw new EntityNotFoundException<Classroom>();

            req.ProjectTo(cr);

            await _repository.AddOrUpdateAsync(cr);
        }

        public async Task<IEnumerable<VClassroom>> GetAllBySchoolYearAsync(long schoolYearId)
        {
            return await _vService.GetAllBySchoolYearAsync(schoolYearId);
        }

        public async Task<IEnumerable<VClassroom>> GetAllViewAsync()
        {
            return await _vService.GetAllAsync();
        }

        public async Task<IEnumerable<VClassroom>> GetPageViewAsync(int page, int pageSize)
        {
            return await _vService.GetPageAsync(page, pageSize);
        }
    }
}
