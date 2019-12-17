using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class SchoolYearService : Service<SchoolYear>, ISchoolYearService
    {
        public SchoolYearService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public override Task AddAsync(object request)
        {
            throw new System.NotImplementedException();
        }

        public override Task UpdateAsync(object request)
        {
            throw new System.NotImplementedException();
        }
    }
}
