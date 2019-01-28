using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Repositories
{
    public interface IGenreRepository : IDisposable
    {
        Task<List<Genre>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Genre> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default(CancellationToken));
        Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default(CancellationToken));
        Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken));
    }
}