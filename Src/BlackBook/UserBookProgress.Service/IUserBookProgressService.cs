using BlackBook.Data.Model;

namespace UserBookProgressService
{
    public interface IUserBookProgressService
    {
        Task<UserBookProgress> CreateUserBookProgressAsync(int bookId, int lastReadPage);

        Task<UserBookProgress> GetUserBookProgressByIdAsync(int id);
    }
}