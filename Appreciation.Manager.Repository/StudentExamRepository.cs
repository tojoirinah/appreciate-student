using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class StudentExamRepository : Repository<StudentExam>, IStudentExamRepository
    {
        public StudentExamRepository(AppreciationContext context) : base(context)
        {

        }

        public async Task<IEnumerable<StudentExam>> GenerateComment()
        {
            return await Task.Run(() => _context
               .Database
               .SqlQuery<IEnumerable<StudentExam>>("dbo.sp_GenerateComment")
               .FirstOrDefault());
        }

        public async Task RemoveByStudentId(long studentId)
        {
            var list = _table.Where(item => item.StudentId == studentId);
            if (list != null)
            {
                await Task.Run(() => list.ToList().ForEach(item => _table.Remove(item)));
            }
        }
    }
}
