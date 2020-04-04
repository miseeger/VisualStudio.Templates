using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using $ext_safeprojectname$.Core.Data.Model;
using $ext_safeprojectname$.Core.Interface;

namespace $safeprojectname$.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
            ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }


        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var fc = _customerService.getAllCustomers();
            _logger.LogInformation("All customers fetched.");
            return fc;
        }
    }
}
