using Microsoft.EntityFrameworkCore.Metadata.Builders;
using $safeprojectname$.Data.Entities;

namespace $safeprojectname$.Data.Configurations
{
    public class GenreConfiguration
    {
        public GenreConfiguration(EntityTypeBuilder<Genre> entity)
        {
            entity.Property(e => e.Name).HasMaxLength(120);
        }
    }
}