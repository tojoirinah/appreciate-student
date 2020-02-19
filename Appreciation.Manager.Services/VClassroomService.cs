using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VClassroomService : Service<VClassroom>, IVClassroomService
    {
        public VClassroomService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async override Task<IEnumerable<VClassroom>> GetAllAsync()
        {
            return await _repository.GetAllDataAsync(x => !x.SchoolYear.IsClosed, new string[] { "SchoolYear" });
        }

        public async override Task<IEnumerable<VClassroom>> GetPageAsync(int page, int pageSize)
        {
            return await _repository.GetPageAsync(page, pageSize, new string[] { "SchoolYear" });
        }


        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VClassroom>> GetAllBySchoolYearAsync(long schoolYearId)
        {
            return await _repository.GetAllDataAsync(x => !x.SchoolYear.IsClosed && x.SchoolYear.Id == schoolYearId, new string[] { "SchoolYear" });
        }
    }
}
