using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BookFiles.Service
{
    public interface IBookFileService
    {
        Task<BookFile> SaveBookFileAsync(IFormFile file, int bookId);

        Task<BookFile> GetBookFileByIdAsync(int id);
    }
}