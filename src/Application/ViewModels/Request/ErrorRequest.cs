using Domain.Entity.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.Request
{
    public class ErrorRequest
    {
        [Range(0, 2, ErrorMessage = "Invalid Error Type")]
        public ErrorType Type { get; set; }

        [MaxLength(200, ErrorMessage = "Title lenght should be less than 200 characters")]
        public string Title { get; set; }

        [MaxLength(600, ErrorMessage = "Details lenght should be less than 600 characters")]
        public string Details { get; set; }

        public IList<IFormFile> Files { get; set; }
    }
}
