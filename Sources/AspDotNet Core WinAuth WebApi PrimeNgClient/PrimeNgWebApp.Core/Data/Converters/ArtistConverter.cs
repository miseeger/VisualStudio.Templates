using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class ArtistConverter
    {
        public static ArtistViewModel Convert(Artist artist)
        {
            var artistViewModel = new ArtistViewModel { ArtistId = artist.ArtistId, Name = artist.Name };
            return artistViewModel;
        }

        public static List<ArtistViewModel> ConvertList(IEnumerable<Artist> artists)
        {
            return artists.Select(a =>
                {
                    var model = new ArtistViewModel { ArtistId = a.ArtistId, Name = a.Name };
                    return model;
                })
                .ToList();
        }
    }
}