namespace QUIZproject
{
    partial class QuizForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizForm));
            llbQuestions = new ListBox();
            lbAnswers = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            lblQ = new Label();
            rbMH = new RadioButton();
            rbS = new RadioButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            btnSave = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // llbQuestions
            // 
            llbQuestions.FormattingEnabled = true;
            llbQuestions.Location = new Point(46, 66);
            llbQuestions.Name = "llbQuestions";
            llbQuestions.Size = new Size(485, 364);
            llbQuestions.TabIndex = 0;
            // 
            // lbAnswers
            // 
            lbAnswers.FormattingEnabled = true;
            lbAnswers.Location = new Point(574, 66);
            lbAnswers.Name = "lbAnswers";
            lbAnswers.Size = new Size(396, 184);
            lbAnswers.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 11F);
            btnAdd.Location = new Point(574, 289);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 11F);
            btnDelete.Location = new Point(572, 345);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 40);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 11F);
            btnEdit.Location = new Point(739, 288);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(94, 40);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lblQ
            // 
            lblQ.AutoSize = true;
            lblQ.BackColor = Color.Transparent;
            lblQ.Location = new Point(48, 23);
            lblQ.Name = "lblQ";
            lblQ.Size = new Size(72, 20);
            lblQ.TabIndex = 5;
            lblQ.Text = "questions";
            // 
            // rbMH
            // 
            rbMH.AutoSize = true;
            rbMH.Font = new Font("Segoe UI", 12F);
            rbMH.Location = new Point(330, 23);
            rbMH.Name = "rbMH";
            rbMH.Size = new Size(170, 32);
            rbMH.TabIndex = 6;
            rbMH.TabStop = true;
            rbMH.Text = "Історія Музики";
            rbMH.UseVisualStyleBackColor = true;
            rbMH.CheckedChanged += rbMH_CheckedChanged;
            // 
            // rbS
            // 
            rbS.AutoSize = true;
            rbS.Font = new Font("Segoe UI", 12F);
            rbS.Location = new Point(506, 23);
            rbS.Name = "rbS";
            rbS.Size = new Size(145, 32);
            rbS.TabIndex = 7;
            rbS.TabStop = true;
            rbS.Text = "Сольфеджіо";
            rbS.UseVisualStyleBackColor = true;
            rbS.CheckedChanged += rbS_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1014, 28);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem, exportToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(137, 26);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importMenu_Click;
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(137, 26);
            exportToolStripMenuItem.Text = "Export";
            exportToolStripMenuItem.Click += exportMenu_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(137, 26);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeMenu_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 11F);
            btnSave.Location = new Point(739, 345);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 40);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1014, 450);
            Controls.Add(btnSave);
            Controls.Add(rbS);
            Controls.Add(rbMH);
            Controls.Add(lblQ);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lbAnswers);
            Controls.Add(llbQuestions);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "QuizForm";
            Text = "QuizForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox llbQuestions;
        private ListBox lbAnswers;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Label lblQ;
        private RadioButton rbMH;
        private RadioButton rbS;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Button btnSave;
    }
}