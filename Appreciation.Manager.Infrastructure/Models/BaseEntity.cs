using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appreciation.Manager.Infrastructure.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [DefaultValue("getutcdate()")]
        public DateTime DateCreated { get; set; }
    }
}
