namespace BlackBook.Api.Model
{
    public class BookAddRequestModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public IFormFile File { get; set; }
    }
}