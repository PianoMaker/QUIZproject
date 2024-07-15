using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace QUIZproject_server
{
    public partial class QuizForm : Form
    {
        //дисципліна
        private Subject subj;
        // колекції питань
        private List<Quiz> mh_questions = new();
        private List<SQuiz> s_questions = new();
        // файли з питаннями зберігаю в спільному каталозі з exe-файлом
        private readonly string MusicHistoryPath = "MusicHistory.bin";
        private readonly string SolfegioPath = "SolfegioQuiz.bin";

        public List<SQuiz> S_questions { get => s_questions; set => s_questions = value; }
        public List<Quiz> Mh_questions { get => mh_questions; set => mh_questions = value; }

        public delegate bool DisplayBold(int index);

        private DisplayBold DisplayBoldDelegate;
        public QuizForm()
        {
            InitializeComponent();
            LoadQuizBase(MusicHistoryPath);
            LoadSQuizBase(SolfegioPath);
            rbMH.Checked = true;
            rbMH.BackColor = Color.LightGreen;
            subj = Subject.Musichistory;
            Load_mh_questions();
            lbAnswers.DrawMode = DrawMode.OwnerDrawFixed;
            lbAnswers.DrawItem += lbAnswers_DrawItem;

        }

        private void Load_mh_questions()
        {
            lbQuestions.Items.Clear();
            foreach (var q in Mh_questions)
                lbQuestions.Items.Add(q.Question);
            
        }

        private void Load_s_questions()
        {
            lbQuestions.Items.Clear();
            foreach (var q in S_questions)
                lbQuestions.Items.Add(q.Question);
        }

        private void rbS_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void rbMH_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exportMenu_Click(object sender, EventArgs e)
        {
            ExportQuizBase();

        }

        private void importMenu_Click(object sender, EventArgs e)
        {
            ImportQuiz();
        }

        private void ImportQuiz()
        {
            MessageBox.Show("Todo: import quiz");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddQuestion();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditQuestion(lbQuestions.SelectedIndex);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteQuestion(lbQuestions.SelectedIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"start saving");
            SaveQuizBase("MusicHistory.bin");
            SaveSQuizBase("SolfegioQuiz.bin");
        }

        private void ChooseSubject()
        {
            lbAnswers.Items.Clear();
            if (rbS.Checked)
            {
                subj = Subject.Solfegio;
                rbMH.BackColor = Color.Transparent;
                rbS.BackColor = Color.LightGreen;
                Load_s_questions();
            }
            else if (rbMH.Checked)
            {
                subj = Subject.Musichistory;
                rbMH.BackColor = Color.LightGreen;
                rbS.BackColor = Color.Transparent;
                Load_mh_questions();
            }
        }

        private void AddQuestion()
        {
            var w = new EditQuestionForm(subj);
            w.ShowDialog();
            SaveNewQuestion(w);
            if(subj == Subject.Musichistory)
                Load_mh_questions();
            else if (subj == Subject.Solfegio)
                Load_s_questions();            
        }

        private void EditQuestion(int index)
        {
            if (index == -1)
            {
                MessageBox.Show("Choose quiestion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (subj == Subject.Solfegio)
            {
                var window = new EditQuestionForm(subj, S_questions[index]);
                window.ShowDialog();
                SaveEditedQuestion(window, S_questions[index]);
                Load_s_questions();
            }
            else if (subj == Subject.Musichistory)
            {
                var window = new EditQuestionForm(subj, Mh_questions[index]);
                window.ShowDialog();
                SaveEditedQuestion(window, Mh_questions[index]);
                Load_mh_questions();
            }
            
        }
        private void SaveNewQuestion(EditQuestionForm w)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Musichistory)
            {
                var question = new Quiz(w.Question, w.Answers, w.Correctanswer);
                Mh_questions.Add(question);
                btnSave.Text = "Save*";

            }
            if (w.DialogResult == DialogResult.OK && subj == Subject.Solfegio)
            {
                var question = new SQuiz(w.Question, w.Answers, w.Correctanswer, w.Pitches);
                S_questions.Add(question);
                btnSave.Text = "Save*";
            }
        }

        private void SaveEditedQuestion(EditQuestionForm w, Quiz q)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Musichistory)
            {
                q.Question = w.Question;
                q.Answers = w.Answers;
                q.Correctanswer = w.Correctanswer;
                btnSave.Text = "Save*";
            }            
        }

        private void SaveEditedQuestion(EditQuestionForm w, SQuiz q)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Musichistory)
            {
                q.Question = w.Question; 
                q.Answers = w.Answers; 
                q.Correctanswer = w.Correctanswer;
                q.Pitches = w.Pitches;
                btnSave.Text = "Save*";
            }
        }

        private void DeleteQuestion(int index)
        {
            if (lbQuestions.SelectedIndex == -1)
            {
                MessageBox.Show("Choose quiestion", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (subj == Subject.Musichistory)
            {
                Mh_questions.RemoveAt(index);
                Load_mh_questions();
            }
            else if (subj == Subject.Solfegio)
            {
                S_questions.RemoveAt(index);
                Load_s_questions();
            }
            else MessageBox.Show("Error while choosing a subject");
            btnSave.Text = "Save*";
        }

        private void ExportQuizBase()
        {
            var sfd = new SaveFileDialog();
            sfd.Title = "Зберегти файл";
            sfd.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";

            if (subj == Subject.Musichistory)
            {
                sfd.FileName = "MusicHistoryQuiz.bin";
                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveQuizBase(sfd.FileName);
            }
            else if (subj == Subject.Solfegio)
            {
                sfd.FileName = "Solfegio.bin";
                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveSQuizBase(sfd.FileName);
            }
            else MessageBox.Show("Не визначено дисципліну");
        }

        private void SaveQuizBase(string path)
        {
            try
            {
                MessageBox.Show($"{path} : {SerializeQuizBase().Length} bytes ");
                File.WriteAllBytes(path, SerializeQuizBase());
                btnSave.Text = "Save";
            }
            catch { MessageBox.Show("Error saving file"); }
            
        }

        private void SaveSQuizBase(string path)
        {
            try
            {
                MessageBox.Show($"{path} : {SerializeQuizBase().Length} bytes ");
                File.WriteAllBytes(path, SerializeSQuizBase());
            }
            catch { MessageBox.Show("Error saving file"); }
        }

        private byte[] SerializeQuizBase()
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));
                serializer.WriteObject(memoryStream, Mh_questions);
                return memoryStream.ToArray();
            }
        }

        private byte[] SerializeSQuizBase()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<SQuiz>));
                serializer.WriteObject(memoryStream, S_questions);
                return memoryStream.ToArray();
            }
        }


        private void DeserializeQuizBase(byte[] data)
        {

            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));
                Mh_questions = (List<Quiz>)serializer.ReadObject(memoryStream)!;
            }
        }

        private void DeserializeSQuizBase(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<SQuiz>));
                S_questions = (List<SQuiz>)serializer.ReadObject(memoryStream)!;
                //MessageBox.Show("deserializing s_base is running");
            }
        }

        private void LoadQuizBase(string path)
        {
            var bytes = File.ReadAllBytes(path);
            DeserializeQuizBase(bytes);
            Load_mh_questions();
        }
        private void LoadSQuizBase(string path)
        {
            var bytes = File.ReadAllBytes(path);
            DeserializeSQuizBase(bytes);
            Load_s_questions();
        }

        private void lbQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbAnswers.Items.Clear();
            int i = 1;
            if (subj==Subject.Musichistory)
            {
             
                var index = lbQuestions.SelectedIndex;
                foreach (var item in Mh_questions[index].Answers)
                {
                    lbAnswers.Items.Add($"{i}. {item}");                    
                    i++;
                }
                DisplayBoldFunc(bold => bold == Mh_questions[index].Correctanswer - 1);
            }
            else if (subj == Subject.Solfegio)
            {
                var index = lbQuestions.SelectedIndex;
                foreach (var item in S_questions[index].Answers)
                {
                    lbAnswers.Items.Add(item);
                    i++;
                }
            }           

        }

        public void DisplayBoldFunc(DisplayBold delegateFunc)
        {
            DisplayBoldDelegate = delegateFunc;
        }

        private void lbAnswers_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Визначаємо, чи потрібно відобразити поточний елемент жирним шрифтом
            bool isBold = DisplayBoldDelegate?.Invoke(e.Index) ?? false;

            // Встановлюємо стиль шрифту для відповідного елемента
            Font font = isBold ? new Font(lbAnswers.Font, FontStyle.Bold) : lbAnswers.Font;
            Brush brush = new SolidBrush(lbAnswers.ForeColor);

            // Отримуємо текст елемента
            string text = lbAnswers.Items[e.Index].ToString();

            // Відображаємо текст елемента з відповідним стилем
            e.Graphics.DrawString(text, font, brush, e.Bounds, StringFormat.GenericDefault);

            e.DrawFocusRectangle();
        }




        /*
        private void lbAnswers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < lbAnswers.Items.Count)
            {
                string itemText = lbAnswers.Items[e.Index].ToString();
                Color textColor = Color.DarkGreen;
                e.DrawBackground();
                e.Graphics.DrawString(itemText, e.Font, new SolidBrush(textColor), e.Bounds);
                e.DrawFocusRectangle();
            }
        */
    }
}
