using BlackBook.Data.Model;
using BlackBook.Data.Repository;
using BookFiles.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BookFileService
{
    public class BookFileService : IBookFileService
    {
        private readonly BookFileRepository _bookFileRepository;

        public BookFileService(BookFileRepository bookFileRepository)
        {
            _bookFileRepository = bookFileRepository;
        }

        public async Task<BookFile> SaveBookFileAsync(IFormFile file, int bookId)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine($"{Directory.GetCurrentDirectory()}", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var bookFile = new BookFile
            {
                BookId = bookId,
                FileName = fileName,
                Format = Path.GetExtension(fileName),
                FilePath = filePath
            };

            await _bookFileRepository.AddBookFileAsync(bookFile);

            return bookFile;
        }

        public async Task<BookFile> GetBookFileByIdAsync(int id)
        {
            return await _bookFileRepository.GetBookFileByIdAsync(id);
        }
    }
}