
namespace QUIZproject_server
{
    partial class ServerMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMainForm));
            tbIp = new TextBox();
            btnConnect = new Button();
            tbPort = new TextBox();
            btnEdit = new Button();
            lbClients = new ListBox();
            button1 = new Button();
            lbStatus = new Label();
            btnAdm = new Button();
            lbQ = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportQuizToolStripMenuItem = new ToolStripMenuItem();
            importQuizToolStripMenuItem = new ToolStripMenuItem();
            exportStudentsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbIp
            // 
            tbIp.Anchor = AnchorStyles.Top;
            tbIp.Font = new Font("Segoe UI", 12F);
            tbIp.Location = new Point(214, 33);
            tbIp.Name = "tbIp";
            tbIp.PlaceholderText = "IP";
            tbIp.Size = new Size(156, 34);
            tbIp.TabIndex = 0;
            tbIp.TextChanged += tbIp_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(56, 33);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 34);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // tbPort
            // 
            tbPort.Anchor = AnchorStyles.Top;
            tbPort.Font = new Font("Segoe UI", 12F);
            tbPort.Location = new Point(410, 33);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "port";
            tbPort.Size = new Size(125, 34);
            tbPort.TabIndex = 2;
            tbPort.TextChanged += tbPort_TextChanged;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(622, 31);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 36);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit Quiz";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lbClients
            // 
            lbClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbClients.FormattingEnabled = true;
            lbClients.Location = new Point(49, 123);
            lbClients.Name = "lbClients";
            lbClients.Size = new Size(485, 224);
            lbClients.TabIndex = 4;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(622, 114);
            button1.Name = "button1";
            button1.Size = new Size(130, 70);
            button1.TabIndex = 5;
            button1.Text = "Show Results";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnShowResult_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.BackColor = Color.Transparent;
            lbStatus.Font = new Font("Segoe UI", 10F);
            lbStatus.ForeColor = Color.DarkRed;
            lbStatus.Location = new Point(56, 77);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(124, 23);
            lbStatus.TabIndex = 6;
            lbStatus.Text = "Not connected";
            // 
            // btnAdm
            // 
            btnAdm.Anchor = AnchorStyles.Right;
            btnAdm.Font = new Font("Segoe UI", 12F);
            btnAdm.Location = new Point(622, 221);
            btnAdm.Name = "btnAdm";
            btnAdm.Size = new Size(130, 36);
            btnAdm.TabIndex = 7;
            btnAdm.Text = "Admin tools";
            btnAdm.UseVisualStyleBackColor = true;
            btnAdm.Click += btnAdm_Click;
            // 
            // lbQ
            // 
            lbQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbQ.AutoSize = true;
            lbQ.BackColor = Color.Transparent;
            lbQ.Font = new Font("Segoe UI", 11F);
            lbQ.Location = new Point(49, 375);
            lbQ.Name = "lbQ";
            lbQ.Size = new Size(229, 25);
            lbQ.TabIndex = 8;
            lbQ.Text = "No questnions are loaded";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportQuizToolStripMenuItem, importQuizToolStripMenuItem, exportStudentsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // exportQuizToolStripMenuItem
            // 
            exportQuizToolStripMenuItem.Name = "exportQuizToolStripMenuItem";
            exportQuizToolStripMenuItem.Size = new Size(196, 26);
            exportQuizToolStripMenuItem.Text = "Export Quiz";
            exportQuizToolStripMenuItem.Click += exportQuizToolStripMenuItem_Click;
            // 
            // importQuizToolStripMenuItem
            // 
            importQuizToolStripMenuItem.Name = "importQuizToolStripMenuItem";
            importQuizToolStripMenuItem.Size = new Size(196, 26);
            importQuizToolStripMenuItem.Text = "Import Quiz";
            importQuizToolStripMenuItem.Click += importQuizToolStripMenuItem_Click;
            // 
            // exportStudentsToolStripMenuItem
            // 
            exportStudentsToolStripMenuItem.Name = "exportStudentsToolStripMenuItem";
            exportStudentsToolStripMenuItem.Size = new Size(196, 26);
            exportStudentsToolStripMenuItem.Text = "Export Students";
            exportStudentsToolStripMenuItem.Click += exportStudentsToolStripMenuItem_Click;
            // 
            // ServerMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lbQ);
            Controls.Add(btnAdm);
            Controls.Add(lbStatus);
            Controls.Add(button1);
            Controls.Add(lbClients);
            Controls.Add(btnEdit);
            Controls.Add(tbPort);
            Controls.Add(btnConnect);
            Controls.Add(tbIp);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ServerMainForm";
            Text = "Quiz-Server";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox tbIp;
        private Button btnConnect;
        private TextBox tbPort;
        private Button btnEdit;
        private ListBox lbClients;
        private Button button1;
        private Label lbStatus;
        private Button btnAdm;
        private Label lbQ;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportQuizToolStripMenuItem;
        private ToolStripMenuItem importQuizToolStripMenuItem;
        private ToolStripMenuItem exportStudentsToolStripMenuItem;
    }
}
