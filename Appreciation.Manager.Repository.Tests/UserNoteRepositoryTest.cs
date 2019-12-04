using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class UserNoteRepositoryTest : RepositoryTest<UserNote>, IUserNoteRepository
    {
        public UserNoteRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new UserNote()
            {
                Id = new Guid("5d7d3a49-e6d6-49cd-a2d3-c19842168320"),
                Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                ExamId = new Guid("6e2a6006-11c5-46a4-82b2-bb26c26a1e68"),
                UserEvaluateId = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                DateCreated = DateTime.Now,
                SubjectId = new Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                Note = 4
            });

            _table.Add(new UserNote()
            {
                Id = new Guid("69e23386-6448-487f-b539-4ed1be34b63a"),
                Behavior = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                ExamId = new Guid("0c33e814-8591-4898-8597-45fb51025edf"),
                UserEvaluateId = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                DateCreated = DateTime.Now,
                SubjectId = new Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                Note = 10
            });

            _table.Add(new UserNote()
            {
                Id = new Guid("11cd7bdf-be83-4c68-94e6-ccfc508529ba"),
                Behavior = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                ExamId = new Guid("7bb2a5d4-a724-4abd-8e45-033cd3178554"),
                UserEvaluateId = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                DateCreated = DateTime.Now,
                SubjectId = new Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                Note = 12
            });

            _table.Add(new UserNote()
            {
                Id = new Guid("34c00a20-d5fb-4c29-a183-69ceb6907891"),
                Behavior = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                ExamId = new Guid("cd662a1d-19f6-4a5b-a3a1-b29aabe19be1"),
                UserEvaluateId = new Guid("d34238fc-2a51-4268-bfb3-08de50234ff9"),
                DateCreated = DateTime.Now,
                SubjectId = new Guid("9f9ad5af-72bb-4375-a934-8d408529ea7f"),
                Note = 18
            });
        }
    }
}
