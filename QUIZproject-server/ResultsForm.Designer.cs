namespace QUIZproject_server
{
    partial class ResultsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultsForm));
            dgv = new DataGridView();            
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();            
            SuspendLayout();
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = new Point(0, 28);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(1071, 422);
            dgv.TabIndex = 0;
            dgv.CellContentClick += dgv_CellContentClick;
            //
            // ResultsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1071, 450);
            Controls.Add(dgv);            
            Name = "ResultsForm";
            Text = "Results";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();            
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv;
    }
}