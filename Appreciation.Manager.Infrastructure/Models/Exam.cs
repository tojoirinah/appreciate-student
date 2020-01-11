using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Exam", Schema = "dbo")]
    public class Exam : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public long SchoolYearId { get; set; }

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear SchoolYear { get; set; }

        public long ClassroomId { get; set; }

        [ForeignKey("ClassroomId")]
        public virtual Classroom Classroom { get; set; }
    }
}
