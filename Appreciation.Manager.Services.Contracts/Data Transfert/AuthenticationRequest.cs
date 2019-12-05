namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AuthenticationRequest : Request
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
