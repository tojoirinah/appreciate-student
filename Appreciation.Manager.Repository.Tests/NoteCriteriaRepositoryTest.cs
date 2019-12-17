using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class NoteCriteriaRepositoryTest : RepositoryTest<NoteCriteria>, INoteCriteriaRepository
    {
        public NoteCriteriaRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new NoteCriteria() { 
                Id = 1,
                DateCreated = DateTime.Now,
                NoteMin = 0,
                NoteMax = 5,
                Conseils = "0-5",
                Evaluate = "Evaluate 0-5"
            });
            _table.Add(new NoteCriteria()
            {
                Id = 2,
                DateCreated = DateTime.Now,
                NoteMin = 5,
                NoteMax = 10,
                Conseils = "5-10",
                Evaluate = "Evaluate 5-10"
            });
            _table.Add(new NoteCriteria()
            {
                Id = 3,
                DateCreated = DateTime.Now,
                NoteMin = 10,
                NoteMax = 15,
                Conseils = "10-15",
                Evaluate = "Evaluate 10-15"
            });
            _table.Add(new NoteCriteria()
            {
                Id = 4,
                DateCreated = DateTime.Now,
                NoteMin = 15,
                NoteMax = 20,
                Conseils = "15-20",
                Evaluate = "Evaluate 15-20"
            });

        }
    }
}
