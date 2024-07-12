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

        public LogInForm()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            ifnew = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            ifnew = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
