using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("User", Schema = "dbo")]
    public class Users : BaseEntity
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength]
        public string SecuritySalt { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(500)]
        public string Password { get; set; }

        public long RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual UserRole Role { get; set; }
    }
}
