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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Add)
            {
                number *= 2;
            }
            else if (e.KeyData == Keys.Subtract)
            {
                number /= 2;
            }
            else if (e.KeyData == Keys.C)
            {
                colorDialog1.ShowDialog();
                set_color = colorDialog1.Color;
            }
            else if (e.KeyData == Keys.Up)
            {
                size += 5;

            }
            else if (e.KeyData == Keys.Down) {
                if (size > 5) {
                    size -= 5;
                }
            }
            else if(e.KeyData == Keys.V){
                colorDialog2.ShowDialog();
                bkColor=colorDialog2.Color;

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
            PointF center = new PointF(this.ClientSize.Width/2,this.ClientSize.Height/2);
            g = CreateGraphics();
            g.Clear(bkColor);
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
            }
        }
    }
}
