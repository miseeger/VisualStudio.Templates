using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Configurations
{
    public class PlaylistConfiguration
    {
        public PlaylistConfiguration(EntityTypeBuilder<Playlist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}