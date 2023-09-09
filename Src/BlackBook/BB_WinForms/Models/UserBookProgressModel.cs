namespace BB_WinForms.Models
{
    public class UserBookProgressModel
    {
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        public int BookId { get; set; }

        /// <summary> Последняя прочитанная страница книги </summary>
        public int LastReadPage { get; set; }

        // Навигационное свойство для связи с книгой
        public BookModel Book { get; set; }        
    }
}