﻿using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, type your email")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, type your password")]
        public string Password { get; set; }
    }
}
