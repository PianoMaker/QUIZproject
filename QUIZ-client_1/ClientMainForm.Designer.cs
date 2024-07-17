
namespace QUIZ_client_1
{
    partial class ClientMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
            tbIp = new TextBox();
            tbPort = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            lbStatus = new Label();
            lbMessages = new ListBox();
            rb_hm = new RadioButton();
            rb_s = new RadioButton();
            panel1 = new Panel();
            label1 = new Label();
            btnProfile = new Button();
            btnQuiz = new Button();
            lblQuestion = new Label();
            lbAnswers = new ListBox();
            lblAnswer = new Label();
            num = new NumericUpDown();
            btnPlay = new Button();
            lbQ = new Label();
            pictureBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // tbIp
            // 
            tbIp.Font = new Font("Segoe UI", 12F);
            tbIp.Location = new Point(88, 18);
            tbIp.Name = "tbIp";
            tbIp.PlaceholderText = "IP";
            tbIp.Size = new Size(211, 34);
            tbIp.TabIndex = 0;
            tbIp.TextChanged += tbIp_TextChanged;
            // 
            // tbPort
            // 
            tbPort.Font = new Font("Segoe UI", 12F);
            tbPort.Location = new Point(329, 18);
            tbPort.Name = "tbPort";
            tbPort.PlaceholderText = "Port";
            tbPort.Size = new Size(89, 34);
            tbPort.TabIndex = 1;
            tbPort.TextChanged += tbPort_TextChanged;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(742, 18);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(150, 48);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("Segoe UI", 14F);
            btnSend.Location = new Point(358, 506);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(333, 48);
            btnSend.TabIndex = 8;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.BackColor = Color.Transparent;
            lbStatus.Location = new Point(89, 69);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(104, 20);
            lbStatus.TabIndex = 9;
            lbStatus.Text = "not connected";
            // 
            // lbMessages
            // 
            lbMessages.FormattingEnabled = true;
            lbMessages.HorizontalScrollbar = true;
            lbMessages.Location = new Point(742, 184);
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(208, 364);
            lbMessages.TabIndex = 10;
            // 
            // rb_hm
            // 
            rb_hm.BackColor = Color.Transparent;
            rb_hm.Font = new Font("Times New Roman", 12F);
            rb_hm.Location = new Point(226, 10);
            rb_hm.Name = "rb_hm";
            rb_hm.Size = new Size(166, 32);
            rb_hm.TabIndex = 12;
            rb_hm.TabStop = true;
            rb_hm.Text = "Теорія";
            rb_hm.UseVisualStyleBackColor = false;
            rb_hm.CheckedChanged += rb_hm_CheckedChanged;
            // 
            // rb_s
            // 
            rb_s.BackColor = Color.Transparent;
            rb_s.Font = new Font("Times New Roman", 12F);
            rb_s.Location = new Point(392, 13);
            rb_s.Name = "rb_s";
            rb_s.Size = new Size(210, 26);
            rb_s.TabIndex = 13;
            rb_s.TabStop = true;
            rb_s.Text = "Сольфеджіо";
            rb_s.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(rb_hm);
            panel1.Controls.Add(rb_s);
            panel1.Location = new Point(83, 119);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(608, 61);
            panel1.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(195, 28);
            label1.TabIndex = 14;
            label1.Text = "Оберіть дисципліну";
            // 
            // btnProfile
            // 
            btnProfile.Font = new Font("Segoe UI", 12F);
            btnProfile.Location = new Point(487, 18);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(168, 48);
            btnProfile.TabIndex = 15;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnQuiz
            // 
            btnQuiz.Font = new Font("Segoe UI", 12F);
            btnQuiz.Location = new Point(742, 119);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(208, 48);
            btnQuiz.TabIndex = 16;
            btnQuiz.Text = "Get Quiz";
            btnQuiz.UseVisualStyleBackColor = true;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // lblQuestion
            // 
            lblQuestion.BackColor = Color.Ivory;
            lblQuestion.Font = new Font("Times New Roman", 12F);
            lblQuestion.Location = new Point(83, 198);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(508, 40);
            lblQuestion.TabIndex = 17;
            // 
            // lbAnswers
            // 
            lbAnswers.Font = new Font("Times New Roman", 11F);
            lbAnswers.FormattingEnabled = true;
            lbAnswers.Location = new Point(83, 260);
            lbAnswers.Name = "lbAnswers";
            lbAnswers.Size = new Size(484, 164);
            lbAnswers.TabIndex = 18;
            lbAnswers.SelectedIndexChanged += lbAnswers_SelectedIndexChanged;
            // 
            // lblAnswer
            // 
            lblAnswer.BackColor = Color.Ivory;
            lblAnswer.Font = new Font("Times New Roman", 12F);
            lblAnswer.Location = new Point(83, 447);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(484, 40);
            lblAnswer.TabIndex = 19;
            lblAnswer.Click += lblAnswer_Click;
            // 
            // num
            // 
            num.Font = new Font("Segoe UI", 12F);
            num.Location = new Point(598, 453);
            num.Name = "num";
            num.Size = new Size(93, 34);
            num.TabIndex = 20;
            num.ValueChanged += num_ValueChanged;
            // 
            // btnPlay
            // 
            btnPlay.Font = new Font("Segoe UI", 12F);
            btnPlay.Location = new Point(575, 198);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(116, 40);
            btnPlay.TabIndex = 21;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // lbQ
            // 
            lbQ.AutoSize = true;
            lbQ.BackColor = Color.Transparent;
            lbQ.Font = new Font("Segoe UI", 11F);
            lbQ.Location = new Point(88, 510);
            lbQ.Name = "lbQ";
            lbQ.Size = new Size(218, 25);
            lbQ.TabIndex = 22;
            lbQ.Text = "No questions are loaded";
            // 
            // pictureBox
            // 
            pictureBox.BackColor = Color.Transparent;
            pictureBox.Location = new Point(584, 260);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(107, 164);
            pictureBox.TabIndex = 23;
            pictureBox.TabStop = false;
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(997, 650);
            Controls.Add(pictureBox);
            Controls.Add(lbQ);
            Controls.Add(btnPlay);
            Controls.Add(num);
            Controls.Add(lblAnswer);
            Controls.Add(lbAnswers);
            Controls.Add(lblQuestion);
            Controls.Add(btnQuiz);
            Controls.Add(btnProfile);
            Controls.Add(lbMessages);
            Controls.Add(lbStatus);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(tbPort);
            Controls.Add(tbIp);
            Controls.Add(panel1);
            Name = "ClientMainForm";
            Text = "ClientForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox tbIp;
        private TextBox tbPort;
        private Button btnConnect;
        private Button btnSend;
        private Label lbStatus;
        private ListBox lbMessages;
        private RadioButton rb_hm;
        private RadioButton rb_s;
        private Panel panel1;
        private Label label1;
        private Button btnProfile;
        private Button btnQuiz;
        private Label lblQuestion;
        private ListBox lbAnswers;
        private Label lblAnswer;
        private NumericUpDown num;
        private Button btnPlay;
        private Label lbQ;
        private PictureBox pictureBox;
    }
}
