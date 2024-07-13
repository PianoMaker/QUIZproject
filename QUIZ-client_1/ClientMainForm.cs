using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using DataBase;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static Models.Serializers;

namespace QUIZ_client_1
{
    public partial class ClientMainForm : Form
    {
        public Subject subj { get; set; }
        private int port;
        private IPAddress ip;
        private Q_Client client;
        private Student student;
        private bool Ifconnected;
        private int? selectedanswer;
        private Quiz? current_mh_question;
        private SQuiz? current_s_question;
        private List<Quiz>? mh_quiz;
        private List<SQuiz>? s_quiz;
        private int mh_index;
        private int s_index;


        public ClientMainForm()
        {
            InitializeComponent();
            ip = IPAddress.Loopback;
            tbIp.Text = ip.ToString();
            port = 1234;
            tbPort.Text = port.ToString();
            Ifconnected = false;
            btnQuiz.Enabled = false;
            btnProfile.Enabled = false;
            rb_hm.Checked = true;
            num.Value = 1;
            num.Enabled = false;
            btnPlay.Enabled = false;
            s_index = 0;
            mh_index = 0;   
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
            await Connect();
            client.Connected += Client_Connected;
            if (Ifconnected == true)
            {
                //btnQuiz.Enabled = true;
                btnProfile.Enabled = true;
                if (student != null)
                    lbStatus.Text = $"connected as {student.Name} {student.SurName}";
                else
                    lbStatus.Text = $"connected anonymously";
            }

        }


        private void rb_hm_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }
        private void rb_s_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void ChooseSubject()
        {
            if (rb_hm.Checked)
            {
                subj = Subject.Musichistory;
            }
            else subj = Subject.Solfegio;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            var window = new LogInForm();
            if (window.ShowDialog() == DialogResult.OK)
            {
                if (CreateProfile())
                {
                    var ifnew = window.ifnew;
                    var slogin = new StudentLogin(student, ifnew);
                    Login(slogin);
                    btnQuiz.Enabled = true;
                }
                else /*MessageBox.Show("cancel pressed");*/
                    return;
            }

        }

        private void btnQuiz_Click(object sender, EventArgs e)
        {
            
            byte[] msg = Encoding.UTF8.GetBytes(subj.ToString());
            client.SendMessage(msg, subj.ToString());
        }

        private void lbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbAnswers.SelectedIndex;
            selectedanswer = index;
            try { num.Value = (int)selectedanswer + 1; }
            catch { MessageBox.Show("Error with Numbering questions"); }
            lblAnswer.Text = (string)lbAnswers.Items[index];
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayChord();
        }


        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (num.Value > 0 && num.Value < lbAnswers.Items.Count)
            {
                selectedanswer = (int)num.Value + 1;
                try { lblAnswer.Text = (string)lbAnswers.Items[(int)num.Value - 1]; }
                catch { MessageBox.Show("index is out of range"); }
            }
        }


        private void OnMessageChanged(object? sender, EventArgs e)
        {
            if (client.Message is not null)
            {
                lbMessages.Items.Add(client.Message);
                if (client.Message.Contains("session started"))
                {
                    lbStatus.Text = "connected";
                    Ifconnected = true;
                }
                else if (client.Message.Contains("imposible to connect server"))
                {
                    lbStatus.Text = "not connected";
                    Ifconnected = false;
                }
            }
        }


        private void Client_Connected(object? sender, EventArgs e)
        {
            if (client.Ifconnected == true)
            {
                Ifconnected = true;
                btnProfile.Enabled = true;
                btnQuiz.Enabled = true;
                btnConnect.Enabled = false;
            }

            else if (client.Ifconnected == false)
            {
                Ifconnected = false;
                btnProfile.Enabled = false;
                btnQuiz.Enabled = false;
                btnConnect.Enabled = true;
            }
        }

        private async Task Connect()
        {
            client = new Q_Client(ip, port);
            client.MessageChanged += OnMessageChanged;
            client.Mh_questions_Received += On_Mh_questions_Received;
            client.S_questions_Received += On_S_questions_Received;
            await client.StartClientAsync();

        }

        private void On_Mh_questions_Received(object? sender, List<Quiz> e)
        {
            btnPlay.Enabled = false;
            mh_quiz = e;
            if (mh_quiz.Count > 0)
            {
                current_mh_question = mh_quiz[mh_index];
                SetQuizInterface(current_mh_question);
            }
            else
            {
                lblQuestion.Text = "No questions received";
                return;
            }


        }

        private void On_S_questions_Received(object? sender, List<SQuiz> e)
        {
            
            s_quiz = e;
            if (s_quiz.Count > 0)
            {
             
                current_s_question = s_quiz[s_index];
                lblQuestion.Text = current_s_question.Question;
                SetQuizInterface(current_s_question);
                Console.Beep(440, 200);
                btnPlay.Enabled = true;
            }
            else
            {
                lblQuestion.Text = "No questions received";
                return;
            }
        }

        private void SetQuizInterface<T>(T quiz) where T : Quiz
        {
            num.Enabled = true;
            num.Minimum = 1;
            num.Maximum = quiz.Answers.Count;
            foreach (var answer in quiz.Answers)
                lbAnswers.Items.Add(answer);
        }

        private bool CreateProfile()
        {
            var window = new StudentForm(false);
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                student = new Student()
                {
                    Name = window.FirstName,
                    SurName = window.SurName,
                    Email = window.Email,
                    Password = window.Password
                };
                return true;
            }
            else return false;
        }


        private void Login(StudentLogin st)
        {
            var msg = SerializeObject(st);
            client.SendMessage(msg);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendAnswer();
            RefreshQuiz();
        }



        private void SendAnswer()
        {
            if (student is null || selectedanswer is null || current_mh_question is null)
            {
                MessageBox.Show("Not ready to send answer"); return;
            }

            StudentAnswer answer;
            current_mh_question.Studentanswer = selectedanswer;

            if (subj == Subject.Musichistory && current_mh_question is not null)
                answer = new(student, current_mh_question);
            else if (subj == Subject.Solfegio && current_s_question is not null)
                answer = new(student, current_s_question);
            else { MessageBox.Show("Not ready to send answer"); return; }
            var data = SerializeObject(answer);
            client.SendMessage(data);
        }

        private void RefreshQuiz()
        {
            if (subj == Subject.Solfegio && s_quiz is not null)
            {

                if (s_quiz.Count > s_index)
                {
                    s_index++;
                    current_s_question = s_quiz[s_index];
                }
            }
            if (subj == Subject.Musichistory && mh_quiz is not null)
            {
                if (mh_quiz.Count > mh_index)
                {
                    mh_index++;
                    current_mh_question = mh_quiz[mh_index];
                }
            }


        }

        private void lblAnswer_Click(object sender, EventArgs e)
        {

        }

       
        private void PlayChord()
        {
            if (current_s_question is not null)
            {
                try { current_s_question.Play(); }
                catch { MessageBox.Show("Inmpossible to play chord"); }
            }
        }
    }

}