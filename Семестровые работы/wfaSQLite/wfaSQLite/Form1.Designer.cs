namespace wfaSQLite
{
    partial class Form1
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
            lvLogs = new ListView();
            edCityName = new TextBox();
            buCityAdd = new Button();
            buCityShow = new Button();
            dataGridView1 = new DataGridView();
            edSQL = new TextBox();
            buRun = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lvLogs
            // 
            lvLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lvLogs.Location = new Point(12, 12);
            lvLogs.Name = "lvLogs";
            lvLogs.Size = new Size(164, 448);
            lvLogs.TabIndex = 0;
            lvLogs.UseCompatibleStateImageBehavior = false;
            // 
            // edCityName
            // 
            edCityName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            edCityName.Location = new Point(182, 12);
            edCityName.Name = "edCityName";
            edCityName.Size = new Size(316, 23);
            edCityName.TabIndex = 1;
            // 
            // buCityAdd
            // 
            buCityAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buCityAdd.Location = new Point(504, 11);
            buCityAdd.Name = "buCityAdd";
            buCityAdd.Size = new Size(120, 24);
            buCityAdd.TabIndex = 2;
            buCityAdd.Text = "Добавить город";
            buCityAdd.UseVisualStyleBackColor = true;
            buCityAdd.Click += button1_Click;
            // 
            // buCityShow
            // 
            buCityShow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            buCityShow.Location = new Point(182, 53);
            buCityShow.Name = "buCityShow";
            buCityShow.Size = new Size(442, 23);
            buCityShow.TabIndex = 3;
            buCityShow.Text = "Показать все города в таблице";
            buCityShow.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(182, 82);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(442, 288);
            dataGridView1.TabIndex = 4;
            // 
            // edSQL
            // 
            edSQL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            edSQL.Location = new Point(182, 376);
            edSQL.Multiline = true;
            edSQL.Name = "edSQL";
            edSQL.Size = new Size(350, 84);
            edSQL.TabIndex = 5;
            edSQL.Text = "select count(id) from city";
            edSQL.TextChanged += textBox1_TextChanged;
            // 
            // buRun
            // 
            buRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buRun.Location = new Point(538, 409);
            buRun.Name = "buRun";
            buRun.Size = new Size(86, 23);
            buRun.TabIndex = 6;
            buRun.Text = "Выполнить";
            buRun.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 472);
            Controls.Add(buRun);
            Controls.Add(edSQL);
            Controls.Add(dataGridView1);
            Controls.Add(buCityShow);
            Controls.Add(buCityAdd);
            Controls.Add(edCityName);
            Controls.Add(lvLogs);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvLogs;
        private TextBox edCityName;
        private Button buCityAdd;
        private Button buCityShow;
        private DataGridView dataGridView1;
        private TextBox edSQL;
        private Button buRun;
    }
}
