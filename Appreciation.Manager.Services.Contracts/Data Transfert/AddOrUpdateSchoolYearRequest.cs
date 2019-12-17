namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddSchoolYearRequest : Request
    {
        public string Name { get; set; }
        public bool IsClosed { get; set; }
    }

    public class UpdateSchoolYearRequest : Request
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsClosed { get; set; }
    }
}
