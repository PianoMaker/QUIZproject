
namespace QUIZ_client_1
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            tbIp = new TextBox();
            tbPort = new TextBox();
            btnConnect = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            lbStatus = new Label();
            lbMessages = new ListBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            panel1 = new Panel();
            label1 = new Label();
            Authorize = new Button();
            panel1.SuspendLayout();
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
            // textBox1
            // 
            textBox1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            textBox1.Location = new Point(83, 186);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Question";
            textBox1.Size = new Size(608, 34);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(83, 257);
            button1.Name = "button1";
            button1.Size = new Size(265, 96);
            button1.TabIndex = 4;
            button1.Text = "A.";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(432, 257);
            button2.Name = "button2";
            button2.Size = new Size(259, 96);
            button2.TabIndex = 5;
            button2.Text = "B. ";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(83, 386);
            button3.Name = "button3";
            button3.Size = new Size(264, 96);
            button3.TabIndex = 6;
            button3.Text = "C.";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button4.Location = new Point(432, 386);
            button4.Name = "button4";
            button4.Size = new Size(259, 96);
            button4.TabIndex = 7;
            button4.Text = "D.";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 14F);
            button5.Location = new Point(83, 506);
            button5.Name = "button5";
            button5.Size = new Size(608, 48);
            button5.TabIndex = 8;
            button5.Text = "Send";
            button5.UseVisualStyleBackColor = true;
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
            lbMessages.Location = new Point(742, 144);
            lbMessages.MultiColumn = true;
            lbMessages.Name = "lbMessages";
            lbMessages.Size = new Size(150, 404);
            lbMessages.TabIndex = 10;
            // 
            // radioButton1
            // 
            radioButton1.BackColor = Color.Transparent;
            radioButton1.Font = new Font("Times New Roman", 12F);
            radioButton1.Location = new Point(226, 10);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(166, 32);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Історія музики";
            radioButton1.UseVisualStyleBackColor = false;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radioButton2
            // 
            radioButton2.BackColor = Color.Transparent;
            radioButton2.Font = new Font("Times New Roman", 12F);
            radioButton2.Location = new Point(392, 13);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(210, 26);
            radioButton2.TabIndex = 13;
            radioButton2.TabStop = true;
            radioButton2.Text = "Сольфеджіо";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(radioButton2);
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
            // Authorize
            // 
            Authorize.Font = new Font("Segoe UI", 12F);
            Authorize.Location = new Point(487, 18);
            Authorize.Name = "Authorize";
            Authorize.Size = new Size(168, 48);
            Authorize.TabIndex = 15;
            Authorize.Text = "Profile";
            Authorize.UseVisualStyleBackColor = true;
            Authorize.Click += Authorize_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(911, 650);
            Controls.Add(Authorize);
            Controls.Add(lbMessages);
            Controls.Add(lbStatus);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(btnConnect);
            Controls.Add(tbPort);
            Controls.Add(tbIp);
            Controls.Add(panel1);
            Name = "ClientForm";
            Text = "ClientForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private TextBox tbIp;
        private TextBox tbPort;
        private Button btnConnect;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label lbStatus;
        private ListBox lbMessages;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Panel panel1;
        private Label label1;
        private Button Authorize;
    }
}
