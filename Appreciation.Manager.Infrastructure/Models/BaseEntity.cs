using System;

namespace Appreciation.Manager.Infrastructure.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
