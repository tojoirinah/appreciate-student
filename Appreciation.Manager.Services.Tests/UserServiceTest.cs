using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Repository.Tests;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        protected IUserService _userService;

        [TestInitialize]
        public void InitializeTest()
        {
            var unitOfWork = Mock.Of<IUnitOfWork>();

            var userRepository = new UserRepositoryTest(unitOfWork);
            _userService = new UserService(unitOfWork, userRepository);

        }

        [TestMethod]
        public async Task Authenticate_ThrowError_UsernameNotFound()
        {
            try
            {
                var req = new AuthenticationRequest()
                {
                    UserName = "5454",
                    Password = "kenshiro1321345589$po"
                };
                var user = await _userService.Login(req);
               // Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Le login n'existe pas");
            }
        }

        [TestMethod]
        public async Task Authenticate_ThrowError_InvalidPassword()
        {
            try
            {
                var req = new AuthenticationRequest()
                {
                    UserName = "UserName001",
                    Password = "1234"
                };
                var user = await _userService.Login(req);
                Assert.IsNotNull(user);
            }
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Le mot de passe est invalide");
            }
        }

        [TestMethod]
        public async Task Authenticate_ReturnOk_WithAssociateLogin()
        {
            try
            {
                var req = new AuthenticationRequest() {
                    UserName = "UserName001", Password = "kenshiro1321345589$po"
                };
                var user = await _userService.Login(req);
                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "");
            }
        }
    }
}
