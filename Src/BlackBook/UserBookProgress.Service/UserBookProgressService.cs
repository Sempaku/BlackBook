using BlackBook.Data.Model;
using BlackBook.Data.Repository;

namespace UserBookProgressService
{
    public class UserBookProgressService : IUserBookProgressService
    {
        private readonly UserBookProgressRepository _userBookProgressRepository;

        public UserBookProgressService(UserBookProgressRepository userBookProgressRepository)
        {
            _userBookProgressRepository = userBookProgressRepository;
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
    }
}