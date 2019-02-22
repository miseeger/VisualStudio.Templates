﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public class MediaTypeRepository : IMediaTypeRepository
    {
        private readonly DataContext _context;

        public MediaTypeRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> MediaTypeExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<MediaType>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.MediaType.ToListAsync(ct);
        }

        public async Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.MediaType.FindAsync(id);
        }

        public async Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default(CancellationToken))
        {
            _context.MediaType.Add(newMediaType);
            await _context.SaveChangesAsync(ct);
            return newMediaType;
        }

        public async Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default(CancellationToken))
        {
            if (!await MediaTypeExists(mediaType.MediaTypeId, ct))
                return false;
            _context.MediaType.Update(mediaType);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await MediaTypeExists(id, ct))
                return false;
            var toRemove = _context.MediaType.Find(id);
            _context.MediaType.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}