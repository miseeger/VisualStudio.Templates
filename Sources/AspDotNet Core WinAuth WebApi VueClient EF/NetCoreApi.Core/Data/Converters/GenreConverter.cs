using System.Collections.Generic;
using System.Linq;
using $safeprojectname$.Data.Entities;
using $safeprojectname$.Data.ViewModels;

namespace $safeprojectname$.Data.Converters
{
    public static class GenreConverter
    {
        public static GenreViewModel Convert(Genre genre)
        {
            var genreViewModel = new GenreViewModel
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };

            return genreViewModel;
        }

        public static List<GenreViewModel> ConvertList(IEnumerable<Genre> genres)
        {
            return genres.Select(g =>
                {
                    var model = new GenreViewModel
                    {
                        GenreId = g.GenreId,
                        Name = g.Name
                    };
                    return model;
                })
                .ToList();
        }
    }
}