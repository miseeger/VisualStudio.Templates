using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Core.Data.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}