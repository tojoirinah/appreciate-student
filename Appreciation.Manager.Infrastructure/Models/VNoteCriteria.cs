using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_VNoteCriteria", Schema = "dbo")]
    public class VNoteCriteria : BaseEntity
    {
        [Column("Min")]
        public double NoteMin { get; set; }

        [Column("Max")]
        public double NoteMax { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Description { get; set; }

        public bool CanDelete { get; set; }
    }
}
