using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IStudentExamService : IService<StudentExam>
    {
        Task RemoveAllStudentSchoolYearByStudentId(long studentId);

        Task GenerateComment();

        Task<IEnumerable<StudentExam>> SearchStudentExam(StudentExamSearchRequest request);
    }
}
