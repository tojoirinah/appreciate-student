using Appreciation.Manager.Infrastructure.Models;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IStudentExamService : IService<StudentExam>
    {
        Task RemoveAllStudentSchoolYearByStudentId(long studentId);

        Task GenerateComment();
    }
}
