using Appreciation.Manager.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student : BaseEntity
    {

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
