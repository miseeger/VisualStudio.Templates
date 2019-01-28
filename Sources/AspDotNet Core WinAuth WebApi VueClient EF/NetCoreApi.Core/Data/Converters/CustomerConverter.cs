using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class CustomerConverter
    {
        public static CustomerViewModel Convert(Customer customer)
        {
            var customerViewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Company = customer.Company,
                Address = customer.Address,
                City = customer.City,
                State = customer.State,
                Country = customer.Country,
                PostalCode = customer.PostalCode,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Email = customer.Email,
                SupportRepId = customer.SupportRepId
            };

            return customerViewModel;
        }

        public static IEnumerable<CustomerViewModel> ConvertList(IEnumerable<Customer> customers)
        {
            return customers.Select(c =>
                {
                    var model = new CustomerViewModel
                    {
                        CustomerId = c.CustomerId,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        Company = c.Company,
                        Address = c.Address,
                        City = c.City,
                        State = c.State,
                        Country = c.Country,
                        PostalCode = c.PostalCode,
                        Phone = c.Phone,
                        Fax = c.Fax,
                        Email = c.Email,
                        SupportRepId = c.SupportRepId
                    };
                    return model;
                })
                .ToList();
        }
    }
}