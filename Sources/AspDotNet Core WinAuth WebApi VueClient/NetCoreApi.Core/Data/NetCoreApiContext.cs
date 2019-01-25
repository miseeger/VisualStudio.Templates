using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Data
{
    public partial class $ext_safeprojectname$Context : DbContext
    {

        //public virtual DbSet<Blog> Blog { get; set; }
        //public virtual DbSet<Post> Post { get; set; }


        public $ext_safeprojectname$Context()
        {
        }


        public $ext_safeprojectname$Context(DbContextOptions<$ext_safeprojectname$Context> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>(entity =>
            //{
            //    entity.Property(e => e.Url).IsRequired();
            //});

            //modelBuilder.Entity<Post>(entity =>
            //{
            //    entity.HasOne(d => d.Blog)
            //        .WithMany(p => p.Post)
            //        .HasForeignKey(d => d.BlogId);
            //});
        }
    }
}
