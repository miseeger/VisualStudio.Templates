using System.Collections.Generic;

namespace $safeprojectname$.Data.ViewModels
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        public IList<TrackViewModel> Tracks { get; set; }
    }
}