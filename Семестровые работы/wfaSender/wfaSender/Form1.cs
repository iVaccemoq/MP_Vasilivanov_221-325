namespace wfaSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += buttonAll_Click;
            button2.Click += buttonAll_Click;
            button3.Click += buttonAll_Click;
            checkBox1.Click += buttonAll_Click;
            label1.Click += buttonAll_Click;
            this.Click += buttonAll_Click;
        }

        private void buttonAll_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(button1.Text);

            //var button = (Button)sender;
            //MessageBox.Show(button.Text);

            //if (sender is Button) {
            //    MessageBox.Show(((Button)sender).Text);
            //if (sender is CheckBox) {
            //    MessageBox.Show(((CheckBox)sender).Text);


            //if (sender is Control)
            //{
            //    MessageBox.Show(((Control)sender).Text);
            //}

            //if (sender is Control)
            //{
            //    var c = (Control)sender;
            //    MessageBox.Show(c.Text);
            //}

            if (sender is Control c) 
                {
                    MessageBox.Show($"{c.Text} | {c.Name} ");
                }
        }
    }
}
