using Appreciation.Manager.Infrastructure.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("BehaviorCriteria", Schema = "dbo")]
    public class BehaviorCriteria : BaseEntity
    {
        [Column(TypeName = "int")]
        public BehaviorEnum Criteria { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string Evaluate { get; set; }
    }
}
