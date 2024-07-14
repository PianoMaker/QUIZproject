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
        private bool IfloggedIn;
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
            client.LoggedIn += Client_LoggedIn;
            if (Ifconnected == true)
            {
                //btnQuiz.Enabled = true;//прибрати потім
                btnProfile.Enabled = true;
                if (student != null)
                    lbStatus.Text = $"trying to connect as {student.Name} {student.SurName}";
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
                if (current_mh_question is not null)
                    SetQuizInterface(current_mh_question);
                else EmptyQuizInterface();
            }
            else
            {
                subj = Subject.Solfegio;
                if (current_s_question is not null)
                    SetQuizInterface(current_s_question);
                else EmptyQuizInterface();
            }
        }



        private void btnProfile_Click(object sender, EventArgs e)
        {
            var window = new LogInForm();
            if (window.ShowDialog() == DialogResult.OK)
            {
                var login = window.Login;                
                if (login is null) return;
                lbStatus.Text = $"trying to connect as {login.Name} {login.SurName}";
                //MessageBox.Show($"{login.Password} : {login.Email} : {login.Ifnew}");
                Login(login);
                
            }
            else return;
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
            if (num.Value > 0 && num.Value <= lbAnswers.Items.Count)
            {
                selectedanswer = (int)num.Value + 1;

                try {
                    lblAnswer.Text = (string)lbAnswers.Items[(int)num.Value - 1];
                    lbAnswers.SelectedIndex = (int)num.Value - 1;
                }
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

        private StudentLogin? CreateProfile(bool ifnew)
        {
            var window = new StudentForm(false);
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                var student = new Student()
                {
                    Name = window.FirstName,
                    SurName = window.SurName,
                    Email = window.Email,
                    Password = window.Password
                };
                return new StudentLogin(student, ifnew);
            }
        else return null;
            
        }


        private void Login(StudentLogin st)
        {
            try
            {
                var msg = SerializeObject(st);
                client.SendMessage(msg);
                //student = st;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error sending file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Client_LoggedIn(object? sender, Student e)
        {
            try
            {
                student = e;
                lbMessages.Items.Add($"Logged as {student.Name} {student.SurName}");
                lbStatus.Text= $"Logged as {student.Name} {student.SurName}";
                btnQuiz.Enabled = true;
            }
            catch (Exception ex)
            {
                lbMessages.Items.Add($"Failed to log in");
                MessageBox.Show(ex.Message, "Login failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SetQuizInterface<T>(T question) where T : Quiz
        {
            num.Enabled = true;
            num.Minimum = 1;
            num.Maximum = question.Answers.Count;
            lblQuestion.Text = question.Question;
            lbAnswers.Items.Clear();
            foreach (var answer in question.Answers)
                lbAnswers.Items.Add(answer);
            if (subj == Subject.Musichistory && mh_quiz is not null)
                lbQ.Text = $"{mh_index + 1} question from {mh_quiz.Count}";
            else if (subj == Subject.Solfegio && s_quiz is not null)
                lbQ.Text = $"{mh_index + 1} question from {s_quiz.Count}";
        }

        private void EmptyQuizInterface()
        {
            num.Enabled = false;
            lbAnswers.Items.Clear();
            lblQuestion.Text = string.Empty;
            lbQ.Text = "No questions are loaded";
        }

        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (btnSend.Text != "Exit")
            {
                Answer();
                RefreshQuiz();
            }
            else this.Close();
        }

        private void Answer()
        {
            if (student is null || selectedanswer is null)
            {
                MessageBox.Show("Not ready to send answer"); return;
            }

            ShortAnswer answer; int choice;
            //lbMessages.Items.Add("start creating answer");

            if (subj == Subject.Musichistory && current_mh_question is not null             )
            {
                choice = (int)selectedanswer;
                answer = new(subj, student.Email, mh_index, choice);
                //lbMessages.Items.Add("start creating mh-answer");
            }
            else if (subj == Subject.Solfegio && current_s_question is not null
                && current_s_question.Studentanswer is not null)
            {
                choice = (int)selectedanswer;
                answer = new(subj, student.Email, s_index, choice);
                //lbMessages.Items.Add("start creating s-answer");
            }
            else
            {
                lbMessages.Items.Add("Error while creating answer");                
                return;
            }

            lbMessages.Items.Add("answer obj created");
            try
            {
                var data = SerializeObject(answer);
                //lbMessages.Items.Add("answer obj serializied");
                client.SendMessage(data);
                lbMessages.Items.Add("answer sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Send message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshQuiz()
        {
            if (subj == Subject.Solfegio && s_quiz is not null
                && s_quiz.Count > s_index + 1)
            {
                s_index++;
                current_s_question = s_quiz[s_index];
                SetQuizInterface(current_s_question);
            }
            else if (subj == Subject.Musichistory && mh_quiz is not null
                && mh_quiz.Count > mh_index + 1)
            {
                mh_index++;
                current_mh_question = mh_quiz[mh_index];
                SetQuizInterface(current_mh_question);
            }
            else if ((mh_quiz is not null && mh_quiz.Count == mh_index + 1) || (s_quiz is not null && s_quiz.Count == s_index + 1))
            {
                EmptyQuizInterface();
                lbQ.Text = "Congratulations! Quiz is done!";
                btnSend.Text = "Exit";
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
