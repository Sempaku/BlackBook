using BlackBook.Data.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStorageService
{
    public interface IBookStorageService
    {
        /// <summary> Создание книги (INSERT через хранимую процедуру); возвращает Id новой записи </summary>
        Task<int> AddBookAsync(Book book, IFormFile file, Uri remoteFilePath);

        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookAsync(int id);

        /// <summary> Поиск по названию, автору и оглавлению (хранимая функция fn_books_search) </summary>
        Task<List<Book>> SearchBooksAsync(string query);

        /// <summary> Изменение книги (UPDATE через хранимую процедуру) </summary>
        Task UpdateBookAsync(Book book);

        Task RemoveBookAsync(Book book);

        Task RemoveBookAsync(Uri fileUri);
    }
}
