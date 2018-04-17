using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB10
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black, 1);

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            BackGround(800, 500);

            Stars(50, 90, 15);
            Stars(300, 70, 15);
            Stars(500, 120, 15);
            Stars(720, 200, 15);
            Stars(65, 390, 15);
            Stars(280, 370, 15);
            Stars(620, 300, 15);
            Stars(710, 440, 15);

            Asteroid(150, 170, 1.2);
            Asteroid(180, 330, 1.2);
            Asteroid(650, 160, 1.2);
            Asteroid(530, 400, 1.2);

            Spaceship(370, 260, 1.2);
            Bullet(410, 190, 1);

            Info(550, 10, 220, 40);
        }

        private void Bullet(float x, float y, float e)
        {
            float k = (float)e;

            PointF[] p = { new PointF(x, y),
                          new PointF(x + 8 * k, y + 4 * k),
                          new PointF(x + 12 * k, y + 12 * k),
                          new PointF(x + 16 * k, y + 4 * k),
                          new PointF(x + 24 * k, y),
                          new PointF(x + 16 * k, y - 4 * k),
                          new PointF(x + 12 * k, y - 12 * k),
                          new PointF(x + 8 * k, y - 4 * k) };

            g.FillPolygon(Brushes.Green, p);
        }

        private void Info(float x, float y, float dx, float dy)
        {
            g.FillRectangle(Brushes.White, new RectangleF(new PointF(x, y), new SizeF(dx, dy)));

            pen.Width = 3;
            pen.Color = Color.Yellow;

            g.DrawRectangle(pen, x, y, dx, dy);

            string info = "Level: 1 Score: 200 Live: ***";
            x += 4;
            y += 10;
            g.DrawString(info, new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, x, y);
        }

        private void BackGround(float x, float y)
        {
            g.FillRectangle(Brushes.Blue, new RectangleF(new Point(0, 0), new SizeF(x, y)));

            pen.Width = 9;
            g.DrawRectangle(pen, 0, 0, x, y);
        }

        private void Stars(float x, float y, double e)
        {
            float radius = (float)e;

            RectangleF r = new RectangleF(x, y, 2 * radius, 2 * radius);

            g.FillEllipse(Brushes.White, r);
        }

        private void Asteroid(float x, float y, double e)
        {
            float k = (float)e;

            PointF[] p = { new PointF(x, y),
                           new PointF(x + 13 * k, y),
                           new PointF(x + 21 * k, y + 9 * k),
                           new PointF(x + 29 * k, y),
                           new PointF(x + 42 * k, y),
                           new PointF(x + 36 * k, y - 9 * k),
                           new PointF(x + 42 * k, y - 18 * k),
                           new PointF(x + 29 * k, y - 18 * k),
                           new PointF(x + 21 * k, y - 27 * k),
                           new PointF(x + 13 * k, y - 18 * k),
                           new PointF(x, y - 18 * k),
                           new PointF(x + 6 * k, y - 12 * k) };

            g.FillPolygon(Brushes.Red, p);
        }

        private void Spaceship(float x, float y, double e)
        {
            float k = (float)e;

            Body(x, y, k);

            x += 23 * k;
            y -= 15 * k;

            Gun(x, y, k);
        }

        private void Gun(float x, float y, float k)
        {
            PointF[] p = { new PointF(x, y),
                           new PointF(x + 12 * k, y - 15 * k),
                           new PointF(x + 24 * k, y),
                           new PointF(x + 18 * k, y),
                           new PointF(x + 18 * k, y + 15 * k),
                           new PointF(x + 6 * k, y + 15 * k),
                           new PointF(x + 6 * k, y) };

            g.FillPolygon(Brushes.Green, p);
        }

        private void Body(float x, float y, float k)
        {
            PointF[] p = { new PointF(x, y),
                           new PointF(x + 36 * k, y + 18 * k),
                           new PointF(x + 72 * k, y),
                           new PointF(x + 72 * k, y - 30 * k),
                           new PointF(x + 36 * k, y - 48 * k),
                           new PointF(x, y - 30 * k) };

            g.FillPolygon(Brushes.Yellow, p);
        }
    }
}
