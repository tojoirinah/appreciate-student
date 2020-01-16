using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface ISchoolYearService : IService<SchoolYear>
    {
        Task<SchoolYear> UpdateStatusSchoolYear(UpdateStatusSchoolYearRequest request);
        Task<IEnumerable<VSchoolYear>> GetAllViewAsync();
    }
}
