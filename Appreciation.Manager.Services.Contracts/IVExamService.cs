using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVExamService : IService<VExam>
    {
        Task<IEnumerable<VExam>> SearchExam(ExamSearchRequest request);
    }
}
