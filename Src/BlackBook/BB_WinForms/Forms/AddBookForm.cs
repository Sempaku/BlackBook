﻿using Patagames.Pdf.Net;
using System;
using System.IO;
using System.Windows.Forms;

namespace BB_WinForms.Forms
{
    public partial class AddBookForm : Form
    {
        public bool Result { get; private set; } = false;
        private static string _filenamePath = "";
        private static int _countPages = 0;
        private static TextBox reference;

        public AddBookForm()
        {
            InitializeComponent();
            reference = textBox_pages;
        }

        public static bool GetResult(string filename)
        {
            _filenamePath = filename;

            DialogResult dialogResult;
            bool result;

            using (var form = new AddBookForm())
            {
                DeterminateCountPagesFromPDF(_filenamePath);
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

            if (!ValidateString(textBox_genre.Text))
            {
                MessageBox.Show("Bad input: Genre"); Close();
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
                    Genre = textBox_genre.Text,
                    Pages = _countPages,
                }, _filenamePath);

            if (result) Result = true;

            Close();
        }

        private static void DeterminateCountPagesFromPDF(string pathToPdf)
        {
            PdfDocument pdfDocument = PdfDocument.Load(pathToPdf);
            _countPages = pdfDocument.Pages.Count;
            reference.Text = _countPages.ToString();
        }
    }
}