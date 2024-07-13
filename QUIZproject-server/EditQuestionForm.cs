﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace QUIZproject_server
{
    public partial class EditQuestionForm : Form
    {
        //private enum Subject { Musichistory, Solfegio }

        //private readonly int camerton = 220;//HZ
        public string Question { get; set; }

        public List<string> Answers { get; set; }

        public List<int> Pitches { get; set; }

        string[] notes =
        {
            " ",
            "a",
            "ais/b",
            "h",
            "c",
            "cis/des",
            "d",
            "dis/es",
            "e",
            "f",
            "fis",
            "g",
            "gis/as"
        };



        public int Correctanswer { get; set; }

        public EditQuestionForm(Subject subj)
        {
            InitializeComponent();
            Answers = new List<string>();
            num.Maximum = Answers.Count;
            num.Minimum = 0;    
            InitialaizeSolfegio(subj);
            Pitches = null!;
        }
        public EditQuestionForm(Subject subj, Quiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            num.Maximum = Answers.Count;
            num.Minimum = 0;
            Correctanswer = quiz.Correctanswer;            
            num.Value = quiz.Correctanswer;
            InitialaizeSolfegio(subj);
            Pitches = null!;
            tbQuestion.Text = Question;
            RenewAnswerList();

        }

        public EditQuestionForm(Subject subj, SQuiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            Pitches = quiz.Pitches;
            InitialaizeSolfegio(subj);
            //MessageBox.Show($"count = {quiz.Pitches.Count}, 1={quiz.Pitches[0]}, 2={quiz.Pitches[3]}");
            try
            {
                cb1.SelectedIndex = quiz.Pitches[0] + 1;
                cb2.SelectedIndex = quiz.Pitches[1] + 1;
                cb3.SelectedIndex = quiz.Pitches[2] + 1;
                cb4.SelectedIndex = quiz.Pitches[3] + 1;
                cb5.SelectedIndex = quiz.Pitches[4] + 1;
            }  
            catch (Exception Ex)
            {
                MessageBox.Show("Impossible to proceed voicing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
            Correctanswer = quiz.Correctanswer;
            num.Maximum = Answers.Count;
            num.Minimum = 0;         
            
            tbQuestion.Text = Question;
            RenewAnswerList();
        }



        private void InitialaizeSolfegio(Subject subj)
        {
            if (subj == Subject.Musichistory) panel1.Visible = false;

            foreach (string s in notes)
            {
                cb1.Items.Add(s);
                cb2.Items.Add(s);
                cb3.Items.Add(s);
                cb4.Items.Add(s);
                cb5.Items.Add(s);
            }
            Pitches = new List<int>()
            { -1, -1, -1, -1, -1 };

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[0] = cb1.SelectedIndex - 1;
        }
        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[1] = cb2.SelectedIndex - 1;
        }
        private void cb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[2] = cb3.SelectedIndex - 1;
        }
        private void cb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[3] = cb4.SelectedIndex - 1;
        }
        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[4] = cb5.SelectedIndex - 1;
        }



        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            Question = tbQuestion.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Correctanswer = (int)num.Value;
            DisplayCorrectAnswer();
        }

        private void DisplayCorrectAnswer()
        {
            if (Correctanswer > 0)
                tbCorrectAnswer.Text = Answers[Correctanswer - 1];
            else
                tbCorrectAnswer.Text = "NO ANSWER SET!";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            /*string txt = "";
            foreach (int i in Pitches)
            {
                txt += i.ToString() + " ";
            }
            MessageBox.Show(txt);*/
            var quiz = new SQuiz(Pitches);
            /*MessageBox.Show(quiz.GetFrequences());*/
            quiz.Play();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var w = new AddAnswerForm(Question);
            w.ShowDialog();
            if (w.DialogResult == DialogResult.OK)
            {
                Answers.Add(w.Answer);
                RenewAnswerList();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = lbAnswers.SelectedIndex;
            try
            {
                Answers.RemoveAt(index);
                RenewAnswerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenewAnswerList()
        {
            int i = 1;
            num.Maximum = Answers.Count;
            DisplayCorrectAnswerNumber();

            lbAnswers.Items.Clear();
            foreach (var answer in Answers)
            {
                string temp = $"{i}. {answer}";
                lbAnswers.Items.Add(temp);
                i++;
            }
            DisplayCorrectAnswer();
        }

        private void DisplayCorrectAnswerNumber()
        {
            try
            {
                num.Value = Correctanswer;
            }
            catch { Correctanswer = 0; num.Value = 0; }
        }
    }
}