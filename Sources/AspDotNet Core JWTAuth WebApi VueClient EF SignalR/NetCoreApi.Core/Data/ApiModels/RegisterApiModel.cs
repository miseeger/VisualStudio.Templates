using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Data.ApiModels
{
    public class RegisterApiModel
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