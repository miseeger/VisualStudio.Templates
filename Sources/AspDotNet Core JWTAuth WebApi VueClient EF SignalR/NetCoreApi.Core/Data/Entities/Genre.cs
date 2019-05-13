using System.Collections.Generic;

namespace $safeprojectname$.Data.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; } = new HashSet<Track>();
    }
}