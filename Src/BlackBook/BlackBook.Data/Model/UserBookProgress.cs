using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlackBook.Data.Model
{
    public class UserBookProgress
    {
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary> Последняя прочитанная страница книги </summary>
        [Required]
        public int LastReadPage { get; set; }

        // Навигационное свойство для связи с книгой
        [JsonIgnore]
        public Book Book { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is UserBookProgress progress &&
                   Id == progress.Id &&
                   BookId == progress.BookId &&
                   LastReadPage == progress.LastReadPage;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, BookId, LastReadPage);
        }
    }
}