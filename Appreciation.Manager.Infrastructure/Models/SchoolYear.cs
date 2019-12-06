using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("SchoolYear", Schema = "dbo")]
    public class SchoolYear : BaseEntity
    {
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
