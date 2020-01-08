using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Infrastructure.Models;
using Appreciation.Manager.Services.Contracts.Data_Transfert;
using Appreciation.Manager.Utils;
using AutoMapper;
using System;

namespace Appreciation.Manager.Services.Mappers
{
    public static class UsersMapper
    {
        public static void ProjectTo(this UpdateInformationUsersRequest request, Users user)
        {
            user.Name = request.Name;
            user.FirstName = request.FirstName;
        }

        public static void ProjectTo(this UpdatePasswordUsersRequest request, Users user)
        {
            var securitySalt = EncryptContractor.Instance.SetDefault(Settings.IV, Settings.Key).GenerateEncryptedSecuritySalt();
            var scriptedPassword = PasswordContractor.Instance.GeneratePassword(request.Password, securitySalt);
            user.SecuritySalt = securitySalt;
            user.Password = scriptedPassword;
        }

        public static void ProjectTo(this ResetUserPasswordRequest request, Users user)
        {
            var securitySalt = EncryptContractor.Instance.SetDefault(Settings.IV, Settings.Key).GenerateEncryptedSecuritySalt();
            var scriptedPassword = PasswordContractor.Instance.GeneratePassword(request.NewPassword, securitySalt);
            user.SecuritySalt = securitySalt;
            user.Password = scriptedPassword;
        }

        public static Users ProjectTo(this AddUsersRequest request, IMapper mapper, RoleEnum roleEnum)
        {
            Users user = mapper.Map<Users>(request);
            var securitySalt = EncryptContractor.Instance.SetDefault(Settings.IV, Settings.Key).GenerateEncryptedSecuritySalt();
            user.Password = PasswordContractor.Instance.GeneratePassword(user.Password, securitySalt);
            user.SecuritySalt = securitySalt;
            user.RoleId = (int)roleEnum;
            user.DateCreated = DateTime.Now;
            return user;
        }
    }
}