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
                        Id = 1,
                        DateCreated = DateTime.Now,
                        Criteria = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                        Evaluate = "Continuez comme celà"
                    });
                _table.Add(new BehaviorCriteria()
                {
                    Id =2,
                    DateCreated = DateTime.Now,
                    Criteria = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                    Evaluate = "Vous devriez changer votre comportement"
                });
                _table.Add(new BehaviorCriteria()
                {
                    Id = 3,
                    DateCreated = DateTime.Now,
                    Criteria = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                    Evaluate = "Vous manquez d'investissement"
                });
            }
        }
    }
}
