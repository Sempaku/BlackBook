using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlackBook.Data.Model
{
    public class Rating
    {
        /// <summary> Уникальный идентификатор рейтинга </summary>
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary> Рейтинг книги </summary>
        [Required]
        public int BookRating { get; set; }

        // Навигационное свойство для связи с книгой
        [JsonIgnore]
        public Book Book { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Rating rating &&
                   Id == rating.Id &&
                   BookId == rating.BookId &&
                   BookRating == rating.BookRating &&
                   EqualityComparer<Book>.Default.Equals(Book, rating.Book);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, BookId, BookRating, Book);
        }
    }
}