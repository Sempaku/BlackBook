using BlackBook.Api.Model;
using BlackBook.Data.Model;
using BookStorageService;
using MegaService;
using Microsoft.AspNetCore.Mvc;
using RatingService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UserBookProgressService;

namespace BlackBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookStorageService _bookStorageService;
        private readonly IRatingService _ratingService;
        private readonly IUserBookProgressService _userBookProgressService;
        private readonly IMegaService _megaService;

        public BookController(IBookStorageService bookStorageService, IMegaService megaService, IRatingService ratingService, IUserBookProgressService userBookProgressService)
        {
            _bookStorageService = bookStorageService;
            _megaService = megaService;
            _ratingService = ratingService;
            _userBookProgressService = userBookProgressService;
        }

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(typeof(List<Book>), 200)]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookStorageService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost("DownloadBookByDownloadUrl")]
        [ProducesResponseType(typeof(Stream), 200)]
        public async Task<IActionResult> GetBookByDownloadUrl([FromBody] Uri url)
        {
            Stream book = await _megaService.GetBookByDownloadUrl(url.AbsoluteUri);
            return Ok(book);
        }

        [HttpPost("LoginToMega")]
        public async Task<IActionResult> LoginToMega(LoginModel loginModel)
        {
            if (string.IsNullOrWhiteSpace(loginModel.Email) || string.IsNullOrWhiteSpace(loginModel.Password))
            {
                return BadRequest("Please, enter email/password.");
            }

            var connectionState = await _megaService.LoginToMegaAsync(loginModel.Email, loginModel.Password);
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
                    Genre = model.Genre,
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

        [HttpPost("SetBookRating")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> SetBookRating(JsonElement ratingRequest)
        {
            if (ratingRequest.TryGetProperty("bookId", out var bookIdElement) && ratingRequest.TryGetProperty("rating", out var ratingElement))
            {
                if (int.TryParse(bookIdElement.ToString(), out int bookId)
                    && int.TryParse(ratingElement.ToString(), out int rating))
                {
                    return Ok(await _ratingService.ModifyRatingByBookIdAsync(bookId, rating));
                }
            }

            return BadRequest(false);
        }

        [HttpPost("SetLastReadPage")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> SetLastReadPage(JsonElement lastReadPageRequest)
        {
            if (lastReadPageRequest.TryGetProperty("bookId", out var bookIdElement) && lastReadPageRequest.TryGetProperty("lastReadPage", out var lastReadPageElement))
            {
                if (int.TryParse(bookIdElement.ToString(), out int bookId)
                    && int.TryParse(lastReadPageElement.ToString(), out int lastReadPage))
                {
                    return Ok(await _userBookProgressService.ModifyLastReadPageByBookIdAsync(bookId, lastReadPage));
                }
            }

            return BadRequest(false);
        }

        [HttpPost("RemoveBook")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<IActionResult> RemoveBook([FromBody] Uri fileUri)
        {
            //await _bookStorageService.RemoveBookAsync(fileUri);
            await _megaService.RemoveBook(fileUri);
            return Ok();
        }
    }
}