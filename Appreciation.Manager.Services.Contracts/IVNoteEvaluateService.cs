using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVNoteEvaluateService : IService<VNoteEvaluate>
    {
        Task<IEnumerable<VNoteEvaluate>> SearchNoteEvaluate(NoteEvaluateSearchRequest request);
    }
}
