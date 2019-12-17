using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Repository.Tests
{
    public class StudentRepositoryTest : RepositoryTest<Student>, IStudentRepository
    {
        public StudentRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new Student() { 
                Id = 1,
                Age = 14,
                Civility = CivilityEnum.Female,
                DateCreated = DateTime.Now,
                User = new Users()
                {
                    Id = 1,
                    DateCreated = new System.DateTime(2019, 1, 26),
                    FirstName = "Prenom 001",
                    Name = "Nom 001",
                    UserName = "UserName001",
                    Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                    SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    }
                }

            });

            _table.Add(new Student()
            {
                Id = 2,
                Age = 14,
                Civility = CivilityEnum.Male,
                DateCreated = DateTime.Now,
                User = new Users()
                {
                    Id = 2,
                    DateCreated = new System.DateTime(2019, 1, 26),
                    FirstName = "Prenom 002",
                    Name = "Nom 002",
                    UserName = "UserName002",
                    Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                    SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    }
                }

            });

            _table.Add(new Student()
            {
                Id = 3,
                Age = 12,
                Civility = CivilityEnum.Male,
                DateCreated = DateTime.Now,
                User = new Users()
                {
                    Id = 3,
                    DateCreated = new System.DateTime(2019, 1, 26),
                    FirstName = "Prenom 003",
                    Name = "Nom 003",
                    UserName = "UserName003",
                    Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                    SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    }
                }

            });
        }
    }
}
