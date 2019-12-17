using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("StudentExam", Schema = "dbo")]
    public class StudentExam : BaseEntity
    {
        public long StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Etudiant { get; set; }

        [DefaultValue("false")]
        public bool IsAbsent { get; set; }

        public double? Note { get; set; }

        public long BehaviorId { get; set; }

        [ForeignKey("BehaviorId")]
        public virtual Behavior Comportement { get; set; }

        public long ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam ControlContinu { get; set; }

        [DefaultValue("false")]
        public bool IsClosed { get; set; }


        #region "Automatically generate"
        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string NoteEvaluate { get; set; }

        [Column(TypeName = "VARCHAR")]
        [MaxLength()]
        public string BehaviorEvaluate { get; set; }
        #endregion
    }
}
