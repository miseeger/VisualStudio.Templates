using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface ITrackRepository : IDisposable
    {
        Task<List<Track>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Track> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByAlbumIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByGenreIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetByMediaTypeIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Track> AddAsync(Track newTrack, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Track track, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}