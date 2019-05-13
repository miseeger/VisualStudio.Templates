using System.Collections.Generic;

namespace $safeprojectname$.Data.ViewModels
{
    public class PlaylistViewModel
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public IList<TrackViewModel> Tracks { get; set; }
        public IList<PlaylistTrackViewModel> PlaylistTracks { get; set; }
    }
}