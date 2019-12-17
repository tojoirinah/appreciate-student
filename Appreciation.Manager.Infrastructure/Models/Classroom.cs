using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Classroom", Schema = "dbo")]
    public class Classroom : BaseEntity
    {
        [Column(TypeName = "VARCHAR")]
        [MaxLength(20)]
        public string ClassNumber { get; set; }
    }
}
