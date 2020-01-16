using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_VBehavior", Schema = "dbo")]
    public class VBehavior : BaseEntity
    {
        public int Value { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Description { get; set; }

        public bool CanDelete { get; set; }
    }
}
