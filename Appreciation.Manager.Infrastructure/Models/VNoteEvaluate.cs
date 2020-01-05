using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_NoteEvaluate", Schema = "dbo")]
    public class VNoteEvaluate : BaseEntity
    {
        [Key]
        public long NoteEvaluateId { get; set; }

        public long NoteCriteriaId { get; set; }

        public string Evaluation { get; set; }

        public string Advice { get; set; }

        public double NoteMin { get; set; }

        public double NoteMax { get; set; }

        public string Description { get; set; }

    }
}
