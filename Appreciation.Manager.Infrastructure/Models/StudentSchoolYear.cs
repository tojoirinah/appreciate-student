using Appreciation.Manager.Infrastructure.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appreciation.Manager.Infrastructure.Models
{
    [Table("StudentSchoolYear", Schema = "dbo")]
    public class StudentSchoolYear : BaseEntity
    {
        public long SchoolYearId { get; set; }

        public long StudentId { get; set; }

        public double Note { get; set; }

        [Column(TypeName = "int")]
        public BehaviorEnum Behavior { get; set; }

        public long ExamId { get; set; }
        [ForeignKey("ExamId")]
        public virtual Exam ControlContinu { get; set; }

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
