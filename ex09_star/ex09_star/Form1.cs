using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex09_star
{
    public partial class Form1 : Form
    {
        PointF p1 = new PointF(100.0f,300.0f);
        PointF p2 = new PointF(700.0f, 300.0f);
        PointF p3 = new PointF(400.0f, 900.0f);
        int penSize = 1;
        Color set_color = Color.Black;
        Point Gmid = new Point(400, 200);
        int rotdt = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1000, 1000);
            textBox1.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int dep = int.Parse(textBox1.Text);
            Graphics g = e.Graphics;
            if (checkBox1.Checked) {
                g.TranslateTransform(400, 500);
                g.RotateTransform(rotdt);
                g.TranslateTransform(-400, -500);
            }
            
            Pen p = new Pen(set_color,penSize);
            g.Clear(Color.White);
            draw(p1,p2,p3,p,dep,g);
            draw(p3, p2,p1, p, dep,g);
            draw(p1,p3 ,p2, p, dep,g);
        }
        void draw(PointF A1, PointF A2, PointF A3, Pen p, int dep, Graphics g)
        {
            if (dep > 0)
            {
                Pen np = new Pen(Color.White, penSize+1);
                g.DrawLine(p, A1, A2);
                PointF mid = new PointF((A1.X + A2.X) / 2, (A1.Y + A2.Y) / 2);
                PointF x = new PointF((A1.X * 2 + A2.X) / 3, (A1.Y * 2 + A2.Y) / 3);
                PointF y = new PointF((A1.X + A2.X * 2) / 3, (A1.Y + A2.Y * 2) / 3);
                PointF z = new PointF((mid.X * 4 - A3.X) / 3, (mid.Y * 4 - A3.Y) / 3);
                PointF u1 = new PointF((A1.X * 2 + A3.X) / 3, (A1.Y * 2 + A3.Y) / 3);
                PointF u2 = new PointF((A2.X * 2 + A3.X) / 3, (A2.Y * 2 + A3.Y) / 3);
                //MessageBox.Show("@");
                draw(z, y, x, p, dep - 1, g);
                draw(z, x, y, p, dep - 1, g);
                draw(A1, x, u1, p, dep - 1, g);
                draw(A2, y, u2, p, dep - 1, g);
                draw(x, y, z, np, dep - 1, g);
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            penSize = trackBar1.Value;
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            set_color = colorDialog1.Color;
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (rotdt == 360)
                rotdt = 0;
            else
                rotdt += 5;
            Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Enabled = true;
                textBox1.Enabled = false;
            }
            else {
                timer1.Enabled = false;
                textBox1.Enabled = true;
            }
                
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 100 / trackBar2.Value;
        }
    }
}
