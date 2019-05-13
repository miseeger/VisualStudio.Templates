using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Task<List<Customer>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Customer> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Customer>> GetBySupportRepIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Customer> AddAsync(Customer newCustomer, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Customer customer, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}