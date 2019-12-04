using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using System;

namespace Appreciation.Manager.Repository.Tests
{
    public class BehaviorCriteriaRepositoryTest : RepositoryTest<BehaviorCriteria>, IBehaviorCriteriaRepository
    {
        public BehaviorCriteriaRepositoryTest(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            if (_table != null)
            {
                _table.Add(
                    new BehaviorCriteria()
                    {
                        Id = new System.Guid("fea91a23-28f7-421a-a592-c01d0a7dd6e4"),
                        DateCreated = DateTime.Now,
                        Criteria = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        Evaluate = "Continuez comme celà"
                    });
                _table.Add(new BehaviorCriteria()
                {
                    Id = new System.Guid("c333b946-1f28-48a1-950a-93354555a672"),
                    DateCreated = DateTime.Now,
                    Criteria = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                    Evaluate = "Vous devriez changer votre comportement"
                });
                _table.Add(new BehaviorCriteria()
                {
                    Id = new System.Guid("a4c57c9d-b5a1-47ae-b466-bc4ac6f7e916"),
                    DateCreated = DateTime.Now,
                    Criteria = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                    Evaluate = "Vous manquez d'investissement"
                });
            }
        }
    }
}
