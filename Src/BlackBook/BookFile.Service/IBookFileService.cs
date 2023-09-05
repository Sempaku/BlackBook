using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;

namespace BookFiles.Service
{
    public interface IBookFileService
    {
        Task<BookFile> SaveBookFileAsync(IFormFile file, int bookId);

        Task<BookFile> GetBookFileByIdAsync(int id);
    }
}