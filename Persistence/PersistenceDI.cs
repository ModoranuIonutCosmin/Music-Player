using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.v1;

namespace Persistence
{
    public static class PersistenceDI
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MediaPlayerContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection"), b => b.MigrationsAssembly(typeof(MediaPlayerContext).Assembly.FullName)));
            
            // register implementations related to repository/generic implementation
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IStorageInfoRepository, StorageInfoRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            services.AddTransient<ISubscriptionsRepository, SubscriptionsRepository>();
        }
    }
}
