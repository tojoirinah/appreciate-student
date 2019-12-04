using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Repository.Tests;
using Appreciation.Manager.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Tests
{
    [TestClass]
    public class BehaviorCriteriaServiceTest
    {
        protected IBehaviorCriteriaService _service;

        [TestInitialize]
        public void InitTest()
        {
            var unitOfWork = Mock.Of<IUnitOfWork>();
            IBehaviorCriteriaRepository repository = new BehaviorCriteriaRepositoryTest(unitOfWork);
            _service = new BehaviorCriteriaService(unitOfWork, repository);


        }

        [TestMethod]
        public async Task AddAsync_ShouldReturnOneMoreElementThanInInitialList()
        {
            var listBeforeInsert = await _service.GetAllAsync();
            var countBeforeInsert = listBeforeInsert.Count();
            var behaviorCriteria = new BehaviorCriteria()
            {
                Id = new System.Guid("a06f96fb-fb06-416b-a74e-ea0511afcbb4"),
                DateCreated = DateTime.Now,
                Criteria = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                Evaluate = "Vous manquez d'investissement"
            };
            await _service.AddOrUpdateAsync(behaviorCriteria);

            var listAfterInsert = await _service.GetAllAsync();
            var countAfterInsert = listAfterInsert.Count();

            Assert.AreEqual((countBeforeInsert + 1), countAfterInsert);
        }

        [TestMethod]
        public async Task GetByIdAsync_ReturnExistenceElement()
        {
            var id = new Guid("c333b946-1f28-48a1-950a-93354555a672");
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

            var behaviorCriteria = new BehaviorCriteria()
            {
                Id = new System.Guid("2a54ec5d-a933-40ff-bb4e-9efdc9159c7c"),
                DateCreated = DateTime.Now,
                Criteria = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                Evaluate = "Vous manquez d'investissement"
            };
            await _service.RemoveAsync(behaviorCriteria);

            var listAfterRemoving = await _service.GetAllAsync();
            var countAfterRemoving = listAfterRemoving.Count();

            Assert.AreEqual(countBeforeRemoving, countAfterRemoving);
        }

        [TestMethod]
        public async Task RemoveAsync_If_Exist()
        {
            var listBeforeRemoving = await _service.GetAllAsync();
            var countBeforeRemoving = listBeforeRemoving.Count();

            var behaviorCriteria = new BehaviorCriteria()
            {
                Id = new System.Guid("fea91a23-28f7-421a-a592-c01d0a7dd6e4"),
                DateCreated = DateTime.Now,
                Criteria = Infrastructure.Enumerations.BehaviorEnum.Manque_Investissement,
                Evaluate = "Vous manquez d'investissement"
            };
            await _service.RemoveAsync(behaviorCriteria);

            var listAfterRemoving = await _service.GetAllAsync();
            var countAfterRemoving = listAfterRemoving.Count();

            Assert.AreEqual((countBeforeRemoving - 1), countAfterRemoving);
        }

        [TestMethod]
        public async Task UpdateAsync_IfExist()
        {
            var listBeforeUpdating = await _service.GetAllAsync();
            var countBeforeUpdating = listBeforeUpdating.Count();
            var oldItem = new BehaviorCriteria()
            {
                Id = new System.Guid("fea91a23-28f7-421a-a592-c01d0a7dd6e4"),
                DateCreated = DateTime.Now,
                Criteria = Infrastructure.Enumerations.BehaviorEnum.Attitude_Exemplaire,
                Evaluate = "Continuez comme celà"
            };

            var newItem = new BehaviorCriteria()
            {
                Id = new System.Guid("fea91a23-28f7-421a-a592-c01d0a7dd6e4"),
                DateCreated = DateTime.Now,
                Criteria = Infrastructure.Enumerations.BehaviorEnum.Besoin_changement_Attitude,
                Evaluate = "Oh la"
            };

            await _service.AddOrUpdateAsync(newItem);

            var listAfterUpdating = await _service.GetAllAsync();
            var countAfterUpdating = listAfterUpdating.Count();

            var itemUpdated = await _service.GetByIdAsync(newItem.Id);

            var isUpdated = oldItem.Criteria != itemUpdated.Criteria && oldItem.Evaluate != itemUpdated.Evaluate;
            var isSameCount = countBeforeUpdating == countAfterUpdating;
            Assert.IsTrue(isUpdated && isSameCount);
        }
    }
}
