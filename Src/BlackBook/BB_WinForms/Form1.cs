using BB_WinForms.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var res = MegaAuth.GetResult();
            MessageBox.Show(res.ToString());
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var books = await BlackBookHttpClient.GetAllBooksAsync();
            // Чтобы обновить элементы управления из основного потока
            listBox_BooksOnMain.Invoke((MethodInvoker)delegate {
                listBox_BooksOnMain.Items.AddRange(books.Select(b => b.Title).ToArray());
            });
        }
    }
}
