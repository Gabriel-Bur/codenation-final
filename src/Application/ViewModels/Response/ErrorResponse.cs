using Domain.Entity.Enums;
using System;
using System.Collections.Generic;

namespace Application.ViewModels.Response
{
    public class ErrorResponse
    {
        public Guid Id { get; set; }
        public ErrorType Type { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public IList<ErrorFileResponse> Files { get; set; }
    }
}
