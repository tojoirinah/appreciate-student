using Appreciation.Manager.Infrastructure.Models;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IStudentSchoolYearRepository : IRepository<StudentSchoolYear>
    {
        Task RemoveByStudentId(long studentId);
    }
}
