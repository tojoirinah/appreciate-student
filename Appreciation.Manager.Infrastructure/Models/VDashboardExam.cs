using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("view_DashboardExam", Schema = "dbo")]
    public class VDashboardExam : BaseEntity
    {
        public long ExamId { get; set; }
        public int TotalStudents { get; set; }
        public int TotalAbsents { get; set; }
        public int TotalWaitingNonReseigne { get; set; }
        public decimal PercentNoteRenseigne { get; set; }
        public long SchoolYearId { get; set; }
        public string SchoolYearName { get; set; }
        public long ClassroomId { get; set; }
        public string ClassNumber { get; set; }
        public string ExamName { get; set; }
    }

}
