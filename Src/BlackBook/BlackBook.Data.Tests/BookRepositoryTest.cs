using BlackBook.Data.Model;
using BlackBook.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data.Tests
{
    public class BookRepositoryTest
    {
        [Fact]
        public async Task GetAllBooksAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                var repository = new BookRepository(context);
                var book1 = new Book { Title = "Book1", Author = "Author1", Pages = 1 };
                var book2 = new Book { Title = "Book2", Author = "Author2", Pages = 2 };
                var book3 = new Book { Title = "Book3", Author = "Author3", Pages = 3 };
                List<Book> books = new List<Book> { book1, book2, book3 };

                using (var transaction = context.Database.BeginTransaction())
                {
                    await repository.AddBookAsync(book1);
                    await repository.AddBookAsync(book2);
                    await repository.AddBookAsync(book3);
                    await context.SaveChangesAsync();
                    List<Book> booksFromDb = await repository.GetAllBooksAsync();
                    Assert.Equal(books, booksFromDb);
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task GetBookByIdAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Book", Author = "Author", Pages = 100 };

                using (var transaction = context.Database.BeginTransaction())
                {
                    await repository.AddBookAsync(book);

                    var addedBook = await context.Books.FirstOrDefaultAsync(b =>
                        b.Title == "Book" &&
                        b.Pages == 100 &&
                        b.Author == "Author");
                    var bookFromDb = await repository.GetBookByIdAsync(addedBook.Id);

                    Assert.NotNull(bookFromDb);
                    Assert.Equal(addedBook, bookFromDb);
                    Assert.Equal(addedBook.Title, bookFromDb.Title);
                    Assert.Equal(addedBook.Author, bookFromDb.Author);
                    Assert.Equal(addedBook.Pages, bookFromDb.Pages);
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task AddBookAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                var repository = new BookRepository(context);
                var newBook = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };

                using (var transaction = context.Database.BeginTransaction())
                {
                    await repository.AddBookAsync(newBook);
                    int bookCount = context.Books.Count();
                    Assert.Equal(1, bookCount);
                    transaction.Rollback(); // Откатываем транзакцию, чтобы не сохранять изменения в базе данных
                }
            }
        }

        [Fact]
        public async Task UpdateBookAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Book", Author = "Author", Pages = 100 };

                using (var transaction = context.Database.BeginTransaction())
                {
                    await repository.AddBookAsync(book);

                    var addedBook = await context.Books.FirstOrDefaultAsync(b => b.Title == "Book");
                    addedBook.Title = "Updated Book Title";
                    addedBook.Author = "Updated Author";
                    addedBook.Pages = 300;

                    await repository.UpdateBookAsync(addedBook);

                    var updatedBook = await context.Books.FirstOrDefaultAsync(b => b.Title == "Updated Book Title");

                    Assert.NotNull(updatedBook);
                    Assert.Equal("Updated Author", updatedBook.Author);
                    Assert.Equal(300, updatedBook.Pages);
                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task DeleteBookAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Book", Author = "Author", Pages = 100 };

                using (var transaction = context.Database.BeginTransaction())
                {
                    await repository.AddBookAsync(book);

                    var addedBook = await context.Books.FirstOrDefaultAsync(b => b.Title == "Book");

                    await repository.DeleteBookAsync(addedBook.Id);

                    var deletedBook = await context.Books.FirstOrDefaultAsync(b => b.Title == "Sample Book");
                    Assert.Null(deletedBook);
                    transaction.Rollback();
                }
            }
        }
    }
}