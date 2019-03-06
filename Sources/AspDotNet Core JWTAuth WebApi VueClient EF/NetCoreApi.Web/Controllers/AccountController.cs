using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using $ext_safeprojectname$.Core.Data.ViewModels;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _smtpMailer;

        public AccountController(UserManager<IdentityUser> userManager, IEmailSender smtpMailer)
        {
            _userManager = userManager;
            _smtpMailer = smtpMailer;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorList = new List<string>();

                foreach (var modelState in ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errorList.Add(error.ErrorMessage.Replace("\"", string.Empty));
                    }
                }

                return BadRequest(errorList);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                return BadRequest("A user with that e-mail address already exists!");
            }

            user = new IdentityUser
            {
                UserName = model.Email.Split("@").FirstOrDefault(),
                Email = model.Email,
                EmailConfirmed = true,
                LockoutEnabled = true
            };

            var registerResult = await _userManager.CreateAsync(user, model.Password);

            if (!registerResult.Succeeded)
            {
                var result = registerResult.Errors;

                return registerResult.Errors.Count() == 1 
                    ? BadRequest(registerResult.Errors.First().Description) 
                    : BadRequest(registerResult.Errors.Select(err => err.Description).ToArray());
            }

            await _userManager.AddToRoleAsync(user, "Customer");

            return Ok();
        }

        [HttpPost]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest();
            }

            // https://go.microsoft.com/fwlink/?LinkID=532713
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl =
                $"{Request.Scheme}://{Request.Host}/resetpassword?code={code}";

            await _smtpMailer.SendEmailAsync(
                model.Email,
                "Reset Password",
                $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.");

            return Ok();
        }

        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest();
            }

            var resetResult = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);

            if (!resetResult.Succeeded)
            {
                return BadRequest(resetResult.Errors);
            }

            return Ok();
        }

    }
}