using MegaService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace BlackBook.Api.Pages
{
    public class MegaLoginModel : PageModel
    {
        [BindProperty]
        public Model.LoginModel LoginData { get; set; }

        public string ErrorMessage { get; set; }

        private readonly IMegaService _megaService;

        public MegaLoginModel(IMegaService megaService)
        {
            _megaService = megaService;
        }

        public async Task OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var success = await _megaService.LoginToMegaAsync(LoginData.Email, LoginData.Password);
                if (success)
                {
                    ApplicationData.IsConnectedToMega = true;
                    Response.Redirect("/Index"); // Переход на главную страницу
                }
                else
                {
                    ErrorMessage = "Invalid login or password";
                }
            }
        }
    }
}