using BlackBook.Api.Model;
using BlackBook.Data.Model;
using BookStorageService;
using MegaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BlackBook.Api.Pages.BookAction
{
    public class CreateBookModel : PageModel
    {
        [BindProperty]
        public BookAddRequestModel BookAddRequestModel { get; set; }

        public string ErrorMessage { get; set; }

        private readonly IMegaService _megaService;
        private readonly IBookStorageService _bookStorageService;

        public CreateBookModel(IMegaService megaService, IBookStorageService bookStorageService)
        {
            _megaService = megaService;
            _bookStorageService = bookStorageService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var model = BookAddRequestModel;

            Uri uri = null;

            // файл необязателен — книгу можно завести только с данными и оглавлением
            if (model.File != null && model.File.Length > 0)
            {
                if (!ApplicationData.IsConnectedToMega)
                {
                    ErrorMessage = "Для загрузки файла книги необходимо подключение к MEGA.";
                    return Page();
                }

                using (var stream = model.File.OpenReadStream())
                {
                    uri = await _megaService.UploadStreamToMegaAsync(stream, Guid.NewGuid() + model.File.FileName);
                }

                if (uri == null)
                {
                    ErrorMessage = "Не удалось загрузить файл в MEGA. Книга не создана.";
                    return Page();
                }
            }

            var book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Genre = model.Genre,
                Year = model.Year,
                Pages = model.Pages,
                Toc = model.Toc   // сервис обернёт HTML редактора в XML
            };

            await _bookStorageService.AddBookAsync(book, model.File, uri);

            return RedirectToPage("/Library");
        }
    }
}
