using System.Collections.Generic;

namespace $safeprojectname$.Data.Entities
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        public ICollection<Album> Albums { get; set; } = new HashSet<Album>();
    }
}