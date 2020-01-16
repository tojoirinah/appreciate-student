using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class VDashboardExamService : Service<VDashboardExam>, IVDashboardExamService
    {
        public VDashboardExamService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
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

        public async Task<DashboardDto> GenerateDashboard(long examId = 0)
        {
            var examIdParameter = new SqlParameter
            {
                ParameterName = "examIdParam",
                Direction = ParameterDirection.Input,
                SqlDbType = SqlDbType.BigInt,
                Value = examId
            };


            var listVDashboardExam = await _repository.ExecWithStoreProcedure("dbo.sp_GetDashboardExam @examIdParam", examIdParameter);

            var dtos = await GetDashboardDto(listVDashboardExam);
            return dtos;
        }

        public async Task GenerateStudentExam()
        {
            await _repository.ExecuteNonQuery("dbo.sp_GenerateStudentExam");
        }

        void BuildSchoolYear(IList<SchoolYearDto> source, VDashboardExam item)
        {
            var schoolYear = source.FirstOrDefault(x => x.Id == item.SchoolYearId);
            if (schoolYear == null)
            {
                schoolYear = new SchoolYearDto(item.SchoolYearId, item.SchoolYearName);
                source.Add(schoolYear);
            }
            BuildClassroom(schoolYear.Classrooms, item);

        }

        void BuildClassroom(IList<ClassroomDto> source, VDashboardExam item)
        {
            var classRoom = source.FirstOrDefault(x => x.Id == item.ClassroomId);
            if (classRoom == null)
            {
                classRoom = new ClassroomDto(item.ClassroomId, item.ClassNumber);
                source.Add(classRoom);
            }
            BuildExam(classRoom.Exams, item);
        }

        void BuildExam(IList<ExamDto> source, VDashboardExam item)
        {
            var exam = source.FirstOrDefault(x => x.Id == item.ExamId);
            if (exam == null)
            {
                exam = new ExamDto(item.ExamId, item.ExamName, item.TotalStudents, item.TotalAbsents, item.TotalWaitingNonReseigne, item.PercentNoteRenseigne);
                source.Add(exam);
            }
        }

        private async Task<DashboardDto> GetDashboardDto(IEnumerable<VDashboardExam> list)
        {
            DashboardDto dto = new DashboardDto();
            if (list != null && list.Any())
            {

                foreach (var item in list)
                {
                    BuildSchoolYear(dto.SchoolYears, item);
                }
            }
            return dto;
        }

        
    }
}
