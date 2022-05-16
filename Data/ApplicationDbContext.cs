using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieHolic.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MovieHolic.Models.Movie>? Movie { get; set; }
        public DbSet<MovieHolic.Models.Post>? Post { get; set; }
        public DbSet<MovieHolic.Models.Tag>? Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(pt => new { pt.PostId, pt.TagId });
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Post).WithMany(pt => pt.PostTags).HasForeignKey(p => p.PostId);
            modelBuilder.Entity<PostTag>().HasOne(pt => pt.Tag).WithMany(pt => pt.PostTags).HasForeignKey(t => t.TagId);
        }
    }
