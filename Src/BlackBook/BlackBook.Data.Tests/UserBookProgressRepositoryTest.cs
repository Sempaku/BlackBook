using BlackBook.Data.Model;
using BlackBook.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data.Tests
{
    public class UserBookProgressRepositoryTest
    {
        [Fact]
        public async Task GetAllUserBookProgressAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new UserBookProgressRepository(context);

                    var book1 = new Book { Title = "Sample Book1", Author = "Sample Author1", Pages = 100 };
                    var book2 = new Book { Title = "Sample Book2", Author = "Sample Author2", Pages = 200 };
                    var book3 = new Book { Title = "Sample Book3", Author = "Sample Author3", Pages = 300 };
                    await context.Books.AddAsync(book1);
                    await context.Books.AddAsync(book2);
                    await context.Books.AddAsync(book3);
                    await context.SaveChangesAsync();

                    var book1Id = context.Books.FirstOrDefault(b => b.Title == book1.Title).Id;
                    var book2Id = context.Books.FirstOrDefault(b => b.Title == book2.Title).Id;
                    var book3Id = context.Books.FirstOrDefault(b => b.Title == book3.Title).Id;

                    var progress1 = new UserBookProgress { BookId = book1Id, LastReadPage = 1 };
                    var progress2 = new UserBookProgress { BookId = book2Id, LastReadPage = 2 };
                    var progress3 = new UserBookProgress { BookId = book3Id, LastReadPage = 3 };
                    await repository.AddUserBookProgressAsync(progress1);
                    await repository.AddUserBookProgressAsync(progress2);
                    await repository.AddUserBookProgressAsync(progress3);
                    await context.SaveChangesAsync();

                    var addedProgress1 = await context.UserBookProgress.FirstOrDefaultAsync(bp => bp.BookId == book1Id);
                    var addedProgress2 = await context.UserBookProgress.FirstOrDefaultAsync(bp => bp.BookId == book2Id);
                    var addedProgress3 = await context.UserBookProgress.FirstOrDefaultAsync(bp => bp.BookId == book3Id);

                    Assert.NotNull(addedProgress1);
                    Assert.NotNull(addedProgress1.Book);
                    Assert.Equal("Sample Book1", addedProgress1.Book.Title);
                    Assert.Equal(1, addedProgress1.LastReadPage);

                    Assert.NotNull(addedProgress2);
                    Assert.NotNull(addedProgress2.Book);
                    Assert.Equal("Sample Book2", addedProgress2.Book.Title);
                    Assert.Equal(2, addedProgress2.LastReadPage);

                    Assert.NotNull(addedProgress3);
                    Assert.NotNull(addedProgress3.Book);
                    Assert.Equal("Sample Book3", addedProgress3.Book.Title);
                    Assert.Equal(3, addedProgress3.LastReadPage);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task GetUserBookProgressByIdAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new UserBookProgressRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookId = context.Books.FirstOrDefault(b => b.Title == book.Title).Id;

                    var bookProgress = new UserBookProgress { BookId = bookId, LastReadPage = 100 };
                    await repository.AddUserBookProgressAsync(bookProgress);

                    var addedBookProgress = await context.UserBookProgress.FirstOrDefaultAsync(p => p.BookId == bookId);

                    var progressFromDb = await repository.GetUserBookProgressByIdAsync(addedBookProgress.Id);

                    Assert.NotNull(progressFromDb);
                    Assert.NotNull(progressFromDb.Book);
                    Assert.Equal(100, progressFromDb.LastReadPage);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task AddUserBookProgressAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new UserBookProgressRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookId = context.Books.FirstOrDefault(b => b.Title == book.Title).Id;

                    var bookProgress = new UserBookProgress { BookId = bookId, LastReadPage = 100 };
                    await repository.AddUserBookProgressAsync(bookProgress);

                    var addedProgress = await context.UserBookProgress.FirstOrDefaultAsync(p => p.BookId == bookId);

                    Assert.NotNull(addedProgress);
                    Assert.NotNull(addedProgress.Book);
                    Assert.Equal(100, addedProgress.LastReadPage);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task UpdateUserBookProgressAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new UserBookProgressRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookId = context.Books.FirstOrDefault(b => b.Title == book.Title).Id;

                    var bookProgress = new UserBookProgress { BookId = bookId, LastReadPage = 100 };
                    await repository.AddUserBookProgressAsync(bookProgress);
                    await context.SaveChangesAsync();

                    var addedProgress = await context.UserBookProgress.FirstOrDefaultAsync(p => p.BookId == bookId);
                    addedProgress.LastReadPage = 600;
                    await repository.UpdateUserBookProgressAsync(addedProgress);

                    var progressFromDb = await repository.GetUserBookProgressByIdAsync(addedProgress.Id);

                    Assert.NotNull(progressFromDb);
                    Assert.NotNull(progressFromDb.Book);
                    Assert.Equal(600, progressFromDb.LastReadPage);

                    transaction.Rollback();
                }
            }
        }
    }
}