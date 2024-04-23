using BookStorageService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RatingService;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserBookProgressService;

namespace BlackBook.Api.Pages
{
    public class LibraryModel : PageModel
    {
        public List<BlackBook.Data.Model.Book> Books { get; set; }

        private readonly IBookStorageService _bookStorageService;
        private readonly IUserBookProgressService _userBookProgressService;
        private readonly IRatingService _ratingService;

        public LibraryModel(IBookStorageService bookStorageService, IUserBookProgressService userBookProgressService, IRatingService ratingService)
        {
            _bookStorageService = bookStorageService;
            _userBookProgressService = userBookProgressService;
            _ratingService = ratingService;
        }

        public async Task OnGetAsync()
        {
            Books = await _bookStorageService.GetAllBooksAsync();
        }

        public async Task<IActionResult> OnPostUpdateProgressAsync(int id, int lastReadPage)
        {
            await _userBookProgressService.ModifyLastReadPageByBookIdAsync(id, lastReadPage);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostUpdateRatingAsync(int id, int rating)
        {
            await _ratingService.ModifyRatingByBookIdAsync(id, rating);

            return RedirectToPage();
        }
    }
}