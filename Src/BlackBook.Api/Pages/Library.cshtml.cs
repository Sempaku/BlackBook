using BookStorageService;
using MegaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RatingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserBookProgressService;

namespace BlackBook.Api.Pages
{
    public class LibraryModel : PageModel
    {
        public List<BlackBook.Data.Model.Book> Books { get; set; }

        /// <summary> ??????? ????????? ?????? (???????? / ????? / ??????????) </summary>
        public string Query { get; set; }

        private readonly IBookStorageService _bookStorageService;
        private readonly IUserBookProgressService _userBookProgressService;
        private readonly IRatingService _ratingService;
        private readonly IMegaService _megaService;

        public LibraryModel(IBookStorageService bookStorageService, IUserBookProgressService userBookProgressService, IRatingService ratingService, IMegaService megaService)
        {
            _bookStorageService = bookStorageService;
            _userBookProgressService = userBookProgressService;
            _ratingService = ratingService;
            _megaService = megaService;
        }

        public async Task OnGetAsync(string q)
        {
            Query = q;

            Books = string.IsNullOrWhiteSpace(q)
                ? await _bookStorageService.GetAllBooksAsync()
                : await _bookStorageService.SearchBooksAsync(q.Trim());
        }

        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPostUpdateProgressAsync(int id, int lastReadPage)
        {
            if (id <= 0 || lastReadPage < 0)
            {
                return new JsonResult(new { success = false }) { StatusCode = 400 };
            }

            try
            {
                var result = await _userBookProgressService.ModifyLastReadPageByBookIdAsync(id, lastReadPage);
                return result ? new JsonResult(new { success = true }) : new JsonResult(new { success = false }) { StatusCode = 400 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, error = ex.Message }) { StatusCode = 500 };
            }
        }

        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPostUpdateRatingAsync(int id, int rating)
        {
            if (id <= 0 || rating < 0 || rating > 10)
            {
                return new JsonResult(new { success = false }) { StatusCode = 400 };
            }

            try
            {
                var result = await _ratingService.ModifyRatingByBookIdAsync(id, rating);
                return result ? new JsonResult(new { success = true }) : new JsonResult(new { success = false }) { StatusCode = 400 };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, error = ex.Message }) { StatusCode = 500 };
            }
        }

        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var book = await _bookStorageService.GetBookAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            await _bookStorageService.RemoveBookAsync(book);
            // TODO: ???????? ????? ?? MEGA ???? ?? ????????
            //await _megaService.RemoveBook(new Uri(book.BookFile.FilePath));
            return RedirectToPage();
        }
    }
}