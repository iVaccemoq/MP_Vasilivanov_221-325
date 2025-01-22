using SQLite;

namespace wfaSQLite
{
    public partial class Form1 : Form
    {
        private readonly SQLiteConnection db;

        public Form1()
        {
            InitializeComponent();

            db = new SQLiteConnection("myDB.db"); //также автоматически выполн€ет проверку, нужно ли создавать таблицы

            db.CreateTable<Logs>();
            db.CreateTable<City>();
            db.CreateTable<User>();

            db.Insert(new Logs() { DateTime = DateTime.Now }); //создаЄтс€ новый экземпл€р объекта Logs и вставл€етс€ в таблицу

            lvLogs.Columns.Add("ƒата¬рем€", 120);
            lvLogs.View = View.Details;

            foreach (var log in db.Table<Logs>())
            {
                lvLogs.Items.Add(log.DateTime.ToString());
            }

            buCityAdd.Click += (s, e) => db.Insert(new City() { Name = edCityName.Text });
            buCityShow.Click += (s, e) => dataGridView1.DataSource = db.Table<City>().ToList();

            buRun.Click += (s, e) => MessageBox.Show(db.ExecuteScalar<int>(edSQL.Text).ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
