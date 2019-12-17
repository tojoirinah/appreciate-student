using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Behavior", Schema = "dbo")]
    public class Behavior : BaseEntity
    {
        public int Value { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Description { get; set; }
    }
}
