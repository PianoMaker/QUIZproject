namespace QUIZ_client_1
{
    partial class LogInForm
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
            btnLogIn = new Button();
            btnRegister = new Button();
            SuspendLayout();
            // 
            // btnLogIn
            // 
            btnLogIn.Font = new Font("Segoe UI", 12F);
            btnLogIn.Location = new Point(100, 57);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(100, 37);
            btnLogIn.TabIndex = 0;
            btnLogIn.Text = "Login";
            btnLogIn.UseVisualStyleBackColor = true;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 12F);
            btnRegister.Location = new Point(290, 57);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 37);
            btnRegister.TabIndex = 1;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 153);
            Controls.Add(btnRegister);
            Controls.Add(btnLogIn);
            Name = "LogInForm";
            Text = "LogIn";
            ResumeLayout(false);
        }

        #endregion

        private Button btnLogIn;
        private Button btnRegister;
    }
}