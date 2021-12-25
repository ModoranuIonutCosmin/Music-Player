using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;

namespace Infrastructure.Tets
{
    public class DatabaseBaseTest : IDisposable
    {
        protected readonly MediaPlayerContext context;

        public DatabaseBaseTest()
        {
            var options = new DbContextOptionsBuilder<MediaPlayerContext>().UseInMemoryDatabase("TestDatabase").Options;
            context = new MediaPlayerContext(options);
            context.Database.EnsureCreated();
            DatabaseInitializer.Initialize(context);
        }

        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
