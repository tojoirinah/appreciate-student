using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;

namespace Appreciation.Manager.Repository
{
    public class SchoolYearRepository : Repository<SchoolYear>, ISchoolYearRepository
    {
        public SchoolYearRepository(AppreciationContext context) : base(context)
        {

        }
    }
}
