﻿using System.IO;

namespace BB_WinForms
{
    public static class ApplicationData
    {
#if DEBUG
        public const string REMOTE_HOST = "https://localhost:7230";

#endif
#if (!DEBUG)
        public const string REMOTE_HOST = "https://bb-sempaku.amvera.io";
#endif

        public const string LOGIN_TO_MEGA_URL = REMOTE_HOST + "/api/Book/LoginToMega";
        public const string GET_ALL_BOOKS_URL = REMOTE_HOST + "/api/Book/GetAllBooks";
        public const string DOWNLOAD_BOOK_BY_DOWNLOAD_URL = REMOTE_HOST + "/api/Book/DownloadBookByDownloadUrl";
        public const string REMOVE_BOOK = REMOTE_HOST + "/api/Book/RemoveBook";
        public const string ADD_BOOK = REMOTE_HOST + "/api/Book/AddBook";
        public const string SET_BOOK_RATING = REMOTE_HOST + "/api/Book/SetBookRating";
        public const string SET_LAST_READ_PAGE = REMOTE_HOST + "/api/Book/SetLastReadPage";

        public static string LocalFileStorage { get; } = Directory.GetCurrentDirectory();
    }
}