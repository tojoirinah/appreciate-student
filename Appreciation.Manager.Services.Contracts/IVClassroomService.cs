using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVClassroomService : IService<VClassroom>
    {
        Task<IEnumerable<VClassroom>> GetAllBySchoolYearAsync(long schoolYearId);
    }
}
