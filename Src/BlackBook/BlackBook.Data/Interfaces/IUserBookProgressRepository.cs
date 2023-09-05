using BlackBook.Data.Model;

namespace BlackBook.Data.Interfaces
{
    public interface IUserBookProgressRepository
    {
        Task<List<UserBookProgress>> GetAllUserBookProgressAsync();

        Task<UserBookProgress> GetUserBookProgressByIdAsync(int id);

        Task AddUserBookProgressAsync(UserBookProgress userBookProgress);

        Task UpdateUserBookProgressAsync(UserBookProgress userBookProgress);
    }
}