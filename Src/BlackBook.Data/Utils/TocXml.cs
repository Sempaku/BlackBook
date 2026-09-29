using System.Xml.Linq;

namespace BlackBook.Data.Utils
{
    /// <summary>
    /// Оглавление книги хранится в БД в XML-поле.
    /// HTML из WYSIWYG-редактора не является well-formed XML (незакрытые теги,
    /// атрибуты без кавычек и т.п.), поэтому он заворачивается в CDATA-секцию
    /// внутри валидного XML-документа:
    ///   <toc><html><![CDATA[ ...HTML из редактора... ]]></html></toc>
    /// Так XML остаётся валидным (пройдёт XSD-валидацию, парсится штатно),
    /// а содержимое оглавления доступно и для отображения, и для поиска.
    /// </summary>
    public static class TocXml
    {
        /// <summary> HTML редактора -> XML для сохранения в БД </summary>
        public static string WrapHtml(string html)
        {
            if (string.IsNullOrWhiteSpace(html))
            {
                return null;
            }

            // "]]>" внутри HTML не должен преждевременно закрыть CDATA-секцию
            var safe = html.Replace("]]>", "]]]]><![CDATA[>");
            return $"<toc><html><![CDATA[{safe}]]></html></toc>";
        }

        /// <summary> XML из БД -> HTML для отображения/редактора </summary>
        public static string UnwrapToHtml(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
            {
                return string.Empty;
            }

            try
            {
                var doc = XDocument.Parse(xml);
                return doc.Root?.Element("html")?.Value ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
