using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using $safeprojectname$.Data;
using $safeprojectname$.Data.Converters;
using $safeprojectname$.Data.ViewModels;
using $safeprojectname$.Interface;

namespace $safeprojectname$.Service
{
    public class DashboardService: IDashboardService
    {
        private readonly DataContext _context;

        public DashboardService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TopTrackViewModel>> GetTop3TracksAsync()
        {
            IEnumerable<TopTrackViewModel> result = new List<TopTrackViewModel>();

            await Task.Run(() =>
            {
                var top3 = _context.Track
                    .Include(a => a.Album)
                    .Include(a => a.Album.Artist)
                    .Where(t => t.TrackId == 840 || t.TrackId == 637 || t.TrackId == 2140);

                result = top3
                    .AsEnumerable()
                    .Select((t, index) =>
                        new TopTrackViewModel
                        {
                            TrackRank = index + 1,
                            Song = t.Name,
                            Album = t.Album.Title,
                            Artist = t.Album.Artist.Name

                        });
            });

            return result;
        }

        public async Task<StatisticsViewModel> GetStatisticsAsync()
        {
            var result = new StatisticsViewModel();

            await Task.Run(() =>
            {
                result.AlbumCount = _context.Album.Count();
                result.ArtistCount = _context.Artist.Count();
                result.SongCount = _context.Track.Count();
                result.PlayLength = _context.Track.Sum(t => t.Milliseconds / 60000);
            });

            return result;
        }

    }
}