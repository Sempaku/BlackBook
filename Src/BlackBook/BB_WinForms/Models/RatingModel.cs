namespace BB_WinForms.Models
{
    public class RatingModel
    {
        /// <summary> Уникальный идентификатор рейтинга </summary>
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        public int BookId { get; set; }

        /// <summary> Рейтинг книги </summary>
        public int BookRating { get; set; }

        // Навигационное свойство для связи с книгой
        public BookModel Book { get; set; }
    }
}