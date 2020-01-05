using Appreciation.Manager.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Appreciation.Manager.Services.Contracts.Data_Transfert
{
    public class AddSchoolYearRequest : Request
    {
        [Required]
        public string Name { get; set; }
        public bool IsClosed { get; set; }
    }

    public class UpdateSchoolYearRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public bool IsClosed { get; set; }
    }

    public class UpdateStatusSchoolYearRequest : Request
    {
        [IdentityValidation]
        public long Id { get; set; }
        public bool IsClosed { get; set; }
    }
}
