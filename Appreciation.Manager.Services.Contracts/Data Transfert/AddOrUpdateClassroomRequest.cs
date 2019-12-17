namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddClassroomRequest : Request
    {
        public string ClassNumber { get; set; }
    }

    public class UpdateClassroomRequest : Request
    {
        public long Id { get; set; }
        public string ClassNumber { get; set; }
    }
}
