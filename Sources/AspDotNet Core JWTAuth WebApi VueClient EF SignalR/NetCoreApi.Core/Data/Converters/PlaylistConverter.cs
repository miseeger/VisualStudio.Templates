using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class PlaylistConverter
    {
        public static PlaylistViewModel Convert(Playlist playlist)
        {
            var playlistViewModel = new PlaylistViewModel
            {
                PlaylistId = playlist.PlaylistId,
                Name = playlist.Name
            };
            return playlistViewModel;
        }

        public static List<PlaylistViewModel> ConvertList(IEnumerable<Playlist> playlists)
        {
            return playlists.Select(p =>
                {
                    var model = new PlaylistViewModel
                    {
                        PlaylistId = p.PlaylistId,
                        Name = p.Name
                    };
                    return model;
                })
                .ToList();
        }
    }
}