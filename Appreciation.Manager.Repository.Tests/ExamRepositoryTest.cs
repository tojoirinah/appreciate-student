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
                Id = 1,
                DateCreated = DateTime.Now,
                Name = "Exam 1",
                Number = 1
            });
            _table.Add(new Exam()
            {
                Id = 2,
                DateCreated = DateTime.Now,
                Name = "Exam 2",
                Number = 2
            });
            _table.Add(new Exam()
            {
                Id = 3,
                DateCreated = DateTime.Now,
                Name = "Exam 3",
                Number = 3
            });
            _table.Add(new Exam()
            {
                Id = 4,
                DateCreated = DateTime.Now,
                Name = "Exam 4",
                Number = 4
            });
        }
    }
}
