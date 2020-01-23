using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VStudentChartService : Service<VStudentChart>, IVStudentChartService
    {
        public VStudentChartService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VStudentChart>> GetStudentChart(long studentId)
        {
            return await _repository.GetAllDataAsync(x => x.StudentId == studentId);
        }
    }
}
