using Appreciation.Manager.Infrastructure.Models;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IStudentSchoolYearService : IService<StudentSchoolYear>
    {
        Task RemoveAllStudentSchoolYearByStudentId(long studentId);
    }
}
