using Mega.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlackBook.ClientRazor.Pages
{
    [IgnoreAntiforgeryToken]
    public class MegaConnectModel : PageModel
    {
        private readonly IMegaClient _megaClient;
        public string ConnectionResult { get; set; }
        public MegaConnectModel(IMegaClient megaClient)
        {
            _megaClient = megaClient;
        }
        public void OnGet()
        {

        }

        public async Task OnPostAsync(string megaEmail, string megaPassword)
        {
            bool conResult = await _megaClient.CreateClientAsync(megaEmail, megaPassword);

            if (conResult)
                ConnectionResult = "Success!";
            else
                ConnectionResult = "Bad auth :(";
        }
    }
}
