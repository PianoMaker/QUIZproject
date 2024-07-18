using System.Net;
using System.Text;
using System.Windows.Forms;
using Models;
using QuizHolder;
using static Utilities.Serializers;
//using Utilities;
/*
using static Utilities.Serializers;
using Quiz = Utilities.Quiz;
using ShortAnswer = Utilities.ShortAnswer;
using SQuiz = Utilities.SQuiz;
using Subject = Utilities.Subject;
*/
namespace QUIZ_client_1
{

    // DISCLAMER! ≤Ì‰ÂÍÒË ‚≥‰ÔÓ‚≥‰ÂÈ ‚≥‰ 0, ‡ÎÂ ÌÓÏÂË ‚≥‰ÔÓ‚≥‰ÂÈ ‚≥‰ 1!

    public partial class ClientMainForm : Form
    {
        public Subject subj { get; set; }


        private int port;
        private IPAddress ip;
        private Q_Client client;
        private Student student;
        private bool Ifconnected;

        private int? selectedanswer;
        private Quiz? current_t_question;
        private SQuiz? current_s_question;
        private List<TQuiz>? t_quiz;
        private List<SQuiz>? s_quiz;
        private int t_index;
        private int s_index;



        public ClientMainForm()
        {
            InitializeComponent();
            ip = IPAddress.Loopback;
            tbIp.Text = ip.ToString();
            port = 1234;
            tbPort.Text = port.ToString();
            s_index = 0;
            t_index = 0;
            Ifconnected = false;
            pictureBox.BringToFront();

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
            client.Connected += OnClient_Connected;
            client.LoggedIn += OnClient_LoggedIn;
            client.QuizLoaded += OnQuizLoaded;
            if (Ifconnected == true)
            {
                //btnQuiz.Enabled = true;//ÔË·‡ÚË ÔÓÚ≥Ï
                btnProfile.Enabled = true;
                if (student != null)
                    lbStatus.Text = $"trying to connect as {student.Name} {student.SurName}";
                else
                    lbStatus.Text = $"connected anonymously";
            }
        }

        private void OnQuizLoaded(object? sender, EventArgs e)
        {
            Task.Run(() =>
            {
                if (subj == Subject.Theory && current_t_question is not null)
                    SetQuizInterface(current_t_question);
                else if (subj == Subject.Solfegio && current_s_question is not null)
                    SetQuizInterface(current_s_question);

            });
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
                subj = Subject.Theory;
                if (t_quiz is not null)
                    GetCurrentTQuestions();
                else EmptyQuizInterface();
            }
            else
            {
                subj = Subject.Solfegio;
                if (s_quiz is not null)
                    GetCurrentSQuestions();
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
            lbQ.Text = string.Empty;
            byte[] msg = Encoding.UTF8.GetBytes(subj.ToString());
            client.SendMessage(msg, subj.ToString());
            selectedanswer = null;
            //MessageBox.Show($"current position: t_index={t_index}, s_index={s_index}, t.count={t_quiz?.Count ?? null}, s.count ={s_quiz?.Count ?? null}");


        }

        private void lbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = lbAnswers.SelectedIndex;
            selectedanswer = index + 1; // ÌÓÏÂ ‚≥‰ÔÓ‚≥‰≥ ·≥Î¸¯Â Á‡ ≥Ì‰ÂÍÒ Ì‡ 1
            try { num.Value = (int)selectedanswer; }
            catch { MessageBox.Show($"Error with Numbering questions: selectedanswer = {selectedanswer}"); }
            Invoke(() => lblAnswer.Text = (string)lbAnswers.Items[index]);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayChord();
        }


