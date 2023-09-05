using BlackBook.Api.Model;
using BlackBook.Data.Model;
using BookStorageService;
using CG.Web.MegaApiClient;
using Mega.Client;
using MegaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlackBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookStorageService _bookStorageService;
        private readonly IMegaService _megaService;

        public BookController(IBookStorageService bookStorageService, IMegaService megaService)
        {
            _bookStorageService = bookStorageService;
            _megaService = megaService;
        }

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(typeof(List<Book>), 200)]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookStorageService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost("LoginToMega")]        
        public async Task<IActionResult> LoginToMega(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Please, enter email/password.");
            }

            var connectionState = await _megaService.LoginToMegaAsync(email, password);
            if (connectionState)
            {
                ApplicationData.IsConnectedToMega = connectionState;
                return Ok("Success!");
            }
            return BadRequest("Invalid data.");
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromForm] BookAddRequestModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid input data.");
            }

            if (model.File == null || model.File.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            if (!ApplicationData.IsConnectedToMega)
            {
                return BadRequest("Please, connect to MEGA.");
            }

            using (var stream = model.File.OpenReadStream())
            {
                var book = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Pages = model.Pages
                };

                var uri = await _megaService.UploadStreamToMegaAsync(stream, Guid.NewGuid() + model.File.FileName); 

                if (uri == null)
                {
                    return BadRequest("Wrong file...");
                }

                await _bookStorageService.AddBookAsync(book, model.File, uri);

                return Ok("Book added successfully.");
            }
        }

       
        
    }
}
