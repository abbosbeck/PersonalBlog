﻿using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data.Entities;

namespace PersonalBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<BlogEntity> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogEntity>()
                .HasIndex(b => b.Slug)
                .IsUnique();
        }
    }
}
