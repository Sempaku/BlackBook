using BlackBook.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackBook.Data.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        /// <summary> INSERT через хранимую процедуру sp_books_insert; возвращает Id новой записи </summary>
        Task<int> AddBookAsync(Book book);

        /// <summary> UPDATE через хранимую процедуру sp_books_update </summary>
        Task UpdateBookAsync(Book book);

        /// <summary> DELETE через хранимую процедуру sp_books_delete </summary>
        Task DeleteBookAsync(int id);

        /// <summary> Поиск через хранимую функцию fn_books_search (название / автор / оглавление) </summary>
        Task<List<Book>> SearchBooksAsync(string query);
    }
}
