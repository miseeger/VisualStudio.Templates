using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Configurations
{
    public class ArtistConfiguration
    {
        public ArtistConfiguration(EntityTypeBuilder<Artist> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}