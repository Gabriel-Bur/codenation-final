using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Core.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        protected BaseEntity() { }

        protected BaseEntity(Guid Id)
        {
            this.Id = Id;
        }
    }
}
