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

        
        int m = 0, n = 2, n3 = 3, number = 2;
        Button[] buttons = new Button[4];
        Button[] buttons3 = new Button[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 600;
            this.Height = 500;
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
            temp.Location = new Point(100 + j * (400 / n), i * (400 / n));
            temp.Click += new EventHandler(btn_Click);
            return temp;
        }

        private void btn_Click(object sender, EventArgs e) {
            if (sender.Equals(buttons[m]))
            {
                removeButton();
                if (n < 32) {
                    n += 1;
                }
                buttons = new Button[n * n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        buttons[i * n + j] = creatButton(i, j);
                    }
                }
                start_Click(sender,e);
                this.Controls.AddRange(buttons);
            }
            else {
                MessageBox.Show("答錯囉");
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
            m = ans.Next(0, n*n);
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
        }
    }
}
