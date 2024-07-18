
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
            rb_hm = new RadioButton();
            rb_s = new RadioButton();
            panel1 = new Panel();
            label1 = new Label();
            btnProfile = new Button();
            btnQuiz = new Button();
            lbQ = new Label();
            panelQuiz = new Panel();
            picpointer = new Label();
            pictureBox = new PictureBox();
            btnPlay = new Button();
            num = new NumericUpDown();
            lblAnswer = new Label();
            lbAnswers = new ListBox();
            lblQuestion = new Label();
            panelPicture = new Panel();
            checkBox1 = new CheckBox();
            lbMessages = new ListBox();
            panel1.SuspendLayout();
            panelQuiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num).BeginInit();
            panelPicture.SuspendLayout();
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
            btnConnect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnConnect.Font = new Font("Segoe UI", 12F);
            btnConnect.Location = new Point(973, 18);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(208, 48);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSend.Font = new Font("Segoe UI", 14F);
            btnSend.Location = new Point(554, 586);
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
            // rb_hm
            // 
            rb_hm.Anchor = AnchorStyles.Top;
            rb_hm.BackColor = Color.Transparent;
            rb_hm.Checked = true;
            rb_hm.Font = new Font("Times New Roman", 13.8F);
            rb_hm.Location = new Point(274, 10);
            rb_hm.Name = "rb_hm";
            rb_hm.Size = new Size(130, 32);
            rb_hm.TabIndex = 12;
            rb_hm.TabStop = true;
            rb_hm.Text = "Теорія";
            rb_hm.UseVisualStyleBackColor = false;
            rb_hm.CheckedChanged += rb_t_CheckedChanged;
            // 
            // rb_s
            // 
            rb_s.Anchor = AnchorStyles.Top;
            rb_s.BackColor = Color.Transparent;
            rb_s.Font = new Font("Times New Roman", 13.8F);
            rb_s.Location = new Point(427, 13);
            rb_s.Name = "rb_s";
            rb_s.Size = new Size(173, 26);
            rb_s.TabIndex = 13;
            rb_s.TabStop = true;
            rb_s.Text = "Сольфеджіо";
            rb_s.UseVisualStyleBackColor = false;
            rb_s.CheckedChanged += rb_s_CheckedChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(rb_hm);
            panel1.Controls.Add(rb_s);
            panel1.Location = new Point(83, 119);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5);
            panel1.Size = new Size(804, 61);
            panel1.TabIndex = 14;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F);
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(233, 29);
            label1.TabIndex = 14;
            label1.Text = "Оберіть дисципліну";
            // 
            // btnProfile
            // 
            btnProfile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProfile.Enabled = false;
            btnProfile.Font = new Font("Segoe UI", 12F);
            btnProfile.Location = new Point(719, 18);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(168, 48);
            btnProfile.TabIndex = 15;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = true;
            btnProfile.Click += btnProfile_Click;
            // 
            // btnQuiz
            // 
            btnQuiz.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnQuiz.Enabled = false;
            btnQuiz.Font = new Font("Segoe UI", 12F);
            btnQuiz.Location = new Point(973, 113);
            btnQuiz.Name = "btnQuiz";
            btnQuiz.Size = new Size(208, 48);
            btnQuiz.TabIndex = 16;
            btnQuiz.Text = "Get Quiz";
            btnQuiz.UseVisualStyleBackColor = true;
            btnQuiz.Click += btnQuiz_Click;
            // 
            // lbQ
            // 
            lbQ.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbQ.AutoSize = true;
            lbQ.BackColor = Color.Transparent;
            lbQ.Font = new Font("Segoe UI", 11F);
            lbQ.Location = new Point(83, 609);
            lbQ.Name = "lbQ";
            lbQ.Size = new Size(218, 25);
            lbQ.TabIndex = 22;
            lbQ.Text = "No questions are loaded";
            // 
            // panelQuiz
            // 
            panelQuiz.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelQuiz.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelQuiz.BackColor = Color.Transparent;
            panelQuiz.Controls.Add(picpointer);
            panelQuiz.Controls.Add(pictureBox);
            panelQuiz.Controls.Add(btnPlay);
            panelQuiz.Controls.Add(num);
            panelQuiz.Controls.Add(lblAnswer);
            panelQuiz.Controls.Add(lbAnswers);
            panelQuiz.Controls.Add(lblQuestion);
            panelQuiz.Location = new Point(85, 202);
            panelQuiz.MaximumSize = new Size(900, 1000);
            panelQuiz.Name = "panelQuiz";
            panelQuiz.Size = new Size(870, 387);
            panelQuiz.TabIndex = 25;
            // 
            // picpointer
            // 
            picpointer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            picpointer.BackColor = Color.Transparent;
            picpointer.Location = new Point(710, 72);
            picpointer.Name = "picpointer";
            picpointer.Size = new Size(155, 184);
            picpointer.TabIndex = 27;
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox.BackColor = Color.Transparent;
            pictureBox.BackgroundImageLayout = ImageLayout.None;
            pictureBox.Location = new Point(710, 72);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(155, 184);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 26;
            pictureBox.TabStop = false;
            pictureBox.Click += pictureBox_Click;
            // 
            // btnPlay
            // 
            btnPlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPlay.Enabled = false;
            btnPlay.Font = new Font("Segoe UI", 12F);
            btnPlay.Location = new Point(710, 0);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(116, 40);
            btnPlay.TabIndex = 25;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Visible = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // num
            // 
            num.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            num.Enabled = false;
            num.Font = new Font("Segoe UI", 12F);
            num.Location = new Point(710, 277);
            num.Name = "num";
            num.Size = new Size(93, 34);
            num.TabIndex = 24;
            num.Value = new decimal(new int[] { 1, 0, 0, 0 });
            num.ValueChanged += num_ValueChanged;
            // 
            // lblAnswer
            // 
            lblAnswer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAnswer.AutoSize = true;
            lblAnswer.BackColor = Color.Ivory;
            lblAnswer.Font = new Font("Times New Roman", 12F);
            lblAnswer.Location = new Point(0, 277);
            lblAnswer.MaximumSize = new Size(700, 68);
            lblAnswer.MinimumSize = new Size(675, 34);
            lblAnswer.Name = "lblAnswer";
            lblAnswer.Size = new Size(675, 34);
            lblAnswer.TabIndex = 22;
            lblAnswer.Click += lblAnswer_Click;
            // 
            // lbAnswers
            // 
            lbAnswers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbAnswers.Font = new Font("Times New Roman", 12F);
            lbAnswers.FormattingEnabled = true;
            lbAnswers.ItemHeight = 22;
            lbAnswers.Location = new Point(8, 72);
            lbAnswers.MinimumSize = new Size(500, 184);
            lbAnswers.Name = "lbAnswers";
            lbAnswers.Size = new Size(675, 180);
            lbAnswers.TabIndex = 21;
            lbAnswers.SelectedIndexChanged += lbAnswers_SelectedIndexChanged;
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblQuestion.BackColor = Color.Ivory;
            lblQuestion.Font = new Font("Times New Roman", 14F);
            lblQuestion.Location = new Point(0, 0);
            lblQuestion.MinimumSize = new Size(500, 30);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(675, 30);
            lblQuestion.TabIndex = 20;
            lblQuestion.Click += lblQuestion_Click;
            // 
            // panelPicture
            // 
            panelPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPicture.BackColor = Color.Transparent;
            panelPicture.Controls.Add(checkBox1);
            panelPicture.Controls.Add(lbMessages);
            panelPicture.Location = new Point(973, 191);
            panelPicture.MaximumSize = new Size(580, 800);
            panelPicture.Name = "panelPicture";
            panelPicture.Size = new Size(259, 443);
            panelPicture.TabIndex = 26;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkBox1.BackColor = Color.LemonChiffon;
            checkBox1.Location = new Point(0, 390);
            checkBox1.MaximumSize = new Size(0, 40);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(259, 40);
            checkBox1.TabIndex = 26;
            checkBox1.Text = "BigPicture mode";
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lbMessages
            // 
            lbMessages.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbMessages.FormattingEnabled = true;
            lbMessages.HorizontalScrollbar = true;
            lbMessages.Location = new Point(0, 0);
            lbMessages.MaximumSize = new Size(1000, 600);
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(259, 384);
            lbMessages.TabIndex = 25;
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1262, 673);
            Controls.Add(panelPicture);
            Controls.Add(panelQuiz);
            Controls.Add(lbQ);
            Controls.Add(btnQuiz);
            Controls.Add(btnProfile);
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
            panelQuiz.ResumeLayout(false);
            panelQuiz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)num).EndInit();
            panelPicture.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }




        #endregion

        private TextBox tbIp;
        private TextBox tbPort;
        private Button btnConnect;
        private Button btnSend;
        private Label lbStatus;
        private RadioButton rb_hm;
        private RadioButton rb_s;
        private Panel panel1;
        private Label label1;
        private Button btnProfile;
        private Button btnQuiz;
        private Label lbQ;
        private Panel panelQuiz;
        private Label lblAnswer;
        private ListBox lbAnswers;
        private Label lblQuestion;
        private Panel panelPicture;
        private CheckBox checkBox1;
        private ListBox lbMessages;
        private PictureBox pictureBox;
        private Button btnPlay;
        private NumericUpDown num;
        private Label picpointer;
    }
}
