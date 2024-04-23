using System;
using System.ComponentModel.DataAnnotations;

namespace BlackBook.Data.Model
{
    public class Book
    {
        /// <summary> Уникальный идентификатор книги </summary>
        public int Id { get; set; }

        /// <summary> Название книги </summary>
        [Required]
        public string Title { get; set; }

        /// <summary> Автор книги </summary>
        [Required]
        public string Author { get; set; }

        /// <summary> Жанр книги </summary>
        [Required]
        public string Genre { get; set; }

        /// <summary> Количество страниц в книге </summary>
        [Required]
        public int Pages { get; set; }

        // Навигационное свойство для связи с файлом книги
        public BookFile BookFile { get; set; }

        // Навигационное свойство для связи с прогрессом чтения
        public UserBookProgress UserBookProgress { get; set; }

        // Навигационное свойство для связи с рейтингом книги
        public Rating Rating { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   Id == book.Id &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Pages == book.Pages &&
                   Rating == book.Rating;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Author, Pages, Rating);
        }
    }
}