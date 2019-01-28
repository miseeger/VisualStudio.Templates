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
        public async Task<List<GenreViewModel>> GetAllGenreAsync(CancellationToken ct = default(CancellationToken))
        {
            var genres = GenreConverter.ConvertList(await _genreRepository.GetAllAsync(ct));
            return genres;
        }

        public async Task<GenreViewModel> GetGenreByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var genreViewModel = GenreConverter.Convert(await _genreRepository.GetByIdAsync(id, ct));
            genreViewModel.Tracks = await GetTrackByGenreIdAsync(genreViewModel.GenreId, ct);
            return genreViewModel;
        }

        public async Task<GenreViewModel> AddGenreAsync(GenreViewModel newGenreViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var genre = new Genre
            {
                Name = newGenreViewModel.Name
            };

            genre = await _genreRepository.AddAsync(genre, ct);
            newGenreViewModel.GenreId = genre.GenreId;
            return newGenreViewModel;
        }

        public async Task<bool> UpdateGenreAsync(GenreViewModel genreViewModel,
            CancellationToken ct = default(CancellationToken))
        {
            var genre = await _genreRepository.GetByIdAsync(genreViewModel.GenreId, ct);

            if (genre == null) return false;
            genre.GenreId = genreViewModel.GenreId;
            genre.Name = genreViewModel.Name;

            return await _genreRepository.UpdateAsync(genre, ct);
        }

        public async Task<bool> DeleteGenreAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _genreRepository.DeleteAsync(id, ct);
        }
    }
}