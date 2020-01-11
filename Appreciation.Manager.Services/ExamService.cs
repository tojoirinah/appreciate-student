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
    public class ExamService : Service<Exam>, IExamService
    {
        public ExamService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {

        }

        public async override Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _repository.GetAllAsync(new string[] { "Classroom", "SchoolYear" });
        }

        public async override Task<Exam> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "Classroom", "SchoolYear" });
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is ExamRequest))
                throw new Exception("Convert type not allowed");

            ExamRequest rq = (ExamRequest)request;
            var ex = rq.ProjectTo(_mapper);

            await _repository.AddOrUpdateAsync(ex);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is ExamRequest))
                throw new Exception("Convert type not allowed");

            ExamRequest req = (ExamRequest)request;
            Exam ex = await _repository.GetByIdAsync(req.Id);
            if (ex == null)
                throw new Exception("Exam not found");

            req.ProjectTo(ex);

            await _repository.AddOrUpdateAsync(ex);
        }

        public async Task<IEnumerable<Exam>> SearchExam(ExamSearchRequest request)
        {
            return await _repository.GetAllDataAsync(
                x => ((request.SchoolYearId > 0 && x.SchoolYearId == request.SchoolYearId) || request.SchoolYearId == 0)
                    && ((request.ClassroomId > 0 && x.ClassroomId == request.ClassroomId) || request.ClassroomId == 0)
                , new string[] { "Classroom", "SchoolYear" });
        }
    }
}
