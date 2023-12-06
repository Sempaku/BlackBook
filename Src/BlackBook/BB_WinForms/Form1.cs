using BB_WinForms.DbUtils;
using BB_WinForms.Forms;
using BB_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB_WinForms
{
    public partial class Form1 : Form
    {
        private List<BookModel> _books;

        public Form1()
        {
            InitializeComponent();
            var res = MegaAuth.GetResult();
            MessageBox.Show(res.ToString());
            UpdateDataGridView();
            UpdateFilterComboBox();
            
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            _books = await BlackBookHttpClient.GetAllBooksAsync();
            // Чтобы обновить элементы управления из основного потока
            listBox_BooksOnMain.Invoke((MethodInvoker)delegate
            {
                listBox_BooksOnMain.Items.AddRange(_books.Select(b => b.Title).ToArray());
            });
        }

        private async void listBox_BooksOnMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Получите выбранное имя книги из listBox
            string selectedBookName = listBox_BooksOnMain.SelectedItem as string;
            var book = _books.Where(b => b.Title == selectedBookName).FirstOrDefault();

            if (BookContainInLocalDirectory(book.BookFile.FileName))
            {
                OpenBookInPdfReader($"{ApplicationData.LocalFileStorage}/{book.BookFile.FileName}");
            }
            else
            {
                if (book != null)
                {
                    if (await BlackBookHttpClient.DownloadBook(book))
                    {
                        OpenBookInPdfReader($@"{ApplicationData.LocalFileStorage}\\{book.BookFile.FileName}");
                    }
                }
            }
        }

        private bool BookContainInLocalDirectory(string bookName)
        {
            if (bookName != null)
            {
                string localBookPath = Path.Combine(ApplicationData.LocalFileStorage, bookName);
                if (File.Exists(localBookPath))
                {
                    return true;
                }
            }
            return false;
        }

        private void OpenBookInPdfReader(string pathToBook)
        {
            pdf_Reader.src = pathToBook;
        }

        private async void syncToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox_BooksOnMain.Items.Clear();
            _books = await BlackBookHttpClient.GetAllBooksAsync();
            // Чтобы обновить элементы управления из основного потока
            listBox_BooksOnMain.Invoke((MethodInvoker)delegate
            {
                listBox_BooksOnMain.Items.AddRange(_books.Select(b => b.Title).ToArray());
            });

            await UpdateDataGridView();
        }

        private async Task UpdateDataGridView()
        {
            /*
            var sql = "SELECT * FROM public.\"Books\"";
            var connectionString = "Host=127.0.0.1;Port=5432;Database=bb_test_db;Username=postgres;Password=2003;";
            dataGridView1.DataSource = NpgsqlHelper.ExecuteNpgsqlTextCommand(sql, connectionString);
            */

            var books = await BlackBookHttpClient.GetAllBooksAsync();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("Genre", typeof(string)); 
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Pages", typeof(string));

            // Добавьте данные из списка books в DataTable
            foreach (var book in books)
            {
                DataRow row = dt.NewRow();
                row["Id"] = book.Id;
                row["Title"] = book.Title;
                row["Author"] = book.Author;                
                row["Genre"] = book.Genre;
                row["Rating"] = book.Rating.BookRating.ToString();
                row["Pages"] = book.Pages;
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;
        }

        private void UpdateFilterComboBox()
        {
            foreach (DataGridViewTextBoxColumn column in dataGridView1.Columns)
            {
                if (column.HeaderText == "Id")
                    continue;

                var text = column.HeaderText;
                comboBox_Filter1.Items.Add(text);
                comboBox_Filter2.Items.Add(text);
            }
        }

        private void comboBox_Filter1_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedFilter = (sender as ComboBox).SelectedItem.ToString();

            int columnIndex = GetColumnIndex(selectedFilter);
            List<string> values = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                values.Add(row.Cells[columnIndex].Value.ToString());
            }
            comboBox_Filter1Value.Items.Clear();
            comboBox_Filter1Value.Items.AddRange(values.Distinct().ToArray());
        }

        private void comboBox_Filter2_SelectedValueChanged(object sender, EventArgs e)
        {
            var selectedFilter = (sender as ComboBox).SelectedItem.ToString();

            int columnIndex = GetColumnIndex(selectedFilter);
            List<string> values = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                values.Add(row.Cells[columnIndex].Value.ToString());
            }
            comboBox_Filter2Value.Items.Clear();
            comboBox_Filter2Value.Items.AddRange(values.Distinct().ToArray());
        }

        private int GetColumnIndex(string columnHeaderText)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                var column = dataGridView1.Columns[i];
                if (column.HeaderText == columnHeaderText)
                    return i;

            }
            return -1;
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = ".PDF | *.pdf";

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFileDialog1.FileName))
            {
                try
                {
                    var addResult = AddBookForm.GetResult(openFileDialog1.FileName);
                    if (addResult)
                        MessageBox.Show("Succes!");
                    else
                        MessageBox.Show("Fail!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                var changedValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                var bookId = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                await BlackBookHttpClient.SetRatingByBook(bookId, changedValue);
            }
        }

        private void button_Filter_Click(object sender, EventArgs e)
        {
            BookColumn filter1Property = BookColumnsHelper.GetColumn(comboBox_Filter1.Text);
            BookColumn filter2Property = BookColumnsHelper.GetColumn(comboBox_Filter2.Text);
            var filter1Value = comboBox_Filter1Value.Text;
            var filter2Value = comboBox_Filter2Value.Text;

            var result = FilterBook(_books, filter1Property, filter1Value);
            result = FilterBook(result, filter2Property, filter2Value);

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Author", typeof(string));
            dt.Columns.Add("Genre", typeof(string));
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Pages", typeof(string));

            foreach (var book in result)
            {
                DataRow row = dt.NewRow();
                row["Id"] = book.Id;
                row["Title"] = book.Title;
                row["Author"] = book.Author;
                row["Genre"] = book.Genre;
                row["Rating"] = book.Rating.BookRating.ToString();
                row["Pages"] = book.Pages;
                dt.Rows.Add(row);
            }

            dataGridView1.DataSource = dt;
            
        }

        private List<BookModel> FilterBook(List<BookModel> books, BookColumn filterField, string filterValue)
        {
            var query = books.AsQueryable();

            switch (filterField)
            {
                case BookColumn.Title:
                    query = query.Where(book => book.Title == filterValue);
                    break;

                case BookColumn.Author:
                    query = query.Where(book => book.Author == filterValue);
                    break;

                case BookColumn.Genre:
                    query = query.Where(book => book.Genre == filterValue);
                    break;

                case BookColumn.Rating:
                    query = query.Where(book => book.Rating.BookRating.ToString() == filterValue);
                    break;

                case BookColumn.Pages:
                    query = query.Where(book => book.Pages.ToString() == filterValue);
                    break;
            }

            return query.ToList();
        }
    }

    public enum BookColumn
    {        
        Id,
        Title,
        Author,
        Genre,
        Rating,
        Pages
    }

    public static class BookColumnsHelper
    {
        /// <summary>
        /// [{RUS,ENG}, BookColumn]
        /// </summary>
        private static Dictionary<string[], BookColumn> columns = new Dictionary<string[], BookColumn>
        {
            {new string[] {"Уникальный идентификатор:","Id",}, BookColumn.Id},
            {new string[] { "Название книги:" ,"Title" }, BookColumn.Title},
            {new string[] { "Автор:" ,"Author" }, BookColumn.Author},
            {new string[] { "Жанр:", "Genre" }, BookColumn.Genre},
            {new string[] { "Рейтинг:" ,"Rating" }, BookColumn.Rating},
            {new string[] { "Страницы:" ,"Pages" }, BookColumn.Pages},
        };

        public static BookColumn GetColumn(string columnName)
        {
            foreach (var pair in columns)
            {
                if (pair.Key.Contains(columnName))
                {
                    return pair.Value;
                }
            }

            throw new ArgumentException($"Неизвестное имя столбца: {columnName}");
        }
    }
}