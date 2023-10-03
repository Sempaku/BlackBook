using Microsoft.AspNetCore.Http;

namespace BB_WinForms.Models
{
    public class BookAddRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Pages { get; set; }
        public IFormFile File { get; set; }
    }
}