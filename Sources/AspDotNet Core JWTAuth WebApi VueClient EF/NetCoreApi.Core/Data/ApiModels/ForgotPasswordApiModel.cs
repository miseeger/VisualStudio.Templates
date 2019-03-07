using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Data.ApiModels
{
    public class ForgotPasswordApiModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}