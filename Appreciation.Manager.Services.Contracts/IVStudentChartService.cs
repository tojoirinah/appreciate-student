using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVStudentChartService : IService<VStudentChart>
    {
        Task<IEnumerable<VStudentChart>> GetStudentChart(long studentId);
    }
}
