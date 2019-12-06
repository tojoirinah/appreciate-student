using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Utils;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class UserService : Service<Users>, IUserService
    {
        protected IUserRepository _repository;
        public UserService(IUnitOfWork unitOfWork, IUserRepository repository) : base(unitOfWork)
        {
            _repository = repository;
        }

        public async Task<Users> Login(AuthenticationRequest auth)
        {
            Users user = null;
            user = await _repository.GetUserName(auth.UserName);

            if (user != null)
            {
                var encryptedPassword = PasswordContractor.Instance.GeneratePassword(auth.Password, user.SecuritySalt);


                if (String.Compare(user.Password, encryptedPassword, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return user;
                }
                throw new Exception("Le mot de passe est invalide");
            }

            throw new Exception("Le login n'existe pas");
        }

        public async override Task AddOrUpdateAsync(Users entity)
        {
            var securitySalt = EncryptContractor.Instance.SetDefault(Settings.IV, Settings.Key).GenerateEncryptedSecuritySalt();
            entity.Password = PasswordContractor.Instance.GeneratePassword(entity.Password, securitySalt);
            entity.SecuritySalt = securitySalt;

            await _unitOfWork.Repository<Users>().AddOrUpdateAsync(entity);
        }
    }
}
