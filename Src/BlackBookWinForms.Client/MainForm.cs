using BlackBookWinForms.Client.Forms;

namespace BlackBookWinForms.Client
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();

            var connectionResult = MegaAuth.GetResult(serviceProvider);
        }
    }
}
