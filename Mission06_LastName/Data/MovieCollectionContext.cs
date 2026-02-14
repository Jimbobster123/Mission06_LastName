using Microsoft.EntityFrameworkCore;
using Mission06_LastName.Models;

namespace Mission06_LastName.Data
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        { }

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