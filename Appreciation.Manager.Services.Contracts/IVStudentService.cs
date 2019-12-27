using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Contracts
{
    public interface IVStudentService : IService<VStudent>
    {
        Task<IEnumerable<VStudent>> SearchStudent(StudentSearchRequest request);
    }
}
