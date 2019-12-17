using Appreciation.Manager.Infrastructure;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Tests2.DataFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services.Tests2
{
    [TestClass]
    public class UserServiceTest
    {
        protected IUsersService _userService;
        private Mock<DbSet<Users>> _mockUsersDBSet;

        [TestInitialize]
        public void InitializeTest()
        {


            _mockUsersDBSet = new Mock<DbSet<Users>>();
            _mockUsersDBSet.SetSource(UsersDataFactory.GetUsers());

            var contextMock = new AppreciationContext();
            contextMock.Users = _mockUsersDBSet.Object;

            var unitOfWork = new UnitOfWork(contextMock);
            var repository = new UsersRepository(unitOfWork);


            _userService = new UsersService(repository);

        }

        [TestMethod]
        public async Task Authenticate_ThrowError_UsernameNotFound()
        {
            try
            {
                var req = new AuthenticationRequest()
                {
                    UserName = "UserName100",
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
                    UserName = "UserName13",
                    Password = "1234"
                };
                var l = await _userService.GetAllAsync();
                var user = await _userService.Login(req);
                Assert.IsNotNull(user);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Le mot de passe est invalide");
            }
        }

        [TestMethod]
        public async Task Authenticate_ReturnOk_WithAssociateLogin()
        {
            try
            {
                var req = new AuthenticationRequest()
                {
                    UserName = "UserName13",
                    Password = "kenshiro1321345589$po"
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
