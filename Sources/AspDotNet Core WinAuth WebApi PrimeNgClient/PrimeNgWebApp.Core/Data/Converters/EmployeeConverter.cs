using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeViewModel Convert(Employee employee)
        {
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                Title = employee.Title,
                ReportsTo = employee.ReportsTo,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                State = employee.State,
                Country = employee.Country,
                PostalCode = employee.PostalCode,
                Phone = employee.Phone,
                Fax = employee.Fax,
                Email = employee.Email
            };

            return employeeViewModel;
        }

        public static List<EmployeeViewModel> ConvertList(IEnumerable<Employee> employees)
        {
            return employees.Select(e =>
                {
                    var model = new EmployeeViewModel
                    {
                        EmployeeId = e.EmployeeId,
                        LastName = e.LastName,
                        FirstName = e.FirstName,
                        Title = e.Title,
                        ReportsTo = e.ReportsTo,
                        BirthDate = e.BirthDate,
                        HireDate = e.HireDate,
                        Address = e.Address,
                        City = e.City,
                        State = e.State,
                        Country = e.Country,
                        PostalCode = e.PostalCode,
                        Phone = e.Phone,
                        Fax = e.Fax,
                        Email = e.Email
                    };
                    return model;
                })
                .ToList();
        }
    }
}