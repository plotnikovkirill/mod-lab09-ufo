using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace lab9
{
    public partial class Form1 : Form
    {
        private Bitmap drawingBitmap;
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
     
            drawingBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            g = Graphics.FromImage(drawingBitmap);
            g.Clear(Color.Gray);

            g.ScaleTransform(0.5f, 0.5f);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Отображаем Bitmap на форме
            e.Graphics.DrawImage(drawingBitmap, 0, 0);
        }
        public static double sinus(double x, int n)
        {
            double xx = x * x;
            double term = x;
            double result = x;

            for (int i = 1; i < n; i++)
            {
                term *= xx / ((2 * i) * (2 * i + 1));
                result += (i % 2 == 0) ? term : -term;
            }
            return result;
        }

        public static double cosinus(double x, int n)
        {
            double xx = x * x;
            double term = 1;
            double result = 1;

            for (int i = 1; i < n; i++)
            {
                term *= xx / ((2 * i - 1) * (2 * i));
                result += (i % 2 == 0) ? term : -term;
            }
            return result;
        }

        private void DrawPoint(int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < drawingBitmap.Width && y < drawingBitmap.Height)
            {
                drawingBitmap.SetPixel(x, y, color);
            }
            this.Invalidate();
        }
        private void Line(int x1, int y1, int x2, int y2)
        {
            double k = (double)(y2 - y1) / (x2 - x1);
            double b = y1 - k * x1;
            for (int x = x1; x <= x2; x++)
                DrawPoint(x + Width / 2, (int)Math.Round(k * x + b) + Height / 2, Color.Black);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox3.Text);
            int x2 = int.Parse(textBox2.Text);
            int y2 = int.Parse(textBox4.Text);

            if (x1 > x2)
            {
                (x2, x1) = (x1, x2);
                (y2, y1) = (y1, y2);
            }

            Line(x1, y1, x2, y2);
        }
        private double Line2(int x1, int y1, int x2, int y2, int n, int step)
        {
            double angle = Math.Atan((double)(y2 - y1) / (double)(x2 - x1));
            double x = x1;
            double y = y1;
            double distance = (Math.Abs(x - x2)) * (Math.Abs(x - x2)) + Math.Abs(y - y2) * Math.Abs(y - y2);
            double value = 1;
            while (x < x2)
            {
                distance = (Math.Abs(x - x2)) * (Math.Abs(x - x2)) + Math.Abs(y - y2) * Math.Abs(y - y2);
                x += ((double)step * cosinus(angle, n));
                y += ((double)step * sinus(angle, n));
                DrawPoint((int)x + Width / 2, (int)y + Width / 2, Color.Gold);
            }
            return Math.Sqrt(distance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox3.Text);
            int x2 = int.Parse(textBox2.Text);
            int y2 = int.Parse(textBox4.Text);

            if (x1 > x2)
            {
                (x2, x1) = (x1, x2);
                (y2, y1) = (y1, y2);
            }
            Line2(x1, y1, x2, y2, 3, 1);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int x1 = -200; int y1 = -200;
                int x2 = 7800; int y2 = 7900;
                int step = 1;
                StreamWriter f = new StreamWriter("../../../../result/data.txt");
                for (int i = 1; i < 18; i++) {
                    textBox5.Text = i.ToString();
                    double err = Line2(x1, y1, x2, y2, i, step);
                    f.WriteLine(i + " " + err);
                    await Task.Delay(100);
                }
                f.Close();
            }
            catch (Exception o)
            {
                Console.WriteLine("Exception: " + o.Message);
            }
        }
    }
}
