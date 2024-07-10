namespace QUIZproject
{
    partial class QuizEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizEditForm));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            listBox1 = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            panel1 = new Panel();
            cb5 = new ComboBox();
            cb4 = new ComboBox();
            cb3 = new ComboBox();
            cb2 = new ComboBox();
            cb1 = new ComboBox();
            brnSave = new Button();
            btnCancel = new Button();
            num = new NumericUpDown();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(54, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(629, 27);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(54, 354);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(629, 27);
            textBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(54, 129);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(629, 104);
            listBox1.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11F);
            btnAdd.Location = new Point(220, 255);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 40);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Location = new Point(390, 255);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 40);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(202, 255, 212);
            panel1.Controls.Add(cb5);
            panel1.Controls.Add(cb4);
            panel1.Controls.Add(cb3);
            panel1.Controls.Add(cb2);
            panel1.Controls.Add(cb1);
            panel1.Location = new Point(98, 62);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 45);
            panel1.TabIndex = 5;
            // 
            // cb5
            // 
            cb5.FormattingEnabled = true;
            cb5.Location = new Point(420, 5);
            cb5.Name = "cb5";
            cb5.Size = new Size(87, 28);
            cb5.TabIndex = 14;
            // 
            // cb4
            // 
            cb4.FormattingEnabled = true;
            cb4.Location = new Point(320, 5);
            cb4.Name = "cb4";
            cb4.Size = new Size(87, 28);
            cb4.TabIndex = 13;
            // 
            // cb3
            // 
            cb3.FormattingEnabled = true;
            cb3.Location = new Point(220, 5);
            cb3.Name = "cb3";
            cb3.Size = new Size(87, 28);
            cb3.TabIndex = 12;
            // 
            // cb2
            // 
            cb2.FormattingEnabled = true;
            cb2.Location = new Point(120, 5);
            cb2.Name = "cb2";
            cb2.Size = new Size(87, 28);
            cb2.TabIndex = 11;
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
            // brnSave
            // 
            brnSave.Font = new Font("Segoe UI", 12F);
            brnSave.Location = new Point(164, 387);
            brnSave.Name = "brnSave";
            brnSave.Size = new Size(150, 45);
            brnSave.TabIndex = 6;
            brnSave.Text = "Save";
            brnSave.UseVisualStyleBackColor = true;
            brnSave.Click += btnSave_Click;
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
            // numericUpDown1
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
            // QuizEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(755, 450);
            Controls.Add(label1);
            Controls.Add(num);
            Controls.Add(btnCancel);
            Controls.Add(brnSave);
            Controls.Add(panel1);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(listBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "QuizEditForm";
            Text = "QuizEditForm";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private ListBox listBox1;
        private Button btnAdd;
        private Button btnDelete;
        private Panel panel1;
        private ComboBox cb5;
        private ComboBox cb4;
        private ComboBox cb3;
        private ComboBox cb2;
        private ComboBox cb1;
        private Button brnSave;
        private Button btnCancel;
        private NumericUpDown num;
        private Label label1;
    }
}