﻿using System;
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
using static Models.Serializers;

namespace QUIZproject_server
{
    public partial class QuizForm : Form
    {
        //дисципліна
        private Subject subj;
        // колекції питань
        private List<Quiz> t_questions = new();
        private List<SQuiz> s_questions = new();
        // файли з питаннями зберігаю в спільному каталозі з exe-файлом
        private readonly string TheoryPath = "Theory.bin";
        private readonly string SolfegioPath = "Solfegio.bin";

        public List<Quiz> T_questions
        {
            get => t_questions;
            set
            {
                t_questions = value;
                QestionsChanged(T_questions.Count);
            }
        }

        public List<SQuiz> S_questions
        {
            get => s_questions;
            set
            {
                s_questions = value;
                if (s_questions is not null)
                    QestionsChanged(s_questions.Count);
            }
        }


        public event EventHandler<int> QuestionsCount;

        private void QestionsChanged(int count)
        {
            QuestionsCount?.Invoke(this, count);
        }
       


        public delegate bool DisplayBold(int index);

        private DisplayBold DisplayBoldDelegate;
        public QuizForm()
        {
            InitializeComponent();            
            LoadQuizBase(TheoryPath);
            LoadSQuizBase(SolfegioPath);
            
            rbMH.Checked = true;
            rbMH.BackColor = Color.LightGreen;
            subj = Subject.Theory;
            Load_t_questions();
            lbAnswers.DrawMode = DrawMode.OwnerDrawFixed;
            lbAnswers.DrawItem += lbAnswers_DrawItem;

        }

        private void Load_t_questions()
        {
            lbQuestions.Items.Clear();
            if (t_questions is not null)
                foreach (var q in T_questions)
                    lbQuestions.Items.Add(q.Question);
            else t_questions = new();
        }

        private void Load_s_questions()
        {
            lbQuestions.Items.Clear();
            if (s_questions is not null)
                foreach (var q in S_questions)
                    lbQuestions.Items.Add(q.Question);
            else s_questions = new();
        }

