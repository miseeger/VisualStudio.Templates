using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using $safeprojectname$.Data.Interface;
using $safeprojectname$.Data.Model;
using $safeprojectname$.Interface;

namespace $safeprojectname$.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IDataService _dataService;
        
        public CustomerService(ILogger<CustomerService> logger, IDataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }


        public IEnumerable<Customer> getAllCustomers()
        {
            IEnumerable<Customer> result = new List<Customer>();

            try
            {
                _dataService.Connection.Open();
                result = _dataService
                    .Fetch<Customer>()
                    .OrderBy(c => c.ContactName)
                    .ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return result;
            }
            finally
            {
                _dataService.Connection.Close();
            }

            return result;
        }
    }
}
