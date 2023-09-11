using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;

namespace BookStorageService
{
    public class BookStorageService : IBookStorageService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFileRepository _bookFileRepository;
        private readonly IUserBookProgressRepository _userBookProgressRepository;

        public BookStorageService(IBookRepository bookRepository,
            IBookFileRepository bookFileRepository, IUserBookProgressRepository userBookProgressRepository)
        {
            _bookRepository = bookRepository;
            _bookFileRepository = bookFileRepository;
            _userBookProgressRepository = userBookProgressRepository;
        }

        public async Task AddBookAsync(Book book, IFormFile file, Uri remoteFilePath)
        {
            BookFile bookFile = new BookFile
            {
                BookId = book.Id,
                FileName = file.FileName,
                Format = Path.GetExtension(file.FileName),
                FilePath = remoteFilePath.AbsoluteUri
            };

            book.BookFile = bookFile;
            book.UserBookProgress = new UserBookProgress { BookId = book.Id, LastReadPage = 0 };

            await _bookRepository.AddBookAsync(book);

        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> books = await _bookRepository.GetAllBooksAsync();
            return books;
        }      
    }
}