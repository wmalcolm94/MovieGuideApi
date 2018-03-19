using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Models
{
    public class MovieGuideContext : DbContext
    {
        public MovieGuideContext(DbContextOptions<MovieGuideContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
    }
}