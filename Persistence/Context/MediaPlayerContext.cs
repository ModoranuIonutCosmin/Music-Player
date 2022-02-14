using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class MediaPlayerContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Storage> StorageInfo { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<NewsPost> News { get; set; }

        public MediaPlayerContext()
        {

        }

        public MediaPlayerContext(DbContextOptions<MediaPlayerContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOne<Subscription>(u => u.Subscription)
                .WithOne(s => s.ApplicationUser)
                .HasForeignKey<Subscription>(u => u.ApplicationUserId);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Database=Player;Integrated Security=True");
        }
    }
}
