using Mega.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackBook.Api.Pages
{
    public class MegaConnectionModel : PageModel
    {
        private static string _connectionResult;
        public string ConnectionResult => _connectionResult ;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string megaEmail, string megaPassword)
        {
            /*bool connectionResult = await _megaClient.CreateClientAsync(megaEmail, megaPassword);
            if (connectionResult)
            {
                return RedirectToPage("BookLibrary");
            }
            _connectionResult = "Bad auth :(";
            return RedirectToPage();*/
            return StatusCode(200);
        }
    }
}
