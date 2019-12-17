using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using AutoMapper;

namespace Appreciation.Manager.Services
{
    public class NoteCriteriaService : ServiceReadOnly<NoteCriteria>, INoteCriteriaService
    {
        public NoteCriteriaService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }
    }
}
