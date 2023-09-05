using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data.Repository
{
    public class BookFileRepository : IBookFileRepository
    {
        private readonly ApplicationDbContext _context;

        public BookFileRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<BookFile>> GetAllBookFilesAsync()
        {
            return await _context.BookFiles.ToListAsync();
        }

        public async Task<BookFile> GetBookFileByIdAsync(int id)
        {
            return await _context.BookFiles.FindAsync(id);
        }

        public async Task AddBookFileAsync(BookFile bookFile)
        {
            _context.BookFiles.Add(bookFile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookFileAsync(BookFile bookFile)
        {
            _context.Entry(bookFile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}