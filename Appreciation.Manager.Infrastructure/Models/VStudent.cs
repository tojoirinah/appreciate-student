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
    [Table("view_Student", Schema = "dbo")]
    public class VStudent : BaseEntity
    {
        [Key]
        public long StudentId { get; set; }

        public string SchoolYear { get; set; }
        public bool IsClosed { get; set; }
        public string Classroom { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public CivilityEnum Civility { get; set; }
        public long SchoolYearId { get; set; }
        public long ClassroomId { get; set; }
        public long UserId { get; set; }
    }
}
