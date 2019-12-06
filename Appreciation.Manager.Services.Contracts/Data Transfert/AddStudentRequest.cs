using Appreciation.Manager.Infrastructure.Enumerations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddStudentRequest : Request
    {
        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        public AddUsersRequest User { get; set; }
    }
}
