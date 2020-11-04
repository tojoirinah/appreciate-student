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
    public class SchoolYearService : Service<SchoolYear>, ISchoolYearService
    {
        private readonly IVSchoolYearService _vService;
        public SchoolYearService(IMapper mapper, IUnitOfWork unitOfWork, IVSchoolYearService vService) : base(unitOfWork, mapper)
        {
            _vService = vService;
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddSchoolYearRequest))
                throw new ConversionTypeNotAllowedException();

            AddSchoolYearRequest rq = (AddSchoolYearRequest)request;
            var item = rq.ProjectTo(_mapper);

            // update student
            await _repository.AddOrUpdateAsync(item);
        }

        public async Task<IEnumerable<VSchoolYear>> GetAllViewAsync()
        {
            return await _vService.GetAllAsync();
        }

        public async  Task<IEnumerable<VSchoolYear>> GetPageViewAsync(int page, int pageSize)
        {
            return await _vService.GetPageAsync(page, pageSize);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateSchoolYearRequest))
                throw new ConversionTypeNotAllowedException();

            UpdateSchoolYearRequest req = (UpdateSchoolYearRequest)request;
            SchoolYear item = await _repository.GetByIdAsync(req.Id);
            if (item == null)
                throw new EntityNotFoundException<SchoolYear>();

            req.ProjectTo(item);

            await _repository.AddOrUpdateAsync(item);
        }

        public async Task<SchoolYear> UpdateStatusSchoolYear(UpdateStatusSchoolYearRequest request)
        {
            SchoolYear u = await _repository.GetByIdAsync(request.Id);

            if (u == null)
                throw new EntityNotFoundException<SchoolYear>();

            request.ProjectTo(u);
            await _repository.AddOrUpdateAsync(u);
            return await Task.Run(() => u);
        }


    }
}
