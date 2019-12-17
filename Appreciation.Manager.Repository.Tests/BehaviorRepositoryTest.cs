using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class BehaviorRepositoryTest : RepositoryTest<Behavior>, IBehaviorRepository
    {
        public BehaviorRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new Behavior() { 
                Id = 1,
                DateCreated = DateTime.Now,
                Value = 0,
                ComportementDescription = "0"
            });
            _table.Add(new Behavior()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                Value = 5,
                ComportementDescription = "5"
            });
            _table.Add(new Behavior()
            {
                Id = 2,
                DateCreated = DateTime.Now,
                Value = 10,
                ComportementDescription = "10"
            });
            _table.Add(new Behavior()
            {
                Id = 3,
                DateCreated = DateTime.Now,
                Value = 15,
                ComportementDescription = "15"
            });
            _table.Add(new Behavior()
            {
                Id = 4,
                DateCreated = DateTime.Now,
                Value = 20,
                ComportementDescription = "20"
            });
        }
    }
}
