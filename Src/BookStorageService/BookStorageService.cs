using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using BlackBook.Data.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStorageService
{
    public class BookStorageService : IBookStorageService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookFileRepository _bookFileRepository;
        private readonly IUserBookProgressRepository _userBookProgressRepository;
        private readonly IRatingRepository _ratingRepository;

        public BookStorageService(
            IBookRepository bookRepository,
            IBookFileRepository bookFileRepository,
            IUserBookProgressRepository userBookProgressRepository,
            IRatingRepository ratingRepository)
        {
            _bookRepository = bookRepository;
            _bookFileRepository = bookFileRepository;
            _userBookProgressRepository = userBookProgressRepository;
            _ratingRepository = ratingRepository;
        }

        public async Task<int> AddBookAsync(Book book, IFormFile file, Uri remoteFilePath)
        {
            book.Toc = TocXml.WrapHtml(book.Toc);

            var bookId = await _bookRepository.AddBookAsync(book);

            if (file != null)
            {
                await _bookFileRepository.AddBookFileAsync(new BookFile
                {
                    BookId = bookId,
                    FileName = file.FileName,
                    Format = Path.GetExtension(file.FileName),
                    FilePath = remoteFilePath?.AbsoluteUri ?? string.Empty
                });
            }

            await _userBookProgressRepository.AddUserBookProgressAsync(
                new UserBookProgress { BookId = bookId, LastReadPage = 0 });

            await _ratingRepository.AddRatingAsync(
                new Rating { BookId = bookId, BookRating = 0 });

            return bookId;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<List<Book>> SearchBooksAsync(string query)
        {
            return await _bookRepository.SearchBooksAsync(query);
        }

        public async Task UpdateBookAsync(Book book)
        {
            book.Toc = TocXml.WrapHtml(book.Toc);
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task RemoveBookAsync(Book book)
        {
            await _bookRepository.DeleteBookAsync(book.Id);
        }

        public async Task RemoveBookAsync(Uri fileUri)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var book = books.FirstOrDefault(b => b.BookFile != null && b.BookFile.FilePath == fileUri.ToString());
            if (book != null)
            {
                await _bookRepository.DeleteBookAsync(book.Id);
            }
        }
    }
}
