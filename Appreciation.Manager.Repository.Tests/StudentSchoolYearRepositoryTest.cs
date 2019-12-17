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
    public class StudentSchoolYearRepositoryTest : RepositoryTest<StudentSchoolYear>, IStudentSchoolYearRepository
    {
        public StudentSchoolYearRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            #region "Note 0-5"
            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 4,
                Comportement = new Behavior()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Value = 0,
                    ComportementDescription = "0"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
                    Id = 1,
                    Age = 14,
                    Civility = CivilityEnum.Female,
                    DateCreated = DateTime.Now,
                    User = new Users()
                    {
                        Id = 2,
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

                },
                Note = 3,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 5,
                    ComportementDescription = "5"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 3,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 10,
                    ComportementDescription = "10"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 3,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 15,
                    ComportementDescription = "15"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 3,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 20,
                    ComportementDescription = "20"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });
            #endregion

            #region "Note 5-10"
            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 7,
                Comportement = new Behavior()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Value = 0,
                    ComportementDescription = "0"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 7,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 5,
                    ComportementDescription = "5"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 7,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 10,
                    ComportementDescription = "10"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 7,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 15,
                    ComportementDescription = "15"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 7,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 20,
                    ComportementDescription = "20"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });
            #endregion

            #region "Note 10-15"
            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 12,
                Comportement = new Behavior()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Value = 0,
                    ComportementDescription = "0"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 12,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 5,
                    ComportementDescription = "5"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 12,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 10,
                    ComportementDescription = "10"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 12,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 15,
                    ComportementDescription = "15"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 12,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 20,
                    ComportementDescription = "20"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });
            #endregion

            #region "Note 15-20"
            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 19,
                Comportement = new Behavior()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Value = 0,
                    ComportementDescription = "0"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 19,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 5,
                    ComportementDescription = "5"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 19,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 10,
                    ComportementDescription = "10"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 19,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 15,
                    ComportementDescription = "15"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });

            _table.Add(new StudentSchoolYear()
            {
                Id = 1,
                DateCreated = DateTime.Now,
                SchoolYearId = 1,
                Etudiant = new Student()
                {
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

                },
                Note = 19,
                Comportement = new Behavior()
                {
                    Id = 2,
                    DateCreated = DateTime.Now,
                    Value = 20,
                    ComportementDescription = "20"
                },
                AnneeScolaire = new SchoolYear()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "2019-2020"
                },
                ControlContinu = new Exam()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    Name = "Exam 1",
                    Number = 1
                }
            });
            #endregion
        }

        public async Task RemoveByStudentId(long studentId)
        {
            await Task.Run(() => {
                var item = _table.FirstOrDefault(x => x.Etudiant.Id == studentId);
                if (item != null)
                {
                    _table.Remove(item);
                }
            });
        }
    }
}
