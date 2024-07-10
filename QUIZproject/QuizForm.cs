using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace QUIZproject
{
    public partial class QuizForm : Form
    {
        Subject subj;
        List<Quiz> mh_questions = new();
        List<SQuiz> s_questions = new();
        string FilePath;
        public QuizForm()
        {
            InitializeComponent();
            rbMH.Checked = true;
            rbMH.BackColor = Color.LightGreen;
            subj = Subject.Musichistory;
            Load_mh_questions();
            FilePath = Path.GetDirectoryName(Application.ExecutablePath)!;
        }

        private void Load_mh_questions()
        {
            foreach (var q in mh_questions)
                llbQuestions.Items.Add(q);
        }

        private void Load_s_questions()
        {
            foreach (var q in s_questions)
                llbQuestions.Items.Add(q);
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
            EditQuestion();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteQuestion();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveQuizBase("MusicHistory.bin");
            SaveSQuizBase("SolfegioQuiz.bin");
        }

        private void ChooseSubject()
        {
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
            var w = new QuizEditForm(subj);
            w.ShowDialog();
            SaveQuestion(w);
        }

        private void EditQuestion()
        {
            int index = llbQuestions.SelectedIndex;
            if (subj == Subject.Solfegio)
            {
                var window = new QuizEditForm(subj, s_questions[index]);
                window.ShowDialog();
                SaveQuestion(window);
            }
            else if (subj == Subject.Musichistory)
            {
                var window = new QuizEditForm(subj, mh_questions[index]);
                window.ShowDialog();
                SaveQuestion(window);
            }
        }
        private void SaveQuestion(QuizEditForm w)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Musichistory)
            {
                var question = new Quiz(w.Question, w.Answers, w.Correctanswer);
                mh_questions.Add(question);

            }
            if (w.DialogResult == DialogResult.OK && subj == Subject.Solfegio)
            {
                var question = new SQuiz();
                s_questions.Add(question);
            }
        }

        private void DeleteQuestion()
        {
            var index = llbQuestions.SelectedIndex;
            throw new NotImplementedException();
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
                File.WriteAllBytes(path, SerializeQuizBase());
            }
            catch { MessageBox.Show("Error saving file"); }
        }

        private void SaveSQuizBase(string path)
        {
            try
            {
                File.WriteAllBytes(path, SerializeSQuizBase());
            }
            catch { MessageBox.Show("Error saving file"); }
        }

        private byte[] SerializeQuizBase()
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));
                serializer.WriteObject(memoryStream, mh_questions);
                return memoryStream.ToArray();
            }
        }

        private byte[] SerializeSQuizBase()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<SQuiz>));
                serializer.WriteObject(memoryStream, s_questions);
                return memoryStream.ToArray();
            }
        }


        private void DeserializeQuizBase(byte[] data)
        {
            
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Quiz>));                
                mh_questions = (List<Quiz>)serializer.ReadObject(memoryStream)!;
            }
        }

        private void DeserializeSQuizBase(byte[] data)
        {
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<SQuiz>));
                s_questions = (List<SQuiz>)serializer.ReadObject(memoryStream)!;
            }
        }

    }    
}
