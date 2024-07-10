using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace QUIZproject
{
    public partial class QuizEditForm : Form
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

        public QuizEditForm(Subject subj)
        {
            InitializeComponent();
            Answers = new List<string>();
            num.Maximum = Answers.Count;
            InitialaizeSolfegio(subj);
            Pitches = new List<int>()
            { -1, -1, -1, -1, -1 };
        }
        public QuizEditForm(Subject subj, Quiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            Correctanswer = quiz.Correctanswer;
            num.Maximum = Answers.Count;
            InitialaizeSolfegio(subj);
            Pitches = new List<int>()
            { -1, -1, -1, -1, -1 };
        }

        public QuizEditForm(Subject subj, SQuiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            Pitches = quiz.Pitches;
            Correctanswer = quiz.Correctanswer;
            num.Maximum = Answers.Count;
            InitialaizeSolfegio(subj);
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

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Question = textBox1.Text;
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
    }
}
