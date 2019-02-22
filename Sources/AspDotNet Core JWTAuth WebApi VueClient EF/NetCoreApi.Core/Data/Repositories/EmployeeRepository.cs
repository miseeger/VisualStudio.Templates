﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> EmployeeExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Employee>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Employee.ToListAsync(ct);
        }

        public async Task<Employee> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<Employee> AddAsync(Employee newEmployee, CancellationToken ct = default(CancellationToken))
        {
            _context.Employee.Add(newEmployee);
            await _context.SaveChangesAsync(ct);
            return newEmployee;
        }

        public async Task<bool> UpdateAsync(Employee employee, CancellationToken ct = default(CancellationToken))
        {
            if (!await EmployeeExists(employee.EmployeeId, ct))
                return false;
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await EmployeeExists(id, ct))
                return false;
            var toRemove = _context.Employee.Find(id);
            _context.Employee.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<Employee> GetReportsToAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Employee.FindAsync(id);
        }

        public async Task<List<Employee>> GetDirectReportsAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            return await _context.Employee.Where(e => e.ReportsTo == id).ToListAsync(ct);
        }
    }
}