using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IExamService : IService<Exam>
    {

        Task<IEnumerable<Exam>> SearchExam(ExamSearchRequest request);
    }
}
