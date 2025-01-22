namespace pingPong
{
    partial class MenuForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.rbtnDifficulty1 = new System.Windows.Forms.RadioButton();
            this.rbtnDifficulty2 = new System.Windows.Forms.RadioButton();
            this.rbtnDifficulty3 = new System.Windows.Forms.RadioButton();
            this.groupBoxDifficulty = new System.Windows.Forms.GroupBox();
            this.groupBoxDifficulty.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(243, 130);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Начать игру";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(359, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // rbtnDifficulty1
            // 
            this.rbtnDifficulty1.AutoSize = true;
            this.rbtnDifficulty1.Checked = true;
            this.rbtnDifficulty1.Location = new System.Drawing.Point(69, 45);
            this.rbtnDifficulty1.Name = "rbtnDifficulty1";
            this.rbtnDifficulty1.Size = new System.Drawing.Size(57, 19);
            this.rbtnDifficulty1.TabIndex = 5;
            this.rbtnDifficulty1.TabStop = true;
            this.rbtnDifficulty1.Text = "Легко";
            this.rbtnDifficulty1.UseVisualStyleBackColor = true;
            // 
            // rbtnDifficulty2
            // 
            this.rbtnDifficulty2.AutoSize = true;
            this.rbtnDifficulty2.Location = new System.Drawing.Point(182, 46);
            this.rbtnDifficulty2.Name = "rbtnDifficulty2";
            this.rbtnDifficulty2.Size = new System.Drawing.Size(65, 19);
            this.rbtnDifficulty2.TabIndex = 6;
            this.rbtnDifficulty2.TabStop = true;
            this.rbtnDifficulty2.Text = "Средне";
            this.rbtnDifficulty2.UseVisualStyleBackColor = true;
            // 
            // rbtnDifficulty3
            // 
            this.rbtnDifficulty3.AutoSize = true;
            this.rbtnDifficulty3.Location = new System.Drawing.Point(295, 46);
            this.rbtnDifficulty3.Name = "rbtnDifficulty3";
            this.rbtnDifficulty3.Size = new System.Drawing.Size(66, 19);
            this.rbtnDifficulty3.TabIndex = 7;
            this.rbtnDifficulty3.TabStop = true;
            this.rbtnDifficulty3.Text = "Тяжело";
            this.rbtnDifficulty3.UseVisualStyleBackColor = true;
            // 
            // groupBoxDifficulty
            // 
            this.groupBoxDifficulty.Controls.Add(this.rbtnDifficulty2);
            this.groupBoxDifficulty.Controls.Add(this.rbtnDifficulty3);
            this.groupBoxDifficulty.Controls.Add(this.rbtnDifficulty1);
            this.groupBoxDifficulty.Location = new System.Drawing.Point(129, 193);
            this.groupBoxDifficulty.Name = "groupBoxDifficulty";
            this.groupBoxDifficulty.Size = new System.Drawing.Size(461, 100);
            this.groupBoxDifficulty.TabIndex = 8;
            this.groupBoxDifficulty.TabStop = false;
            this.groupBoxDifficulty.Text = "Выбор сложности";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxDifficulty);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.Name = "MenuForm";
            this.Text = "Меню";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Load += new System.EventHandler(this.MenuForm_Load);
            this.groupBoxDifficulty.ResumeLayout(false);
            this.groupBoxDifficulty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStart;
        private Button btnExit;
        private RadioButton rbtnDifficulty1;
        private RadioButton rbtnDifficulty2;
        private RadioButton rbtnDifficulty3;
        private GroupBox groupBoxDifficulty;
    }
}