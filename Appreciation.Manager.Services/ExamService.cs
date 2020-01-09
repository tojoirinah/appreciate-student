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
            return await _repository.GetAllDataAsync(x => !x.SchoolYear.IsClosed, new string[] { "SchoolYear" });
        }

        public async override Task<Exam> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "SchoolYear" });
        }

        public async override Task AddAsync(object request)
        {
            if (!(request is AddExamRequest))
                throw new Exception("Convert type not allowed");

            AddExamRequest rq = (AddExamRequest)request;
            var ex = rq.ProjectTo(_mapper);

            await _repository.AddOrUpdateAsync(ex);
        }

        public async override Task UpdateAsync(object request)
        {
            if (!(request is UpdateExamRequest))
                throw new Exception("Convert type not allowed");

            UpdateExamRequest req = (UpdateExamRequest)request;
            Exam ex = await _repository.GetByIdAsync(req.Id);
            if (ex == null)
                throw new Exception("Exam not found");

            req.ProjectTo(ex);

            await _repository.AddOrUpdateAsync(ex);
        }


    }
}
