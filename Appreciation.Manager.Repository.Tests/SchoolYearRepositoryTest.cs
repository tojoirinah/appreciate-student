using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Tests
{
    public class SchoolYearRepositoryTest : RepositoryTest<SchoolYear>, ISchoolYearRepository
    {
        public SchoolYearRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new SchoolYear() { 
                Id = 1,
                DateCreated = DateTime.Now,
                Name = "2019-2020"
            });
        }
    }
}
