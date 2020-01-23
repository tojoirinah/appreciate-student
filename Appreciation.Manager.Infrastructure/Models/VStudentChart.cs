using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_VStudentChart", Schema = "dbo")]
    public class VStudentChart : BaseEntity
    {
        public long ExamId { get; set; }

        public string Exam { get; set; }

        public double Note { get; set; }

        public long StudentId { get; set; }
    }
}
