using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace BlackBook.Data.Repository
{
    /// <summary>
    /// Доступ к книгам через хранимые процедуры PostgreSQL:
    ///   sp_books_insert / sp_books_update / sp_books_delete — DML (CALL),
    ///   fn_books_select / fn_books_get_by_id / fn_books_search — выборки (SELECT ... FROM fn_...()).
    /// EF Core используется для маппинга результатов выборок в сущности.
    /// Скрипты создания процедур: Sql/02_stored_procs.sql.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _context.Books
                .FromSqlRaw("SELECT * FROM fn_books_select()")
                .Include(b => b.BookFile)
                .Include(b => b.UserBookProgress)
                .Include(b => b.Rating)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .FromSqlInterpolated($"SELECT * FROM fn_books_get_by_id({id})")
                .Include(b => b.BookFile)
                .Include(b => b.UserBookProgress)
                .Include(b => b.Rating)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddBookAsync(Book book)
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var command = connection.CreateCommand();
            command.CommandText =
                "CALL sp_books_insert(@title, @author, @genre, @year, @pages, CAST(@toc AS xml), NULL)";

            AddParameter(command, "@title", book.Title);
            AddParameter(command, "@author", book.Author);
            AddParameter(command, "@genre", book.Genre);
            AddParameter(command, "@year", book.Year);
            AddParameter(command, "@pages", book.Pages);
            AddParameter(command, "@toc", book.Toc);

            // CALL с INOUT-параметром p_new_id возвращает строку с Id новой записи
            await using var reader = await command.ExecuteReaderAsync();
            await reader.ReadAsync();
            var newId = reader.GetInt32(0);
            book.Id = newId;
            return newId;
        }

        public async Task UpdateBookAsync(Book book)
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await using var command = connection.CreateCommand();
            command.CommandText =
                "CALL sp_books_update(@id, @title, @author, @genre, @year, @pages, CAST(@toc AS xml))";

            AddParameter(command, "@id", book.Id);
            AddParameter(command, "@title", book.Title);
            AddParameter(command, "@author", book.Author);
            AddParameter(command, "@genre", book.Genre);
            AddParameter(command, "@year", book.Year);
            AddParameter(command, "@pages", book.Pages);
            AddParameter(command, "@toc", book.Toc);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($"CALL sp_books_delete({id})");
        }

        public async Task<List<Book>> SearchBooksAsync(string query)
        {
            return await _context.Books
                .FromSqlInterpolated($"SELECT * FROM fn_books_search({query})")
                .Include(b => b.BookFile)
                .Include(b => b.UserBookProgress)
                .Include(b => b.Rating)
                .ToListAsync();
        }

        private static void AddParameter(DbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value ?? System.DBNull.Value;
            command.Parameters.Add(parameter);
        }
    }
}
