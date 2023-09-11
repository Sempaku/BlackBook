using BB_WinForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BB_WinForms
{
    public class BlackBookHttpClient
    {
        private static HttpClient _httpClient = new HttpClient();
        
        public static async Task<bool> LoginToMegaAsync(LoginModel loginModel)
        {
            var responce = await SendPostRequestAsync(ApplicationData.LOGIN_TO_MEGA_URL, loginModel);
            return responce.IsSuccessStatusCode ? true : false;
        }

        public static async Task<List<BookModel>> GetAllBooksAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(ApplicationData.GET_ALL_BOOKS_URL);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    List<BookModel> books = JsonConvert.DeserializeObject<List<BookModel>>(responseBody);
                    return books;
                }
                else
                {
                    MessageBox.Show($"Invalid operation: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return null;
            }
        }

        public static async Task<bool> DownloadBook(BookModel book)
        {
            string fileUrl = book.BookFile.FilePath;
            Uri uri = new Uri(fileUrl);

            try
            {
                HttpResponseMessage response = await SendPostRequestAsync(ApplicationData.DOWNLOAD_BOOK_BY_DOWNLOAD_URL, uri);

                if (response.IsSuccessStatusCode)
                {
                    // Читаем поток данных (книгу) из ответа.
                    Stream bookStream = await response.Content.ReadAsStreamAsync();

                    string localFilePath = $@"{ApplicationData.LocalFileStorage}\\{book.BookFile.FileName}";
                    using (FileStream fileStream = File.Create(localFilePath))
                    {
                        bookStream.CopyTo(fileStream);
                    }

                    // Закрываем поток данных (книгу).
                    bookStream.Close();
                    return true;
                }
                else
                {
                    // Обработка ошибки, если запрос не был успешным.
                    MessageBox.Show($"Ошибка: {response.StatusCode}");
                    return false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }

        private static async Task<HttpResponseMessage> SendPostRequestAsync(string endpoint, object data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(endpoint, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    MessageBox.Show($"Invalid operation: {response.StatusCode} - {response.Content.ReadAsStringAsync()}");
                    return response;
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
