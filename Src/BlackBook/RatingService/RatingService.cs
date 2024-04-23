using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using System.Threading.Tasks;

namespace RatingService
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IBookRepository _bookRepository;

        public RatingService(IRatingRepository ratingRepository, IBookRepository bookRepository)
        {
            _ratingRepository = ratingRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Rating> CreateRatingAsync(int bookId, int rating)
        {
            var bookRating = new Rating
            {
                BookId = bookId,
                BookRating = rating
            };

            await _ratingRepository.AddRatingAsync(bookRating);

            return bookRating;
        }

        public async Task<Rating> GetRatingByIdAsync(int id)
        {
            return await _ratingRepository.GetRatingByIdAsync(id);
        }

        public async Task<bool> ModifyRatingByBookIdAsync(int bookId, int rating)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            book.Rating.BookRating = rating;
            return await _ratingRepository.UpdateRatingAsync(book.Rating);
        }
    }
}