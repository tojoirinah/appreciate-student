using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository
{
    public class StudentSchoolYearRepository : Repository<StudentSchoolYear>, IStudentSchoolYearRepository
    {
        public StudentSchoolYearRepository(AppreciationContext context) : base(context)
        {

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
