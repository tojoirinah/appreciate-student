using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVDashboardExamService : IService<VDashboardExam>
    {
        Task<DashboardDto> GenerateDashboard(long examId = 0);
    }
}
