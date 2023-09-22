using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        Graphics g = null;
        int i = 0;
        bool checksqueue = false;

        private void Form1_Load(object sender, EventArgs e) {
            //因為Form沒有內建的函式來處理滑鼠滾輪的事件，所以需要自己添加
            this.MouseWheel += Form1_MouseWheel;
            label1.Text = "size=" + size.ToString();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //設定畫布
            if (g ==null)
            {
                g =this.CreateGraphics();
            }

            if (checksqueue)
            {
                //偵測點擊，如果為左鍵則執行在畫布中畫出橢圓
                if (e.Button == MouseButtons.Left)
                {
                    //畫出橢圓的函式，前面的參數是畫筆的樣式，後面為橢圓生成的範圍和大小
                    g.FillRectangle(new SolidBrush(set_color), e.X, e.Y, size, size);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    g.DrawRectangle(new Pen(CR()), e.X, e.Y, size, size);
                }
            }
            else {
                //偵測點擊，如果為左鍵則執行在畫布中畫出橢圓
                if (e.Button == MouseButtons.Left)
                {
                    //畫出橢圓的函式，前面的參數是畫筆的樣式，後面為橢圓生成的範圍和大小
                    g.FillEllipse(new SolidBrush(set_color), e.X, e.Y, size, size);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    g.FillEllipse(new SolidBrush(CR()), e.X, e.Y, size, size);
                }
            }

            

            //紀錄現在已經點了幾次了
            i++;
            label1.Text = i.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //顯示調色盤
            colorDialog1.ShowDialog();
            //將調色盤顏色設定為點擊後的顏色
            set_color = colorDialog1.Color;
            //同上，但改變的目標是pictureBox
            pictureBox1.BackColor = set_color;
        }
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {
                size += 5;
            }
            else if(size>0)
            {
                size -= 5;
            }
            label1.Text = "size=" + size.ToString();
        }
        Color CR() {
            Random r = new Random();
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
        }
        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked) {
                set_color = CR();
                pictureBox1.BackColor = set_color;
            }
            
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox2.Checked)
            {
                checksqueue = true;
            }
            else { 
                checksqueue= false; 
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.udebug.com/UVa/10000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create image.
            Image imageFile = Image.FromFile("D:\\window_coding\\ex01_bub\\ex01_bub\\img\\zzz.jpg");

            if (g== null )
            {
                g =this.CreateGraphics();
            }

            // Create graphics object for alteration.
            Graphics newGraphics = Graphics.FromImage(imageFile);

            // Draw image to screen.
            g.DrawImage(imageFile, new PointF(0.0F, 0.0F));

            // Dispose of graphics object.
            newGraphics.Dispose();
        }
    }
}
