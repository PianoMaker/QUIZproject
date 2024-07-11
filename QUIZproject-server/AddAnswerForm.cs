using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZproject_server
{
    public partial class AddAnswerForm : Form
    {
        public string Answer { get; set; }
        public AddAnswerForm()
        {
            InitializeComponent();
        }

        public AddAnswerForm(string question)
        {
            InitializeComponent();
            lbQuestion.Text = question;
            textBox1.Text = Answer;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Answer = textBox1.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Answer = textBox1.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
