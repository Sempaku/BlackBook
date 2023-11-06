using BlackBook.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBook.Data.Interfaces
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetAllRatingAsync();

        Task<Rating> GetRatingByIdAsync(int id);

        Task AddRatingAsync(Rating rating);

        Task<bool> UpdateRatingAsync(Rating rating);
    }
}