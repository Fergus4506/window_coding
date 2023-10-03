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
        float x1 = 460.0F, y1 = 115.0F;
        float x2, y2;
        int second = DateTime.Now.Second;
        int hour = DateTime.Now.Hour;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            doPaint();
        }
        void doPaint() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            
            g.DrawEllipse(new Pen(Color.Black), 390, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black),455,115,10,10);

            g.DrawString("12",new Font("Times New Roman",10,FontStyle.Bold | FontStyle.Italic),new SolidBrush(Color.Green),new Point(390+65,50));
            g.DrawString("6", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 65, 50+140-15));
            g.DrawString("3", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 140-15, 50+140/2-10));
            g.DrawString("9", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390+5, 50+140/2-10));
        }
    }
}
