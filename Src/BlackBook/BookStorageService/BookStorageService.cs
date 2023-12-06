using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
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

        public BookStorageService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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
            book.Rating = new Rating { BookId = book.Id , BookRating = 0};
            await _bookRepository.AddBookAsync(book);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            List<Book> books = await _bookRepository.GetAllBooksAsync();
            return books;
        }

        public async Task RemoveBookAsync(Book book)
        {
            await _bookRepository.DeleteBookAsync(book.Id);
        }

        public async Task RemoveBookAsync(Uri fileUri)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            await _bookRepository.DeleteBookAsync(books.First(book => book.BookFile.FilePath == fileUri.ToString()).Id);
        }
    }
}