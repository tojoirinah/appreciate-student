using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("UserEvaluate", Schema = "dbo")]
    public class UserEvaluate : BaseEntity
    {
        [MaxLength()]
        public string NoteEvaluation { get; set; }
        [MaxLength()]
        public string BehaviorEvaluation { get; set; }
    }
}
