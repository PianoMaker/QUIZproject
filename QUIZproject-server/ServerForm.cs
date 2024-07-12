using DataBase;
using DbLayer;
using System.Net;
using static Models.Serializers;

namespace QUIZproject_server
{
    public partial class ServerForm : Form
    {

        private Q_Server server;
        internal Q_Server _Server { get => server; set => server = value; }

        //private Numbers nums;
        private int[] numbers;
        private IPAddress Ip;
        private int port;

        public ServerForm()
        {
            InitializeComponent();
            Ip = IPAddress.Loopback;
            tbIp.Text = Ip.ToString();
            port = 1234;
            tbPort.Text = port.ToString();

        }


        private void tbIp_TextChanged(object sender, EventArgs e)
        {
            Ip = IPAddress.Parse(tbIp.Text);
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            port = int.Parse(tbPort.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var window = new QuizForm();
            window.ShowDialog();
        }

        private void btnRes_Click(object sender, EventArgs e)
        {
            var window = new ResultsForm();
            window.ShowDialog();
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                StartServer();
                lbStatus.ForeColor = Color.DarkGreen;
                lbStatus.Text = "Connected";
            }
            catch
            {
                lbStatus.ForeColor = Color.Red;
                lbStatus.Text = "Not connected";
            }


        }

        private void StartServer()
        {
            try
            {
                server = new Q_Server(Ip, port);
                server.MessageChanged += OnServerMessage;
                if (server != null)
                {
                    server.StartServer();
                    lbStatus.Text = "server launched";
                    lbStatus.ForeColor = Color.DarkGreen;

                }
            }
            catch (Exception ex)
            {
                lbStatus.Text = $"Impossible to launch socket!\n{ex}";
            }
        }

        private void OnServerMessage(object? sender, EventArgs e)
        {
            Invoke(() => lbClients.Items.Add(server.Message));            
        }

        private void btnAdm_Click(object sender, EventArgs e)
        {
            var factory = new StudentsDbContextFactory();
            var window = new ENFCodeForm(factory);
            window.ShowDialog();
        }
    }
}
