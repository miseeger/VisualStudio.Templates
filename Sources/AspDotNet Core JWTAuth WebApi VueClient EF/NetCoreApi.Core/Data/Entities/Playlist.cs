using System.Collections.Generic;

namespace $safeprojectname$.Data.Entities
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTracks { get; set; } = new HashSet<PlaylistTrack>();
    }
}