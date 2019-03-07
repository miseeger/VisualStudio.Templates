using System.ComponentModel.DataAnnotations;

namespace $safeprojectname$.Data.ApiModels
{
    public class LoginApiModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}