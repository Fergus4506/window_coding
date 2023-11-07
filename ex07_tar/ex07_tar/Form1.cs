using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex07_tar
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 900;
            this.Height = 1000;
            times.Text = "2";
        }

        private void start_Click(object sender, EventArgs e)
        {
            int cnt = Int32.Parse(times.Text);
            //MessageBox.Show(cnt.ToString());
            g = this.CreateGraphics();
            g.Clear(Color.White);

            Point[] arr = new Point[3] { new Point(400, 100), new Point(0, 900), new Point(800, 900) };
            g.DrawPolygon(pen,arr);
            g.FillPolygon(brush,arr);
            if (cnt > 0)
                draw_wit_tar(g,arr,cnt);
        }
        void draw_wit_tar(Graphics g,Point[] arr,int stop) {
            Point[] temp = new Point[3] { new Point((arr[0].X + arr[1].X) / 2, (arr[0].Y + arr[1].Y) / 2), new Point((arr[1].X + arr[2].X) / 2, (arr[1].Y + arr[2].Y) / 2), new Point((arr[2].X + arr[0].X) / 2, (arr[2].Y + arr[0].Y) / 2) };
            g.DrawPolygon(new Pen(Color.White), temp);
            g.FillPolygon(new SolidBrush(Color.White), temp);
            if (stop - 1 != 0) {
                for (int i = 0; i < 3; i++) {
                    if(i==0)
                        draw_wit_tar(g,new Point[3]{arr[0],temp[0],temp[2]},stop-1);
                    else if(i==1)
                        draw_wit_tar(g, new Point[3] { temp[0], arr[1], temp[1] }, stop - 1);
                    else if(i==2)
                        draw_wit_tar(g, new Point[3] { temp[2], temp[1], arr[2] }, stop - 1);
                }
            }
                
        }
    }
}
