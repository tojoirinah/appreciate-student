using Appreciation.Manager.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Behavior", Schema = "dbo")]
    public class Behavior : BaseEntity
    {
        [Column("Value", TypeName = "int")]
        public BehaviorEnum ComportementValue { get; set; }

        [Column("Description", TypeName = "VARCHAR")]
        [MaxLength()]
        public string ComportementDescription { get; set; }
    }
}
