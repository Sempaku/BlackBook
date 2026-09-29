using BlackBook.Data.Model;
using BlackBook.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace BlackBook.Data.Tests
{
    public class BookFileRepositoryTest
    {
        [Fact]
        public async Task GetAllBookFilesAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new BookFileRepository(context);

                    var book1 = new Book { Title = "Sample Book1", Author = "Sample Author1", Pages = 100 };
                    var book2 = new Book { Title = "Sample Book2", Author = "Sample Author2", Pages = 200 };
                    var book3 = new Book { Title = "Sample Book3", Author = "Sample Author3", Pages = 300 };
                    await context.Books.AddAsync(book1);
                    await context.Books.AddAsync(book2);
                    await context.Books.AddAsync(book3);
                    await context.SaveChangesAsync();

                    var bookFile1 = new BookFile { Format = "PDF", FileName = "SampleFile1.pdf", FilePath = "/path/sample1.pdf", BookId = book1.Id };
                    var bookFile2 = new BookFile { Format = "PDF", FileName = "SampleFile2.pdf", FilePath = "/path/sample2.pdf", BookId = book2.Id };
                    var bookFile3 = new BookFile { Format = "PDF", FileName = "SampleFile3.pdf", FilePath = "/path/sample3.pdf", BookId = book3.Id };
                    await repository.AddBookFileAsync(bookFile1);
                    await repository.AddBookFileAsync(bookFile2);
                    await repository.AddBookFileAsync(bookFile3);

                    var addedFile1 = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile1.pdf");
                    var addedFile2 = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile2.pdf");
                    var addedFile3 = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile3.pdf");
                    Assert.NotNull(addedFile1);
                    Assert.Equal("Sample Book1", addedFile1.Book.Title);
                    Assert.Equal("SampleFile1.pdf", addedFile1.FileName);
                    Assert.Equal("/path/sample1.pdf", addedFile1.FilePath);
                    Assert.NotNull(addedFile1.Book);

                    Assert.NotNull(addedFile2);
                    Assert.Equal("Sample Book2", addedFile2.Book.Title);
                    Assert.Equal("SampleFile2.pdf", addedFile2.FileName);
                    Assert.Equal("/path/sample2.pdf", addedFile2.FilePath);
                    Assert.NotNull(addedFile2.Book);

                    Assert.NotNull(addedFile3);
                    Assert.Equal("Sample Book3", addedFile3.Book.Title);
                    Assert.Equal("SampleFile3.pdf", addedFile3.FileName);
                    Assert.Equal("/path/sample3.pdf", addedFile3.FilePath);
                    Assert.NotNull(addedFile3.Book);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task GetBookFileByIdAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new BookFileRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookFile = new BookFile { Format = "PDF", FileName = "SampleFile.pdf", FilePath = "/path/sample.pdf", BookId = book.Id };
                    await repository.AddBookFileAsync(bookFile);

                    var addedFile = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile.pdf");

                    var fileFromDb = await repository.GetBookFileByIdAsync(addedFile.Id);

                    Assert.NotNull(fileFromDb);
                    Assert.Equal("PDF", fileFromDb.Format);
                    Assert.Equal("SampleFile.pdf", fileFromDb.FileName);
                    Assert.Equal("/path/sample.pdf", fileFromDb.FilePath);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task AddBookFileAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new BookFileRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookFile = new BookFile { Format = "PDF", FileName = "SampleFile.pdf", FilePath = "/path/sample.pdf", BookId = book.Id };
                    await repository.AddBookFileAsync(bookFile);

                    var addedFile = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile.pdf");

                    Assert.NotNull(addedFile);
                    Assert.Equal("SampleFile.pdf", addedFile.FileName);
                    Assert.Equal("/path/sample.pdf", addedFile.FilePath);
                    Assert.Equal("PDF", addedFile.Format);
                    Assert.NotNull(addedFile.Book);
                    Assert.Equal("Sample Book", addedFile.Book.Title);

                    transaction.Rollback();
                }
            }
        }

        [Fact]
        public async Task UpdateBookFileAsyncTest()
        {
            using (var context = DbContextCreator.CreateDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var repository = new BookFileRepository(context);

                    var book = new Book { Title = "Sample Book", Author = "Sample Author", Pages = 200 };
                    await context.Books.AddAsync(book);
                    await context.SaveChangesAsync();

                    var bookFile = new BookFile { Format = "PDF", FileName = "SampleFile.pdf", FilePath = "/path/sample.pdf", BookId = book.Id };
                    await repository.AddBookFileAsync(bookFile);

                    var addedFile = await context.BookFiles.FirstOrDefaultAsync(f => f.FileName == "SampleFile.pdf");
                    addedFile.Format = "EPUB";
                    addedFile.FileName = "NewFile.epub";
                    addedFile.FilePath = "/newpath/books/NewFile.epub";
                    await repository.UpdateBookFileAsync(addedFile);

                    var fileFromDb = await repository.GetBookFileByIdAsync(addedFile.Id);

                    Assert.NotNull(fileFromDb);
                    Assert.Equal("NewFile.epub", fileFromDb.FileName);
                    Assert.Equal("/newpath/books/NewFile.epub", fileFromDb.FilePath);
                    Assert.Equal("EPUB", fileFromDb.Format);
                    Assert.NotNull(fileFromDb.Book);
                    Assert.Equal("Sample Book", fileFromDb.Book.Title);

                    transaction.Rollback();
                }
            }
        }
    }
}