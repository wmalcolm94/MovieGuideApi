using Microsoft.EntityFrameworkCore;

namespace MovieGuideApi.Models
{
    public class MovieGuideContext : DbContext
    {
        public MovieGuideContext(DbContextOptions<MovieGuideContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasOne(a => a.chat)
                .WithOne(b => b.evnt)
                .HasForeignKey<Chat>(b => b.eventId);
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<UserEvent> UserEvent { get; set; }
    }
}