using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class TrackConverter
    {
        public static TrackViewModel Convert(Track track)
        {
            var trackViewModel = new TrackViewModel
            {
                TrackId = track.TrackId,
                Name = track.Name,
                AlbumId = track.AlbumId,
                MediaTypeId = track.MediaTypeId,
                GenreId = track.GenreId,
                Composer = track.Composer,
                Milliseconds = track.Milliseconds,
                Bytes = track.Bytes,
                UnitPrice = track.UnitPrice
            };
            return trackViewModel;
        }

        public static List<TrackViewModel> ConvertList(IEnumerable<Track> tracks)
        {
            return tracks.Select(t =>
                {
                    var model = new TrackViewModel
                    {
                        TrackId = t.TrackId,
                        Name = t.Name,
                        AlbumId = t.AlbumId,
                        MediaTypeId = t.MediaTypeId,
                        GenreId = t.GenreId,
                        Composer = t.Composer,
                        Milliseconds = t.Milliseconds,
                        Bytes = t.Bytes,
                        UnitPrice = t.UnitPrice
                    };
                    return model;
                })
                .ToList();
        }
    }
}