using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Identity;
using System.Runtime.CompilerServices;
using MovieApi.Persistence.Context;

namespace MovieApi.Persistence.Context
{
    public class MovieContext : IdentityDbContext<AppUser>
    {
        private object cm;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ApiMovieDb;Integrated Security=true;TrustServerCertificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Cast> Casts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Reviews)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId)
                .IsRequired();

            //----------------------------------
            modelBuilder.Entity<CastMovie>()
              .HasKey(cm => new { cm.MovieId, cm.CastId });

            modelBuilder.Entity<CastMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CastMovies)
                .HasForeignKey(cm => cm.MovieId);

            modelBuilder.Entity<CastMovie>()
                .HasOne(cm => cm.Cast)
                .WithMany(c => c.CastMovies)
                .HasForeignKey(cm => cm.CastId);

            //----------------------------------
            modelBuilder.Entity<CategoryMovie>()
              .HasKey(cm => new { cm.MovieId, cm.CategoryId });

            modelBuilder.Entity<CategoryMovie>()
                .HasOne(cm => cm.Movie)
                .WithMany(m => m.CategoryMovies)
                .HasForeignKey(cm => cm.MovieId);

            modelBuilder.Entity<CategoryMovie>()
                .HasOne(cm => cm.Category)
                .WithMany(c => c.CategoryMovies)
                .HasForeignKey(cm => cm.CategoryId);
            //------------------------------------

            modelBuilder.Entity<TagMovie>()
                .HasKey (tm => new { tm.MovieId, tm.TagId });

            modelBuilder.Entity<TagMovie>()
                .HasOne (tm => tm.Movie)
                .WithMany (m => m.TagMovies)
                .HasForeignKey (tm => tm.MovieId);

            modelBuilder.Entity<TagMovie>()
                .HasOne (tm => tm.Tag)
                .WithMany (t => t.TagMovies)
                .HasForeignKey(tm  => tm.TagId);
        }
    }
}