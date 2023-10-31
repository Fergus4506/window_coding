using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex06_pickColor
{
    public partial class Form1 : Form
    {
        static Random R = new Random();
        static Random G = new Random();
        static Random B = new Random();
        Random ans = new Random();
        int r = R.Next(0, 255);
        int g = G.Next(0, 255);
        int b = B.Next(0, 255);
        int c = 50;

        
        int m = 0, n = 2, limit=32,sorce=0,time=0;
        Button[] buttons = new Button[4];
        Button[] buttons3 = new Button[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 700;
            this.Height = 600;
            int needCheck = ans.Next();
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                        buttons[i * n + j] = creatButton(i, j);
                }
            }
            this.Controls.AddRange(buttons);
        }

        private Button creatButton(int i,int j) {
            Button temp = new Button();
            temp.Name = "button" + (i * 2 + j);
            temp.Text = "";
            temp.Size = new Size(400 / n, 400 / n);
            temp.BackColor = Color.FromArgb(r,g,b);
            temp.Location = new Point(250 + j * (400 / n), i * (400 / n));
            temp.Click += new EventHandler(btn_Click);
            return temp;
        }

        private void btn_Click(object sender, EventArgs e) {
            if (sender.Equals(buttons[m]))
            {
                removeButton();
                if (n < limit) {
                    n += 1;
                }
                sorce += 1;
                label4.Text = "目前得分" + sorce;
                buttons = new Button[n * n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i * n + j] = creatButton(i, j);
                        if (checkBox1.Checked)
                        {
                            buttons[i * n + j].Text = i + "-" + j;
                        }
                    }
                    
                }
                start_Click(sender,e);
                this.Controls.AddRange(buttons);
            }
            else {
                MessageBox.Show("答錯囉");
                sorce -= 1;
                label4.Text = "目前得分" + sorce;
            }
        }
        private void removeButton() {
            for (int i = 0; i < n * n; i++) {
                this.Controls.Remove(buttons[i]);
            }
            r = R.Next(0, 255);
            g = G.Next(0, 255);
            b = B.Next(0, 255);
        }
        private void start_Click(object sender, EventArgs e)
        {
            if (time != 500) {
                timer1.Enabled = true;
            } 
            m = ans.Next(0, n*n);
            start.Enabled = false;
            if ((b + c) > 255)
            {
                if(n%3==0)
                    buttons[m].BackColor = Color.FromArgb(r-c, g, b );
                else if(n%3==1)
                    buttons[m].BackColor = Color.FromArgb(r, g-c, b);
                else
                    buttons[m].BackColor = Color.FromArgb(r, g, b-c);
            }
            else {
                if (n % 3 == 0)
                    buttons[m].BackColor = Color.FromArgb(r + c, g, b);
                else if (n % 3 == 1)
                    buttons[m].BackColor = Color.FromArgb(r, g + c, b);
                else
                    buttons[m].BackColor = Color.FromArgb(r, g, b + c);
            }
            if (checkBox1.Checked)
                label3.Text = "目前答案" + m / n + "-" + m % n;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            limit = Int32.Parse(textBox1.Text);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            c = trackBar1.Value;
            label2.Text = "目前色差" + c.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (time > 0){
                time -= 1;
                label6.Text = "剩餘時間為" + time / 60 + "分" + time % 60 + "秒";
            }
            else {
                MessageBox.Show("計時結束囉，得分為" + sorce);
                timer1.Enabled = false;
                reset_Click(sender,e);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < n * n; i++)
                {
                    buttons[i].Text = i / n + "-" + i % n;
                }
                label3.Text = "目前答案" + m / n + "-" + m % n;
            }
            else {
                for (int i = 0; i < n * n; i++)
                {
                    buttons[i].Text = "";
                }
                label3.Text = "沒有在作弊喔!!OVO";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            time=trackBar2.Value*5;
            if(time==100){
                label5.Text="不計時";
            }
            else{
                label5.Text = "倒數計時設定為" + time / 60 + "分" + time % 60 + "秒";
                label6.Text = "剩餘時間為" + time / 60 + "分" + time % 60 + "秒";
            }
            
        }

        private void reset_Click(object sender, EventArgs e)
        {

        }
    }
}
