namespace QuizHolder
{
    public partial class AddAnswerForm : Form
    {
        public string Answer { get; set; }
        public AddAnswerForm()
        {
            InitializeComponent();
            ButtonSubmitEnable();
        }

        public AddAnswerForm(string question)
        {
            InitializeComponent();
            lbQuestion.Text = question;
            textBox1.Text = Answer;
            ButtonSubmitEnable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Answer = textBox1.Text;
            ButtonSubmitEnable();
        }

        private void ButtonSubmitEnable()
        {
            if (string.IsNullOrEmpty(Answer))
                btnSubmit.Enabled = false; 
            else btnSubmit.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Answer = textBox1.Text;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
