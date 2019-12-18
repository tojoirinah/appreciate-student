using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Contracts
{
    public interface IStudentExamRepository : IRepository<StudentExam>
    {
        Task RemoveByStudentId(long studentId);


    }
}
