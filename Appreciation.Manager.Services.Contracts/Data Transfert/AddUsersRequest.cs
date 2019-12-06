namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddUsersRequest : Request
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
