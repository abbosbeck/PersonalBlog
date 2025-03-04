using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Entities;

namespace PersonalBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<BlogEntity> Blogs { get; set; }
        public DbSet<BlogImageEntity> BlogImages { get; set; }
        public DbSet<BlogOldSlugEntity> OldSlugs { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogEntity>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            modelBuilder.Entity<BlogEntity>()
                .HasQueryFilter(b => b.IsPublished);
        }
    }
}
