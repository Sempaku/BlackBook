using BlackBook.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackBook.Api.Pages
{
    public class BookLibraryModel : PageModel
    {
        public List<Book> ListBooks { get; set; }
        public async Task OnGetAsync()
        {
            var responce = new HttpClient().GetFromJsonAsync<List<Book>>($"{ApplicationData.ApiUrl}GetAllBooks");
            ListBooks = await responce;
        }
    }
}
