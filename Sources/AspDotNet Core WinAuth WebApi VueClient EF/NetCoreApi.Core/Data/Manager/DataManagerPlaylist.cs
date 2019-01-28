using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Converters;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Manager
{
    public partial class DataManager : IDataManager
    {
        public async Task<List<PlaylistViewModel>> GetAllPlaylistAsync(
            CancellationToken ct = default(CancellationToken))
        {
            var playlists = PlaylistConverter.ConvertList(await _playlistRepository.GetAllAsync(ct));
            return playlists;
        }

        public async Task<PlaylistViewModel> GetPlaylistByIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var playlistViewModel = PlaylistConverter.Convert(await _playlistRepository.GetByIdAsync(id, ct));
            playlistViewModel.Tracks = await GetTrackByPlaylistIdIdAsync(playlistViewModel.PlaylistId, ct);
            return playlistViewModel;
        }

        public async Task<PlaylistViewModel> AddPlaylistAsync(PlaylistViewModel newPlaylistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var playlist = new Playlist
            {
                Name = newPlaylistViewModel.Name
            };

            playlist = await _playlistRepository.AddAsync(playlist, ct);
            newPlaylistViewModel.PlaylistId = playlist.PlaylistId;
            return newPlaylistViewModel;
        }

        public async Task<bool> UpdatePlaylistAsync(PlaylistViewModel playlistViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var playlist = await _playlistRepository.GetByIdAsync(playlistViewModel.PlaylistId, ct);

            if (playlist == null) return false;
            playlist.PlaylistId = playlistViewModel.PlaylistId;
            playlist.Name = playlistViewModel.Name;

            return await _playlistRepository.UpdateAsync(playlist, ct);
        }

        public async Task<bool> DeletePlaylistAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _playlistRepository.DeleteAsync(id, ct);
        }
    }
}