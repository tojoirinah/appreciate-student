using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Repository.Contracts;
using Appreciation.Manager.Services.Contracts;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Services.Contracts.Exceptions;
using Appreciation.Manager.Services.Mappers;
using Appreciation.Manager.Utils;
using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
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
            Users user = await _repository.GetDataAsync(x => x.UserName == auth.UserName);

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
                throw new ConversionTypeNotAllowedException();

            UpdateInformationUsersRequest req = (UpdateInformationUsersRequest)request;
            Users user = await _repository.GetByIdAsync(req.Id);
            if (user == null)
            {
                throw new EntityNotFoundException<Users>();
            }

            user = _mapper.Map<Users>(request);
            await _repository.AddOrUpdateAsync(user);
        }

        public override async Task AddAsync(object request)
        {
            if (!(request is AddUsersRequest))
                throw new ConversionTypeNotAllowedException();

            AddUsersRequest rq = (AddUsersRequest)request;
            Users u = rq.ProjectTo(_mapper, RoleEnum.Admin);

            await _repository.AddOrUpdateAsync(u);
        }

        public async Task UpdatePasswordUsers(UpdatePasswordUsersRequest request)
        {
            Users u = await _repository.GetByIdAsync(request.Id);

            if (u == null)
                throw new EntityNotFoundException<Users>();

            request.ProjectTo(u);
            await _repository.AddOrUpdateAsync(u);
        }

        public async override Task<Users> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id, new string[] { "Role" });
        }

        public async Task SendRequestForgottenPassword(ForgottenUserPasswordRequest request)
        {
            Users user = await _repository.GetDataAsync(x => x.UserName == request.UserName);
            if (user == null)
            {
                throw new EntityNotFoundException<Users>();

            }

            var claimIdentity = new ClaimsIdentity(new Claim[] {
                    new Claim("UserId",user.Id.ToString()),
                    new Claim("RoleId",user.RoleId.ToString()),
                    new Claim("UserName",user.UserName)
                });

            var token = JwtTokenHelper.CreateToken(
                claimIdentity,
                Settings.TokenExpire,
                Settings.JwtSecretKey
            );

            using (var client = new WebClient())
            {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + Settings.ForgottenPasswordTemplate;
                var htmlCode = client.DownloadString(path);
                var url = string.Format("{0}{1}{2}?token={3}", Settings.CorsDomain, Settings.Domain, Settings.ResetPasswordUrl, token);
                var body = htmlCode.Replace("_@1_", url);

                var mailRequest = new MailRequest()
                {
                    Body = body,
                    Subject = "Mot de passe oublié",
                    Recipient = user.UserName
                };

                MailHelper.SendMailSuccess(mailRequest);
            }

        }

        public async Task<Users> ResetUserPassword(ResetUserPasswordRequest request)
        {
            var claims = JwtTokenHelper.GetTokenClaims(request.Token, Settings.JwtSecretKey);
            var userId = claims.FirstOrDefault(x => x.Type == "UserId");
            if (userId == null)
                throw new Exception("Invalid token");

            Users u = await _repository.GetByIdAsync(Convert.ToInt64(userId.Value));
            request.ProjectTo(u);
            await _repository.AddOrUpdateAsync(u);
            return u;
        }
    }
}
