using System;
using System.Windows.Forms;

namespace pingPong
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int difficulty = 1;

            if (rbtnDifficulty2.Checked)
            {
                difficulty = 2;
            }
            else if (rbtnDifficulty3.Checked)
            {
                difficulty = 3;
            }

            Form1 gameForm = new Form1(difficulty);
            gameForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
