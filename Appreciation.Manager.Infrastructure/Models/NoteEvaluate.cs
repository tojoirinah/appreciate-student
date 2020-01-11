using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("NoteEvaluate", Schema = "dbo")]
    public class NoteEvaluate : BaseEntity
    {
        public long NoteCriteriaId { get; set; }

        [ForeignKey("NoteCriteriaId")]
        public virtual NoteCriteria NoteCriteria { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Evaluation { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Advice { get; set; }
    }
}
