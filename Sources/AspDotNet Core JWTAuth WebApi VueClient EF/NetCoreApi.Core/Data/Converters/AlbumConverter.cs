using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class AlbumConverter
    {
        public static AlbumViewModel Convert(Album album)
        {
            var albumViewModel = new AlbumViewModel
            {
                AlbumId = album.AlbumId,
                ArtistId = album.ArtistId,
                Title = album.Title
            };

            return albumViewModel;
        }

        public static List<AlbumViewModel> ConvertList(IEnumerable<Album> albums)
        {
            return albums.Select(a =>
                {
                    var model = new AlbumViewModel
                    {
                        AlbumId = a.AlbumId,
                        ArtistId = a.ArtistId,
                        Title = a.Title
                    };
                    return model;
                })
                .ToList();
        }
    }
}