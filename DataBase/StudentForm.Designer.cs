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
            tbOK = new Button();
            btnCancel = new Button();
            tbEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            tbPassword = new TextBox();
            bTest = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Font = new Font("Segoe UI", 11F);
            tbName.Location = new Point(56, 51);
            tbName.Name = "tbName";
            tbName.PlaceholderText = "FirstName";
            tbName.Size = new Size(187, 32);
            tbName.TabIndex = 0;
            tbName.TextChanged += textBox1_TextChanged;
            // 
            // tbSurName
            // 
            tbSurName.Font = new Font("Segoe UI", 11F);
            tbSurName.Location = new Point(262, 51);
            tbSurName.Name = "tbSurName";
            tbSurName.PlaceholderText = "Surname";
            tbSurName.Size = new Size(184, 32);
            tbSurName.TabIndex = 1;
            tbSurName.TextChanged += textBox2_TextChanged;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Font = new Font("Segoe UI", 11F);
            numericUpDown1.Location = new Point(595, 106);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(69, 32);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Font = new Font("Segoe UI", 11F);
            numericUpDown2.Location = new Point(471, 106);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(78, 32);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.ValueChanged += numericUpDown2_ValueChanged;
            // 
            // tbOK
            // 
            tbOK.Font = new Font("Segoe UI", 11F);
            tbOK.Location = new Point(227, 165);
            tbOK.Name = "tbOK";
            tbOK.Size = new Size(107, 36);
            tbOK.TabIndex = 6;
            tbOK.Text = "OK";
            tbOK.UseVisualStyleBackColor = true;
            tbOK.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 11F);
            btnCancel.Location = new Point(390, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(106, 36);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tbEmail
            // 
            tbEmail.Font = new Font("Segoe UI", 11F);
            tbEmail.Location = new Point(56, 106);
            tbEmail.Name = "tbEmail";
            tbEmail.PlaceholderText = "E-mail";
            tbEmail.Size = new Size(244, 32);
            tbEmail.TabIndex = 2;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(470, 58);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 8;
            label1.Text = "Theory";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(595, 58);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 9;
            label2.Text = "Solfegio";
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.Location = new Point(321, 105);
            tbPassword.Name = "tbPassword";
            tbPassword.PlaceholderText = "Password";
            tbPassword.Size = new Size(125, 32);
            tbPassword.TabIndex = 5;
            tbPassword.TextChanged += tbPassword_TextChanged;
            // 
            // bTest
            // 
            bTest.BackColor = Color.IndianRed;
            bTest.Location = new Point(56, 171);
            bTest.Name = "bTest";
            bTest.Size = new Size(94, 29);
            bTest.TabIndex = 10;
            bTest.Text = "test";
            bTest.UseVisualStyleBackColor = false;
            bTest.Click += bTest_Click;
            // 
            // StudentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(710, 249);
            Controls.Add(bTest);
            Controls.Add(tbPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbEmail);
            Controls.Add(btnCancel);
            Controls.Add(tbOK);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(tbSurName);
            Controls.Add(tbName);
            Name = "StudentForm";
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
        private Button tbOK;
        private Button btnCancel;
        private TextBox tbEmail;
        private Label label1;
        private Label label2;
        private TextBox tbPassword;
        private Button bTest;
    }
}