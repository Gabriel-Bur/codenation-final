using Domain.Entity;
using Domain.Entity.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Core.Entity
{
    public class Error : BaseEntity
    {
        public ErrorType Type { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        #region Navigation
        public virtual ICollection<ErrorFile> Files { get; set; }
        #endregion

        public Error() {}

        public Error(Guid id, ErrorType errorType, string title, string details) : base(id)
        {
            this.Type = errorType;
            this.Title = title;
            this.Details = details;
        }
    }
}
