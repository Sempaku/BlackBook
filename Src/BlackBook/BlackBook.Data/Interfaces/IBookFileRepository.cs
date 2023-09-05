using BlackBook.Data.Model;

namespace BlackBook.Data.Interfaces
{
    public interface IBookFileRepository
    {
        Task<List<BookFile>> GetAllBookFilesAsync();

        Task<BookFile> GetBookFileByIdAsync(int id);

        Task AddBookFileAsync(BookFile bookFile);

        Task UpdateBookFileAsync(BookFile bookFile);
    }
}