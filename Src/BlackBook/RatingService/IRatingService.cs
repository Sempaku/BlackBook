using BlackBook.Data.Model;

namespace RatingService
{
    public interface IRatingService
    {
        Task<Rating> CreateRatingAsync(int bookId, int rating);
        Task<Rating> GetRatingByIdAsync(int id);
        Task<bool> ModifyRatingByBookIdAsync(int bookId, int rating);
    }
}