using DataBase;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZ_client_1
{
    public partial class LogInForm : Form
    {
        public bool ifnew { get; set; }
        private string email;
        private string password;
        public StudentLogin? Login { get; set; }

        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email))
            {
                tbEmail.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                tbPassword.BackColor = Color.Pink;
                return;
            }

            ifnew = false;
            Student st = new();
            st.Password = password;
            st.Email = email;
            Login = new StudentLogin(st, false);            
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ifnew = true;
            Login = CreateProfile();
            DialogResult = DialogResult.OK;
            Close();
        }


        private StudentLogin? CreateProfile()
        {
            var window = new StudentForm(false);
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                var student = new Student()
                {
                    Name = window.FirstName,
                    SurName = window.SurName,
                    Email = window.Email,
                    Password = window.Password
                };
                return new StudentLogin(student, true);
            }
            else return null;

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            tbEmail.BackColor = Color.White;
            email = tbEmail.Text;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            tbPassword.BackColor = Color.White;
            password = tbPassword.Text;
        }
    }


}
