using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class UserRoleRepositoryTest : RepositoryTest<UserRole>, IUserRoleRepository
    {
        public UserRoleRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new UserRole()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                RoleName = "Admin"
            });
            _table.Add(new UserRole()
            {
                Id = 2,
                DateCreated = DateTime.Now,
                RoleName = "Student"
            });
        }
    }
}
