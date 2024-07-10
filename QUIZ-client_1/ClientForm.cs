using System.Net;
using System.Security.Cryptography.X509Certificates;
using DataBase;
using Models;

namespace QUIZ_client_1
{
    public partial class ClientForm : Form
    {
        Subject subj;
        private int port;
        private IPAddress ip;
        Q_Client client;
        Student student;
        public ClientForm()
        {
            InitializeComponent();
            ip = IPAddress.Loopback;
            tbIp.Text = ip.ToString();
            port = 1234;
            tbPort.Text = port.ToString();
        }

        private void tbPort_TextChanged(object sender, EventArgs e)
        {
            port = int.Parse(tbPort.Text);
        }

        private void tbIp_TextChanged(object sender, EventArgs e)
        {
            ip = IPAddress.Parse(tbIp.Text);
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            if(student == null) {
                MessageBox.Show("You need to create Profile first");
                CreateProfile();
            }
            if(student != null) 
                await Connect();
        }

        private async Task Connect()
        {
            client = new Q_Client(ip, port);
            client.MessageChanged += OnMessageChanged;
            //client.NumbersChanged += OnNumbersChanged;
            lbStatus.Text = $"connecting as {student.Name} {student.SurName}";
            await client.StartClientAsync();
        }

        private void OnMessageChanged(object? sender, EventArgs e)
        {
            if (client.Message is not null)
            {
                lbMessages.Items.Add(client.Message);
                if (client.Message.Contains("session started"))
                    lbStatus.Text = "connected";
                else if (client.Message.Contains("imposible to connect server"))
                    lbStatus.Text = "not connected";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void ChooseSubject()
        {
            if (!radioButton1.Checked)
            {
                subj = Subject.Musichistory;
            }
            else subj = Subject.Solfegio;
        }

        private void Authorize_Click(object sender, EventArgs e)
        {
            CreateProfile();
        }

        private void CreateProfile()
        {
            var window = new StudentForm(false);
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
                student = new Student()
                {
                    Name = window.Name,
                    SurName = window.SurName
                };
        }
    }
}
