using System;

namespace Domain.Core
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreationDataTime { get; set; }
        public DateTime DeletionDateTime { get; set; }
    }
}
