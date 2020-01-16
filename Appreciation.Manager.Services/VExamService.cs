using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VExamService : Service<VExam>, IVExamService
    {
        public VExamService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }



        public override Task AddAsync(object request)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VExam>> SearchExam(ExamSearchRequest request)
        {
            return await _repository.GetAllDataAsync(
         x => ((request.SchoolYearId > 0 && x.SchoolYearId == request.SchoolYearId) || request.SchoolYearId == 0)
             && ((request.ClassroomId > 0 && x.ClassroomId == request.ClassroomId) || request.ClassroomId == 0)
         , new string[] { "Classroom", "SchoolYear" });
        }

        public override Task UpdateAsync(object request)
        {
            throw new NotImplementedException();
        }
    }
}
