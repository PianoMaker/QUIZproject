using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class StudentForm : Form
    {
        public int S { get; set; }
        public int MH { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public StudentForm(bool admin = true)
        {
            InitializeComponent();
            if (!admin)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        public StudentForm(string email, string name, string surname, bool admin = true)
        {
            InitializeComponent();
            if (!admin)
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
            Email = email;
            FirstName = name;
            SurName = surname;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbName.BackColor = Color.White;
            FirstName = tbName.Text;
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
            string txt; bool ok = true;
            if (string.IsNullOrEmpty(Email))
            { tbEmail.BackColor = Color.Pink; ok = false; }
            if (string.IsNullOrEmpty(FirstName))
            { tbName.BackColor = Color.Pink; ok = false; }
            if (string.IsNullOrEmpty(SurName))
            { tbSurName.BackColor = Color.Pink; ok = false; }
            if (!EmailIsEligible(out txt))
            {
                tbEmail.BackColor = Color.Pink;
                MessageBox.Show(txt, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ok = false;
            }
            if (ok == true)
            {

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool EmailIsEligible(out string txt)
        {
            bool ok = true;
            txt = "";
            if (!Email.Contains("@"))
            {
                txt += "\nEmail needs to contain @";
                ok = false;
            }

            int atIndex = Email.IndexOf("@");
            if (atIndex == -1 || Email.Substring(atIndex).IndexOf(".") == -1)
            {
                txt += "\nEmail needs to contain a valid domain part (e.g., domain.com)";
                ok = false;
            }
            int lastDotIndex = Email.LastIndexOf(".");
            if (lastDotIndex != -1 && Email.Substring(lastDotIndex).Length < 3)
            {
                txt += "\nEmail needs to have a valid domain extension (e.g., .com, .org)";
                ok = false;
            }
            if (Email.Length > 320)
            {
                txt += "\nEmail is too long";
                ok = false;
            }

            if (Email.Any(c => c < 32 || c > 126 || !char.IsLetterOrDigit(c) && c != '@' && c != '.' && c != '_'))
            {
                txt += "\nEmail contains invalid characters";
                ok = false;
            }

            if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                txt += "\nEmail format is invalid";
                ok = false;
            }

            return ok;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            Email = tbEmail.Text;
            tbEmail.BackColor = Color.White;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Password = tbPassword.Text;
        }

        private void bTest_Click(object sender, EventArgs e)
        {
            Name = "test";
            tbName.Text = Name;
            SurName = "test";
            tbSurName.Text = SurName;
            Email = "test@test.com";
            tbEmail.Text = Email;
            Password = "testpassword";
            tbPassword.Text = Password;
            
        }
    }
}
