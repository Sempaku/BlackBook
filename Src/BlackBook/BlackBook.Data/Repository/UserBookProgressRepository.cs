using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data.Repository
{
    public class UserBookProgressRepository : IUserBookProgressRepository
    {
        private readonly ApplicationDbContext _context;

        public UserBookProgressRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<UserBookProgress>> GetAllUserBookProgressAsync()
        {
            return await _context.UserBookProgress.ToListAsync();
        }

        public async Task<UserBookProgress> GetUserBookProgressByIdAsync(int id)
        {
            return await _context.UserBookProgress.FindAsync(id);
        }

        public async Task AddUserBookProgressAsync(UserBookProgress userBookProgress)
        {
            _context.UserBookProgress.Add(userBookProgress);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserBookProgressAsync(UserBookProgress userBookProgress)
        {
            _context.Entry(userBookProgress).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}