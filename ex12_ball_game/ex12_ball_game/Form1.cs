using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex12_ball_game
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int point = 0;
        List<PictureBox> ball_list;
        List<List<int>> ball_list_speed;
        int count = 0;
        int rk_count = 0;
        int racker_le = 500;
        bool checkhk = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball_list = new List<PictureBox>();
            ball_list_speed = new List<List<int>>();
            racket.Size = new Size(racker_le, 20);
            racket.BackColor = Color.Black;
            /*ball.Size = new Size(30, 30);
            ball.BackColor = Color.Red;*/
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            pictureBox1.Left = this.Bounds.Right-100;
            label1.Left = this.Bounds.Right-120;
            label1.Visible = true;
            racket.Top = playground.Bottom - (playground.Bottom / 10);
            //MessageBox.Show(lbl_gameover.Width.ToString());
            lbl_gameover.Location = new Point((playground.Width/2)-(lbl_gameover.Width*3),(playground.Height/2)-(lbl_gameover.Height*3));
            lbl_gameover.Text = "Gamerover\n F1:Restart\n Esc:Exit";
            lbl_gameover.Font = new Font("Times New Roman", 30, FontStyle.Bold);
            lbl_gameover.Visible = true;
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Escape)) {
                this.Close();
            }
            if (e.KeyCode.Equals(Keys.F1)) {
                count = 1;
                rk_count = 1;
                racker_le = 500;
                racket.Size = new Size(racker_le,20);
                delet_ball_all(ball_list);
                ball_list = new List<PictureBox>();
                ball_list_speed = new List<List<int>>();
                creat_ball();
                for (int i = 0; i < ball_list.Count(); i++) {
                    ball_list[i].Top = 50;
                    ball_list[i].Left = 50;
                    ball_list_speed[i][0] = 4;
                    ball_list_speed[i][1] = 4;
                }
                point = 0;
                timer1.Enabled = true;
                playground.BackColor = Color.White;
                lbl_gameover.Visible = false;
                lbl_point.Text = "分數:" + point.ToString();
                //MessageBox.Show(ball_list.Count().ToString());
            }
            if(e.KeyCode.Equals(Keys.S)) {
                if(timer1.Enabled)
                { 
                    timer1.Stop();
                    Image image = Resource1.stop_button;
                    pictureBox1.Image = image;
                    label1.Text = "pass S to start";
                }
                else { 
                    timer1.Start();
                    Image image = Resource1.play_button;
                    pictureBox1.Image = image;
                    label1.Text = "pass S to stop";
                }
            }
            if (e.KeyCode.Equals(Keys.F3)) {
                if (checkhk)
                    checkhk = false;
                else checkhk = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkhk) {
                racket.Left = ball_list[0].Left-racker_le/2+15;
            }
            else
                racket.Left = Cursor.Position.X - (racket.Width / 2);
            int ct=ball_list.Count();
            for (int i = 0; i < ct; i++) {
                ball_list[i].Left += ball_list_speed[i][0];
                ball_list[i].Top += ball_list_speed[i][1];
                if (ball_list[i].Bottom >= racket.Top && ball_list[i].Bottom <= racket.Bottom && ball_list[i].Left > (racket.Left - ball_list[i].Width) && ball_list[i].Right <= (racket.Right + ball_list[i].Width))
                {
                    count += 1;
                    rk_count += 1;
                    ball_list_speed[i][0] += 2;
                    ball_list_speed[i][1] += 2;
                    ball_list_speed[i][1] = -ball_list_speed[i][1];
                    point += 1;
                    lbl_point.Text = "分數:" + point.ToString();
                    //MessageBox.Show(ball_list[i].Name);
                    Random rand = new Random();
                    int r = rand.Next(0, 255);
                    int g = rand.Next(0, 255);
                    int b = 125;
                    playground.BackColor = Color.FromArgb(r, g, b);
                }
                if (ball_list[i].Left <= playground.Left)
                    ball_list_speed[i][0] = -ball_list_speed[i][0];
                if (ball_list[i].Right >= playground.Right)
                    ball_list_speed[i][0] = -ball_list_speed[i][0];
                if (ball_list[i].Top <= playground.Top)
                    ball_list_speed[i][1] = -ball_list_speed[i][1];
                if (ball_list[i].Bottom >= playground.Bottom)
                {
                    delet_ball(i);
                    if (ball_list.Count() == 0) { 
                        timer1.Stop();
                        lbl_gameover.Show();
                    }
                    break;
                } 
            }
            if (count % 5 == 0) {
                creat_ball();
                count += 1;
            }
            if (rk_count % 4 == 0) {
                if(racker_le>100)
                    racker_le -= 25;
                racket.Size=new Size(racker_le,20);
                rk_count += 1;
            }
                
               
        }
        void creat_ball() {
            PictureBox temp = new PictureBox();
            List<int> temp_speed = new List<int>();
            if (ball_list.Count()==0)
                temp.Name = "ball" + (ball_list.Count()+ 1).ToString();
            else
                temp.Name = "ball" + (1).ToString();
            
            temp.Size = new Size(30, 30);
            Image image = Resource1.beach_ball;
            temp.Image = image;
            temp.SizeMode=PictureBoxSizeMode.StretchImage;
            temp.Location = new Point(30,30);
            playground.Controls.Add(temp);
            ball_list.Add(temp);
            temp_speed.Add(4);
            temp_speed.Add(4);
            ball_list_speed.Add(temp_speed);
        }
        void delet_ball(int i) {
            playground.Controls.Remove(ball_list[i]);
            ball_list.Remove(ball_list[i]);
            ball_list_speed.Remove(ball_list_speed[i]);
        }
        void delet_ball_all(List<PictureBox> ball_list)
        {
            for (int i = 0; i < ball_list.Count; i++) {
                playground.Controls.Remove(ball_list[i]);
            }
        }
    }
}
