
namespace DataBase
{
    partial class ENFCodeForm
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
            btnCreate = new Button();
            dgv = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnJson = new Button();
            btnRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(53, 37);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(149, 29);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += BtnCreate_Click;
            // 
            // dgv
            // 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Dock = DockStyle.Bottom;
            dgv.Location = new Point(0, 152);
            dgv.Name = "dgv";
            dgv.RowHeadersWidth = 51;
            dgv.Size = new Size(800, 298);
            dgv.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(53, 97);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(149, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Student";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(208, 37);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(164, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete Database";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnJson
            // 
            btnJson.Location = new Point(378, 37);
            btnJson.Name = "btnJson";
            btnJson.Size = new Size(129, 29);
            btnJson.TabIndex = 6;
            btnJson.Text = "json settings";
            btnJson.UseVisualStyleBackColor = true;
            btnJson.Click += BtnJson_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(208, 97);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(164, 29);
            btnRemove.TabIndex = 7;
            btnRemove.Text = "Remove Student";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += this.btnRemove_Click;
            // 
            // ENFCodeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemove);
            Controls.Add(btnJson);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgv);
            Controls.Add(btnCreate);
            Name = "ENFCodeForm";
            Text = "ENFcodeForm";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
        }


        #endregion

        private Button btnCreate;
        private DataGridView dgv;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnJson;
        private Button btnRemove;
    }
}
