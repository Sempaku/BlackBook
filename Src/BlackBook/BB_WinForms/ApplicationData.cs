using System.IO;

namespace BB_WinForms
{
    public static class ApplicationData
    {
        public const string REMOTE_HOST = "https://localhost:7230";
        public const string LOGIN_TO_MEGA_URL = REMOTE_HOST + "/api/Book/LoginToMega";
        public const string GET_ALL_BOOKS_URL = REMOTE_HOST + "/api/Book/GetAllBooks";
        public const string DOWNLOAD_BOOK_BY_DOWNLOAD_URL = REMOTE_HOST + "/api/Book/DownloadBookByDownloadUrl";
        public const string ADD_BOOK = REMOTE_HOST + "/api/Book/AddBook";

        public static string LocalFileStorage { get; } = Directory.GetCurrentDirectory();
    }
}