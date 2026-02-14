using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Models;
// MovieCollectionContext.cs
// Defines the database context for the application.


namespace Mission06_LastName.Data
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        { }
// Configures EF Core to manage Movies and Categories tables.
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Keep Category name unique (good normalization hygiene)
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}