using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // GET api/values/my/claims
        [Authorize]
        [HttpGet]
        [Route("my/claims")]
        public ActionResult<List<string>> Claims()
        {
            _logger.LogInformation("Returning userclaims!");
            return Request.HttpContext.User.Claims.Select(c => c.Value).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _logger.LogInformation("Call to retrieve values!");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}
