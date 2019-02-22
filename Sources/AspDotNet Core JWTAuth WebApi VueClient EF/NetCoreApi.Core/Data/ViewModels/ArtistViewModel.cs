using System.Collections.Generic;

namespace $safeprojectname$.Data.ViewModels
{
    public class ArtistViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public IList<AlbumViewModel> Albums { get; set; }
    }
}