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
    /// <summary>
    /// Карточка книги: данные, оглавление (XML -> HTML) и чтение PDF.
    /// </summary>
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

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var book = await _bookStorageService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            Book = book;

            var bookFile = book.BookFile;
            if (bookFile == null)
            {
                // без файла показываем карточку с данными и оглавлением
                return Page();
            }
            BookFile = bookFile;

            if (BookContainInLocalDirectory(bookFile.FileName))
            {
                var filePath = Path.Combine(ApplicationData.LocalFileStorage, bookFile.FileName);
                PdfContent = await System.IO.File.ReadAllBytesAsync(filePath);
            }
            else
            {
                // файла нет в локальном кэше — тянем из облака
                var bookStream = await _megaService.GetBookByDownloadUrl(bookFile.FilePath);

                if (bookStream == null)
                {
                    return NotFound();
                }

                using (var memoryStream = new MemoryStream())
                {
                    await bookStream.CopyToAsync(memoryStream);
                    PdfContent = memoryStream.ToArray();
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
