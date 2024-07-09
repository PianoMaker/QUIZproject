using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace QUIZproject
{
    public enum Subject { Musichistory, Solfegio }
    public partial class QuizForm : Form
    {
        
        Subject subj;
        List<Quiz> mh_questions;
        List<SQuiz> s_questions;
        public QuizForm()
        {
            InitializeComponent();
            rbMH.Checked = true;
            rbMH.BackColor = Color.LightGreen;
            subj = Subject.Musichistory;
        }

        private void rbS_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void rbMH_CheckedChanged(object sender, EventArgs e)
        {
            ChooseSubject();
        }

        private void ChooseSubject()
        {
            if (rbS.Checked)
            {
                subj = Subject.Solfegio;
                rbMH.BackColor = Color.Transparent;
                rbS.BackColor = Color.LightGreen;
            }
            else if (rbMH.Checked)
            {
                subj = Subject.Musichistory;
                rbMH.BackColor = Color.LightGreen;
                rbS.BackColor = Color.Transparent;
            }
        }

        private void closeMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exportMenu_Click(object sender, EventArgs e)
        {
            ExportQuiz();

        }

        private void ExportQuiz()
        {
            MessageBox.Show("Todo: export quiz");
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

        private void AddQuestion()
        {
            throw new NotImplementedException();
        }



        private void EditQuestion()
        {
            var window = new QuizEditForm(subj);
        }



        private void DeleteQuestion()
        {
            throw new NotImplementedException();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
