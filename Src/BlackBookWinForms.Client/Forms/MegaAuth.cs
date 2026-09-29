
using Mega.Client;
using MegaService;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace BlackBookWinForms.Client.Forms
{
    public partial class MegaAuth : Form
    {
        private string _emailPattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        public bool ConnectionResult { get; private set; } = false;
        private IServiceProvider _serviceProvider;

        private readonly IMegaService _megaService;
        public MegaAuth(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _megaService = serviceProvider.GetRequiredService<IMegaService>();
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateEmail(tb_Email.Text))
            {
                MessageBox.Show("Email введен неверно");
                return;
            }
            ConnectionResult = await _megaService.LoginToMegaAsync(tb_Email.Text, tb_Password.Text);
            if (!ConnectionResult)
            {
                MessageBox.Show("Недачное подключение к Mega");
                return;
            }
            Close();
        }


        public static bool GetResult(IServiceProvider serviceProvider)
        {
            DialogResult dialogResult;
            bool connectionResult;

            using(var form = new MegaAuth(serviceProvider))
            {
                dialogResult = form.ShowDialog();       
                connectionResult = form.ConnectionResult;
            }
            return connectionResult;
        }

        private bool ValidateEmail(string text) => Regex.IsMatch(text, _emailPattern);
    }
}
