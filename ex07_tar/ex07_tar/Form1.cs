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
        Color setColor = Color.Black;
        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);
        int count = -1;
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
            int cnt = Int32.Parse(times.Text)+1;
            //MessageBox.Show(cnt.ToString());
            g = this.CreateGraphics();
            g.Clear(Color.White);
            trackBar1.Maximum = (int)(Math.Pow(3, cnt-1));
            Point[] arr = new Point[3] { new Point(400, 100), new Point(0, 900), new Point(800, 900) };
            if (count == -1)
            {
                if (cnt > 0)
                    draw_black_tar(g, arr, cnt);
                if (check3D.Checked)
                {
                    PointF mid = new PointF(500, 750);
                    draw_3d_left_part(g, new PointF[3] { new PointF(400, 100), new PointF(0, 900), mid }, cnt, Color.Green);
                    draw_3d_left_part(g, new PointF[3] { mid, new PointF(0, 900), new PointF(800, 900) }, cnt, Color.Blue);
                    draw_3d_left_part(g, new PointF[3] { new PointF(400, 100), mid, new PointF(800, 900) }, cnt, Color.Red);
                }
            }
            else {
                draw_black_tar_count(g,arr,cnt,count);
            }
            
        }
        /*void draw_wit_tar(Graphics g,Point[] arr,int stop) {
            Point[] temp = new Point[3] { new Point((arr[0].X + arr[1].X) / 2, (arr[0].Y + arr[1].Y) / 2), new Point((arr[1].X + arr[2].X) / 2, (arr[1].Y + arr[2].Y) / 2), new Point((arr[2].X + arr[0].X) / 2, (arr[2].Y + arr[0].Y) / 2) };
            //g.DrawPolygon(new Pen(Color.White), temp);
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
        }*/
        void draw_black_tar(Graphics g, Point[] arr, int stop) {
            Point[] temp = new Point[3] { new Point((arr[0].X + arr[1].X) / 2, (arr[0].Y + arr[1].Y) / 2), new Point((arr[1].X + arr[2].X) / 2, (arr[1].Y + arr[2].Y) / 2), new Point((arr[2].X + arr[0].X) / 2, (arr[2].Y + arr[0].Y) / 2) };
            //g.DrawPolygon(new Pen(Color.White), temp);
            //g.FillPolygon(new SolidBrush(Color.White), temp);
            if (stop - 1 > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                        draw_black_tar(g, new Point[3] { arr[0], temp[0], temp[2] }, stop - 1);
                    else if (i == 1)
                        draw_black_tar(g, new Point[3] { temp[0], arr[1], temp[1] }, stop - 1);
                    else if (i == 2)
                        draw_black_tar(g, new Point[3] { temp[2], temp[1], arr[2] }, stop - 1);
                }
            }
            else {
                g.DrawPolygon(new Pen(setColor), arr);
                g.FillPolygon(new SolidBrush(setColor), arr);
            }
        }
        int draw_black_tar_count(Graphics g, Point[] arr, int stop,int count)
        {
            Point[] temp = new Point[3] { new Point((arr[0].X + arr[1].X) / 2, (arr[0].Y + arr[1].Y) / 2), new Point((arr[1].X + arr[2].X) / 2, (arr[1].Y + arr[2].Y) / 2), new Point((arr[2].X + arr[0].X) / 2, (arr[2].Y + arr[0].Y) / 2) };
            //g.DrawPolygon(new Pen(Color.White), temp);
            //g.FillPolygon(new SolidBrush(Color.White), temp);
            if (stop - 1 > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (count == 0)
                        return 0;
                    if (i == 0)
                        count=draw_black_tar_count(g, new Point[3] { arr[0], temp[0], temp[2] }, stop - 1,count);
                    else if (i == 1)
                        count=draw_black_tar_count(g, new Point[3] { temp[0], arr[1], temp[1] }, stop - 1,count);
                    else if (i == 2)
                        count=draw_black_tar_count(g, new Point[3] { temp[2], temp[1], arr[2] }, stop - 1,count);
                    
                }
            }
            else
            {
                g.DrawPolygon(new Pen(setColor), arr);
                g.FillPolygon(new SolidBrush(setColor), arr);
                return count - 1;
            }
            return count;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            setColor = colorDialog1.Color;
            pictureBox1.BackColor = setColor;
            pen.Color = setColor;
            brush.Color = setColor;
            start_Click(sender,e);
        }
        void draw_3d_left_part(Graphics g,PointF[] arr,int stop,Color c) {
            PointF[] temp = new PointF[3] { new PointF((arr[0].X + arr[1].X) / 2, (arr[0].Y + arr[1].Y) / 2), new PointF((arr[1].X + arr[2].X) / 2, (arr[1].Y + arr[2].Y) / 2), new PointF((arr[2].X + arr[0].X) / 2, (arr[2].Y + arr[0].Y) / 2) };
            //g.DrawPolygon(new Pen(Color.White), temp);
            //g.FillPolygon(new SolidBrush(Color.White), temp);
            if (stop - 1 > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i == 0)
                        draw_3d_left_part(g, new PointF[3] { arr[0], temp[0], temp[2] }, stop - 1,c);
                    else if (i == 1)
                        draw_3d_left_part(g, new PointF[3] { temp[0], arr[1], temp[1] }, stop - 1,c);
                    else if (i == 2)
                        draw_3d_left_part(g, new PointF[3] { temp[2], temp[1], arr[2] }, stop - 1,c);
                }
            }
            else
            {
                g.DrawPolygon(new Pen(c), arr);
                g.FillPolygon(new SolidBrush(c), arr);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            count = trackBar1.Value;
            start_Click(sender, e);
        }

        private void check3D_CheckedChanged(object sender, EventArgs e)
        {
            if (check3D.Checked)
            {
                count = -1;
                trackBar1.Enabled = false;
            }
            else {
                trackBar1.Enabled = true;
            }
            start_Click(sender, e);
        }
    }
}