        private void num_ValueChanged(object sender, EventArgs e)
        {
            if (num.Value > 0 && num.Value <= lbAnswers.Items.Count)
            {
                selectedanswer = (int)num.Value;
                try
                {
                    Invoke(() =>
                    {
                        lblAnswer.Text = lbAnswers.Items[(int)num.Value - 1].ToString();
                        lbAnswers.SelectedIndex = (int)num.Value - 1;//≥Ì‰ÂÍÒ ÏÂÌ¯Â Á‡ ÌÓÏÂ ‚≥‰ÔÓ‚≥‰≥
                    });
                }
                catch { MessageBox.Show("index is out of range"); }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (Answer())
                RefreshQuiz();
        }

        ///œŒƒ≤Ø

        private void OnMessageChanged(object? sender, EventArgs e)
        {
            if (client.Message is not null)
            {
                Invoke(() => lbMessages.Items.Add(client.Message));
                if (client.Message.Contains("session started"))
                {
                    Invoke(() => lbStatus.Text = "connected");
                    Ifconnected = true;
                }
                else if (client.Message.Contains("imposible to connect server"))
                {
                    Invoke(() => lbStatus.Text = "not connected");
                    Ifconnected = false;
                }
            }
        }

        private void On_T_questions_Received(object? sender, List<TQuiz> e)
        {
            btnPlay.Enabled = false;
            t_quiz = e;
            GetCurrentTQuestions();
        }

        private void On_S_questions_Received(object? sender, List<SQuiz> e)
        {
            s_quiz = e;
            GetCurrentSQuestions();
        }


        private void OnClient_Connected(object? sender, EventArgs e)
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

        private void OnClient_LoggedIn(object? sender, Student e)
        {
            //MessageBox.Show("OnClient_LoggedIn");
            // œ–» ÀŒ√”¬¿ÕÕ≤  Œ–»—“”¬¿◊¿
            try
            {
                student = e;
                t_index = e.T_answered;
                s_index = e.S_answered;
                Invoke(() =>
                {
                    lbMessages.Items.Add($"Logged as {student.Name} {student.SurName}");
                    lbStatus.Text = $"Logged as {student.Name} {student.SurName}";
                    btnQuiz.Enabled = true;
                    lbMessages.Items.Add($"t={t_index}, s={s_index}");
                    ;
                });
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
            client.T_questions_Received += On_T_questions_Received;
            client.S_questions_Received += On_S_questions_Received;
            await client.StartClientAsync();

        }

        // ƒ≤Ø
        private void Login(StudentLogin st)
        {
            try
            {
                var msg = SerializeObject(st);
                client.Relogin += (sender, e) => OnRelogin(sender, st);
                client.SendMessage(msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error sending file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnRelogin(object? sender, StudentLogin e)
        {
            e.Ifnew = false;
            Login(e);
            Invoke(() => lbMessages.Items.Add("try to relogin"));
        }

        // œ–» Œ“–»Ã¿ÕÕ≤ œ»“¿Õ‹
        private void GetCurrentTQuestions()
        {
            if (t_quiz is null) return;
            if (t_quiz.Count > 0 && t_index < t_quiz.Count)
            {
                current_t_question = t_quiz[t_index];
                SetQuizInterface(current_t_question);
            }

            else if (t_index >= t_quiz.Count)
                EmptyQuizInterface("Your quiz is already done!");

            else
                EmptyQuizInterface("No questions received");

        }


        private void GetCurrentSQuestions()
        {
            if (s_quiz is null) return;
            if (s_quiz.Count > 0 && s_index < s_quiz.Count)
            {
                current_s_question = s_quiz[s_index];
                SetQuizInterface(current_s_question);
                Invoke(() => lblQuestion.Text = current_s_question.Question);
                Invoke(() => btnPlay.Enabled = true);
            }

            else if (s_index >= s_quiz.Count)
                EmptyQuizInterface("Your quiz is already done!");

            else
                EmptyQuizInterface("No questions received");
        }


        private void SetQuizInterface<T>(T question) where T : Quiz
        {
            Invoke(() =>
            {
                num.Enabled = true;
                num.Minimum = 1;
                num.Maximum = question.Answers.Count;
                lblQuestion.Text = question.Question;
                lblAnswer.Text = string.Empty;
                pictureBox.Image = question.Picture;
                lbAnswers.Items.Clear();
                foreach (var answer in question.Answers)
                    lbAnswers.Items.Add(answer);
                if (subj == Subject.Theory && t_quiz is not null)
                    lbQ.Text = $"{t_index + 1} question from {t_quiz.Count}";
                else if (subj == Subject.Solfegio && s_quiz is not null)
                    lbQ.Text = $"{s_index + 1} question from {s_quiz.Count}";
                btnSend.Enabled = true;
                num.Enabled = true;
            });

        }

        private void EmptyQuizInterface(string msg)
        {
            EmptyQuizInterface();
            Invoke(() => lblAnswer.Text = msg);
        }

        private void EmptyQuizInterface()
        {
            if (this.IsHandleCreated)//≥Ì‡Í¯Â „Î˛Í Ì‡ ÒÚ‡Ú≥
            {
                Invoke(() =>
            {
                num.Enabled = false;
                lblAnswer.Text = string.Empty;
                lbAnswers.Items.Clear();
                lblQuestion.Text = string.Empty;
                btnPlay.Enabled = false;
                btnSend.Enabled = false;
                lbQ.Text = "No questions are loaded";
            });
            }
        }


        private bool Answer()
        {
            if (student is null || selectedanswer is null)
            {
                MessageBox.Show($"Not ready to send answer:\n student: {student?.Email ?? null}  answer: {selectedanswer?? null}");
                return false;
            }

            ShortAnswer answer; int choice;
            //MessageBox.Show($"Creating Answer {subj} : {s_index} : {selectedanswer}");


            if (subj == Subject.Theory && current_t_question is not null)
            {
                choice = (int)selectedanswer;
                answer = new(subj, student.Email, t_index, choice);
                lbMessages.Items.Add($"creating t-answer: {choice}");
            }
            else if (subj == Subject.Solfegio && current_s_question is not null)
            {
                choice = (int)selectedanswer;
                answer = new(subj, student.Email, s_index, choice);
                lbMessages.Items.Add($"creating s-answer: {choice}");
            }
            else
            {
                lbMessages.Items.Add("Error while creating answer");
                return false;
            }


            try
            {
                var data = SerializeObject(answer);
                client.SendMessage(data);
                lbMessages.Items.Add("answer sent");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Send message Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void RefreshQuiz()
        {
            //MessageBox.Show($"previous position: t={t_index}, s={s_index}, t.count={t_quiz?.Count ?? 0}, s.count ={s_quiz?.Count ?? 0}");
            if (subj == Subject.Solfegio && s_quiz is not null)
            {
                s_index++;
                if (s_quiz.Count > s_index)
                {
                    current_s_question = s_quiz[s_index];
                    SetQuizInterface(current_s_question);
                }
                else
                {
                    EmptyQuizInterface();
                    lbQ.Text = "Congratulations! Quiz is done!";
                }
            }
            else if (subj == Subject.Theory && t_quiz is not null)
            {
                t_index++;
                if (t_quiz.Count > t_index)
                {
                    current_t_question = t_quiz[t_index];
                    SetQuizInterface(current_t_question);
                }
                else
                {
                    EmptyQuizInterface();
                    lbQ.Text = "Congratulations! Quiz is done!";
                }
            }
            else
            {
                MessageBox.Show($"Results Error\n: subj = {subj}, t_index = {t_index}, s_index = {s_index}, t_count={t_quiz?.Count ?? null}, s_count={s_quiz?.Count ?? null}  ");
            }


            selectedanswer = null;
        }

        private void lblAnswer_Click(object sender, EventArgs e)        
        {
            if (string.IsNullOrEmpty(lblAnswer.Text)) return;
            Task.Run(() =>
            {
                string fullAnswer = lblAnswer.Text;                
                Form answerForm = new Form();
                answerForm.Text = "œÓ‚ÌËÈ ÚÂÍÒÚ";
                answerForm.Size = new Size(800, 600);              

                Label lblFullAnswer = new Label();
                lblFullAnswer.Dock = DockStyle.Fill;
                lblFullAnswer.Font = new Font("Segoe UI", 12F);
                lblFullAnswer.Text = fullAnswer;
                lblFullAnswer.TextAlign = ContentAlignment.MiddleCenter;
                lblFullAnswer.AutoSize = false;                                
                answerForm.Controls.Add(lblFullAnswer);
                answerForm.ShowDialog();
            });
        }


        private void PlayChord()
        {
            if (current_s_question is not null)
            {
                try { current_s_question.Play(); }
                catch { MessageBox.Show("Inmpossible to play chord"); }
            }
        }

        private async void pictureBox_Click(object sender, EventArgs e)
        {
            await OpenImage(pictureBox.Image);
        }

        private Task OpenImage(Image image)
        {
            return Task.Run(() =>
            {
                Form fullSizeForm = new Form
                {
                    Text = "Full Size Image",
                    Width = image.Width,
                    Height = image.Height
                };

                PictureBox fullSizePictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Dock = DockStyle.Fill
                };

                fullSizeForm.Controls.Add(fullSizePictureBox);
                fullSizeForm.ShowDialog();
            });
        
         

        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lbMessages.Visible = !checkBox1.Checked;            
            if (lbMessages.Visible)
            {              
                
                pictureBox.Parent = panelQuiz;                
                pictureBox.Size = picpointer.Size;
                pictureBox.Location = picpointer.Location;
                picpointer.SendToBack();
                pictureBox.BringToFront();                
                lblAnswer.MaximumSize = new Size(lbAnswers.Width, 48);
                lblQuestion.MaximumSize = new Size(lbAnswers.Width, 48);
            }
            else
            {                
                pictureBox.Parent = panelPicture;                
                pictureBox.Size = panelPicture.Size;
                pictureBox.Location = new Point(0, 0);
                lblAnswer.MaximumSize = new Size(panel1.Width, 48);
                lblQuestion.MaximumSize = new Size(lbAnswers.Width, 48);
                //lbAnswers.Size = new Size(804, 184);

            }
        }
    }
}
