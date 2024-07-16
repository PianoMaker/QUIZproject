using DataBase;
using DbLayer;
using Models;
using System.Net;
using static Models.Serializers;

namespace QUIZproject_server
{
    public partial class ServerMainForm : Form
    {

        private Q_Server server;
        internal Q_Server _Server { get => server; set => server = value; }

        //private Numbers nums;
        private int[] numbers;
        private IPAddress Ip;
        private int port;
        private QuizForm Q;
        private StudentsDbContextFactory factory;


        public ServerMainForm()
        {
            InitializeComponent();
            Ip = IPAddress.Loopback;
            tbIp.Text = Ip.ToString();
            port = 1234;
            tbPort.Text = port.ToString();
            Q = new QuizForm();
            factory = new StudentsDbContextFactory();
            DisplayQuestionsInfo();
        }

        private void DisplayQuestionsInfo()
        {
            if (Q.Mh_questions.Any())
                lbQ.Text = $"Music history questions: {Q.Mh_questions.Count}\n";
            if (Q.S_questions.Any())
                lbQ.Text += $"Solfegio questions: {Q.S_questions.Count}";
        }

        private void tbIp_TextChanged(object sender, EventArgs e)
        {
            Ip = IPAddress.Parse(tbIp.Text);
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            port = int.Parse(tbPort.Text);
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var window = new QuizForm();
                window.ShowDialog();
                window.QuestionsCount += OnQuestionsCount;               

            });
        }


        private async void btnShowResult_Click(object sender, EventArgs e)
        {
            UpdateMarks();
            await Task.Run(() =>
            {

                var window = new ResultsForm();
                window.ShowDialog();
            });

        }

        
        private async void btnAdm_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                var window = new ENFCodeForm(factory, Q.Mh_questions.Count, Q.S_questions.Count);
                window.ShowDialog();
            });

        }
        private void UpdateMarks()
        {
            var enf = new ENFCodeForm(factory, Q.Mh_questions.Count, Q.S_questions.Count);
            enf.UpdateMarks();
        }
        
        private void OnQuestionsCount(object? sender, int e)
        {
            DisplayQuestionsInfo();
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
                server = new Q_Server(Ip, port, Q.Mh_questions, Q.S_questions, factory);
                lbQ.Text = $"({server.Mh_questions.Count} Music History questions and {server.S_questions.Count} solfegio questions";
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


    }
}
