namespace wfaSearchCity
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
            edSearch = new TextBox();
            edResult = new TextBox();
            SuspendLayout();
            // 
            // edSearch
            // 
            edSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            edSearch.Location = new Point(12, 12);
            edSearch.Name = "edSearch";
            edSearch.Size = new Size(619, 23);
            edSearch.TabIndex = 0;
            // 
            // edResult
            // 
            edResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            edResult.Location = new Point(12, 38);
            edResult.Multiline = true;
            edResult.Name = "edResult";
            edResult.ScrollBars = ScrollBars.Vertical;
            edResult.Size = new Size(619, 172);
            edResult.TabIndex = 1;
            edResult.TextChanged += textBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 222);
            Controls.Add(edResult);
            Controls.Add(edSearch);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox edSearch;
        private TextBox edResult;
    }
}
