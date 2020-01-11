using Appreciation.Manager.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class ExamRequest : Request
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [IdentityValidation]
        public long SchoolYearId { get; set; }

        [IdentityValidation]
        public long ClassroomId { get; set; }
    }

    public class ExamSearchRequest : Request
    {
        public long SchoolYearId { get; set; }

        public long ClassroomId { get; set; }
    }

}
