using System;

namespace Domain.Core.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
    }
}
