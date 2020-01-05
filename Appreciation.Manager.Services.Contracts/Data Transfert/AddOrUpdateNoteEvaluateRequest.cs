using Appreciation.Manager.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddNoteEvaluateRequest : Request
    {
        [IdentityValidation]
        public long NoteCriteriaId { get; set; }

        [Required]
        public string Evaluation { get; set; }
        public string Advice { get; set; }
    }

    public class UpdateNoteEvaluateRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [IdentityValidation]
        public long NoteCriteriaId { get; set; }

        [Required]
        public string Evaluation { get; set; }
        public string Advice { get; set; }
    }

    public class NoteEvaluateSearchRequest : Request
    {
        public long NoteCriteriaId { get; set; }
    }
}
