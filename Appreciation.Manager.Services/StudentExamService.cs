using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Mappers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            if (!(request is StudentExamRequest))
                throw new Exception("Convert type not allowed");

            StudentExamRequest rq = (StudentExamRequest)request;
            var std = rq.ProjectTo(_mapper);

            await _repository.AddOrUpdateAsync(std);
        }

        public async Task GenerateComment()
        {
            await _repository.ExecuteNonQuery("dbo.sp_GenerateComment");
        }

        public async Task<IEnumerable<StudentExam>> GetListByExam(long examid)
        {
            return await _repository.GetAllDataAsync(x => x.ExamId == examid 
                                                        && !x.ControlContinu.SchoolYear.IsClosed
                                                        && !x.IsClosed, 
                new string[] { "Etudiant", 
                               "Etudiant.User",
                               "Etudiant.User.Role",
                               "Etudiant.AnneeScolaire",
                               "Etudiant.Classroom",
                               "Comportement", 
                               "ControlContinu", 
                               "ControlContinu.SchoolYear",
                               "ControlContinu.Classroom"});
        }

        public async Task RemoveAllStudentSchoolYearByStudentId(long studentId)
        {
            await ((IStudentExamRepository)_repository).RemoveByStudentId(studentId); // todo
        }

        public async Task<IEnumerable<StudentExam>> SearchStudentExam(StudentExamSearchRequest request)
        {
            var schoolYearIdParameter = new SqlParameter
            {
                ParameterName = "schoolYearId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.SchoolYearId
            };

            var classroomIdParameter = new SqlParameter
            {
                ParameterName = "classroomId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.ClassroomId
            };

            var examIdParameter = new SqlParameter
            {
                ParameterName = "examId",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = request.ExamId
            };

            return await _repository.ExecWithStoreProcedure("dbo.sp_SearchStudentExam @schoolYearId, @classroomId, @examId", schoolYearIdParameter, classroomIdParameter, examIdParameter);

        }

        public override async Task UpdateAsync(object request)
        {

            if (!(request is StudentExamRequest))
                throw new Exception("Convert type not allowed");

            StudentExamRequest req = (StudentExamRequest)request;
            StudentExam entity = await _repository.GetByIdAsync(req.Id);
            if (entity == null)
                throw new Exception("Student exam not found");

            req.ProjectTo(entity);

            await _repository.AddOrUpdateAsync(entity);
        }
    }
}
