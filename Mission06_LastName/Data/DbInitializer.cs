using Mission06_LastName.Models;

namespace Mission06_LastName.Data
{
    public static class DbInitializer
    {
        public static void Seed(MovieCollectionContext context)
        {
            // If movies exist, assume seeded
            if (context.Movies.Any()) return;

            // Categories
            var action = new Category { Name = "Action" };
            var drama = new Category { Name = "Drama" };
            var comedy = new Category { Name = "Comedy" };

            context.Categories.AddRange(action, drama, comedy);
            context.SaveChanges();

            // 3 favorite movies (edit these if you want)
            var movies = new List<Movie>
            {
                new Movie
                {
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = Rating.PG13,
                    Edited = false,
                    CategoryId = action.CategoryId,
                    LentTo = null,
                    Notes = "Classic"
                },
                new Movie
                {
                    Title = "Interstellar",
                    Year = 2014,
                    Director = "Christopher Nolan",
                    Rating = Rating.PG13,
                    Edited = false,
                    CategoryId = drama.CategoryId,
                    LentTo = null,
                    Notes = "Space"
                },
                new Movie
                {
                    Title = "Nacho Libre",
                    Year = 2006,
                    Director = "Jared Hess",
                    Rating = Rating.PG,
                    Edited = false,
                    CategoryId = comedy.CategoryId,
                    LentTo = null,
                    Notes = "Funny"
                }
            };

            context.Movies.AddRange(movies);
            context.SaveChanges();
        }
    }
}