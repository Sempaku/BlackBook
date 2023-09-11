
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace BB_WinForms
{
    public static class ApplicationData
    {
        public const string REMOTE_HOST = "https://localhost:7230";
        public const string LOGIN_TO_MEGA_URL = REMOTE_HOST + "/api/Book/LoginToMega";
        public const string GET_ALL_BOOKS_URL = REMOTE_HOST + "/api/Book/GetAllBooks";
        public const string DOWNLOAD_BOOK_BY_DOWNLOAD_URL = REMOTE_HOST + "/api/Book/DownloadBookByDownloadUrl";

        public static string LocalFileStorage { get; } = Directory.GetCurrentDirectory();
    }
}
