namespace wfaSearchCity
{
    public partial class Form1 : Form
    {
        private string[] cities;

        public Form1()
        {
            InitializeComponent();

            cities = Properties.Resources.Cities.Split(' ');

            edSearch.TextChanged += Edsearch_TextChanged;

        }

        private void Edsearch_TextChanged(object? sender, EventArgs e)
        {
            var r = cities.Where(i => i.ToUpper().Contains(edSearch.Text.ToUpper()))
                .Where(i => i != "")
                .OrderBy(i => 1)
                //.Take(400)
                .ToArray();

            edResult.Text = String.Join(Environment.NewLine, r);
            this.Text = $"{Application.ProductName} : {edSearch.Text} : {r.Count()}";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
