namespace BB_WinForms.Models
{
    public class BookModel
    {
        /// <summary> Уникальный идентификатор книги </summary>
        public int Id { get; set; }

        /// <summary> Название книги </summary>
        public string Title { get; set; }

        /// <summary> Автор книги </summary>
        public string Author { get; set; }

        /// <summary> Жанр книги </summary>
        public string Genre { get; set; }

        /// <summary> Количество страниц в книге </summary>
        public int Pages { get; set; }

        // Навигационное свойство для связи с файлом книги
        public BookFileModel BookFile { get; set; }

        // Навигационное свойство для связи с файлом книги
        public RatingModel Rating { get; set; }

        // Навигационное свойство для связи с прогрессом чтения
        public UserBookProgressModel UserBookProgress { get; set; }
    }
}