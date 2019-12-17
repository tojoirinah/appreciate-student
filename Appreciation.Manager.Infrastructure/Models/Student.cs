using Appreciation.Manager.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student : BaseEntity
    {
        public long SchoolYearId { get; set; }

        [ForeignKey("SchoolYearId")]
        public virtual SchoolYear AnneeScolaire { get; set; }

        public long ClassRoomId { get; set; }

        [ForeignKey("ClassRoomId")]
        public virtual Classroom Classroom { get; set; }


        [Required]
        public int Age { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public CivilityEnum Civility { get; set; }

        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual Users User { get; set; }




    }
}
