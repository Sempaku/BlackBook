using BlackBook.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBook.Data.Interfaces
{
    public interface IUserBookProgressRepository
    {
        Task<List<UserBookProgress>> GetAllUserBookProgressAsync();

        Task<UserBookProgress> GetUserBookProgressByIdAsync(int id);

        Task AddUserBookProgressAsync(UserBookProgress userBookProgress);

        Task<bool> UpdateUserBookProgressAsync(UserBookProgress userBookProgress);
    }
}