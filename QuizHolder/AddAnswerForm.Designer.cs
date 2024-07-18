namespace QuizHolder
{
    partial class AddAnswerForm
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
            textBox1 = new TextBox();
            btnSubmit = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            lbQuestion = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Times New Roman", 11F);
            textBox1.Location = new Point(61, 84);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(694, 29);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Font = new Font("Segoe UI", 12F);
            btnSubmit.Location = new Point(145, 152);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(94, 61);
            btnSubmit.TabIndex = 1;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F);
            btnClear.Location = new Point(354, 152);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 61);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.Location = new Point(572, 152);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 61);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbQuestion
            // 
            lbQuestion.AutoSize = true;
            lbQuestion.Font = new Font("Times New Roman", 12F);
            lbQuestion.Location = new Point(69, 36);
            lbQuestion.Name = "lbQuestion";
            lbQuestion.Size = new Size(24, 22);
            lbQuestion.TabIndex = 4;
            lbQuestion.Text = "Q";
            // 
            // AddAnswerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 246);
            Controls.Add(lbQuestion);
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Controls.Add(btnSubmit);
            Controls.Add(textBox1);
            Name = "AddAnswerForm";
            Text = "AddAnswerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
    private Button btnSubmit;
    private Button btnClear;
    private Button btnCancel;
        private Label lbQuestion;
    }
}