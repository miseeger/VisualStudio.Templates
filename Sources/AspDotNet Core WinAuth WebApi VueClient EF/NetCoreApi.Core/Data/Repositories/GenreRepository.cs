using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        
        private IMemoryCache _cache;

        public GenreRepository(DataContext context, IMemoryCache memoryCache)
        {
            _context = context;
            
            _cache = memoryCache;
        }

        private async Task<bool> GenreExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Genre>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Genre.ToListAsync(ct);
        }

        public async Task<Genre> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var cachedGenre = _cache.Get<Genre>(id);

            if (cachedGenre != null)
            {
                return cachedGenre;
            }
            else
            {

                var dbGenre = await _context.Genre.FindAsync(id);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(604800));
                _cache.Set(dbGenre.GenreId, dbGenre, cacheEntryOptions);

                return dbGenre;
            }
        }

        public async Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default(CancellationToken))
        {
            _context.Genre.Add(newGenre);
            await _context.SaveChangesAsync(ct);
            return newGenre;
        }

        public async Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default(CancellationToken))
        {
            if (!await GenreExists(genre.GenreId, ct))
                return false;
            _context.Genre.Update(genre);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            if (!await GenreExists(id, ct))
                return false;
            var toRemove = _context.Genre.Find(id);
            _context.Genre.Remove(toRemove);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}