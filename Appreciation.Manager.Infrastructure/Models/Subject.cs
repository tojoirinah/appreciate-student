using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("Subject", Schema = "dbo")]
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
    }
}
