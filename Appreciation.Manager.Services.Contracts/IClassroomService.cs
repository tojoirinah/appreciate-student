using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IClassroomService : IService<Classroom>
    {
        Task<IEnumerable<VClassroom>> GetAllBySchoolYearAsync(long schoolYearId);

        Task<IEnumerable<VClassroom>> GetAllViewAsync();
    }
}
