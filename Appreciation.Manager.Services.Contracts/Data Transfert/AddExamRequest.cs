namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddExamRequest : Request
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
