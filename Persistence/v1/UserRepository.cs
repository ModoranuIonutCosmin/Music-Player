﻿using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.v1
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(MediaPlayerContext databaseContext) : base(databaseContext)
        {

        }

        public async Task<ApplicationUser> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), $"Username can't be null");

            return await Context.Users.Where(user => user.UserName == username)
                .FirstOrDefaultAsync();
        }
        
        public async Task<ApplicationUser> GetByUsernameSubscriptionAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException(nameof(username), $"Username can't be null");

            return await Context.Users
                .Where(user => user.UserName == username)
                    .Include(u => u.Subscription)
                .FirstOrDefaultAsync();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException(nameof(email), $"Email can't be null");
            }

            return await Context.Users.FirstOrDefaultAsync(user => user.Email == email);
        }
    }
}
