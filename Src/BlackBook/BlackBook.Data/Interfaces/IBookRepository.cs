﻿using BlackBook.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBook.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task AddBookAsync(Book book);

        Task UpdateBookAsync(Book book);

        Task DeleteBookAsync(int id);
    }
}