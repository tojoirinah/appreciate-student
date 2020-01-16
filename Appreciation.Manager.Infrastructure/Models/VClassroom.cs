using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_VClassroom", Schema = "dbo")]
    public class VClassroom : BaseEntity
    {
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        public string ClassNumber { get; set; }

        public long SchoolYearId { get; set; }

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear SchoolYear { get; set; }

        public bool CanDelete { get; set; }
    }
}
