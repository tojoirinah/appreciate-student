using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Mappers;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class StudentExamService : Service<StudentExam>, IStudentExamService
    {
        public StudentExamService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddStudentExamRequest))
                throw new Exception("Convert type not allowed");

            AddStudentExamRequest rq = (AddStudentExamRequest)request;
            var std = rq.ProjectTo(_mapper);

            await _repository.AddOrUpdateAsync(std);
        }

        public async Task GenerateComment()
        {
            await ((IStudentExamRepository)_repository).GenerateComment();
        }

        public async Task RemoveAllStudentSchoolYearByStudentId(long studentId)
        {
            await ((IStudentExamRepository)_repository).RemoveByStudentId(studentId);
        }

        public override async Task UpdateAsync(object request)
        {

            if (!(request is UpdateStudentExamRequest))
                throw new Exception("Convert type not allowed");

            UpdateStudentExamRequest req = (UpdateStudentExamRequest)request;
            StudentExam entity = await _repository.GetByIdAsync(req.Id);
            if (entity == null)
                throw new Exception("Student exam not found");

            req.ProjectTo(entity);

            await _repository.AddOrUpdateAsync(entity);
        }
    }
}
