using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Data.ApiModels
{
    public class ResetPasswordApiModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}