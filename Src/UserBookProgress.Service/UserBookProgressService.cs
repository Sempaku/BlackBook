using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using System.Threading.Tasks;

namespace UserBookProgressService
{
    public class UserBookProgressService : IUserBookProgressService
    {
        private readonly IUserBookProgressRepository _userBookProgressRepository;
        private readonly IBookRepository _bookRepository;

        public UserBookProgressService(IUserBookProgressRepository userBookProgressRepository, IBookRepository bookRepository)
        {
            _userBookProgressRepository = userBookProgressRepository;
            _bookRepository = bookRepository;
        }

        public async Task<UserBookProgress> CreateUserBookProgressAsync(int bookId, int lastReadPage)
        {
            var userBookProgress = new UserBookProgress
            {
                BookId = bookId,
                LastReadPage = lastReadPage
            };

            await _userBookProgressRepository.AddUserBookProgressAsync(userBookProgress);

            return userBookProgress;
        }

        public async Task<UserBookProgress> GetUserBookProgressByIdAsync(int id)
        {
            return await _userBookProgressRepository.GetUserBookProgressByIdAsync(id);
        }

        public async Task<bool> ModifyLastReadPageByBookIdAsync(int bookId, int lastReadPage)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book?.UserBookProgress == null)
                return false;

            book.UserBookProgress.LastReadPage = lastReadPage;
            _userBookProgressRepository.Attach(book.UserBookProgress);
            return await _userBookProgressRepository.UpdateUserBookProgressAsync(book.UserBookProgress);
        }
    }
}