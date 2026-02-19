using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Models;

namespace Mission06_LastName.Data
{
    // Defines the database context for the Joel Hilton Movie Collection app
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Make CategoryName unique
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.CategoryName)
                .IsUnique();
        }
    }
}