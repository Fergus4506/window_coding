using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex03_clock
{
    public partial class Form1 : Form
    {
        float x1 = 460.0F, y1 = 120.0F;
        float x2, y2;
        const float pi = 3.141592654F;
        int second = DateTime.Now.Second;
        int minute = DateTime.Now.Minute;
        int hour = DateTime.Now.Hour*5;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            doPaint();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            if (second == 60) {
                minute++;
                second=0;
            }
            if (minute == 60) {
                hour+=5;
                minute = 0;
            }
            if (hour == 24) {
                hour = 0;
            }
            doPaint();
        }
        void doPaint() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            
            g.DrawEllipse(new Pen(Color.Black), 390, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black),455,115,10,10);
            
            for (int i = 1; i <= 60; i++) {
                float drRadian = (float)i * pi / 180;
                int x = (int)(x1 + 63 * (float)Math.Sin(6 * drRadian));
                int y = (int)(y1 - 63 * (float)(Math.Cos(6 * drRadian)));
                int x_h = (int)(x1 + 70 * (float)Math.Sin(6 * drRadian));
                int y_h = (int)(y1 - 70 * (float)(Math.Cos(6 * drRadian)));
                int x_helf = (int)(x1 + 65 * (float)Math.Sin(6 * drRadian));
                int y_helf = (int)(y1 - 65 * (float)(Math.Cos(6 * drRadian)));

                if (i % 5 == 0)
                {
                    g.DrawString((i / 5).ToString(), new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(x - 5, y - 7));
                }
                else {
                    g.DrawLine(new Pen(Color.Black, 1), x_h, y_h, x_helf, y_helf);
                }
                
            }
                g.DrawEllipse(new Pen(Color.Black), 220, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black), 285, 115, 10, 10);

            float secRadian = (float)second * pi / 180;
            float midRadian = (float)minute * pi / 180;
            float hurRadian = (float)hour * pi / 180;

            x2 = x1 + 60 * (float)Math.Sin(6 * secRadian);
            y2 = y1 - 60 * (float)(Math.Cos(6 * secRadian));
            g.DrawLine(new Pen(Color.Red), x1, y1, x2, y2);

            x2 = x1 + 45 * (float)Math.Sin(6 * midRadian);
            y2 = y1 - 45 * (float)(Math.Cos(6 * midRadian));
            g.DrawLine(new Pen(Color.Brown,5), x1, y1, x2, y2);

            x2 = x1 + 35 * (float)Math.Sin(6 * hurRadian);
            y2 = y1 - 35* (float)(Math.Cos(6 * hurRadian));
            g.DrawLine(new Pen(Color.Black,10), x1, y1, x2, y2);

            /*g.DrawString("12",new Font("Times New Roman",10,FontStyle.Bold | FontStyle.Italic),new SolidBrush(Color.Green),new Point(390+65,50));
            g.DrawString("6", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 65, 50+140-15));
            g.DrawString("3", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 140-15, 50+140/2-10));
            g.DrawString("9", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390+5, 50+140/2-10));*/
        }
    }
}
