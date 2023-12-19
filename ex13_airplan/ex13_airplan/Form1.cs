using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ex13_airplan
{
    public partial class Form1 : Form
    {
        List<PictureBox> opt_s = new List<PictureBox>();
        List<PictureBox> bullets = new List<PictureBox>();
        List<int> opt_move = new List<int>();
        int point = 0;
        int time_sk = 100;
        int time_mm = 0;
        WindowsMediaPlayer player;
        public Form1()
        {
            InitializeComponent();
            /*path=
            player = new WindowsMediaPlayer();
            player.URL = path;
            player.controls.play();*/
            this.SetBounds(0, 0, 800, 600);
            plane.Left = (this.Width - plane.Width) / 2;
            plane.Top = (this.Height - plane.Height) - 50;
            //timer1.Enabled = true;
            newOpt();
            label2.Left = 800-150;
            textBox1.Top = 10;
            textBox1.Left = 250;
            button1.Top = 10;
            button1.Left = 300;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time_mm += 1;
            if (time_mm == 10) {
                time_sk -= 1;
                time_mm = 0;
            }
            label2.Text = "剩餘時間" + time_sk.ToString();
            enemyMove();
            bombMove();
            bool check = false;
            if (point % 5 == 0 && point!=0) {
                newOpt();
            }
            for (int i = 0; i < bullets.Count; i++) {
                for (int j = 0; j < opt_s.Count; j++) {
                    if (isOverlap(bullets[i].Bounds, opt_s[j].Bounds))
                    {
                        point += 1;
                        label1.Text = "分數:" + point.ToString();
                        this.Controls.Remove(bullets[i]);
                        bullets.RemoveAt(i);
                        this.Controls.Remove(opt_s[j]);
                        opt_s.RemoveAt(j);
                        opt_move.RemoveAt(j);
                        check=true;
                        newOpt();
                        break;
                    }
                }
                if (check) {
                    break;
                }
            }
            if (time_sk == 0) {
                MessageBox.Show("game over");
                timer1.Stop();
            }
        }
        void enemyMove() {
            for (int i = 0; i < opt_s.Count; i++) {
                int stepX = opt_move[i];
                if (opt_s[i].Right >= this.ClientSize.Width)
                {
                    stepX = -1 * stepX;
                }
                if (opt_s[i].Left <= 0)
                {
                    stepX = -1 * stepX;
                }
                opt_s[i].Left += stepX;
                opt_move[i] = stepX;
            }
                
        }
        void bombMove() {
            for (int i = 0; i < bullets.Count; i++) {
                bullets[i].Top -= 10;
                if (bullets[i].Top <= 0) {
                    this.Controls.Remove(bullets[i]);
                    bullets.RemoveAt(i);
                    i--;
                    continue;
                }
            }
        }
        bool isOverlap(Rectangle r1,Rectangle r2) {
            if (r1.Left > r2.Left && r1.Left < r2.Right) {
                if (r1.Top > r2.Top && r1.Top < r2.Bottom) {
                    return true;
                }
            }
            return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Space)) {
                newBullet();
            }
            if (e.KeyCode.Equals(Keys.Left)) {
                plane.Left -= 10;
            }
            else if(e.KeyCode.Equals(Keys.Right)){
                plane.Left += 10;
            }
            else if (e.KeyCode.Equals(Keys.Up)) {
                plane.Top -= 10;
            }
            else if (e.KeyCode.Equals(Keys.Down)) {
                plane.Top += 10;
            }
        }
        void newBullet() {
            PictureBox bullet = new PictureBox();
            bullet.Image = bullet_sample.Image;
            bullet.Size = bullet_sample.Size;
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Transparent;
            bullet.Left = (plane.Left + plane.Right - bullet.Width) / 2;
            bullet.Top = plane.Top-60;

            this.Controls.Add(bullet);
            this.Controls.SetChildIndex(bullet, 0);
            bullet.Visible = true;
            bullets.Add(bullet);
        }
        void newOpt()
        {
            PictureBox opt = new PictureBox();
            opt.Image =ept_sample.Image;
            opt.Size = ept_sample.Size;
            opt.BackColor = Color.Transparent;
            opt.Left = new Random().Next(200,600)/ 2;
            opt.Top = new Random().Next(0,100);
            this.Controls.Add(opt);
            //this.Controls.SetChildIndex(opt, 0);
            opt.Visible = true;
            int stepx = 10;
            opt_s.Add(opt);
            opt_move.Add(stepx);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ept_sample_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            time_sk = Int32.Parse(textBox1.Text);
            timer1.Start();
            textBox1.Hide();
            button1.Hide();
            textBox1.Enabled = false;
            button1.Enabled = false;
        }
    }
}
