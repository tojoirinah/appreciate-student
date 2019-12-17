namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddExamRequest : Request
    {
        public string Name { get; set; }
    }

    public class UpdateExamRequest : Request
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
