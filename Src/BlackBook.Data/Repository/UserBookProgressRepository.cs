using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<bool> UpdateUserBookProgressAsync(UserBookProgress userBookProgress)
        {
            try
            {
                var existing = await _context.UserBookProgress.FindAsync(userBookProgress.Id);
                if (existing == null) return false;
                
                existing.LastReadPage = userBookProgress.LastReadPage;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Attach(UserBookProgress userBookProgress)
        {
            _context.UserBookProgress.Attach(userBookProgress);
        }
    }
}