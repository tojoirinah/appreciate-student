using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;
using System.Collections.Generic;

namespace Appreciation.Manager.Repository.Tests
{
    public class StudentRepositoryTest : RepositoryTest<Student>, IStudentRepository
    {
        public StudentRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var subject = new Subject()
            {
                Id = new System.Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                DateCreated = DateTime.Now,
                Name = "Physique-Chimie"
            };

            _table.Add(new Student()
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
                    }
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
            });
        }
    }
}
