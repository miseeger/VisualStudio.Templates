﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        private readonly DataContext _context;

        public InvoiceLineRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> InvoiceLineExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<InvoiceLine>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.InvoiceLine.ToListAsync(ct);
        }

        public async Task<InvoiceLine> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.InvoiceLine.FindAsync(id);
        }

        public async Task<InvoiceLine> AddAsync(InvoiceLine newInvoiceLine,
            CancellationToken ct = default(CancellationToken))
        {
            _context.InvoiceLine.Add(newInvoiceLine);
            await _context.SaveChangesAsync(ct);
            return newInvoiceLine;
        }

        public async Task<bool> UpdateAsync(InvoiceLine invoiceLine, CancellationToken ct = default(CancellationToken))
        {
            if (!await InvoiceLineExists(invoiceLine.InvoiceLineId, ct))
                return false;
            _context.InvoiceLine.Update(invoiceLine);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await InvoiceLineExists(id, ct))
                return false;
            var toRemove = _context.InvoiceLine.Find(id);
            _context.InvoiceLine.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<InvoiceLine>> GetByInvoiceIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            return await _context.InvoiceLine.Where(a => a.InvoiceId == id).ToListAsync(ct);
        }

        public async Task<List<InvoiceLine>> GetByTrackIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            return await _context.InvoiceLine.Where(a => a.TrackId == id).ToListAsync(ct);
        }
    }
}