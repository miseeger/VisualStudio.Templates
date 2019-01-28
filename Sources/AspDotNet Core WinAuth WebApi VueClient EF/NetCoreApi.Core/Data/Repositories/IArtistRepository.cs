using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface IArtistRepository : IDisposable
    {
        Task<List<Artist>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Artist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Artist> AddAsync(Artist newArtist, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Artist artist, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}