using UserManagment.API.Domain.Entities;

namespace UserManagment.API.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();
        Task<UserDetails?> GetByIdAsync(int id);
        Task AddAsync(UserDetails userDetails);
        Task UpdateAsync(UserDetails userDetails);
        Task DeleteAsync(int id);

    }
}