using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlackBook.Data.Model
{
    public class BookFile
    {
        /// <summary> Уникальный идентификатор файла книги </summary>
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        [Required]
        public int BookId { get; set; }

        /// <summary> Формат книги </summary>
        [Required]
        public string Format { get; set; }

        /// <summary> Путь до файла </summary>
        [Required]
        public string FilePath { get; set; }

        /// <summary> Имя файла </summary>
        [Required]
        public string FileName { get; set; }

        // Навигационное свойство для связи с книгой
        [JsonIgnore]
        public Book Book { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is BookFile file &&
                   Id == file.Id &&
                   BookId == file.BookId &&
                   Format == file.Format &&
                   FilePath == file.FilePath &&
                   FileName == file.FileName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, BookId, Format, FilePath, FileName);
        }
    }
}