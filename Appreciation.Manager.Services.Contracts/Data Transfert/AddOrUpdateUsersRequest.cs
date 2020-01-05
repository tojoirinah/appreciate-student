using Appreciation.Manager.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddUsersRequest : Request
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class UpdateInformationUsersRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }
    }

    public class UpdatePasswordUsersRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
