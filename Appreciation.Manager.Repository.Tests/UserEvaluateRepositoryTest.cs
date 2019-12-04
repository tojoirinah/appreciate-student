using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class UserEvaluateRepositoryTest : RepositoryTest<UserEvaluate>, IUserEvaluateRepository
    {
        public UserEvaluateRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _table.Add(new UserEvaluate()
            {
                Id = new Guid("e9502f39-bb02-439f-b7c2-8b5b7f8ccb04"),
                DateCreated = DateTime.Now,
                NoteEvaluation = "Note assez basse",
                BehaviorEvaluation = "Comportement inadmissible"
            });

            _table.Add(new UserEvaluate()
            {
                Id = new Guid("a7667c75-e01e-454b-a773-cc55a4c40619"),
                DateCreated = DateTime.Now,
                NoteEvaluation = "Note correct",
                BehaviorEvaluation = "Comportement inadmissible"
            });

            _table.Add(new UserEvaluate()
            {
                Id = new Guid("f1b5943f-1b30-4e4d-8607-48ee0a1e2b39"),
                DateCreated = DateTime.Now,
                NoteEvaluation = "Note bon dans l'ensemble",
                BehaviorEvaluation = "Elève sérieux"
            });

            _table.Add(new UserEvaluate()
            {
                Id = new Guid("d34238fc-2a51-4268-bfb3-08de50234ff9"),
                DateCreated = DateTime.Now,
                NoteEvaluation = "Très bon, continuez comme celà",
                BehaviorEvaluation = "Comportement exemplaire"
            });
        }
    }
}
