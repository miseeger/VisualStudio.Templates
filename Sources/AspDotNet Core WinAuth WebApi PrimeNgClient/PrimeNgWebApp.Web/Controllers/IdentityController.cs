using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(ILogger<IdentityController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // GET api/identity/me
        [HttpGet]
        [Route("me")]
        public ActionResult<object> Me()
        {
            var wi = (WindowsIdentity) User.Identity;
            _logger.LogInformation($"Auth requested as {wi.Name}");
            return new { Name = wi.Name } ;
        }
    }
}
