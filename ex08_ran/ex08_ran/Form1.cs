using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex08_ran
{
    public partial class Form1 : Form
    {
        Color set_color = Color.Black;
        Random cc = new Random();
        int n = -1,checknow=9999;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "2";
            trackBar1.Maximum = (int)(Math.Pow(9, 2));
            this.Width = 900;
            this.Height = 900;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Point start = new Point(100, 100);
            Pen dfpen = new Pen(set_color);
            Brush dfbrush = new SolidBrush(set_color);
            if (trange_from.Checked) {
                g.TranslateTransform(400.0F, -100.0F);
                g.RotateTransform(45.0f);
            }
            
            if (n == 0)
                g.FillRectangle(dfbrush, start.X, start.Y, 540, 540);
            else if(n>0)
                draw_ran(g,start,dfpen,dfbrush,180,n,0);
            

        }
        int draw_ran(Graphics g,Point start,Pen dfp,Brush dfb,int ransize,int count,int now) {
            if (count == 0 || now==checknow)
                return now;
            set_color = randonColor();
            dfp.Color = set_color;
            dfb = new SolidBrush(set_color);
            Point[] allranStart = new Point[9];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    allranStart[i * 3 + j] = new Point(start.X+ransize*j,start.Y+ransize*i);
                }
            }
            for (int i = 0; i < 9; i++) {
                if(i!=4){
                    g.DrawRectangle(dfp, allranStart[i].X, allranStart[i].Y, ransize, ransize);
                    now=draw_ran(g, allranStart[i], dfp, dfb, ransize / 3, count - 1,now+1);
                }
                else{
                    g.FillRectangle(dfb,allranStart[i].X,allranStart[i].Y,ransize,ransize);
                    now += 1;
                }
                if (now == checknow)
                    return now;
            }
            return now;
        }
        private void draw_Click(object sender, EventArgs e)
        {
            n = Int32.Parse(textBox1.Text);
            trackBar1.Maximum = (int)(Math.Pow(9, n));
            Invalidate();
        }
        Color randonColor() {
            if (ranColor.Checked == true)
                return Color.FromArgb(cc.Next(0, 255), cc.Next(0, 255), 50);
            else
                return Color.Black;
        }

        private void trange_from_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            n = Int32.Parse(textBox1.Text);
            trackBar1.Maximum = (int)(Math.Pow(9,n));
            checknow = trackBar1.Value;
            Invalidate();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            n = 2;
        }

        private void ranColor_CheckedChanged(object sender, EventArgs e)
        {
            if (ranColor.Checked){
                checknow = 9999;
                trackBar1.Enabled = false;
            }
            else {
                trackBar1.Enabled = true;
            }
            Invalidate();

        }

    }
}
