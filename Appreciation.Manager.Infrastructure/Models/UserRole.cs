using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Role", Schema = "dbo")]
    public class UserRole : BaseEntity
    {
        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}
