using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Data.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
    
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        public string Password { get; set; }
    
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}