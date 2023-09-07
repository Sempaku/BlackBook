using BB_WinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB_WinForms.Forms
{
    public partial class MegaAuth : Form
    {
        private string _emailPattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        public bool ConnectionResult { get; private set; } = false;
        private readonly HttpClient _httpClient;

        
        public MegaAuth()
        {
            _httpClient = new HttpClient();
            InitializeComponent();
        }

        private async void btn_ConnectToMega_Click(object sender, EventArgs e)
        {
            if (!ValidateEmail(tb_Email.Text))
            {
                MessageBox.Show("Email введен неверно");
                return;
            }

            string json = JsonConvert.SerializeObject(new LoginModel { Email = tb_Email.Text, Password = tb_Password.Text });
            //var result = await _httpClient.PostAsync(, new StringContent(json));

            var result = await SendPostRequestAsync("https://localhost:7230/api/Book/LoginToMega",
                new LoginModel { Email = tb_Email.Text, Password = tb_Password.Text });
            ConnectionResult = result.IsSuccessStatusCode ? true : false;

            if (!ConnectionResult)
            {
                MessageBox.Show("Недачное подключение к Mega");
                return;
            }
            Close();
        }


        public static bool GetResult()
        {
            DialogResult dialogResult;
            bool connectionResult;

            using (var form = new MegaAuth())
            {
                dialogResult = form.ShowDialog();
                connectionResult = form.ConnectionResult;
            }
            return connectionResult;
        }

        private bool ValidateEmail(string text) => Regex.IsMatch(text, _emailPattern);

        private async Task<HttpResponseMessage> SendPostRequestAsync(string endpoint, object data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responce = await _httpClient.PostAsync(endpoint, stringContent);

                if (responce.IsSuccessStatusCode)
                {
                    return responce;
                }
                else
                {
                    MessageBox.Show($"Invalid operation: {responce.StatusCode} - {responce.Content.ReadAsStringAsync()}");
                    return responce;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
