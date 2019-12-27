using Appreciation.Manager.Infrastructure.Enumerations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddStudentRequest : Request
    {


        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        public long SchoolYearId { get; set; }

        public long ClassRoomId { get; set; }

        public AddUsersRequest User { get; set; }
    }

    public class UpdateInformationStudentRequest : Request
    {
        public long Id { get; set; }
        public int Age { get; set; }

        public CivilityEnum Civility { get; set; }

        public long SchoolYearId { get; set; }

        public long ClassRoomId { get; set; }

        public UpdateInformationUsersRequest User { get; set; }
    }

    public class StudentSearchRequest : Request
    {
        public long SchoolYearId { get; set; }

        public long ClassroomId { get; set; }

    }
}
