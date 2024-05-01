using BlackBook.Data.Model;
using BookStorageService;
using MegaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlackBook.Api.Pages.BookAction
{
    public class ViewBookModel : PageModel
    {
        private readonly IMegaService _megaService;
        private readonly IBookStorageService _bookStorageService;

        public BookFile BookFile { get; set; }
        public Book Book { get; set; }
        public string PathToBook { get; set; }
        public byte[] PdfContent { get; set; }

        public ViewBookModel(IMegaService megaService, IBookStorageService bookStorageService)
        {
            _megaService = megaService;
            _bookStorageService = bookStorageService;
        }

        public string GetPdfFilePath()
        {
            return Path.Combine("~\\wwwroot\\books", BookFile.FileName);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Получаем ID книги из параметра маршрута
            var book = (await _bookStorageService.GetAllBooksAsync()).Find(b => b.Id == id);
            Book = book ?? throw new ArgumentNullException(nameof(book));

            var bookFile = book.BookFile;
            if (bookFile == null)
            {
                return NotFound();
            }
            BookFile = bookFile;

            if (BookContainInLocalDirectory(bookFile.FileName))
            {
                // Книга уже скачана, преобразуем путь в Stream
                var filePath = Path.Combine(ApplicationData.LocalFileStorage, bookFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    PdfContent = new byte[fileStream.Length];
                    await fileStream.ReadAsync(PdfContent, 0, (int)fileStream.Length);
                }
            }
            else
            {
                // Загружаем книгу с помощью вашего сервиса загрузки
                var bookStream = await _megaService.GetBookByDownloadUrl(bookFile.FilePath);

                if (bookStream == null)
                {
                    return NotFound();
                }

                var filePath = Path.Combine(ApplicationData.LocalFileStorage, bookFile.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    bookStream.CopyTo(fileStream);
                    PdfContent = new byte[bookStream.Length];
                    await bookStream.ReadAsync(PdfContent, 0, (int)bookStream.Length);
                }
            }

            return Page();
        }

        private bool BookContainInLocalDirectory(string bookName)
        {
            if (bookName != null)
            {
                string localBookPath = Path.Combine(ApplicationData.LocalFileStorage, bookName);
                if (System.IO.File.Exists(localBookPath))
                {
                    return true;
                }
            }
            return false;
        }
    }
}