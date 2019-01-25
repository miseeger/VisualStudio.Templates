using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace $safeprojectname$.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = logger;
        }

        // GET api/values/my/usergroups
        [HttpGet]
        [Route("my/usergroups")]

        public ActionResult<List<string>> UserGroups()
        {
            var wi = (WindowsIdentity)User.Identity;
            var groups = new List<string>();
            const string DOMAIN = "DOM\\";

            var conf = _configuration["Logging:LogLevel:Default"];

            foreach (var group in wi.Groups)
            {
                var grpString = group.Translate(typeof(NTAccount)).ToString();

                if (grpString.StartsWith(DOMAIN))
                {
                    groups.Add(grpString.Replace(DOMAIN, string.Empty));
                }
                
            }

            _logger.LogInformation("Returning usergroups!");


            return groups;
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // For more information on protecting this API from Cross Site Request Forgery (CSRF) attacks, see https://go.microsoft.com/fwlink/?LinkID=717803
        }
    }
}
