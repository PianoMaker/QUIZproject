namespace DataBase
{
    partial class StudentForm
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
            tbName = new TextBox();
            tbSurName = new TextBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            button1 = new Button();
            btnCancel = new Button();
            tbEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(56, 54);
            tbName.Name = "tbName";
            tbName.PlaceholderText = "FirstName";
            tbName.Size = new Size(166, 27);
            tbName.TabIndex = 0;
            tbName.TextChanged += textBox1_TextChanged;
            // 
            // tbSurName
            // 
            tbSurName.Location = new Point(240, 54);
            tbSurName.Name = "tbSurName";
            tbSurName.PlaceholderText = "Surname";
            tbSurName.Size = new Size(184, 27);
            tbSurName.TabIndex = 1;
            tbSurName.TextChanged += textBox2_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(595, 106);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(69, 27);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(471, 106);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(78, 27);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // button1
            // 
            button1.Location = new Point(240, 165);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 5;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(390, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(56, 106);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "E-mail";
            tbEmail.Size = new Size(368, 27);
            tbEmail.TabIndex = 2;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(470, 58);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 7;
            label1.Text = "Music History";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(595, 58);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 8;
            label2.Text = "Solfegio";
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 220);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbEmail);
            Controls.Add(btnCancel);
            Controls.Add(button1);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(tbSurName);
            Controls.Add(tbName);
            FirstName = "StudentForm";
            Text = "EditStudentForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private TextBox tbSurName;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Button button1;
        private Button btnCancel;
        private TextBox tbEmail;
        private Label label1;
        private Label label2;
    }
}