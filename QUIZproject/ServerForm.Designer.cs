﻿
namespace QUIZproject
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            tbIp = new TextBox();
            btnConnect = new Button();
            tbPort = new TextBox();
            btnEdit = new Button();
            lbServer = new ListBox();
            button1 = new Button();
            lbStatus = new Label();
            SuspendLayout();
            // 
            // tbIp
            // 
            tbIp.Font = new Font("Segoe UI", 12F);
            tbIp.Location = new Point(213, 22);
            tbIp.Name = "tbIp";
            tbIp.PlaceholderText = "IP";
            tbIp.Size = new Size(156, 34);
            tbIp.TabIndex = 0;
            tbIp.TextChanged += tbIp_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(55, 22);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 34);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // tbPort
            // 
            tbPort.Font = new Font("Segoe UI", 12F);
            tbPort.Location = new Point(409, 22);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "port";
            tbPort.Size = new Size(125, 34);
            tbPort.TabIndex = 2;
            tbPort.TextChanged += tbPort_TextChanged;
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Segoe UI", 12F);
            btnEdit.Location = new Point(621, 20);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 36);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit Quiz";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // lbServer
            // 
            lbServer.FormattingEnabled = true;
            lbServer.Location = new Point(49, 103);
            lbServer.Name = "lbServer";
            lbServer.Size = new Size(485, 284);
            lbServer.TabIndex = 4;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(621, 103);
            button1.Name = "button1";
            button1.Size = new Size(130, 70);
            button1.TabIndex = 5;
            button1.Text = "Show Results";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnRes_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.BackColor = Color.Transparent;
            lbStatus.Font = new Font("Segoe UI", 10F);
            lbStatus.ForeColor = Color.DarkRed;
            lbStatus.Location = new Point(56, 64);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(124, 23);
            lbStatus.TabIndex = 6;
            lbStatus.Text = "Not connected";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(lbStatus);
            Controls.Add(button1);
            Controls.Add(lbServer);
            Controls.Add(btnEdit);
            Controls.Add(tbPort);
            Controls.Add(btnConnect);
            Controls.Add(tbIp);
            Name = "ServerForm";
            Text = "Quiz-Server";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox tbIp;
        private Button btnConnect;
        private TextBox tbPort;
        private Button btnEdit;
        private ListBox lbServer;
        private Button button1;
        private Label lbStatus;
    }
}
