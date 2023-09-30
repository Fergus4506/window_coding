using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mirrurball
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        int size = 20,number=1;
        double xx, yy, deg;
        Color bkColor= Color.White;
        bool draw=false,dl=false,dk=false;


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dk) dk = false; else dk = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Add)
            {
                number *= 2;
                label1.Text = "目前有" + number.ToString() + "個點";
            }
            else if (e.KeyData == Keys.Subtract)
            {
                if (number > 1)
                {
                    number /= 2;
                }
                label1.Text = "目前有" + number.ToString() + "個點";

            }
            else if (e.KeyData == Keys.C)
            {
                colorDialog1.ShowDialog();
                set_color = colorDialog1.Color;
            }
            else if (e.KeyData == Keys.Up)
            {
                size += 5;
                label1.Text = "目前點的大小" + size.ToString();

            }
            else if (e.KeyData == Keys.Down)
            {
                if (size > 5)
                {
                    size -= 5;
                }
                label1.Text = "目前點的大小" + size.ToString();
            }
            else if (e.KeyData == Keys.V)
            {
                colorDialog2.ShowDialog();
                bkColor = colorDialog2.Color;
            }
            else if (e.KeyData == Keys.D)
            {
                if (draw) draw = false;
                else draw = true;
            }
            else if (e.KeyData == Keys.X)
            {
                if (dl) dl = false;
                else dl = true;
            }
            else if (e.KeyData == Keys.K) {
                if (dk) dk = false; else dk = true;
            }
        }

        Color set_color = Color.Red;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            MessageBox.Show("formWidth="+this.Width+"\nformHeight="+this.Height);
            this.DoubleBuffered=true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            decimal[,] allPoint = new decimal[number,2];
            PointF center = new PointF(this.ClientSize.Width/2,this.ClientSize.Height/2);
            g = CreateGraphics();
            if (draw==false) g.Clear(bkColor);
            for (int i = 0; i < number; i++) { 
                double x =(double) (e.X-center.X);
                double y = (double)(e.Y - center.Y);
                double temp =2 * Math.PI  * i / number;
                //Math.Cos(temp) * x - Math.Sin(temp) * y,Math.Sin(temp) * x + Math.Cos(temp) * y
                decimal new_x = (decimal)(Math.Cos(temp) * x - Math.Sin(temp) * y);
                decimal new_y = (decimal)(Math.Sin(temp) * x + Math.Cos(temp) * y);
                new_x +=(decimal) center.X;
                new_y += (decimal)center.Y;
                g.FillEllipse(new SolidBrush(set_color),(float)new_x-size/2,(float)new_y-size/2,size,size);
                allPoint[i, 0] = new_x;
                allPoint[i, 1] = new_y;
            }
            if (dl && number != 1) {
                Draw_line(allPoint,number);
            }

        }
        private void Draw_line(decimal[,] allPoint,int number) {
            if (dk)
            {
                for (int i = 0; i < (int)number / 2; i++)
                {
                    g.DrawLine(new Pen(set_color, size), (float)allPoint[i, 0], (float)allPoint[i, 1], (float)allPoint[(int)(number / 2) + i, 0], (float)allPoint[(int)(number / 2) + i, 1]);
                }
            }
            else {
                for (int i = 0; i < (int)number / 2; i++)
                {
                    g.DrawLine(new Pen(set_color, size), (float)allPoint[i, 0], (float)allPoint[i, 1], (float)allPoint[number-i-1, 0], (float)allPoint[number- i-1, 1]);
                }
            }
            
           
            
            
        }
    }
}
