namespace wfaGraphicSinCos
{
    internal class MyGraphic
    {
        public int Height { get; }
        public int Width { get; }

        private readonly Bitmap b;
        private readonly Graphics g;
        private readonly int grShiftY;
        private readonly double grWidthPI;

        public int countWave { get; } = 10;
        public int dotDiameter { get; } = 5;
        public Bitmap Bitmap { get { return b; } }

        public MyGraphic(int width, int height) 
        {
            Width = width;
            Height = height;

            b = new Bitmap(width, height);
            g = Graphics.FromImage(b);

            grShiftY = b.Height / 2;
            grWidthPI = Math.PI / (b.Width);
        }

        public void DrawAxes()
        {
            //рисуем х
            g.DrawLine(new Pen(Color.Black), 0, grShiftY, b.Width, grShiftY);

            //рисуем у
            g.DrawLine(new Pen(Color.Black), b.Width/2, 0, b.Width/2, b.Height);
        }

        public void DrawSin()
        {
            double x, y;

            for (int i = 0; i < b.Width; i++)
            {
                x = i;
                y = grShiftY * -Math.Sin(i * grWidthPI * countWave) + grShiftY;
                g.FillEllipse(new SolidBrush(Color.Red), (int) x - dotDiameter/2, (int)y - dotDiameter/2, dotDiameter, dotDiameter);
            }
        }

        public void DrawCos()
        {
            double x, y;

            for (int i = 0; i < b.Width; i++)
            {
                x = i;
                y = grShiftY * -Math.Cos(i * grWidthPI * countWave) + grShiftY;
                g.FillEllipse(new SolidBrush(Color.Green), (int)x - dotDiameter / 2, (int)y - dotDiameter / 2, dotDiameter, dotDiameter);
            }
        }

        public void DrawTan()
        {
            double x, y;

            for (int i = 0; i < b.Width; i++)
            {
                x = i;
                y = grShiftY * -Math.Tan(i * grWidthPI * countWave) + grShiftY;
                if (y > 0 && y < b.Height)
                {
                    g.FillEllipse(new SolidBrush(Color.Blue), (int)x - dotDiameter / 2, (int)y - dotDiameter / 2, dotDiameter, dotDiameter);
                }
            }
        }


    }
}