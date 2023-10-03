using BB_WinForms.DbUtils;
using BB_WinForms.Forms;
using BB_WinForms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _books = await BlackBookHttpClient.GetAllBooksAsync();
            // Чтобы обновить элементы управления из основного потока
            listBox_BooksOnMain.Invoke((MethodInvoker)delegate {
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
            listBox_BooksOnMain.Invoke((MethodInvoker)delegate {
                listBox_BooksOnMain.Items.AddRange(_books.Select(b => b.Title).ToArray());
            });

            UpdateDataGridView();
        }

        private void UpdateDataGridView()
        {
            var sql = "SELECT * FROM public.\"Books\"";
            var connectionString = "Host=127.0.0.1;Port=5432;Database=bb_test_db;Username=postgres;Password=2003;";
            dataGridView1.DataSource = NpgsqlHelper.ExecuteNpgsqlTextCommand(sql, connectionString);
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
    }
}
