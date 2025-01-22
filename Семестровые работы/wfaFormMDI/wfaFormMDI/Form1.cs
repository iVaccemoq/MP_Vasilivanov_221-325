namespace wfaFormMDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmNote newForm1 = new fmNote();
            newForm1.MdiParent = this;
            newForm1.Show();
        }
    }
}
