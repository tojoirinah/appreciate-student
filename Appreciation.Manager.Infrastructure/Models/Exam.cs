using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Exam", Schema = "dbo")]
    public class Exam : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
