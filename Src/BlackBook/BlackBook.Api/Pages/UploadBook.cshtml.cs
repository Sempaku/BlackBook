using BlackBook.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackBook.Api.Pages
{
    public class UploadBookModel : PageModel
    {
        [BindProperty]
        public string BookTitle { get; set; }
        [BindProperty]
        public string BookAuthor { get; set; }
        [BindProperty]
        public int BookPages { get; set; }
        [BindProperty]
        public IFormFile BookFile { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            

        }
    }
}
