using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface IEmployeeRepository : IDisposable
    {
        Task<List<Employee>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Employee> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Employee>> GetDirectReportsAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}