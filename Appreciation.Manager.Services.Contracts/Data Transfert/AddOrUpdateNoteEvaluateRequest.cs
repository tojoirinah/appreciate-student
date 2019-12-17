namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddNoteEvaluateRequest : Request
    {
        public long NoteCriteriaId { get; set; }
        public string Evaluation { get; set; }
        public string Advice { get; set; }
    }

    public class UpdateNoteEvaluateRequest : Request
    {
        public long Id { get; set; }
        public long NoteCriteriaId { get; set; }
        public string Evaluation { get; set; }
        public string Advice { get; set; }
    }
}
