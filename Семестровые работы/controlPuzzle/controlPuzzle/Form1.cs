
using controlPuzzle.Properties;

namespace controlPuzzle
{
    public partial class Form1 : Form
    {
        private const int AutoSickRange = 20;
        private Random rnd = new Random();
        private PictureBox[,] px;
        private int cellWidth;
        private int cellHeight;
        private Point startMouseDown;

        public int Rows { get; } = 3;
        public int Cols { get; } = 5;

        public Form1()
        {
            InitializeComponent();

            CreateCells();
            ResizeCells();
            StartLocationCells();

            this.Text += "  : F1 - собрать, F2 - другой размер, F3/F4 - перемешать";
            this.KeyDown += Form1_KeyDown;
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    StartLocationCells();
                    break;
                case Keys.F2:
                    ResizeCells();
                    break;
                case Keys.F3:
                    RandomLocationCells();
                    break;
                case Keys.F4:
                    Random2LocationCells();
                    break;
            }
        }

        private void Random2LocationCells()
        {
            StartLocationCells();
            for (int i = 0; i < 10; i++)
            {
                var r1 = rnd.Next(Rows);
                var c1 = rnd.Next(Cols);
                var r2 = rnd.Next(Rows);
                var c2 = rnd.Next(Cols);

                (px[r1, c1].Location, px[r2, c2].Location) = (px[r2, c2].Location, px[r1, c1].Location);
            }
        }

        private void RandomLocationCells()
        {
            for (int r = 0; r < Rows; r++)
            {
                for(int c = 0; c < Cols; c++)
                {
                    px[r, c].Location = new Point(
                        rnd.Next(this.ClientSize.Width - cellWidth),
                        rnd.Next(this.ClientSize.Height - cellHeight));
                }
            }
        }

        private void StartLocationCells()
        {
            for (int r = 0; r < Rows; r++) //Y
            {
                for(int c = 0; c < Cols; c++) //X
                {
                    px[r, c].Location = new Point(c * cellWidth, r * cellHeight);
                }
            }

        }

        private void ResizeCells()
        {
            cellWidth = ClientSize.Width / Cols;
            cellHeight = ClientSize.Height / Rows;

            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    px[r, c].Width = cellWidth;
                    px[r, c].Height = cellHeight;
                    px[r, c].Image = new Bitmap(cellWidth, cellHeight);

                    var g = Graphics.FromImage(px[r, c].Image);
                    g.DrawImage(
                        new Bitmap(new MemoryStream(Properties.Resources.CityImg)),
                        new Rectangle(0, 0, cellWidth, cellHeight),
                        new Rectangle(c*cellWidth, r*cellHeight, cellWidth, cellHeight),
                        GraphicsUnit.Pixel
                        );

                    g.DrawString($"{r}:{c}",
                        new Font("", 15),
                        new SolidBrush(Color.Black),
                        new Rectangle(0, 0, cellWidth, cellHeight),
                        new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

                    g.Dispose( );

                }
            }
        }

        //StartLocationCells

        private void CreateCells()
        {
            px = new PictureBox[Rows, Cols];
            for (int r = 0; r < Rows; r++) // Y
            {
                for (int c = 0; c < Cols; c++) // X
                {
                    px[r, c] = new PictureBox();
                    px[r, c].BorderStyle = BorderStyle.FixedSingle;
                    px[r, c].MouseDown += PictureBoxAll_MouseDown;
                    px[r, c].MouseMove += PictureBoxAll_MouseMove;
                    px[r, c].MouseUp += PictureBoxAll_MouseUp;
                    px[r, c].Tag = (r, c, true);

                    this.Controls.Add(px[r, c]);
                }
            }
        }

        private void PictureBoxAll_MouseUp(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox v)
            {
                if (e.Button == MouseButtons.Left)
                {
                    v.Cursor = Cursors.Default;

                    var p = v.Location;
                    //прилипание

                    for (int r = 0; r < Rows; r++) //Y
                    {
                        for (int c = 0; c < Cols; c++) //X
                        {
                            if (p.X > c * cellWidth - AutoSickRange && p.X < c * cellWidth + AutoSickRange)
                                p.X = c * cellWidth;
                            if (p.Y > r * cellHeight - AutoSickRange && p.Y < r * cellHeight + AutoSickRange)
                                p.Y = r * cellHeight;
                        }
                    }

                    v.Location = p;
                }
                CheckCell(v);
            }
        }

        private void CheckCell(PictureBox v)
        {
            (int rr, int cc, bool isRotate) = ((int, int, bool))v.Tag;
            if (v.Location == new Point(cc * cellWidth, rr * Height) && isRotate == true)
            {
                MessageBox.Show("Верно!");
            } 
        }

        private void PictureBoxAll_MouseMove(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox v)
            {
                if (e.Button == MouseButtons.Left)
                {
                    v.Location = new Point(
                        v.Location.X + e.Location.X - startMouseDown.X,
                        v.Location.Y + e.Location.Y - startMouseDown.Y);
                }
            }
        }

        private void PictureBoxAll_MouseDown(object? sender, MouseEventArgs e)
        {
            if (sender is PictureBox v)
            {
                if (e.Button == MouseButtons.Left)
                {
                    startMouseDown = e.Location;
                    v.BringToFront(); //перенести картинку наверх
                    v.Cursor = Cursors.SizeAll;
                }

                if (e.Button == MouseButtons.Right)
                {
                    v.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    (int rr, int cc, bool isRotate) = ((int, int, bool))v.Tag;
                    v.Tag = (rr, cc, isRotate);
                    v.Invalidate();
                    CheckCell(v);
                }
            }
        }
    }
}
