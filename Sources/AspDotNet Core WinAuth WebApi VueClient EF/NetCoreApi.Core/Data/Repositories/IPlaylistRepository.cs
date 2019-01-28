using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface IPlaylistRepository : IDisposable
    {
        Task<List<Playlist>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Playlist> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Playlist> AddAsync(Playlist newPlaylist, CancellationToken ct = default(CancellationToken));
        Task<List<Track>> GetTrackByPlaylistIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Playlist playlist, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}