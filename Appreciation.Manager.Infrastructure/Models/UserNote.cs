using Appreciation.Manager.Infrastructure.Enumerations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("UserNote", Schema = "dbo")]
    public class UserNote : BaseEntity
    {
        public Guid SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public virtual Subject Matiere { get; set; }

        public double Note { get; set; }

        [Column(TypeName = "int")]
        public BehaviorEnum Behavior { get; set; }

        public Guid ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam ControlContinu { get; set; }

        public Guid UserEvaluateId { get; set; }

        [ForeignKey("UserEvaluateId")]
        public virtual UserEvaluate Evaluate { get; set; }
    }
}
