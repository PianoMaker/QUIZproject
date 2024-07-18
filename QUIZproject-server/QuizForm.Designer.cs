using System.Windows.Forms;
using System;
namespace QuizHolder
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
            lbQuestions = new ListBox();
            lbAnswers = new ListBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            lblQ = new Label();
            rbT = new RadioButton();
            rbS = new RadioButton();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            btnSave = new Button();
            btnPlay = new Button();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // lbQuestions
            // 
            lbQuestions.FormattingEnabled = true;
            lbQuestions.Location = new Point(46, 106);
            lbQuestions.Name = "lbQuestions";
            lbQuestions.Size = new Size(485, 324);
            lbQuestions.TabIndex = 0;
            lbQuestions.SelectedIndexChanged += lbQuestions_SelectedIndexChanged;
            // 
            // lbAnswers
            // 
            lbAnswers.FormattingEnabled = true;
            lbAnswers.Location = new Point(710, 106);
            lbAnswers.Name = "lbAnswers";
            lbAnswers.Size = new Size(275, 144);
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
            lblQ.Font = new Font("Segoe UI", 11F);
            lblQ.Location = new Point(46, 60);
            lblQ.Name = "lblQ";
            lblQ.Size = new Size(0, 25);
            lblQ.TabIndex = 5;
            // 
            // rbT
            // 
            rbT.AutoSize = true;
            rbT.BackColor = Color.Transparent;
            rbT.Font = new Font("Segoe UI", 12F);
            rbT.Location = new Point(330, 23);
            rbT.Name = "rbT";
            rbT.Size = new Size(92, 32);
            rbT.TabIndex = 6;
            rbT.TabStop = true;
            rbT.Text = "Теорія";
            rbT.UseVisualStyleBackColor = false;
            rbT.CheckedChanged += rbT_CheckedChanged;
            // 
            // rbS
            // 
            rbS.AutoSize = true;
            rbS.BackColor = Color.Transparent;
            rbS.Font = new Font("Segoe UI", 12F);
            rbS.Location = new Point(506, 23);
            rbS.Name = "rbS";
            rbS.Size = new Size(145, 32);
            rbS.TabIndex = 7;
            rbS.TabStop = true;
            rbS.Text = "Сольфеджіо";
            rbS.UseVisualStyleBackColor = false;
            rbS.CheckedChanged += rbS_CheckedChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1043, 24);
            menuStrip1.TabIndex = 10;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(32, 19);
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(32, 19);
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(32, 19);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(32, 19);
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
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 12F);
            btnPlay.Location = new Point(574, 106);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 40);
            btnPlay.TabIndex = 11;
            btnPlay.Text = "PLAY";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(574, 170);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(94, 80);
            pictureBox.TabIndex = 12;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // QuizForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1043, 450);
            Controls.Add(pictureBox);
            Controls.Add(btnPlay);
            Controls.Add(btnSave);
            Controls.Add(rbS);
            Controls.Add(rbT);
            Controls.Add(lblQ);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(lbAnswers);
            Controls.Add(lbQuestions);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "QuizForm";
            Text = "QuizForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private ListBox lbQuestions;
        private ListBox lbAnswers;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Label lblQ;
        private RadioButton rbT;
        private RadioButton rbS;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Button btnSave;
        private Button btnPlay;
        private PictureBox pictureBox;
    }
}