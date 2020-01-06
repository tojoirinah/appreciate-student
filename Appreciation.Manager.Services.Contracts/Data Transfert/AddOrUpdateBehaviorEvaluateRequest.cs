using Appreciation.Manager.Utils.Attributes;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddBehaviorEvaluateRequest : Request
    {
        [IdentityValidation]
        public long BehaviorId { get; set; }

        [IdentityValidation]
        public long NoteCriteriaId { get; set; }

        public string Evaluation { get; set; }
    }

    public class UpdateBehaviorEvaluateRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [IdentityValidation]
        public long BehaviorId { get; set; }

        [IdentityValidation]
        public long NoteCriteriaId { get; set; }

        public string Evaluation { get; set; }
    }

    public class BehaviorEvaluateSearchRequest : Request
    {
        public long BehaviorId { get; set; }
        public long NoteCriteriaId { get; set; }
    }
}
