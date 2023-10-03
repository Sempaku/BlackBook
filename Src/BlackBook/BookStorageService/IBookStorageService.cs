using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;

namespace BookStorageService
{
    public interface IBookStorageService
    {
        Task AddBookAsync(Book book, IFormFile file, Uri remoteFilePath);

        Task<List<Book>> GetAllBooksAsync();
    }
}