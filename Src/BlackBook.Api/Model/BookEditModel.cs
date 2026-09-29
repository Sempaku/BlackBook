using System.ComponentModel.DataAnnotations;

namespace BlackBook.Api.Model
{
    /// <summary> Модель редактирования книги (карточка книги) </summary>
    public class BookEditModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }

        /// <summary> Оглавление: HTML из WYSIWYG-редактора (сохраняется в БД как XML) </summary>
        public string Toc { get; set; }
    }
}
