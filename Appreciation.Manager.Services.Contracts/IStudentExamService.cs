using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IStudentExamService : IService<StudentExam>
    {
        Task RemoveAllStudentSchoolYearByStudentId(long studentId);

        Task<IEnumerable<StudentExam>> SearchStudentExam(StudentExamSearchRequest request);

        Task<IEnumerable<StudentExam>> GetListByExam(long examid);

        Task<IEnumerable<StudentExam>> GenerateComment(long examid);

        Task UpdateListAsync(List<StudentExamRequest> request);
    }
}
