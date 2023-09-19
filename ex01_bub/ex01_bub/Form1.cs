using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex01_bub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int size = 10;
        Color set_color = Color.Red;
        Graphics g;
        int i = 0;

        private void Form1_Load(object sender, EventArgs e) {
        
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            if (e.Button == MouseButtons.Left) {
                g.FillEllipse(new SolidBrush(set_color),e.X,e.Y,size,size);
            }
            i++;
            label1.Text = i.ToString();
        }
        
        
    }
}
