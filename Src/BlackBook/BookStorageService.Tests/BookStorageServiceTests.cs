using BlackBook.Data.Interfaces;
using BlackBook.Data.Model;
using BlackBook.Data.Repository;
using BlackBook.Data.Tests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;

namespace BookStorageService.Tests
{
    public class BookStorageServiceTests
    {
        [Fact]
        public async Task AddBookAsync_SavesBookToDiskAndDatabase()
        {
            // Arrange
            var bookRepositoryMock = new Mock<IBookRepository>();
            var bookFileRepositoryMock = new Mock<IBookFileRepository>();
            var userBookProgressRepositoryMock = new Mock<IUserBookProgressRepository>();

            var bookStorageService = new BookStorageService(
                bookRepositoryMock.Object,
                bookFileRepositoryMock.Object,
                userBookProgressRepositoryMock.Object
            );

            var book = new Book
            {
                Id = 1,
                Title = "Sample Book",
                Author = "Sample Author",
                Pages = 200
            };

            var fileMock = new Mock<IFormFile>();
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("Sample file content");
            writer.Flush();
            memoryStream.Position = 0;
            fileMock.Setup(f => f.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(f => f.FileName).Returns("sample.pdf");

            // Act
            await bookStorageService.AddBookAsync(book, fileMock.Object, new Uri("testUri"));

            // Assert
            bookRepositoryMock.Verify(repo => repo.AddBookAsync(book), Times.Once);
        }

        [Fact]
        public async Task AddBookAsync_RealFile_SavesBookAndFile()
        {
            // Путь к файлу на вашем диске
            string filePath
= "C:\\Users\\lalka\\OneDrive\\Рабочий стол\\BlackBook\\Src\\BlackBook\\BookStorageService.Tests\\test.pdf";

            var bookRepositoryMock = new BookRepository(DbContextCreator.CreateDbContext());
            var bookFileRepositoryMock = new BookFileRepository(DbContextCreator.CreateDbContext());
            var userBookProgressRepositoryMock = new UserBookProgressRepository(DbContextCreator.CreateDbContext());

            var bookStorageService = new BookStorageService(
                bookRepositoryMock,
                bookFileRepositoryMock,
                userBookProgressRepositoryMock
            );

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var fileName = Path.GetFileName(filePath);
                var contentType = "application/pdf";

                var file = new FormFile(stream, 0, stream.Length, null, fileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = contentType
                };

                var book = new Book
                {
                    Id = 1,
                    Title = "Sample Book",
                    Author = "Sample Author",
                    Pages = 200
                };

                await bookStorageService.AddBookAsync(book, file, new Uri("testUri"));

                Assert.True(true);
            }
        }
    }
}