        private void rbS_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void rbMH_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
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
            //MessageBox.Show($"start saving");
            SaveQuizBase(TheoryPath);
            SaveSQuizBase(SolfegioPath);
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
                subj = Subject.Theory;
                rbMH.BackColor = Color.LightGreen;
                rbS.BackColor = Color.Transparent;
                Load_t_questions();
            }
        }

        private void AddQuestion()
        {
            var w = new EditQuestionForm(subj);
            w.ShowDialog();
            SaveNewQuestion(w);
            if (subj == Subject.Theory)
                Load_t_questions();
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
            else if (subj == Subject.Theory)
            {
                var window = new EditQuestionForm(subj, T_questions[index]);
                window.ShowDialog();
                SaveEditedQuestion(window, T_questions[index]);
                Load_t_questions();
            }

        }
        private void SaveNewQuestion(EditQuestionForm w)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Theory)
            {
                var question = new Quiz(w.Question, w.Answers, w.Correctanswer);
                T_questions.Add(question);
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
            if (w.DialogResult == DialogResult.OK && subj == Subject.Theory)
            {
                q.Question = w.Question;
                q.Answers = w.Answers;
                q.Correctanswer = w.Correctanswer;
                btnSave.Text = "Save*";
            }
        }

        private void SaveEditedQuestion(EditQuestionForm w, SQuiz q)
        {
            if (w.DialogResult == DialogResult.OK && subj == Subject.Theory)
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
            if (subj == Subject.Theory)
            {
                T_questions.RemoveAt(index);
                Load_t_questions();
            }
            else if (subj == Subject.Solfegio)
            {
                S_questions.RemoveAt(index);
                Load_s_questions();
            }
            else MessageBox.Show("Error while choosing a subject");
            btnSave.Text = "Save*";
        }

        // виклик з основного вікна, інакше System.Threading.ThreadStateException
        public void ExportQuizBase()
        {

            if (t_questions.Count > 0)
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "Зберегти файл";
                sfd.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
                sfd.FileName = "Theory.bin";
                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveQuizBase(sfd.FileName);
            }
            else MessageBox.Show("Theory quiz is empty, nothing to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (s_questions.Count > 0)
            {
                var sfd = new SaveFileDialog();
                sfd.Title = "Зберегти файл";
                sfd.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
                sfd.FileName = "Solfegio.bin";
                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveSQuizBase(sfd.FileName);
            }
            else MessageBox.Show("Solfegio quiz is empty, nothing to save", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ImportQuizBase()
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Title = "Choose theory quiz";
                ofd.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.Yes)
                    LoadQuizBase(ofd.FileName);
            }
            catch { MessageBox.Show("Failed to load Theory quiz"); }
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Title = "Choose solfegio quiz";
                ofd.Filter = "Binary Files (*.bin)|*.bin|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.Yes)
                    LoadSQuizBase(ofd.FileName);
            }
            catch { MessageBox.Show("Failed to load Solfegio quiz"); }

        }

        private void SaveQuizBase(string path)
        {
            try
            {
                //MessageBox.Show($"{path} : {SerializeQuizBase().Length} bytes ");
                File.WriteAllBytes(path, SerializeQuizBase());
                btnSave.Text = "Save";
            }
            catch { MessageBox.Show("Error saving file"); }

        }

        private void SaveSQuizBase(string path)
        {
            try
            {
                //MessageBox.Show($"{path} : {SerializeSQuizBase().Length} bytes ");
                File.WriteAllBytes(path, SerializeSQuizBase());
            }
            catch { MessageBox.Show("Error saving file"); }
        }

        private byte[] SerializeQuizBase()
        {
            return SerializeObject(T_questions);
        }

        private byte[] SerializeSQuizBase()
        {
            return SerializeObject(S_questions);
        }

        private void DeserializeQuizBase(byte[] data)
        {
            if (TryDeserializeObject(data, data.Length, out List<Quiz> t_questions))
                T_questions = t_questions;
        }

        private void DeserializeSQuizBase(byte[] data)
        {
            if (TryDeserializeObject(data, data.Length, out List<SQuiz> s_questions))
                S_questions = s_questions;

        }

        // ЗАВАНТАЖЕННЯ ПИТАНЬ І ВІДПОВІДЕЙ
        private void LoadQuizBase(string path)
        {
            try
            {                
                var bytes = File.ReadAllBytes(path);
                DeserializeQuizBase(bytes);
                Load_t_questions();
            }
            catch (Exception e)
            {
                lblQ.Text += "Impossible to load theory quiz\n";
            }
        }
        private void LoadSQuizBase(string path)
        {
            try
            {
                var bytes = File.ReadAllBytes(path);
                DeserializeSQuizBase(bytes);
                Load_s_questions();
            }
            catch (Exception e)
            {
                lblQ.Text += "Impossible to load solfegio quiz\n";
            }
        }

        private void lbQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbQuestions.SelectedIndex == -1) return;
            // убезпечує від помилки якщо миша не влучає в питання
            
            lbAnswers.Items.Clear();
            int i = 1;
            if (subj == Subject.Theory)
            {
                
                var index = lbQuestions.SelectedIndex;
                foreach (var item in T_questions[index].Answers)
                {
                    lbAnswers.Items.Add($"{i}. {item}");
                    i++;
                }
                // ІНДЕКС ПРАВИЛЬНОЇ ВІДПОВІДІ ТУТ
                DisplayBoldFunc(bold => bold == T_questions[index].Correctanswer - 1);
            }
            else if (subj == Subject.Solfegio)
            {
            
                var index = lbQuestions.SelectedIndex;
                foreach (var item in S_questions[index].Answers)
                {
                    lbAnswers.Items.Add(item);
                    i++;
                }
                // ІНДЕКС ПРАВИЛЬНОЇ ВІДПОВІДІ ТУТ
                DisplayBoldFunc(bold => bold == S_questions[index].Correctanswer - 1);
            }
            

        }

        public void DisplayBoldFunc(DisplayBold delegateFunc)
        {
            DisplayBoldDelegate = delegateFunc;
        }

        private void lbAnswers_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) 
                return;
            

            e.DrawBackground();

            // Визначаємо, чи потрібно відобразити поточний елемент жирним шрифтом
            bool isBold = DisplayBoldDelegate?.Invoke(e.Index) ?? false;
            

            Font font = isBold ? new Font(lbAnswers.Font, FontStyle.Bold) : lbAnswers.Font;
            Brush brush = isBold ? new SolidBrush(Color.DarkGreen) : new SolidBrush(lbAnswers.ForeColor);

            // Отримуємо текст елемента

            string text = lbAnswers.Items[e.Index]?.ToString() ?? "Error occured!";


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
