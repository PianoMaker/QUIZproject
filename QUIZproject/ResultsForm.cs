using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUIZproject
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ExportMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("exporting");
        }

        private void CloseMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
