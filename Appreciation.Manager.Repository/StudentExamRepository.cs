using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class StudentExamRepository : Repository<StudentExam>, IStudentExamRepository
    {
        public StudentExamRepository(AppreciationContext context) : base(context)
        {

        }

        //public async Task<IEnumerable<StudentExam>> GenerateComment()
        //{
        //    return  await Task.Run(() => _context
        //       .Database
        //       .SqlQuery<StudentExam>("dbo.sp_GenerateComment")
        //       .ToList());
        //}

        public async Task RemoveByStudentId(long studentId)
        {
            var list = _table.Where(item => item.StudentId == studentId);
            if (list != null)
            {
                await Task.Run(() => list.ToList().ForEach(item => _table.Remove(item)));
            }
        }

        //public async Task<IEnumerable<StudentExam>> SearchStudentExam(long schoolYearId, long classroomId, long examId)
        //{
        //    var schoolYearIdParameter = new SqlParameter
        //    {
        //        ParameterName = "schoolYearId",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.BigInt,
        //        Value = schoolYearId
        //    };

        //    var classroomIdParameter = new SqlParameter
        //    {
        //        ParameterName = "classroomId",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.BigInt,
        //        Value = classroomId
        //    };

        //    var examIdParameter = new SqlParameter
        //    {
        //        ParameterName = "examId",
        //        Direction = ParameterDirection.Input,
        //        SqlDbType = SqlDbType.BigInt,
        //        Value = examId
        //    };

        //    return await Task.Run(() => 
        //        _context
        //           .Database
        //           .SqlQuery<StudentExam>("dbo.sp_SearchStudentExam @schoolYearId, @classroomId, @examId", schoolYearIdParameter, classroomIdParameter, examIdParameter)
        //           .ToList()
        //       );
        //}
    }
}
