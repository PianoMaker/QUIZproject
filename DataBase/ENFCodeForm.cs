using DbLayer;
using Models;
using System.Data;
using System.Diagnostics;
using System.DirectoryServices;

namespace DataBase
{
    public partial class ENFCodeForm : Form
    {

        private StudentsDbContextFactory factory;
        private string[] args;
        private int Mhquestions { get; set; }
        private int Squestions { get; set; }

        private int MaxMark {  get; set; }

        public ENFCodeForm(StudentsDbContextFactory factory)
        {
            InitializeComponent();
            this.factory = factory;
            args = new string[] { };            
            MaxMark = 12;
            CheckDataBase();
            dgv.CellEndEdit += new DataGridViewCellEventHandler(dgv_CellEndEdit);
        }

        public ENFCodeForm(StudentsDbContextFactory factory, int mh_question_count, int s_questions_count)
        {
            InitializeComponent();
            this.factory = factory;
            args = new string[] { };
            Mhquestions = mh_question_count;
            Squestions = s_questions_count;
            MaxMark = 12;
            CheckDataBase();
            dgv.CellEndEdit += new DataGridViewCellEventHandler(dgv_CellEndEdit);
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDatabase();
        }

        private void ShowDatabase()
        {
            using (var db = factory.CreateDbContext(args))
            {
                UpdateMarks();
                var students = db.Students.ToList();
                dgv.DataSource = students;
            }
        }

        public void UpdateMarks()
        {
            //MessageBox.Show($"Upd marks, {Mhquestions} : {Squestions}");
            using (var db = factory.CreateDbContext(args))
            {
                foreach (var st in db.Students)
                {
                    if (st.T_answered == Mhquestions && Mhquestions > 0)
                        st.MH_mark = st.T_correctAnswers * MaxMark / Mhquestions;
                    if (st.S_answered == Squestions && Squestions > 0)
                        st.S_mark = st.S_correctAnswers * MaxMark / Squestions;                   
                }
                db.SaveChanges();
            }
        }


        private void BtnCreate_Click(object sender, EventArgs e)
        {
            using (var db = factory.CreateDbContext(args))
            {
                if (!DatabaseExists())
                {
                    db.Create();
                    CheckDataBase();
                }
                else ShowDatabase();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (var db = factory.CreateDbContext(args))
            {

                db.Delete();
                CheckDataBase();
            }
        }

        private void BtnJson_Click(object sender, EventArgs e)
        {

            string jsonFileName = "appsettings.json";
            string jsonFilePath = Path.Combine(Application.StartupPath, jsonFileName);

            if (File.Exists(jsonFilePath)) ShowJson(jsonFilePath);
            else CreateJson();

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var window = new StudentForm();
            if (window.ShowDialog() == DialogResult.OK)
                AddStudent(window.FirstName, window.SurName, window.Email, window.Password, window.S, window.MH);

        }




        private void AddStudent(string name, string surname, string email, string password, int s, int mh)
        {
            using (var db = factory.CreateDbContext(args))
            {

                var existingStudent = db.Students.FirstOrDefault(s => s.Email == email);

                if (existingStudent != null)
                {
                    MessageBox.Show("Студент з таким email вже існує.");
                    return;
                }
                else
                {
                    var student = new Student()
                    {
                        Name = name,
                        SurName = surname,
                        Email = email,
                        Password = password,
                        S_mark = s,
                        MH_mark = mh
                    };

                    db.Students.Add(student);
                    db.SaveChanges();
                    ShowDatabase();
                }

            }
        }

        private void CheckDataBase()
        {
            if (DatabaseExists())
            {
                btnDelete.Visible = true;
                btnCreate.Text = "Show DataBase";
            }
            else
            {
                btnDelete.Visible = false;
                btnCreate.Text = "Create DataBase";
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
                RemoveStudent();
            else MessageBox.Show("Select Student to remove");
        }

        private void RemoveStudent()
        {
            using (var db = factory.CreateDbContext(args))
            {
                int selectedStudentId = Convert.ToInt32(dgv.SelectedRows[0].Cells["Id"].Value);
                var studentToRemove = db.Students.FirstOrDefault(s => s.Id == selectedStudentId);
                if (studentToRemove != null)
                {

                    db.Students.Remove(studentToRemove);
                    db.SaveChanges();
                    MessageBox.Show("Student removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowDatabase();
                }
                else
                {
                    MessageBox.Show("Selected student not found in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public bool DatabaseExists()
        {
            using (var db = factory.CreateDbContext(args))
            {
                return db.Database.CanConnect();
            }
        }

        private static void ShowJson(string jsonFilePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                MessageBox.Show($"JSON content:\n\n{jsonContent}", "JSON File Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void CreateJson()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.Title = "Create New appsettings.json";
                saveFileDialog.InitialDirectory = Application.StartupPath;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string newFilePath = saveFileDialog.FileName;

                    try
                    {

                        string userInput = "";

                        using (StreamWriter sw = new StreamWriter(newFilePath))
                        {
                            sw.Write(userInput);
                        }

                        Process.Start("notepad.exe", newFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating JSON file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Operation cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Переконайтеся, що редагування було по дійсній клітинці
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;
                if (dgv != null)
                {
                    // Отримуємо нове значення з клітинки
                    var newValue = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    using (var db = factory.CreateDbContext(args))
                    {

                        int studentId = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value);
                        var student = db.Students.FirstOrDefault(s => s.Id == studentId);
                        if (student != null)
                        {
                            string columnName = dgv.Columns[e.ColumnIndex].Name;

                            var property = typeof(Student).GetProperty(columnName);
                            if (property != null)
                            {
                                var convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                                property.SetValue(student, convertedValue);
                                db.SaveChanges(); // Зберігаємо зміни в базі даних

                            }
                        }
                    }
                }
            }
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            string info;

            using (var db = factory.CreateDbContext(args))
            {
                int totalStudents = db.Students.Count();
                if (totalStudents > 0)
                {

                    double averageMH = db.Students.Where(s => s.MH_mark.HasValue).Any()
                        ? db.Students.Where(s => s.MH_mark.HasValue).Average(s => s.MH_mark.Value)
                        : 0;

                    double averageS = db.Students.Where(s => s.S_mark.HasValue).Any()
                        ? db.Students.Where(s => s.S_mark.HasValue).Average(s => s.S_mark.Value)
                        : 0;

                    info = $"Загальна кількість студентів: {totalStudents}\n";

                    if (averageMH > 0) info += $"Середній бал з Історії музики: {averageMH:F2}\n";

                    if (averageS > 0) info += $"Середній бал з Сольфеджіо: {averageS:F2}\n";

                }
                else info = "Студенти ще не зареєструвались";
            }

            MessageBox.Show(info, "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MaxMark = (int)numericUpDown1.Value;
            UpdateMarks();
        }
    }
}

