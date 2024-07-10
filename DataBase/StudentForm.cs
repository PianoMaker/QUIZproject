using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class StudentForm : Form
    {
        public int S { get; set; }
        public int MH { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public StudentForm(bool admin = true)
        {
            InitializeComponent();
            if (!admin)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
            Name = tbName.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            tbSurName.BackColor = Color.White;
            SurName = tbSurName.Text;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            MH = (int)numericUpDown1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            S = (int)numericUpDown2.Value;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(SurName))
            { tbName.BackColor = Color.Pink; tbSurName.BackColor = Color.Pink; }
            else if (string.IsNullOrEmpty(Name))
                tbName.BackColor = Color.Pink;
            else if (string.IsNullOrEmpty(SurName))
                tbSurName.BackColor = Color.Pink;
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
