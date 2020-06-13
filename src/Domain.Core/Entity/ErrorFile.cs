using Domain.Core.Entity;
using System;

namespace Domain.Entity
{
    public class ErrorFile : BaseEntity
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }

        #region Navigation
        public virtual Guid ErrorId { get; set; }
        public virtual Error Error { get; set; }
        #endregion

    }
}
