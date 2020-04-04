using System.Collections.Generic;
using $safeprojectname$.Data.Model;

namespace $safeprojectname$.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> getAllCustomers();
    }
}
