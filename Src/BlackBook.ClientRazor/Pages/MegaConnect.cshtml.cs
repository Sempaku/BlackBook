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

        public async Task<IActionResult> OnPostAsync(string megaEmail, string megaPassword)
        {
            if (string.IsNullOrEmpty(megaEmail) || string.IsNullOrEmpty(megaPassword))
            {
                ConnectionResult = "Ошибка: введите email и пароль";
                return Page();
            }

            bool conResult = await _megaClient.CreateClientAsync(megaEmail, megaPassword);

            ConnectionResult = conResult ? "Успешное подключение к MEGA!" : "Ошибка подключения к MEGA. Проверьте email и пароль.";
            return Page();
        }
    }
}
