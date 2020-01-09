using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_BehaviorEvaluate", Schema = "dbo")]
    public class VBehaviorEvaluate : BaseEntity
    {
        [Key]
        public long BehaviorEvaluateId { get; set; }

        public string Evaluation { get; set; }

        public long BehaviorId { get; set; }

        public long NoteCriteriaId { get; set; }

        public string BehaviorDescription { get; set; }

        public string NoteCriteriaDescription { get; set; }

        public double NoteMin { get; set; }

        public double NoteMax { get; set; }
    }
}
