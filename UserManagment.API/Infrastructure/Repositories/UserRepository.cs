using Microsoft.EntityFrameworkCore;
using UserManagment.API.Domain.Entities;
using UserManagment.API.Infrastructure.Contexts;

namespace UserManagment.API.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync() => await _context.UserDetails.AsNoTracking().ToListAsync();
        public async Task<UserDetails?> GetByIdAsync(int id)
        {
            return  await _context.UserDetails.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(UserDetails userDetails)
        {
            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(UserDetails userDetails)
        {
            _context.UserDetails.Update(userDetails);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var userDetails = await _context.UserDetails.AsNoTracking().SingleAsync(t => t.Id == id);
            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
                await _context.SaveChangesAsync();
            }
        }
    }

}