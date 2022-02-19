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
            services.AddDbContext<MediaPlayerContext>(options =>
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                if (environment == "Development")
                {
                    options.UseSqlServer(configuration.GetConnectionString("MyConnection"),
                        b => b.MigrationsAssembly(typeof(MediaPlayerContext).Assembly.FullName));
                }
                else
                {
                    //Production
                    var connectionUrl = Environment.GetEnvironmentVariable("AZURESQLDB_URL");

                    options.UseSqlServer(connectionUrl);
                }
                

            });
            
            // register implementations related to repository/generic implementation
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<IStorageInfoRepository, StorageInfoRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            services.AddTransient<ISubscriptionsRepository, SubscriptionsRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IFavoritesRepository, FavoritesRepository>();
        }
    }
}
