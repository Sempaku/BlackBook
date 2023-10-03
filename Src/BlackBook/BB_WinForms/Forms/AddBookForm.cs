using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB_WinForms.Forms
{
    public partial class AddBookForm : Form
    {
        public bool Result { get; private set; } = false;
        private static string _filenamePath = "";

        public AddBookForm()
        {
            InitializeComponent();
        }

        public static bool GetResult(string filename)
        {
            _filenamePath = filename;
            DialogResult dialogResult;
            bool result;
            
            using (var form = new AddBookForm())
            {
                dialogResult = form.ShowDialog();
                result = form.Result;
            }
            return result;
        }

        private bool ValidateString(string @string)
        {
            return !string.IsNullOrEmpty(@string) && !string.IsNullOrWhiteSpace(@string);
        }

        private bool ValidatePages(string @int)
        {
            return int.TryParse(@int, out int result) && result > 0;
        }

        private async void button_add_Click(object sender, EventArgs e)
        {
            if (!ValidatePages(textBox_pages.Text))
            {
                MessageBox.Show("Bad input: Pages."); Close();
            }

            if (!ValidateString(textBox_title.Text) && !ValidateString(textBox_author.Text))
            {
                MessageBox.Show("Bad input: Title OR Author"); Close();
            }

            if (!File.Exists(_filenamePath))
            {
                MessageBox.Show("Bad input: Directory not contains file."); Close();
            }

            var result = await BlackBookHttpClient.AddBook(
                new Models.BookAddRequestModel
                {
                    Title = textBox_title.Text,
                    Author = textBox_author.Text,
                    Pages = int.Parse(textBox_pages.Text),
                }, _filenamePath);

            if (result) Result = true;
            
            Close();
        }

        
    }
}
