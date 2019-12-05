using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Repository.Tests;
using Appreciation.Manager.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Tests
{
    [TestClass]
    public class StudentServiceTest
    {
        protected IStudentService _service;
        protected IUserService _userService;
        protected IUserNoteService _userNoteService;

        [TestInitialize]
        public void InitTest()
        {
            var unitOfWork = Mock.Of<IUnitOfWork>();

            var userRepository = new UserRepositoryTest(unitOfWork);
            _userService = new UserService(unitOfWork, userRepository);


            var subjectRepository = new SubjectRepositoryTest(unitOfWork);
            var subjectService = new SubjectService(unitOfWork, subjectRepository);

            var exampRepository = new ExamRepositoryTest(unitOfWork);
            var examService = new ExamService(unitOfWork, exampRepository);

            var userEvaluateRepository = new UserEvaluateRepositoryTest(unitOfWork);
            var userEvaluateService = new UserEvaluateService(unitOfWork, userEvaluateRepository);

            var userNoteRepository = new UserNoteRepositoryTest(unitOfWork);
            _userNoteService = new UserNoteService(unitOfWork, userNoteRepository, subjectService, examService, userEvaluateService);

            var studentRepository = new StudentRepositoryTest(unitOfWork);
            _service = new StudentService(unitOfWork, studentRepository, _userService, _userNoteService);


        }

        [TestMethod]
        public async Task AddAsync_ShouldReturnOneMoreElementThanInInitialList()
        {
            var listBeforeInsert = await _service.GetAllAsync();
            var countBeforeInsert = listBeforeInsert.Count();
            var subject = new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            };
            var student = new Student()
            {
                Age = 15,
                Civility = Infrastructure.Enumerations.CivilityEnum.Female,
                DateCreated = DateTime.Now,
                Id = new Guid("065c52ef-6362-4223-9ff1-a9ee4db2eed8"),
                User = new Users()
                {
                    Id = new Guid("836b1be9-b708-4851-b637-fa3f1cf49a72"),
                    DateCreated = DateTime.Now,
                    FirstName = "Prenom 004",
                    Name = "Nom 004",
                    Password = "123456",
                    Role= new UserRole() {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    },
                    SecuritySalt = "123456"
                },
                Notes = new List<UserNote>()
                {
                    new UserNote() {
                        Id = new Guid("5d7d3a49-e6d6-49cd-a2d3-c19842168320"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("6e2a6006-11c5-46a4-82b2-bb26c26a1e68"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 2",
                            Number = 2
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 4
                    },
                    new UserNote()
                    {
                        Id = new Guid("69e23386-6448-487f-b539-4ed1be34b63a"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                        ControlContinu =new Exam() {
                            Id = new Guid("0c33e814-8591-4898-8597-45fb51025edf"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 1",
                            Number = 1
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("a7667c75-e01e-454b-a773-cc55a4c40619"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note correct",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 10
                    },
                    new UserNote()
                    {
                        Id = new Guid("11cd7bdf-be83-4c68-94e6-ccfc508529ba"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("7bb2a5d4-a724-4abd-8e45-033cd3178554"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 3",
                            Number = 3
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 12
                    },
                    new UserNote()
                    {
                        Id = new Guid("34c00a20-d5fb-4c29-a183-69ceb6907891"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("cd662a1d-19f6-4a5b-a3a1-b29aabe19be1"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 4",
                            Number = 4
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("d34238fc-2a51-4268-bfb3-08de50234ff9"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Très bon, continuez comme celà",
                            BehaviorEvaluation = "Comportement exemplaire"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 18
                    }
                }
            };
            await _service.AddOrUpdateAsync(student);

            var listAfterInsert = await _service.GetAllAsync();
            var countAfterInsert = listAfterInsert.Count();

            Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnExistenceElement()
        {
            var id = new Guid("62aa1a04-6475-4189-8161-4b7b6b7fe389");
            var item = await _service.GetByIdAsync(id);

            Assert.IsNotNull(item);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnNull_InexistenceElement()
        {
            var id = Guid.NewGuid();
            var item = await _service.GetByIdAsync(id);

            Assert.IsNotNull(item);
        }

        [TestMethod]
        public async Task RemoveAsync_Nothing_If_ItemDoesntExist()
        {
            var listBeforeRemoving = await _service.GetAllAsync();
            var countBeforeRemoving = listBeforeRemoving.Count();

            var subject = new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            };

            var student = new Student()
            {
                Age = 15,
                Civility = Infrastructure.Enumerations.CivilityEnum.Female,
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid(),
                User = new Users()
                {
                    Id = Guid.NewGuid(),
                    DateCreated = DateTime.Now,
                    FirstName = "Prenom 004",
                    Name = "Nom 004",
                    Password = "123456",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    },
                    SecuritySalt = "123456"
                },
                Notes = new List<UserNote>()
                {
                    new UserNote() {
                        Id = Guid.NewGuid(),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            Name = "Exam 2",
                            Number = 2
                        },
                        Evaluate = new UserEvaluate() {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 4
                    },
                    new UserNote()
                    {
                        Id = new Guid("69e23386-6448-487f-b539-4ed1be34b63a"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                        ControlContinu =new Exam() {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            Name = "Exam 1",
                            Number = 1
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note correct",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 10
                    },
                    new UserNote()
                    {
                        Id = Guid.NewGuid(),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                        ControlContinu = new Exam()
                        {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            Name = "Exam 3",
                            Number = 3
                        },
                        Evaluate = new UserEvaluate() {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 12
                    },
                    new UserNote()
                    {
                        Id = Guid.NewGuid(),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            Name = "Exam 4",
                            Number = 4
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = Guid.NewGuid(),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Très bon, continuez comme celà",
                            BehaviorEvaluation = "Comportement exemplaire"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 18
                    }
                }
            };
            await _service.RemoveAsync(student);

            var listAfterRemoving = await _service.GetAllAsync();
            var countAfterRemoving = listAfterRemoving.Count();

            Assert.AreEqual(countBeforeRemoving, countAfterRemoving);
        }

        [TestMethod]
        public async Task RemoveAsync_If_Exist()
        {
            var listBeforeRemoving = await _service.GetAllAsync();
            var countBeforeRemoving = listBeforeRemoving.Count();
            var subject = new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            };

            var student = new Student()
            {
                Age = 14,
                Civility = Infrastructure.Enumerations.CivilityEnum.Male,
                DateCreated = DateTime.Now,
                Id = new Guid("62aa1a04-6475-4189-8161-4b7b6b7fe389"),
                User = new Users()
                {
                    Id = new System.Guid("0b69677c-1025-45c3-b65a-21573fe9f1fc"),
                    DateCreated = new System.DateTime(2019, 1, 26),
                    FirstName = "Prenom 001",
                    Name = "Nom 001",
                    Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                    SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    },
                },
                Notes = new List<UserNote>()
                {
                    new UserNote() {
                        Id = new Guid("5d7d3a49-e6d6-49cd-a2d3-c19842168320"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("6e2a6006-11c5-46a4-82b2-bb26c26a1e68"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 2",
                            Number = 2
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 4
                    },
                    new UserNote()
                    {
                        Id = new Guid("69e23386-6448-487f-b539-4ed1be34b63a"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                        ControlContinu =new Exam() {
                            Id = new Guid("0c33e814-8591-4898-8597-45fb51025edf"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 1",
                            Number = 1
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("a7667c75-e01e-454b-a773-cc55a4c40619"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note correct",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 10
                    },
                    new UserNote()
                    {
                        Id = new Guid("11cd7bdf-be83-4c68-94e6-ccfc508529ba"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("7bb2a5d4-a724-4abd-8e45-033cd3178554"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 3",
                            Number = 3
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 12
                    },
                    new UserNote()
                    {
                        Id = new Guid("34c00a20-d5fb-4c29-a183-69ceb6907891"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("cd662a1d-19f6-4a5b-a3a1-b29aabe19be1"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 4",
                            Number = 4
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("d34238fc-2a51-4268-bfb3-08de50234ff9"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Très bon, continuez comme celà",
                            BehaviorEvaluation = "Comportement exemplaire"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 18
                    }
                }
            };
            await _service.RemoveAsync(student);

            var listAfterRemoving = await _service.GetAllAsync();
            var countAfterRemoving = listAfterRemoving.Count();

            Assert.AreEqual((countBeforeRemoving - 1), countAfterRemoving);
        }

        [TestMethod]
        public async Task UpdateAsync_IfExist()
        {
            var listBeforeUpdating = await _service.GetAllAsync();
            var countBeforeUpdating = listBeforeUpdating.Count();
            var oldItem = listBeforeUpdating.FirstOrDefault();

            var subject = new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            };

            var newItem = new Student()
            {
                Age = 19,
                Civility = Infrastructure.Enumerations.CivilityEnum.Male,
                DateCreated = DateTime.Now,
                Id = new Guid("62aa1a04-6475-4189-8161-4b7b6b7fe389"),
                User = new Users()
                {
                    Id = new System.Guid("0b69677c-1025-45c3-b65a-21573fe9f1fc"),
                    DateCreated = new System.DateTime(2019, 1, 26),
                    FirstName = "Prenom 007",
                    Name = "Nom 007",
                    Password = "51402fc81279c47ad6c14f335e1348847ec601ad31d2bcb61c0ce2dfa5313f53",
                    SecuritySalt = "bMjKQVV8|G5ZAe9M0wj8X|LIXFZps0CBbfDRhTY32GYPB7PxTnMbHhkX4mumNrlmH9yoaBmBERG4S2hYUC1fnb|zY0KUZ8MNJ0miBfBxsbl3UAMfbf0wlVg8GF8tumrcxD3cgtfTtkIDcEeynFtUevC|GOLF5APPLEegg9MUSIC0walmartjack8XBOX|c5UjOhAYYi3Z12TKxYNsnwp2zuRbw3xPnBv9ejH80jlWLgpE2mYjCfFlnYpzu9C4|qmmYgTgNQOWeKxptfnEkdNMH2JRKzNk1GNg9Yv7hFKxtNBaUJ1ThZXzC8e52c1Td",
                    Role = new UserRole()
                    {
                        Id = (int)RoleEnum.Student,
                        RoleName = "Student"
                    },
                },
                Notes = new List<UserNote>()
                {
                    new UserNote() {
                        Id = new Guid("5d7d3a49-e6d6-49cd-a2d3-c19842168320"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("6e2a6006-11c5-46a4-82b2-bb26c26a1e68"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 2",
                            Number = 2
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 7
                    },
                    new UserNote()
                    {
                        Id = new Guid("69e23386-6448-487f-b539-4ed1be34b63a"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                        ControlContinu =new Exam() {
                            Id = new Guid("0c33e814-8591-4898-8597-45fb51025edf"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 1",
                            Number = 1
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("a7667c75-e01e-454b-a773-cc55a4c40619"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note correct",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 11
                    },
                    new UserNote()
                    {
                        Id = new Guid("11cd7bdf-be83-4c68-94e6-ccfc508529ba"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("7bb2a5d4-a724-4abd-8e45-033cd3178554"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 3",
                            Number = 3
                        },
                        Evaluate = new UserEvaluate() {
                            Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Note assez basse",
                            BehaviorEvaluation = "Comportement inadmissible"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 15
                    },
                    new UserNote()
                    {
                        Id = new Guid("34c00a20-d5fb-4c29-a183-69ceb6907891"),
                        Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        ControlContinu = new Exam()
                        {
                            Id = new Guid("cd662a1d-19f6-4a5b-a3a1-b29aabe19be1"),
                            DateCreated = DateTime.Now,
                            Name = "Exam 4",
                            Number = 4
                        },
                        Evaluate = new UserEvaluate()
                        {
                            Id = new Guid("d34238fc-2a51-4268-bfb3-08de50234ff9"),
                            DateCreated = DateTime.Now,
                            NoteEvaluation = "Très bon, continuez comme celà",
                            BehaviorEvaluation = "Comportement exemplaire"
                        },
                        DateCreated = DateTime.Now,
                        Matiere = subject,
                        Note = 18
                    }
                }
            };

            await _service.AddOrUpdateAsync(newItem);

            var listAfterUpdating = await _service.GetAllAsync();
            var countAfterUpdating = listAfterUpdating.Count();

            var itemUpdated = await _service.GetByIdAsync(newItem.Id);

            var isUpdatedAge = oldItem.Age != itemUpdated.Age;
            var isUpdatedNote = itemUpdated.Notes.Sum(n => n.Note) == (18 + 15 + 11 + 7);
            var isNameUPdated = itemUpdated.User.Name == "Nom 007";
            var isRoleUpdate = itemUpdated.User.Role.Id == (int)RoleEnum.Student;
            var isSameCount = countBeforeUpdating == countAfterUpdating;
            Assert.IsTrue(isUpdatedAge && isSameCount && isUpdatedNote && isNameUPdated && isRoleUpdate);
        }
    }
}
