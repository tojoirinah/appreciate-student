using System;

using Appreciation.Manager.Infrastructure.Models;

namespace Appreciation.Manager.Services.Contracts.Exceptions
{
    public class EntityNotFoundException<T> : Exception where T : BaseEntity
    {
        public EntityNotFoundException() : base($"{typeof(T).Name} not found")
        {

        }
    }
}
