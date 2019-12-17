using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Mappers;
using Appreciation.Manager.Utils;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Appreciation.Manager.Services
{
    public class UsersService : Service<Users>, IUsersService
    {

        public UsersService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
        }

        public async Task<Users> Login(AuthenticationRequest auth)
        {
            Users user = null;
            user = await ((IUsersRepository)_repository).GetUserName(auth.UserName);

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

        public override async Task UpdateAsync(object request)
        {
            if (!(request is UpdateInformationUsersRequest))
                throw new Exception("Convert type not allowed");

            UpdateInformationUsersRequest req = (UpdateInformationUsersRequest)request;
            Users user = await _repository.GetByIdAsync(req.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user = _mapper.Map<Users>(request);
            await _repository.AddOrUpdateAsync(user);
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddUsersRequest))
                throw new Exception("Convert type not allowed");

            AddUsersRequest rq = (AddUsersRequest)request;
            Users u = rq.ProjectTo(_mapper, RoleEnum.Admin);

            await _repository.AddOrUpdateAsync(u);
        }

        public async Task UpdatePasswordUsers(UpdatePasswordUsersRequest request)
        {
            Users u = await _repository.GetByIdAsync(request.Id);

            if (u == null)
                throw new Exception("User not found");

            request.ProjectTo(u);
            await _repository.AddOrUpdateAsync(u);
        }
    }
}
