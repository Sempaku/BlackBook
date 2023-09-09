
namespace BB_WinForms.Models
{
    public class BookFileModel
    {
        /// <summary> Уникальный идентификатор файла книги </summary>
        public int Id { get; set; }

        /// <summary> Уникальный идентификатор книги </summary>
        public int BookId { get; set; }

        /// <summary> Формат книги </summary>
        public string Format { get; set; }

        /// <summary> Путь до файла </summary>
        public string FilePath { get; set; }

        /// <summary> Имя файла </summary>
        public string FileName { get; set; }

        // Навигационное свойство для связи с книгой
        public BookModel Book { get; set; }        
    }
}