using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class SubjectRepositoryTest : RepositoryTest<Subject>, ISubjectRepository
    {
        public SubjectRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            });
        }
    }
}
