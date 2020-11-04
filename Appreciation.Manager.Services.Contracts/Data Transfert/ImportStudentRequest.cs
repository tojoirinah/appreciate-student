namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class ImportStudentRequest : Request
    {
        public string Genre { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SchoolYear { get; set; }
        public string ClassRoom { get; set; }
    }
}
