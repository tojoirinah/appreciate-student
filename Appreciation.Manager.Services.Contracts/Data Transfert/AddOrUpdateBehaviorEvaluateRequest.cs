namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddBehaviorEvaluateRequest : Request
    {
        public long BehaviorId { get; set; }

        public long NoteCriteriaId { get; set; }

        public string Evaluation { get; set; }
    }

    public class UpdateBehaviorEvaluateRequest : Request
    {
        public long Id { get; set; }

        public long BehaviorId { get; set; }


        public long NoteCriteriaId { get; set; }

        public string Evaluation { get; set; }
    }
}
