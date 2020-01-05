using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AuthenticationRequest : Request
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
