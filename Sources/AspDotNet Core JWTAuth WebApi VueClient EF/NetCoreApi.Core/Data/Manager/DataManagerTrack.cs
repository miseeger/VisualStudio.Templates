using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Converters;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Manager
{
    public partial class DataManager : IDataManager
    {
        public async Task<List<TrackViewModel>> GetAllTrackAsync(CancellationToken ct = default(CancellationToken))
        {
            var tracks = TrackConverter.ConvertList(await _trackRepository.GetAllAsync(ct));
            return tracks;
        }

        public async Task<TrackViewModel> GetTrackByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var trackViewModel = TrackConverter.Convert(await _trackRepository.GetByIdAsync(id, ct));
            trackViewModel.Genre = await GetGenreByIdAsync(trackViewModel.GenreId.GetValueOrDefault(), ct);
            trackViewModel.Album = await GetAlbumByIdAsync(trackViewModel.AlbumId, ct);
            trackViewModel.MediaType = await GetMediaTypeByIdAsync(trackViewModel.MediaTypeId, ct);
            trackViewModel.AlbumName = trackViewModel.Album.Title;
            trackViewModel.MediaTypeName = trackViewModel.MediaType.Name;
            trackViewModel.GenreName = trackViewModel.Genre.Name;
            return trackViewModel;
        }

        public async Task<List<TrackViewModel>> GetTrackByAlbumIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByAlbumIdAsync(id, ct);
            return TrackConverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackViewModel>> GetTrackByGenreIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByGenreIdAsync(id, ct);
            return TrackConverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackViewModel>> GetTrackByMediaTypeIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _trackRepository.GetByMediaTypeIdAsync(id, ct);
            return TrackConverter.ConvertList(tracks).ToList();
        }

        public async Task<List<TrackViewModel>> GetTrackByPlaylistIdIdAsync(int id,
            CancellationToken ct = default(CancellationToken))
        {
            var tracks = await _playlistRepository.GetTrackByPlaylistIdAsync(id, ct);
            return TrackConverter.ConvertList(tracks).ToList();
        }

        public async Task<TrackViewModel> AddTrackAsync(TrackViewModel newTrackViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var track = new Track
            {
                TrackId = newTrackViewModel.TrackId,
                Name = newTrackViewModel.Name,
                AlbumId = newTrackViewModel.AlbumId,
                MediaTypeId = newTrackViewModel.MediaTypeId,
                GenreId = newTrackViewModel.GenreId,
                Composer = newTrackViewModel.Composer,
                Milliseconds = newTrackViewModel.Milliseconds,
                Bytes = newTrackViewModel.Bytes,
                UnitPrice = newTrackViewModel.UnitPrice
            };

            await _trackRepository.AddAsync(track, ct);
            newTrackViewModel.TrackId = track.TrackId;
            return newTrackViewModel;
        }

        public async Task<bool> UpdateTrackAsync(TrackViewModel trackViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var track = await _trackRepository.GetByIdAsync(trackViewModel.TrackId, ct);

            if (track == null) return false;
            track.TrackId = trackViewModel.TrackId;
            track.Name = trackViewModel.Name;
            track.AlbumId = trackViewModel.AlbumId;
            track.MediaTypeId = trackViewModel.MediaTypeId;
            track.GenreId = trackViewModel.GenreId;
            track.Composer = trackViewModel.Composer;
            track.Milliseconds = trackViewModel.Milliseconds;
            track.Bytes = trackViewModel.Bytes;
            track.UnitPrice = trackViewModel.UnitPrice;

            return await _trackRepository.UpdateAsync(track, ct);
        }

        public async Task<bool> DeleteTrackAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _trackRepository.DeleteAsync(id, ct);
        }
    }
}