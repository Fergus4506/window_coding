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
        Color set_color = Color.Red;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            MessageBox.Show("formWidth="+this.Width+"\nformHeight="+this.Height);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int xBias = 42;
            g = this.CreateGraphics();
            g.Clear(Color.White);
            g.FillEllipse(new SolidBrush(set_color), e.X-size/2, e.Y-size/2, size, size);
        }
    }
}
