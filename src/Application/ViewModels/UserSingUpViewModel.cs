using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class UserSingUpViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, type your name")]
        [MinLength(2, ErrorMessage = "The name must contain at least two characters")]
        public string Name { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, type your email")]
        [EmailAddress(ErrorMessage = "Type a valid e-mail address")]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, type your password")]
        [MinLength(8, ErrorMessage = "The password must have 8 characters.")]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please, confirm your password")]
        [Compare("Password", ErrorMessage = "The password doesn't match")]
        public string PasswordConfirm { get; set; }
    }
}
