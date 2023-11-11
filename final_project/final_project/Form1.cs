using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form1 : Form
    {
        Graphics g;
        main_character main_player = null;
        std_opt std_Opt = null;
        int[] keyPressStore = new int[] { 0, 0, 0, 0 };
        int shootDelay = 500;
        int rebirth = 50;
        int delifeDelay = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            repaint_image_player(g);
            if(rebirth==50)
                repaint_image_std_opt(g);
            if (shootDelay == 500)
                main_player.shoot(g);
            if(shootDelay==500 && std_Opt!=null)
                std_Opt.shoot(g);
        }
        void repaint_image_player(Graphics g)
        {
            if (main_player == null)
                main_player = new main_character(g);
            else
                main_player.repaint_place(g);
        }
        void repaint_image_std_opt(Graphics g)
        {
            if (std_Opt == null)
                std_Opt = new std_opt(g);
            else
                std_Opt.repaint_place(g);
        }
        private void main_move()
        {
            if (keyPressStore[0] == 1)
                main_player.playerY -= 10;
            if (keyPressStore[1] == 1)
                main_player.playerY += 10;
            if (keyPressStore[2] == 1)
                main_player.playerX -= 10;
            if (keyPressStore[3] == 1)
                main_player.playerX += 10;
            //else if(e.)
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.W)
                keyPressStore[0] = 1;
            else if (e.KeyValue == (int)Keys.S)
                keyPressStore[1] = 1;
            if (e.KeyValue == (int)Keys.A)
                keyPressStore[2] = 1;
            else if (e.KeyValue == (int)Keys.D)
                keyPressStore[3] = 1;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.W)
                keyPressStore[0] = 0;
            else if (e.KeyValue == (int)Keys.S)
                keyPressStore[1] = 0;
            if (e.KeyValue == (int)Keys.A)
                keyPressStore[2] = 0;
            else if (e.KeyValue == (int)Keys.D)
                keyPressStore[3] = 0;
        }

        private void player_timer_Tick(object sender, EventArgs e)
        {
            main_move();
        }

        private void opt_timer_Tick(object sender, EventArgs e)
        {
            if (rebirth < 50)
                rebirth += 5;
            if (delifeDelay < 20) {
                if (main_player.change_state == 0)
                    main_player.plane = Resource1.spaceship_beack;
                else
                    main_player.plane = Resource1.spaceship;
                main_player.change_state = (main_player.change_state + 1) % 2;
                delifeDelay += 5;
            }
                
            if (std_Opt != null) {
                std_Opt.playerY += 2;
                if (std_Opt.being_attacked(main_player))
                {
                    rebirth = 0;
                    std_Opt = null;
                }
            }
            if (main_player != null && std_Opt!=null) {
                if (main_player.being_attacked(std_Opt) && delifeDelay==20) { 
                    delifeDelay = 0;
                    main_player.life -= 1;
                    show_life.Text="剩餘血量:"+main_player.life;
                }
            }
                
        }
    }
    public class main_character
    {
        int shootSpeed = 5;
        public int playerX = 200, playerY = 375,life=3,change_state=0;
        public Point bulletPlace;
        public Image plane = Resource1.spaceship;
        Image bullet = Resource1.bullet_temp;
        public main_character(Graphics g)
        {
            g.DrawImage(plane, 200, 375, 50, 50);
        }
        public void repaint_place(Graphics g)
        {
            g.DrawImage(plane, playerX,playerY, 50, 50);
        }
        public void shoot(Graphics g)
        {
            //MessageBox.Show("射擊");
            if (bulletPlace.IsEmpty)
                bulletPlace = new Point(playerX, playerY - 10);
            else {
                bulletPlace.Y -= 5*shootSpeed;
                if (bulletPlace.Y <= 0)
                    bulletPlace = Point.Empty;
                else
                    g.DrawImage(bullet, bulletPlace.X + 20, bulletPlace.Y, 10, 20);
            }

        }
        public bool being_attacked(std_opt Opt)
        {
            if (Opt.bulletPlace.X <= playerX + 30 && Opt.bulletPlace.X >= playerX - 30 && Opt.bulletPlace.Y <= playerY + 50 && Opt.bulletPlace.Y >= playerY)
            {
                //MessageBox.Show("重");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
    public class std_opt{
        float shootSpeed = 5;
        public int playerX = 200, playerY = 0;
        public Point bulletPlace;
        Random R = new Random();
        Image opt_image= Resource1.ufo_1;
        Image bullet = Resource1.bullet_temp;
        public std_opt(Graphics g)
        {
            playerX = R.Next(0, 400);
            g.DrawImage(opt_image, playerX, 0, 30, 30);
        }
        public void repaint_place(Graphics g)
        {
            g.DrawImage(opt_image, playerX, playerY, 30, 30);
        }
        public void shoot(Graphics g)
        {
            //MessageBox.Show("射擊");
            if (bulletPlace.IsEmpty)
                bulletPlace = new Point(playerX, playerY + 30);
            else
            {
                bulletPlace.Y += 10;
                if (bulletPlace.Y >= 600)
                    bulletPlace = Point.Empty;
                else
                    g.DrawImage(Resource1.bullet_temp, bulletPlace.X + 10, bulletPlace.Y, 10, 20);
            }

        }
        public bool being_attacked(main_character player) {
            if (player.bulletPlace.X <= playerX+30 && player.bulletPlace.X >= playerX-30 && player.bulletPlace.Y <= playerY + 50 && player.bulletPlace.Y >= playerY)
            {
                //MessageBox.Show("重");

                return true;
            }
            else {
                return false;
            }
                
        }
    }

}
