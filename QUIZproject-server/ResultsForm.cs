using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBase;
using DbLayer;
using Models;
using System.Diagnostics;

namespace QUIZproject_server
{
    public partial class ResultsForm : Form
    {
        private StudentsDbContextFactory factory;
        public ResultsForm()
        {
            InitializeComponent();
            factory = new StudentsDbContextFactory();
            try
            {
                ShowResults();
            }
            catch
            {
                dgv.BackgroundColor = Color.Pink;
            }
        }

        private void AdminTools()
        {

            var window = new ENFCodeForm(factory);
            window.ShowDialog();
        }

        private void ShowResults()
        {
            string[] args = null;
            using (var db = factory.CreateDbContext(args))
            {
                var students = db.Students.ToList();
                dgv.DataSource = students.Select(s => new
                {
                    s.Name,
                    s.SurName,
                    s.MH_mark,
                    s.S_mark
                }).ToList();
            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
