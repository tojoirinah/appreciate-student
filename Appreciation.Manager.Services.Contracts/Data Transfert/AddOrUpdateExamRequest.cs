using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddExamRequest : Request
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public long SchoolYearId { get; set; }
    }

    public class UpdateExamRequest : Request
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
