using BlackBook.Data.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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