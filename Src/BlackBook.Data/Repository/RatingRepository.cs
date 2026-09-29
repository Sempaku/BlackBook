using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBook.Data.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Rating>> GetAllRatingAsync()
        {
            return await _context.Rating.ToListAsync();
        }

        public async Task<Rating> GetRatingByIdAsync(int id)
        {
            return await _context.Rating.FindAsync(id);
        }

        public async Task AddRatingAsync(Rating rating)
        {
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRatingAsync(Rating rating)
        {
            try
            {
                var existing = await _context.Rating.FindAsync(rating.Id);
                if (existing == null) return false;
                
                existing.BookRating = rating.BookRating;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Attach(Rating rating)
        {
            _context.Rating.Attach(rating);
        }
    }
}