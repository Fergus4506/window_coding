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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ball_list = new List<PictureBox>();
            ball_list_speed = new List<List<int>>();
            racket.Size = new Size(200, 20);
            racket.BackColor = Color.Black;
            /*ball.Size = new Size(30, 30);
            ball.BackColor = Color.Red;*/
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

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
                delet_ball();
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            int ct=ball_list.Count();
            for (int i = 0; i < ct; i++) {
                ball_list[i].Left += ball_list_speed[i][0];
                ball_list[i].Top += ball_list_speed[i][1];
                if (ball_list[i].Bottom >= racket.Top && ball_list[i].Bottom <= racket.Bottom && ball_list[i].Left > (racket.Left - ball_list[i].Width) && ball_list[i].Right <= (racket.Right + ball_list[i].Width))
                {
                    creat_ball();
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
                    timer1.Enabled = false;
                    lbl_gameover.Visible = true;
                } 
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
            temp.BackColor = Color.Red;
            temp.Location = new Point(30,30);
            playground.Controls.Add(temp);
            ball_list.Add(temp);
            temp_speed.Add(4);
            temp_speed.Add(4);
            ball_list_speed.Add(temp_speed);
        }
        void delet_ball() {
            for (int i = 0; i < ball_list.Count(); i++) {
                playground.Controls.Remove(ball_list[i]);
            }
        }
    }
}
