using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStorageService
{
    public interface IBookStorageService
    {
        Task AddBookAsync(Book book, IFormFile file, Uri remoteFilePath);

        Task<List<Book>> GetAllBooksAsync();
    }
}