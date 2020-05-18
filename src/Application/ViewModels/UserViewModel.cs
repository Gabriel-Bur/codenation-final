using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Type a valid e-mail address")]
        public string Email { get; set; }

        [Required]
        [MinLength(8,ErrorMessage = "The password must have 8 characters.")]
        public string Password { get; set; }
    }
}
