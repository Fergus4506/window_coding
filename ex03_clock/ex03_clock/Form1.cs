using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ex03_clock
{
    public partial class Form1 : Form
    {
        float x1 = 460.0F, y1 = 120.0F;
        float x2, y2;
        const float pi = 3.141592654F;
        int second = DateTime.Now.Second;
        int minute = DateTime.Now.Minute;
        int hour = DateTime.Now.Hour*5;
        string back_count,set_time;
        bool back_check=false,count_clock_enable=true;
        int count_sec = 0,count_min=0,count_hur=0;
        

        Boolean textboxHasText = false;//判断输入框是否有文本

        //textbox获得焦点
        private void Textbox1_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox1.Text = "";

            textBox1.ForeColor = Color.Black;
        }
        private void Textbox2_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox2.Text = "";

            textBox2.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void Textbox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "倒數器(輸入格式為:hh/mm/ss)";
                textBox1.ForeColor = Color.DarkGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }
        private void Textbox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "設定時間(輸入格式為:hh/mm/ss)";
                textBox2.ForeColor = Color.DarkGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            do_count_paint();
            doPaint();
            textBox1.LostFocus += new EventHandler(Textbox1_Leave); //失去焦点后发生事件
            textBox1.GotFocus += new EventHandler(Textbox1_Enter);  //获取焦点前发生事件
            textBox2.LostFocus += new EventHandler(Textbox2_Leave); //失去焦点后发生事件
            textBox2.GotFocus += new EventHandler(Textbox2_Enter);  //获取焦点前发生事件
            this.DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            back_count = textBox1.Text;
            String[] split_back =back_count.Split('/');
            if (split_back.Length != 3 || split_back[0]== "倒數器(輸入格式為:hh")
            {
                MessageBox.Show("請輸入正確格式!!");
                textBox1.Text = "";
            }
            else { 
                back_check= true;
                hour = int.Parse(split_back[0])*5;
                minute = int.Parse(split_back[1]);
                second = int.Parse(split_back[2]);
                MessageBox.Show(hour+""+minute+""+second);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            set_time = textBox2.Text;
            String[] split_set = set_time.Split('/');
            if (back_check != true && split_set.Length == 3 && split_set[0] != "設定時間(輸入格式為:hh")
            {
                hour = int.Parse(split_set[0])*5;
                minute = int.Parse(split_set[1]);
                second = int.Parse(split_set[2]);
            }
            else {
                if (back_check) {
                    MessageBox.Show("正在倒數，不可設定時間，要改變倒數時間請從上面修改");
                }
                else if (split_set.Length != 3 || split_set[0] == "設定時間(輸入格式為:hh") {
                    MessageBox.Show("請輸入正確格式⊙﹏⊙∥");
                }
                textBox2.Text = "";
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            count_sec++;
            if (count_sec %10==0)
            {
                count_min++;
            }
            if (count_min == 60)
            {
                count_hur ++;
                count_min = 0;
            }
            if (count_hur == 60)
            {
                count_hur = 0;
            }
            do_count_paint();
            label1.Text = count_hur.ToString() + "分" + count_min.ToString() + "秒" + (count_sec % 10).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
            }
            else { 
                timer2.Enabled=true;
            }
            

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled)
            {
                timer2.Enabled = false;
            }
            count_sec = 0;
            count_min = 0;
            count_hur = 0;
            do_count_paint();
            label1.Text = count_hur.ToString() + "分" + count_min.ToString() + "秒" + (count_sec % 10).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (back_check)
            {
                if (timer1.Enabled)
                {
                    MessageBox.Show("正在倒數，目前暫停的時間是倒數時間");
                    timer1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("開始倒數了\\(@^0^@)/");
                    timer1.Enabled = true;
                }
                
            }
            else {
                if (timer1.Enabled)
                {
                    MessageBox.Show("時鐘暫停");
                    timer1.Enabled = false;
                }
                else {
                    MessageBox.Show("時鐘暫停結束");
                    timer1.Enabled = true;
                }
                
            }
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count_clock_enable) {
                do_count_paint();
                count_clock_enable = false;
                label1.Text = count_hur.ToString() + "分" + count_min.ToString() + "秒" + (count_sec % 10).ToString();
            }
            if (back_check)
            {
                second--;
                if (second <= 0 && minute <= 0 && hour <= 0)
                {
                    MessageBox.Show("倒數結束");
                    back_check = false;
                    second = DateTime.Now.Second;
                    minute = DateTime.Now.Minute;
                    hour = DateTime.Now.Hour * 5;
                }
                else {

                    if (minute == 0 && second <= 0)
                    {
                        hour -= 5;
                        minute = 59;
                        second = 60;
                    }
                    else if (second <= 0) {
                        minute--;
                        second = 60;
                    } 
                }
            }
            else {
                second++;
                if (second == 60)
                {
                    minute++;
                    second = 0;
                }
                if (minute == 60)
                {
                    hour += 5;
                    minute = 0;
                }
                if (hour == 24)
                {
                    hour = 0;
                }
            }
            
            doPaint();
        }
        void doPaint() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            
            g.DrawEllipse(new Pen(Color.Black), 390, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black),455,115,10,10);
            print_clock_scale(x1,y1,g);
            
            

            float secRadian = (float)second * pi / 180;
            float midRadian = (float)minute * pi / 180;
            float hurRadian = (float)hour * pi / 180;

            draw_clock_line(hurRadian,midRadian,secRadian,x1,y1,g);

            



            /*g.DrawString("12",new Font("Times New Roman",10,FontStyle.Bold | FontStyle.Italic),new SolidBrush(Color.Green),new Point(390+65,50));
            g.DrawString("6", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 65, 50+140-15));
            g.DrawString("3", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 140-15, 50+140/2-10));
            g.DrawString("9", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390+5, 50+140/2-10));*/
        }
        void do_count_paint() {
            Graphics s = groupBox1.CreateGraphics();
            s.Clear(Color.White);
            s.DrawEllipse(new Pen(Color.Black), 30, 30, 140, 140);
            s.FillEllipse(new SolidBrush(Color.Black), 95, 95, 10, 10);
            print_clock_scale(100.0F, 100.0F, s);

            float secRadian = (float)count_sec * pi / 180;
            float midRadian = (float)count_min * pi / 180;
            float hurRadian = (float)count_hur * pi / 180;

            draw_clock_line(hurRadian, midRadian, secRadian, 100.0F, 100.0F, s);

        }
        void print_clock_scale(float centerX,float centerY,Graphics g) {
            for (int i = 1; i <= 60; i++)
            {
                float drRadian = (float)i * pi / 180;
                int x = (int)(centerX + 55 * (float)Math.Sin(6 * drRadian));
                int y = (int)(centerY - 55 * (float)(Math.Cos(6 * drRadian)));
                int x_h = (int)(centerX + 70 * (float)Math.Sin(6 * drRadian));
                int y_h = (int)(centerY - 70 * (float)(Math.Cos(6 * drRadian)));
                int x_helf = (int)(centerX + 65 * (float)Math.Sin(6 * drRadian));
                int y_helf = (int)(centerY - 65 * (float)(Math.Cos(6 * drRadian)));
                int x_helf_L = (int)(centerX + 63 * (float)Math.Sin(6 * drRadian));
                int y_helf_L = (int)(centerY - 63 * (float)(Math.Cos(6 * drRadian)));

                if (i % 5 == 0)
                {
                    if (i == 60)
                        g.DrawString((i / 5).ToString(), new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(x - 10, y - 7));
                    else
                        g.DrawString((i / 5).ToString(), new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(x - 5, y - 7));
                    g.DrawLine(new Pen(Color.Black, 2), x_h, y_h, x_helf_L, y_helf_L);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Black, 1), x_h, y_h, x_helf, y_helf);
                }

            }
        }
        void draw_clock_line(float hurRadian, float midRadian, float secRadian, float centerX, float centerY, Graphics g) {
            x2 = centerX + 60 * (float)Math.Sin(6 * secRadian);
            y2 = centerY - 60 * (float)(Math.Cos(6 * secRadian));
            g.DrawLine(new Pen(Color.Red), centerX, centerY, x2, y2);

            x2 = centerX + 45 * (float)Math.Sin(6 * midRadian);
            y2 = centerY - 45 * (float)(Math.Cos(6 * midRadian));
            g.DrawLine(new Pen(Color.Brown, 5), centerX, centerY, x2, y2);

            x2 = centerX + 35 * (float)Math.Sin(6 * hurRadian);
            y2 = centerY - 35 * (float)(Math.Cos(6 * hurRadian));
            g.DrawLine(new Pen(Color.Black, 10), centerX, centerY, x2, y2);
        }
    }
}
