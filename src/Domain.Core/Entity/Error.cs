using Domain.Entity;
using Domain.Entity.Enums;
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
    }
}
