﻿using System;
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
        int[] keyPressStore = new int[] { 0, 0, 0, 0 };
        int shootDelay = 500;

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
            repaint_image(g);
            if(shootDelay==500)
                main_player.shoot(g);
        }
        void repaint_image(Graphics g)
        {
            if (main_player == null)
                main_player = new main_character(g);
            else
                main_player.repaint_place(g);
        }
        private void main_move()
        {
            if (keyPressStore[0] == 1)
                main_player.playerY -= 7;
            if (keyPressStore[1] == 1)
                main_player.playerY += 7;
            if (keyPressStore[2] == 1)
                main_player.playerX -= 7;
            if (keyPressStore[3] == 1)
                main_player.playerX += 7;
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

        private void player_shooting_timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
    public class main_character
    {
        float shootSpeed = 5;
        public int playerX = 0, playerY = 0;
        Point bulletPlace;
        public main_character(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), 200, 375, 50, 50);
        }
        public void repaint_place(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), playerX, 375 + playerY, 50, 50);
        }
        public void shoot(Graphics g)
        {
            //MessageBox.Show("射擊");
            if (bulletPlace.IsEmpty)
                bulletPlace = new Point(playerX, playerY - 50);
            else {
                bulletPlace.Y -= 1;
                if(bulletPlace.Y==0)
                    bulletPlace= Point.Empty;
            }
            g.FillRectangle(new SolidBrush(Color.Black),bulletPlace.X,bulletPlace.Y,50,50);
        }
    }

}