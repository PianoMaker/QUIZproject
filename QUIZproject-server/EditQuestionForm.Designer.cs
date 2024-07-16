namespace QUIZproject_server
{
    partial class EditQuestionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditQuestionForm));
            tbQuestion = new TextBox();
            tbCorrectAnswer = new TextBox();
            lbAnswers = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            btnPlay = new Button();
            cb5 = new ComboBox();
            cb4 = new ComboBox();
            cb3 = new ComboBox();
            cb2 = new ComboBox();
            cb1 = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            num = new NumericUpDown();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num).BeginInit();
            SuspendLayout();
            // 
            // tbQuestion
            // 
            tbQuestion.Location = new Point(54, 19);
            tbQuestion.Name = "tbQuestion";
            tbQuestion.PlaceholderText = "Answer";
            tbQuestion.Size = new Size(629, 27);
            tbQuestion.TabIndex = 0;
            tbQuestion.TextChanged += tbQuestion_TextChanged;
            // 
            // tbCorrectAnswer
            // 
            tbCorrectAnswer.Location = new Point(54, 354);
            tbCorrectAnswer.Name = "tbCorrectAnswer";
            tbCorrectAnswer.PlaceholderText = "Correct Answer";
            tbCorrectAnswer.Size = new Size(629, 27);
            tbCorrectAnswer.TabIndex = 1;
            // 
            // lbAnswers
            // 
            lbAnswers.FormattingEnabled = true;
            lbAnswers.Location = new Point(54, 129);
            lbAnswers.Name = "lbAnswers";
            lbAnswers.Size = new Size(629, 104);
            lbAnswers.TabIndex = 2;
            lbAnswers.SelectedIndexChanged += lbAnswers_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11F);
            btnAdd.Location = new Point(164, 255);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add Answer";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Location = new Point(390, 255);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete Answer";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(202, 255, 212);
            panel1.Controls.Add(btnPlay);
            panel1.Controls.Add(cb5);
            panel1.Controls.Add(cb4);
            panel1.Controls.Add(cb3);
            panel1.Controls.Add(cb2);
            panel1.Controls.Add(cb1);
            panel1.Location = new Point(54, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(629, 45);
            panel1.TabIndex = 5;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(520, 5);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(87, 28);
            btnPlay.TabIndex = 15;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // cb5
            // 
            cb5.FormattingEnabled = true;
            cb5.Location = new Point(420, 5);
            cb5.Name = "cb5";
            cb5.Size = new Size(87, 28);
            cb5.TabIndex = 14;
            cb5.SelectedIndexChanged += cb5_SelectedIndexChanged;
            // 
            // cb4
            // 
            cb4.FormattingEnabled = true;
            cb4.Location = new Point(320, 5);
            cb4.Name = "cb4";
            cb4.Size = new Size(87, 28);
            cb4.TabIndex = 13;
            cb4.SelectedIndexChanged += cb4_SelectedIndexChanged;
            // 
            // cb3
            // 
            cb3.FormattingEnabled = true;
            cb3.Location = new Point(220, 5);
            cb3.Name = "cb3";
            cb3.Size = new Size(87, 28);
            cb3.TabIndex = 12;
            cb3.SelectedIndexChanged += cb3_SelectedIndexChanged;
            // 
            // cb2
            // 
            cb2.FormattingEnabled = true;
            cb2.Location = new Point(120, 5);
            cb2.Name = "cb2";
            cb2.Size = new Size(87, 28);
            cb2.TabIndex = 11;
            cb2.SelectedIndexChanged += cb2_SelectedIndexChanged;
            // 
            // cb1
            // 
            cb1.FormattingEnabled = true;
            cb1.Location = new Point(20, 5);
            cb1.Name = "cb1";
            cb1.Size = new Size(87, 28);
            cb1.TabIndex = 10;
            cb1.SelectedIndexChanged += cb1_SelectedIndexChanged;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 12F);
            btnSave.Location = new Point(164, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(390, 388);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // num
            // 
            num.Location = new Point(390, 309);
            num.Name = "num";
            num.Size = new Size(94, 27);
            num.TabIndex = 8;
            num.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(181, 316);
            label1.Name = "label1";
            label1.Size = new Size(133, 20);
            label1.TabIndex = 9;
            label1.Text = "Set correct answer:";
            // 
            // EditQuestionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(755, 450);
            Controls.Add(label1);
            Controls.Add(num);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(panel1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lbAnswers);
            Controls.Add(tbCorrectAnswer);
            Controls.Add(tbQuestion);
            Name = "EditQuestionForm";
            Text = "EditQuestionForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbQuestion;
        private TextBox tbCorrectAnswer;
        private ListBox lbAnswers;
        private Button btnAdd;
        private Button btnDelete;
        private Panel panel1;
        private ComboBox cb5;
        private ComboBox cb4;
        private ComboBox cb3;
        private ComboBox cb2;
        private ComboBox cb1;
        private Button btnSave;
        private Button btnCancel;
        private NumericUpDown num;
        private Label label1;
        private Button btnPlay;
    }
}