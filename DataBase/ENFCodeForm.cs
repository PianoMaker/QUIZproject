using DbLayer;
using Models;
using System.Diagnostics;
using System.DirectoryServices;

namespace DataBase
{
    public partial class ENFCodeForm : Form
    {

        private StudentsDbContextFactory factory;
        private string[] args;


        public ENFCodeForm(StudentsDbContextFactory factory)
        {
            InitializeComponent();
            this.factory = factory;
            args = new string[] { };
            CheckDataBase();
        }

        
        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowDatabase();
        }

        private void ShowDatabase()
        {
            using (var db = factory.CreateDbContext(args))
            {
                var students = db.Students.ToList();
                dgv.DataSource = students;
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
            if(window.ShowDialog() == DialogResult.OK)                
            AddStudent(window.FirstName, window.SurName, window.Email, window.Password, window.S, window.MH);

        }


        private void AddStudent(string name, string surname, string email, string password, int s, int mh)
        {
            using (var db = factory.CreateDbContext(args))
            {

                var existingStudent = db.Students.FirstOrDefault(s => s.Email == email);

                if (existingStudent != null)
                {
                    MessageBox.Show("������� � ����� email ��� ����.");
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
                if (studentToRemove != null)                {
                    
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
    }
}
