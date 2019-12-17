using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using System.Collections.Generic;

namespace Appreciation.Manager.Services.Tests2.DataFactory
{
    public class UsersDataFactory
    {
        public static IList<Users> GetUsers()
        {
            var list = new List<Users>();
            int j = 1;
            for (int i = 1; i <= 10; i++)
            {
                list.Add(GetUsersStudent(i));
                j++;
            }

            for (int k = (j + 1); k < 15; k++)
            {
                list.Add(GetUsersAdmin(k));
            }
            return list;
        }



        private static UserRole GetUserRole(RoleEnum role)
        {
            return new UserRole()
            {
                Id = (int)role,
                RoleName = role.ToString()
            };
        }

        private static Users GetUsers(int number, RoleEnum role)
        {
            return new Users()
            {
                Id = number,
                DateCreated = new System.DateTime(2019, 1, 26),
                FirstName = $"Prenom {number}",
                Name = $"Nom {number}",
                UserName = $"UserName{number}",
                Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                Role = GetUserRole(role)
            };
        }

        public static Users GetUsersStudent(int number)
        {
            return GetUsers(number, RoleEnum.Student);
        }

        public static Users GetUsersAdmin(int number)
        {
            return GetUsers(number, RoleEnum.Admin);
        }
    }
}
