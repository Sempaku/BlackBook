using System.IO;

namespace BlackBook.Api
{
    public static class ApplicationData
    {
        public static string ApplicationUrl { get; } = "http://localhost:7230/";
        public static string ApiUrl { get; } = ApplicationUrl + "api/";
        public static string BookApiUrl { get; } = ApiUrl + "Book/";
        public static bool IsConnectedToMega { get; set; } = false;

        public static string LocalFileStorage { get; } = Directory.GetCurrentDirectory() + "\\wwwroot\\books";
    }
}