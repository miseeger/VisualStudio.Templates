using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using $ext_safeprojectname$.Core.Data;
using $ext_safeprojectname$.Core.Data.Converters;
using $ext_safeprojectname$.Core.Data.Entities;
using $ext_safeprojectname$.Core.Data.ViewModels;

namespace $safeprojectname$.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(DataContext context, ILogger<CustomerController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpGet]
        [Produces(typeof(IEnumerable<CustomerViewModel>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(
                    CustomerConverter.ConvertList(
                        await _context.Customer.ToListAsync()
                    )
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _context.Customer
                    .Where(c => c.CustomerId == id)
                    .FirstOrDefaultAsync();
                
                if (customer == null)
                {
                    return NotFound();
                }

                return Ok(CustomerConverter.Convert(customer));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, ex);
            }
        }

    }
}
