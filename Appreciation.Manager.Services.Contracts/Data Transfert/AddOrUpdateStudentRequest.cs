using Appreciation.Manager.Infrastructure.Enumerations;
using Appreciation.Manager.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddStudentRequest : Request
    {


        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        [IdentityValidation]
        public long SchoolYearId { get; set; }

        [IdentityValidation]
        public long ClassRoomId { get; set; }

        [Required]
        public AddUsersRequest User { get; set; }
    }

    public class UpdateInformationStudentRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }
        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        [IdentityValidation]
        public long SchoolYearId { get; set; }

        [IdentityValidation]
        public long ClassRoomId { get; set; }

        [Required]
        public UpdateInformationUsersRequest User { get; set; }
    }

    public class StudentSearchRequest : Request
    {
        public long SchoolYearId { get; set; }

        public long ClassroomId { get; set; }

    }
}
