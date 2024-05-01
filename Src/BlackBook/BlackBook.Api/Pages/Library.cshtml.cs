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

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var books = await _bookStorageService.GetAllBooksAsync();
            var book = books.FirstOrDefault(book => book.Id == id);
            
            if (book == null)
            {
                return NotFound();
            }
            await _bookStorageService.RemoveBookAsync(book);
            // ѕроблемы с мегой, пока нет возможности удал€ть 
            //await _megaService.RemoveBook(new Uri(book.BookFile.FilePath)); 
            return RedirectToPage();
        }
    }
}