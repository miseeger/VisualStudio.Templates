using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class PlaylistTrackConverter
    {
        public static PlaylistTrackViewModel Convert(PlaylistTrack playlistTrack)
        {
            var playlistTrackViewModel = new PlaylistTrackViewModel
            {
                PlaylistId = playlistTrack.PlaylistId,
                TrackId = playlistTrack.TrackId
            };

            return playlistTrackViewModel;
        }

        public static List<PlaylistTrackViewModel> ConvertList(IEnumerable<PlaylistTrack> playlistTracks)
        {
            return playlistTracks.Select(p =>
                {
                    var model = new PlaylistTrackViewModel
                    {
                        PlaylistId = p.PlaylistId,
                        TrackId = p.TrackId
                    };
                    return model;
                })
                .ToList();
        }
    }
}