using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Configurations
{
    public class MediaTypeConfiguration
    {
        public MediaTypeConfiguration(EntityTypeBuilder<MediaType> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}