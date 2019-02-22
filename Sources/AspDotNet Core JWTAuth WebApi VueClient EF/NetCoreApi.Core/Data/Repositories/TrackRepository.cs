﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public class TrackRepository : ITrackRepository
    {
        private readonly DataContext _context;

        public TrackRepository(DataContext context)
        {
            _context = context;
        }

        private async Task<bool> TrackExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Track>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Track.ToListAsync(ct);
        }

        public async Task<Track> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Track.FindAsync(id);
        }

        public async Task<Track> AddAsync(Track newTrack, CancellationToken ct = default(CancellationToken))
        {
            _context.Track.Add(newTrack);
            await _context.SaveChangesAsync(ct);
            return newTrack;
        }

        public async Task<bool> UpdateAsync(Track track, CancellationToken ct = default(CancellationToken))
        {
            if (!await TrackExists(track.TrackId, ct))
                return false;
            _context.Track.Update(track);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await TrackExists(id, ct))
                return false;
            var toRemove = _context.Track.Find(id);
            _context.Track.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Track.Where(a => a.AlbumId == id).ToListAsync(ct);
        }

        public async Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Track.Where(a => a.GenreId == id).ToListAsync(ct);
        }

        public async Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Track.Where(a => a.MediaTypeId == id).ToListAsync(ct);
        }
    }
}