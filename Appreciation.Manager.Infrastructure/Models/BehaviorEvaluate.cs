using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("BehaviorEvaluate", Schema = "dbo")]
    public class BehaviorEvaluate : BaseEntity
    {
        public long BehaviorId { get; set; }

        [ForeignKey("BehaviorId")]
        public virtual Behavior Behavior { get; set; }

        public long NoteCriteriaId { get; set; }

        [ForeignKey("NoteCriteriaId")]
        public virtual NoteCriteria NoteCriteria { get; set; }

        [MaxLength()]
        public string Evaluation { get; set; }
    }
}
