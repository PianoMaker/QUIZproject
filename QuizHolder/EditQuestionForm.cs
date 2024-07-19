using Models;

//EQF

namespace QuizHolder
{
    // DISCLAMER! Індекси відповідей від 0, але номери відповідей від 1!

    public partial class EditQuestionForm : Form
    {
        public Bitmap Picture { get; set; }
        public string Question { get; set; }

        public List<string> Answers { get; set; }

        public List<int> Pitches { get; set; }

        string[] notes =
        {
            " ",
            "a",
            "ais/b",
            "h",
            "c",
            "cis/des",
            "d",
            "dis/es",
            "e",
            "f",
            "fis",
            "g",
            "gis/as"
        };



        public int Correctanswer { get; set; }

        public EditQuestionForm(Subject subj)
        {
            InitializeComponent();
            Answers = new List<string>();
            num.Maximum = Answers.Count;
            num.Minimum = 0;
            IfSolfegio(subj);

            ButtonSendEnable();
        }
        public EditQuestionForm(Subject subj, TQuiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            Picture = quiz.Picture;
            num.Maximum = Answers.Count;
            num.Minimum = 0;
            Correctanswer = quiz.Correctanswer;
            num.Value = quiz.Correctanswer;
            tbQuestion.Text = Question;
            IfSolfegio(subj);
            RenewAnswerList();


        }

        public EditQuestionForm(Subject subj, SQuiz quiz)
        {
            InitializeComponent();
            Question = quiz.Question;
            Answers = quiz.Answers;
            Pitches = quiz.Pitches;
            Picture = quiz.Picture;
            IfSolfegio(subj);
            //MessageBox.Show($"count = {quiz.Pitches.Count}, 1={quiz.Pitches[0]}, 2={quiz.Pitches[3]}");
            try
            {
                cb1.SelectedIndex = quiz.Pitches[0] + 1;
                cb2.SelectedIndex = quiz.Pitches[1] + 1;
                cb3.SelectedIndex = quiz.Pitches[2] + 1;
                cb4.SelectedIndex = quiz.Pitches[3] + 1;
                cb5.SelectedIndex = quiz.Pitches[4] + 1;
            }
            catch (Exception Ex)
            {
                MessageBox.Show($"Impossible to proceed voicing\n{Ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Correctanswer = quiz.Correctanswer;
            num.Maximum = Answers.Count;
            num.Minimum = 0;

            tbQuestion.Text = Question;
            RenewAnswerList();
        }



        private void IfSolfegio(Subject subj)
        {
            
            if (subj == Subject.Theory) panel1.Visible = false;
            else
            {
                foreach (string s in notes)
                {
                    cb1.Items.Add(s);
                    cb2.Items.Add(s);
                    cb3.Items.Add(s);
                    cb4.Items.Add(s);
                    cb5.Items.Add(s);
                }
                Pitches = new List<int>()
                { -1, -1, -1, -1, -1 };
                Question = "Який акорд звучить?";
                tbQuestion.Text = Question;
            }

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[0] = cb1.SelectedIndex - 1;
        }
        private void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[1] = cb2.SelectedIndex - 1;
        }
        private void cb3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[2] = cb3.SelectedIndex - 1;
        }
        private void cb4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[3] = cb4.SelectedIndex - 1;
        }
        private void cb5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pitches[4] = cb5.SelectedIndex - 1;
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e)
        {
            Question = tbQuestion.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Correctanswer = (int)num.Value; // на 1 більше ніж індекс
            DisplayCorrectAnswer();
            ButtonSendEnable();


        }

        private void lbAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Correctanswer = lbAnswers.SelectedIndex + 1; // на 1 більше ніж індекс
            num.Value = Correctanswer;
            DisplayCorrectAnswer();
            ButtonSendEnable();
        }

        private void DisplayCorrectAnswer()
        {
            if (Correctanswer > 0)
                tbCorrectAnswer.Text = Answers[Correctanswer - 1]; // Correctanswer на 1 більше ніж індекс
            else
                tbCorrectAnswer.Text = "NO ANSWER SET!";
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

            var quiz = new SQuiz(Pitches);
            /*MessageBox.Show(quiz.GetFrequences());*/
            quiz.Play();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var w = new AddAnswerForm(Question);
            w.ShowDialog();
            if (w.DialogResult == DialogResult.OK)
            {
                Answers.Add(w.Answer);
                RenewAnswerList();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var index = lbAnswers.SelectedIndex;
            try
            {
                Answers.RemoveAt(index);
                RenewAnswerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenewAnswerList()
        {
            int i = 1;
            num.Maximum = Answers.Count;
            DisplayCorrectAnswerNumber();

            lbAnswers.Items.Clear();
            foreach (var answer in Answers)
            {
                string temp = $"{i}. {answer}";
                lbAnswers.Items.Add(temp);
                i++;
            }
            DisplayCorrectAnswer();
            ButtonSendEnable();
        }

        private void ButtonSendEnable()
        {
            if (Answers.Count < 2 || Correctanswer == 0) btnSave.Enabled = false;
            else btnSave.Enabled = true;
        }

        private void DisplayCorrectAnswerNumber()
        {
            try
            {
                num.Value = Correctanswer;
                ButtonSendEnable();
            }
            catch { Correctanswer = 0; num.Value = 0; }
        }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            await OpenImageAsync(pictureBox.Image);
        }

        private Task OpenImageAsync(Image image)
        {
            return Task.Run(() =>
            {
                Form fullSizeForm = new Form
                {
                    Text = "Full Size Image",
                    Width = image.Width,
                    Height = image.Height
                };

                PictureBox fullSizePictureBox = new PictureBox
                {
                    Image = image,
                    SizeMode = PictureBoxSizeMode.AutoSize,
                    Dock = DockStyle.Fill
                };

                fullSizeForm.Controls.Add(fullSizePictureBox);
                fullSizeForm.ShowDialog();
            });
        }

        
        private void btnImage_Click(object sender, EventArgs e)
        {
            
            Thread thread = new Thread(() =>
            {

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Picture = (Bitmap)Image.FromFile(openFileDialog.FileName);
                        pictureBox.Image = Picture;
                    }
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }
    }
}
