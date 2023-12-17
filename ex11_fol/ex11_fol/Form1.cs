using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex11_fol
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random R;
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new Size(800, 600);
            R = new Random();
        }



        private void creat_fol_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            for (float t = -10; t < 10; t += 0.03f) {
                float x = ((3 * t) / (1 + t * t * t)) * 100;
                float y = ((3 * t * t) / (1 + t * t * t)) * 100;
                g.DrawEllipse(new Pen(Color.Black),x+300,y+300,10,10);
                g.DrawEllipse(new Pen(Color.Black),-x + 300, y + 300, 10, 10);
                g.DrawEllipse(new Pen(Color.Black), x + 300, -y + 300, 10, 10);
                g.DrawEllipse(new Pen(Color.Black), -x + 300, -y + 300, 10, 10);
                
            }
        }
        Color r_color() {
            return Color.FromArgb(R.Next(0,255),R.Next(0,255),125);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            for (float t = -10; t < 10; t += 0.05f)
            {
                float x = ((3 * t) / (1 + t * t * t)) * 100;
                float y = ((3 * t * t) / (1 + t * t * t)) * 100;
                g.FillEllipse(new SolidBrush(r_color()), x + 300, y + 300, 10, 10);
                g.FillEllipse(new SolidBrush(r_color()), -x + 300, y + 300, 10, 10);
                g.FillEllipse(new SolidBrush(r_color()), x + 300, -y + 300, 10, 10);
                g.FillEllipse(new SolidBrush(r_color()), -x + 300, -y + 300, 10, 10);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            g.Clear(Color.White);
            for (float t = -10; t < 10; t += 0.1f)
            {
                float x = (float)(16*(Math.Pow(Math.Sin(t),3))+25)*15;
                float y = (float)(13*Math.Cos(t)-5*Math.Cos(2*t)-2*Math.Cos(3*t)-Math.Cos(4*t)+20)*15;
                g.FillEllipse(new SolidBrush(r_color()), -x + 650, -y + 600, 10, 10);
                //g.FillEllipse(new SolidBrush(r_color()), -x + 300, -y + 300, 10, 10);
            }
        }
    }
}
