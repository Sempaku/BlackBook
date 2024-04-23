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

        public async Task OnPostAsync()
        {
            var model = BookAddRequestModel;

            using (var stream = model.File.OpenReadStream())
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Genre = model.Genre,
                    Pages = model.Pages
                };

                var uri = await _megaService.UploadStreamToMegaAsync(stream, Guid.NewGuid() + model.File.FileName);

                if (uri == null)
                {
                    Response.StatusCode = 403;
                }

                await _bookStorageService.AddBookAsync(book, model.File, uri);

                Response.StatusCode = 200;
            }

            Response.Redirect("/Library");
        }
    }
}