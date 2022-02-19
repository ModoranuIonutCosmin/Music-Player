using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmail(string email);
        Task<ApplicationUser> GetByUsernameAsync(string username);
        Task<ApplicationUser> GetByUsernameSubscriptionAsync(string username);
    }
}