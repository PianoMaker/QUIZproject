namespace QUIZproject_server
{
    partial class QserialTest
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
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            btSerialize = new Button();
            btDeserialize = new Button();
            label1 = new Label();
            btLoad = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 110);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(362, 204);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(395, 110);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(381, 204);
            listBox2.TabIndex = 1;
            // 
            // btSerialize
            // 
            btSerialize.Location = new Point(280, 334);
            btSerialize.Name = "btSerialize";
            btSerialize.Size = new Size(94, 29);
            btSerialize.TabIndex = 2;
            btSerialize.Text = "btSerialize";
            btSerialize.UseVisualStyleBackColor = true;
            // 
            // btDeserialize
            // 
            btDeserialize.Location = new Point(395, 334);
            btDeserialize.Name = "btDeserialize";
            btDeserialize.Size = new Size(118, 29);
            btDeserialize.TabIndex = 3;
            btDeserialize.Text = "btDeserialize";
            btDeserialize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(285, 392);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // btLoad
            // 
            btLoad.Location = new Point(337, 44);
            btLoad.Name = "btLoad";
            btLoad.Size = new Size(94, 29);
            btLoad.TabIndex = 5;
            btLoad.Text = "Load";
            btLoad.UseVisualStyleBackColor = true;
            btLoad.Click += btLoad_Click;
            // 
            // QserialTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btLoad);
            Controls.Add(label1);
            Controls.Add(btDeserialize);
            Controls.Add(btSerialize);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Name = "QserialTest";
            Text = "QserialTest";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Button btSerialize;
        private Button btDeserialize;
        private Label label1;
        private Button btLoad;
    }
}