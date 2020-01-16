using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_VSchoolYear", Schema = "dbo")]
    public class VSchoolYear : BaseEntity
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Name { get; set; }

        [DefaultValue("false")]
        public bool IsClosed { get; set; }

        public bool CanDelete { get; set; }
    }
}
