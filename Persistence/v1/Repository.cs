using Application.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MediaPlayerContext Context;

        public Repository(MediaPlayerContext context)
        {
            this.Context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"{nameof(AddAsync)} entity must not be null");
            }
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"{nameof(DeleteAsync)} entity mult not be null");
            }

            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(GetByIdAsync)} id must not be empty");
            }

            return await Context.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), $"{nameof(UpdateAsync)} entity must not be null");
            }

            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        
    }
}
