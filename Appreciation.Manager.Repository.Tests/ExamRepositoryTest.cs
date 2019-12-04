using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class ExamRepositoryTest : RepositoryTest<Exam>, IExamRepository
    {
        public ExamRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new Exam()
            {
                Id = new Guid("0c33e814-8591-4898-8597-45fb51025edf"),
                DateCreated = DateTime.Now,
                Name = "Exam 1",
                Number = 1
            });
            _table.Add(new Exam()
            {
                Id = new Guid("6e2a6006-11c5-46a4-82b2-bb26c26a1e68"),
                DateCreated = DateTime.Now,
                Name = "Exam 2",
                Number = 2
            });
            _table.Add(new Exam()
            {
                Id = new Guid("7bb2a5d4-a724-4abd-8e45-033cd3178554"),
                DateCreated = DateTime.Now,
                Name = "Exam 3",
                Number = 3
            });
            _table.Add(new Exam()
            {
                Id = new Guid("cd662a1d-19f6-4a5b-a3a1-b29aabe19be1"),
                DateCreated = DateTime.Now,
                Name = "Exam 4",
                Number = 4
            });
        }
    }
}
