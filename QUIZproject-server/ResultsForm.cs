using System.Data;
using DataBase;
using DbLayer;

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

            var window = new AdminForm(factory);
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
                    s.T_mark,
                    s.S_mark
                }).ToList();
            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
