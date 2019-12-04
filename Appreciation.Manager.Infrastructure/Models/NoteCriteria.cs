using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("NoteCriteria", Schema = "dbo")]
    public class NoteCriteria : BaseEntity
    {
        [Column("Min")]
        public double NoteMin { get; set; }
        [Column("Max")]
        public double NoteMax { get; set; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Evaluate { get; set; }
        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Conseils { get; set; }
    }
}
