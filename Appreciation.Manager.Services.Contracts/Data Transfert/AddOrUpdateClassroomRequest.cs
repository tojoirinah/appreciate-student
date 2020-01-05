using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddClassroomRequest : Request
    {
        [Required]
        public string ClassNumber { get; set; }
    }

    public class UpdateClassroomRequest : Request
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string ClassNumber { get; set; }
    }
}
