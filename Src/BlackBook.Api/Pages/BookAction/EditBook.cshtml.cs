using BlackBook.Api.Model;
using BlackBook.Data.Model;
using BlackBook.Data.Utils;
using BookStorageService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BlackBook.Api.Pages.BookAction
{
    /// <summary>
    /// Редактирование книги: данные и оглавление.
    /// </summary>
    public class EditBookModel : PageModel
    {
        [BindProperty]
        public BookEditModel BookEditModel { get; set; }

        private readonly IBookStorageService _bookStorageService;

        public EditBookModel(IBookStorageService bookStorageService)
        {
            _bookStorageService = bookStorageService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var book = await _bookStorageService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            BookEditModel = new BookEditModel
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                Year = book.Year,
                Pages = book.Pages,
                Toc = TocXml.UnwrapToHtml(book.Toc)
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Книга могла быть удалена: обновление несуществующей записи не должно молча проходить
            var existing = await _bookStorageService.GetBookAsync(BookEditModel.Id);
            if (existing == null)
            {
                return NotFound();
            }

            var book = new Book
            {
                Id = BookEditModel.Id,
                Title = BookEditModel.Title,
                Author = BookEditModel.Author,
                Genre = BookEditModel.Genre,
                Year = BookEditModel.Year,
                Pages = BookEditModel.Pages,
                Toc = BookEditModel.Toc   // сервис обернёт HTML редактора в XML
            };

            await _bookStorageService.UpdateBookAsync(book);

            return Redirect("/Library");
        }
    }
}
