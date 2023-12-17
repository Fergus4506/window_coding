﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Globalization;


namespace final_project
{
    public partial class Form1 : Form
    {
        Graphics g;
        main_character main_player = null;//目前玩家的物件
        std_opt[] std_Opt = null;//敵人的陣列(儲存敵人實作物件的陣列)
        public int[] keyPressStore = new int[] { 0, 0, 0, 0 };//判斷目前有哪些按鈕被按下的陣列
        int shootDelay = 500;
        int rebirth = 50;//敵人復活的CD
        int delifeDelay = 40;//玩家受傷時的無敵時間
        Random howManyOpt = new Random();
        Random Opt_place = new Random();
        bool check_game_start = false;//確定有沒有開始遊戲(沒有不做timer)
        WindowsMediaPlayer player;//背景音樂播放器
        public int level;
        PrivateFontCollection pfc;
        bool upCk = true;
        public boss_1[] boss_1s = null;
        int boosStep = 2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            opt_timer.Enabled = false;
            player_timer.Enabled = false;

            //建立背景音樂的程式
            player = new WindowsMediaPlayer();
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            //MessageBox.Show(directory);
            string path = Path.GetFullPath(directory + @"defult_backmicus.mp3");
            player.settings.volume = 70;
            player.settings.setMode("loop", true);//特別注意(循環播放)
            player.URL = path;
            player.controls.play();

            //Create your private font collection object.
            pfc = new PrivateFontCollection();

            //Select your font from the resources.
            //My font here is "Digireu.ttf"
            int fontLength = Resource1.Cubic_11_1_010_R.Length;

            // create a buffer to read in to
            byte[] fontdata = Resource1.Cubic_11_1_010_R;

            // create an unsafe memory block for the font data(need to using System.Runtime.InteropServices)
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);

            //抓取原本文字的樣式並添加進新建的文字中以規範新建的文字樣式
            FontStyle fs = game_title.Font.Style;
            game_title.Font = new Font(pfc.Families[0], 28.0F, fs);
            show_life.Font = new Font(pfc.Families[0], 12.0F, show_life.Font.Style);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (check_game_start) {
                g = e.Graphics;
                repaint_image_player(g);//重畫玩家

                //如果敵人未處於死亡cd的話重畫敵人
                if (rebirth == 50 && level!=boosStep)
                    repaint_image_std_opt(g);

                //如果玩家射擊cd轉好後執行畫子彈的位置(包括重劃子彈)
                if (shootDelay == 500)
                    main_player.shoot(g);

                //如果敵人射擊cd轉好後且敵人沒有全部被擊敗時畫敵人的子彈位置(包括重畫子彈)
                if (shootDelay == 500 && std_Opt != null && level!=boosStep)
                    for (int i = 0; i < std_Opt.Length; i++)
                    {
                        if (std_Opt[i] != null)
                            std_Opt[i].shoot(g, level, i);
                    }
                if (level == boosStep) { 
                    repaint_image_boss(g);
                    boss_1s[0].shoot(g,level,0);
                }
            }
        }

        //畫玩家位置的函式(如果沒有玩家物件的畫則新增)
        void repaint_image_player(Graphics g)
        {
            if (main_player == null)
                main_player = new main_character(g);
            else
                main_player.repaint_place(g);
        }

        //重畫敵人的位置
        void repaint_image_std_opt(Graphics g)
        {
            //如果敵人全部陣亡(std_Opt的陣列為null)則重新新增敵人的數量和實作敵人物件
            if (std_Opt == null)
            {
                level++;
                upCk = true;
                std_Opt = new std_opt[howManyOpt.Next(2 + Math.Min(level % 10, 3), Math.Max(5, Math.Min(level, 10)))];

                for (int i = 0; i < std_Opt.Length; i++)
                {
                    std_Opt[i] = new std_opt(g, Opt_place,level,i);
                }
                //show_life.Text=level.ToString();
            }
            else {
                //如果敵人還有沒陣亡的就重畫他的位置，並且計算有幾個敵人陣亡了
                int checkHowManyOptExist = 0;
                for (int i = 0; i < std_Opt.Length; i++)
                {
                    if (std_Opt[i] == null)
                    {
                        checkHowManyOptExist += 1;
                    }
                    else if (std_Opt[i].playerY >= 600) {
                        std_Opt[i] = null;
                        checkHowManyOptExist += 1;
                    }
                    else
                    {
                        std_Opt[i].repaint_place(g);
                    }
                }
                //show_life.Text=std_Opt.Length.ToString();
                //如果判定到所有敵人都陣亡了則把std_Opt陣列改為null
                if (checkHowManyOptExist == std_Opt.Length) {
                    std_Opt = null;
                    rebirth = 0;
                }
            }
        }

        void repaint_image_boss(Graphics g) {
            if (boss_1s== null)
            {
                boss_1s = new boss_1[1];
                boss_1s[0] = new boss_1(g);
                
            }
            else {
                boss_1s[0].repaint_place(g);
            }
        }

        //根據陣列去判斷按下按下的按鍵再去做位移的動作(為了讓他可以斜對角移動所以才這樣寫)
        //簡單來說就是玩家的操作控制器
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

        //下面兩個函式會去改變keyPressStore陣列裡面的值以此去判斷現在所按的按鍵
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

        //觸發玩家控制器的地方(用timer去判斷多久要觸發判斷，類似遊戲的FPS)
        private void player_timer_Tick(object sender, EventArgs e)
        {
            main_move();
        }

        //觸發有關敵人相關判定的地方(包括但不限敵人的移動、敵人擊中玩家和玩家擊中敵人)
        private void opt_timer_Tick(object sender, EventArgs e)
        {

            //敵人復活的CD時間
            if (rebirth < 50)
                rebirth += 5;

            //玩家被敵人擊中時的動畫
            if (delifeDelay < 40) {
                if (main_player.change_state == 0)
                    main_player.plane = Resource1.spaceship_mode1_full_hat;
                else
                    main_player.plane = Resource1.spaceship_mode1_full_h;
                main_player.change_state = (main_player.change_state + 1) % 2;
                delifeDelay += 5;
            }

            //判斷玩家是否擊中敵人和擊中哪一個敵人和敵人移動的方式
            if (std_Opt != null) {
                for (int i = 0; i < std_Opt.Length; i++) {
                    if (std_Opt[i] != null) {
                        std_Opt[i].playerY += 2;
                        if (std_Opt[i].being_attacked(main_player))
                        {
                            std_Opt[i] = null;
                        }
                    }

                }

            }

            //判斷玩家是否被敵人擊中
            if (main_player != null && std_Opt != null) {
                for (int i = 0; i < std_Opt.Length; i++) {
                    if (std_Opt[i] != null) {
                        if (main_player.being_attacked(std_Opt[i]) && delifeDelay == 40)
                        {
                            delifeDelay = 0;
                            main_player.life -= 1;
                            show_life.Text = main_player.life.ToString();
                        }
                    }
                }
            }
            if (level % 5 == 0 && upCk) {
                main_player.playerUp(pfc, main_player, player_timer, opt_timer, show_life, this);
                upCk = false;
            }
            if (level == boosStep) { 
                opt_timer.Stop();
                boss_timer.Start();
                boss1_life.Visible = true;
                boss1_life.Maximum = 20;
                boss1_life.Minimum = 0;
                boss1_life.Value = 20;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            //開始遊戲的設定
            start_button.Visible = false;
            game_title.Visible = false;
            player_timer.Enabled = true;
            opt_timer.Enabled = true;
            check_game_start = true;
            show_life.Visible = true;
            heart_picture.Visible = true;
            dob_mode_button.Visible = false;
            chl_mode_button.Visible = false;
        }

        private void setting_button_Click(object sender, EventArgs e)
        {
            //呼叫Form2去改變聲音大小
            Form2 f = new Form2(player, player_timer, opt_timer);
            f.Show();
        }

        private void boss_timer_Tick(object sender, EventArgs e)
        {

            if (delifeDelay < 40)
            {
                if (main_player.change_state == 0)
                    main_player.plane = Resource1.spaceship_mode1_full_hat;
                else
                    main_player.plane = Resource1.spaceship_mode1_full_h;
                main_player.change_state = (main_player.change_state + 1) % 2;
                delifeDelay += 5;
            }

            if (main_player != null && boss_1s != null)
            {
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (main_player.being_attacked(boss_1s[i]) && delifeDelay == 40)
                        {
                            delifeDelay = 0;
                            main_player.life -= 1;
                            show_life.Text = main_player.life.ToString();
                        }
                    }
                }
            }
            if (boss_1s != null)
            {
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (boss_1s[i].being_attacked(main_player)) { 
                            boss1_life.Value = boss_1s[i].life;
                        }
                    }

                }

            }

        }
    }

    //玩家物件
    public class main_character
    {
        public int shootSpeed = 5;//玩家的射擊速度
        public int bulletSize = 5;//玩家子彈大小
        //playerX、Y為玩家操縱的腳色所在的位置
        //change_state為玩家目前的狀態(被擊中的狀態、死亡的狀態等等)
        public int playerX = 200, playerY = 375, life = 3, change_state = 0;

        public Point bulletPlace;//子彈位置
        public Image plane = Resource1.spaceship_mode1_full_h;//玩家的飛船圖式
        Image bullet = Resource1.bullet_temp;//子彈的樣式

        //開始時重畫玩家的建構子
        public main_character(Graphics g)
        {
            g.DrawImage(plane, 200, 375, 60, 60);
        }

        //重畫玩家的位置(因為會有移動的需求)
        public void repaint_place(Graphics g)
        {
            g.DrawImage(plane, playerX, playerY, 60, 60);
        }

        //玩家子彈射擊的函式
        public void shoot(Graphics g)
        {

            //如果目前沒有子彈存在的畫則重畫
            if (bulletPlace.IsEmpty)
                bulletPlace = new Point(playerX + 30 - bulletSize / 2, playerY - 10);
            else {
                //如果子彈超過了視窗Y軸的上限話則把子彈消失，不然就讓子彈繼續往Y軸走
                bulletPlace.Y -= 1 * shootSpeed;
                if (bulletPlace.Y <= 0)
                    bulletPlace = Point.Empty;
                else
                    g.DrawImage(bullet, bulletPlace.X, bulletPlace.Y, bulletSize, 20);
            }

        }

        //去判斷玩家是否被敵人的子彈打中(用數學的方式去算實際有沒有重疊)
        public bool being_attacked(std_opt Opt)
        {
            if (Opt.bulletPlace != null) {
                for (int i = 0; i < Opt.bulletPlace.Length; i++)
                {
                    if (Opt.bulletPlace[i] != Point.Empty) {
                        if (Opt.bulletPlace[i].X < playerX+40 && Opt.bulletPlace[i].X+Opt.bulletsize > playerX && Opt.bulletPlace[i].Y <= playerY + 20 && Opt.bulletPlace[i].Y >= playerY-20)
                        {
                            //MessageBox.Show("重");
                            return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }
        //去判斷玩家是否被敵人的子彈打中(用數學的方式去算實際有沒有重疊)
        public bool being_attacked(boss_1 Opt)
        {
            if (Opt.bulletPlace != null)
            {
                for (int i = 0; i < Opt.bulletPlace.Length; i++)
                {
                    if (Opt.bulletPlace[i].X < playerX + 40 && Opt.bulletPlace[i].X + Opt.bulletsize > playerX && Opt.bulletPlace[i].Y <= playerY + 20 && Opt.bulletPlace[i].Y >= playerY)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public void playerUp(PrivateFontCollection pfc, main_character player, Timer t1, Timer t2, Label life, Form1 f1) {
            Form temp = new Form3(pfc, player, t1, t2, life, f1);
            temp.Show();
        }
    }

    //一般敵人的物件
    public class std_opt {
        int shootSpeed = 1;
        public int playerX, playerY = 0;
        public Point[] bulletPlace;
        public int bulletsize = 10;
        bool[] bulletshootck;
        Image opt_image;
        Image bullet = Resource1.bullet_temp;

        //新建敵人時的建構子(在敵人被全部擊敗時會被呼叫)
        public std_opt(Graphics g, Random R,int level,int id_opt)
        {
            playerX = R.Next(0, 400);
            playerY = R.Next(-100, -1);
            if (level > 5 && id_opt % 2 == 0)
            {
                opt_image = Resource1.opt_kind2_stage1;
            }
            else
            {
                opt_image = Resource1.opt_kind1_stage1;
            }
            g.DrawImage(opt_image, playerX, playerY, 60, 60);

        }

        //重畫敵人的位置(敵人行為模式的函示)
        public void repaint_place(Graphics g)
        {
            g.DrawImage(opt_image, playerX, playerY, 40, 40);
            //g.FillEllipse(new SolidBrush(Color.Black), playerX , playerY,5,5);
        }

        //敵人的子彈射擊函式
        public void shoot(Graphics g, int level, int id_opt)
        {
            if (playerY >= 0) {
                //MessageBox.Show("射擊");
                if (level > 5 && id_opt % 2 == 0)
                {
                    shoot_mode_2(g);
                }
                else {
                    
                    shoot_mode_1(g);
                }

            }
        }

        //敵人判定是否被擊中的函式
        public bool being_attacked(main_character player) {
            if (player.bulletPlace.X > playerX - player.bulletSize && player.bulletPlace.X < playerX + 40 && player.bulletPlace.Y < playerY+30 && player.bulletPlace.Y > playerY)
            {
                //MessageBox.Show("重");

                return true;
            }
            else {
                return false;
            }
        }
        //只會射擊一發子彈的基本射擊模式
        public void shoot_mode_1(Graphics g) {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[1];
                bulletPlace[0] = new Point(playerX + 20-bulletsize/2, playerY + 30);
            }
            else
            {
                bulletPlace[0].Y = bulletPlace[0].Y + 2 * shootSpeed;
                if (bulletPlace[0].Y >= 600)
                    bulletPlace = null;
                else
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[0].X , bulletPlace[0].Y, bulletsize, 20);
            }
        }
        //散射的射擊模式(會射擊三發子彈)
        public void shoot_mode_2(Graphics g)
        {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[3];
                bulletshootck = new bool[3];
                for (int i = 0; i < 3; i++) {
                    bulletPlace[i] = new Point(playerX, playerY + 30);
                    bulletshootck[i] = false;
                }
            }
            else
            {
                //這裡是三個不同方向的子彈所需要做的位移(分別是中、左、右)
                int count_how_bullet_out = 0;


                //因為每一點在生成時都會在Y軸+30所以可以用把點設回原點的方式來確定點是否超界了
                if (bulletPlace[0].Y > 600 || bulletshootck[0])
                {
                    bulletshootck[0] = true;
                    count_how_bullet_out++;
                }
                else {
                    bulletPlace[0].Y = bulletPlace[0].Y + 2 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[0].X + bulletsize, bulletPlace[0].Y, 10, 20);
                }



                if (bulletPlace[1].Y > 600 || bulletPlace[1].X > 450 || bulletshootck[1])
                {
                    bulletshootck[1] = true;
                    count_how_bullet_out++;
                }
                else {
                    bulletPlace[1].Y = bulletPlace[1].Y + 1 * shootSpeed;
                    bulletPlace[1].X = bulletPlace[1].X + 1 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[1].X + bulletsize, bulletPlace[1].Y, 10, 20);
                }



                if (bulletPlace[2].Y > 600 || bulletPlace[2].X < 0 || bulletshootck[2])
                {

                    bulletshootck[2] = true;
                    count_how_bullet_out++;
                }
                else {
                    bulletPlace[2].Y = bulletPlace[2].Y + 1 * shootSpeed;
                    bulletPlace[2].X = bulletPlace[2].X - 1 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[2].X + bulletsize, bulletPlace[2].Y, 10, 20);
                }


                //如果三點都超界了就去重劃射擊
                if (count_how_bullet_out == 3) {
                    bulletPlace = null;
                    bulletshootck = null;
                }
            }
        }

    }

    public class boss_1{
        int shootSpeed = 1;
        public int playerX, playerY = 0;
        public int life = 20;
        public int nextX=1, nextY=1;
        public Point[] bulletPlace;
        public int[] way_for_bullet;
        Image opt_image = Resource1.boss_kind1_stage1;
        Image bullet = Resource1.bullet_temp;
        public int bulletsize = 10;
        public boss_1(Graphics g) {
            playerX = 200;
            playerY = 0;
            g.DrawImage(opt_image, playerX, playerY, 72, 89);
        }
        public void repaint_place(Graphics g)
        {
            if (playerX+72 >= 450 || playerX <= 0) {
                nextX = -nextX;
            }
            if (playerY >= 200 || playerY < 0) { 
                nextY = -nextY;
            }
            playerX = playerX + nextX;
            playerY = playerY + nextY;
            g.DrawImage(opt_image, playerX, playerY, 72, 89);
            //g.FillEllipse(new SolidBrush(Color.Black), playerX , playerY,5,5);
        }
        
        public bool being_attacked(main_character player)
        {
            if (player.bulletPlace.X > playerX - player.bulletSize && player.bulletPlace.X < playerX + 100 && player.bulletPlace.Y < playerY +89 && player.bulletPlace.Y > playerY)
            {
                //MessageBox.Show("重");
                player.bulletPlace = Point.Empty;
                this.life -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void shoot(Graphics g, int level, int id_opt)
        {
            shoot_mode_1(g);
        }
        public void shoot_mode_1(Graphics g)
        {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[6];
                way_for_bullet=new int[6];
                for (int i = 0; i < 6; i++)
                {
                    bulletPlace[i] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[i] = 1;
                }
            }
            else
            {
                //因為每一點在生成時都會在Y軸+30所以可以用把點設回原點的方式來確定點是否超界了
                if (bulletPlace[0].Y > 600)
                {
                    bulletPlace[0] = new Point(playerX + 35, playerY + 89);
                }
                else
                {
                    bulletPlace[0].Y = bulletPlace[0].Y + 2 * shootSpeed * way_for_bullet[0];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[0].X + bulletsize, bulletPlace[0].Y, 10, 20);
                }

                if (bulletPlace[1].Y > 750 || bulletPlace[1].X > 600 || bulletPlace[1].X < 0)
                {
                    bulletPlace[1] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[1] = -way_for_bullet[1];
                }
                else
                {
                    bulletPlace[1].Y = bulletPlace[1].Y + 2 * shootSpeed;
                    bulletPlace[1].X = bulletPlace[1].X + 2 * shootSpeed * way_for_bullet[1];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[1].X + bulletsize, bulletPlace[1].Y, 10, 20);
                }

                if (bulletPlace[2].Y > 750 || bulletPlace[2].X < 0 || bulletPlace[2].X > 600)
                {

                    bulletPlace[2] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[2] = -way_for_bullet[2];
                }
                else
                {
                    bulletPlace[2].Y = bulletPlace[2].Y + 2 * shootSpeed;
                    bulletPlace[2].X = bulletPlace[2].X - 2 * shootSpeed * way_for_bullet[2];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[2].X + bulletsize, bulletPlace[2].Y, 10, 20);
                }

                if (bulletPlace[3].Y > 750 || bulletPlace[3].X > 600 || bulletPlace[3].X < 0)
                {
                    bulletPlace[3] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[3] = -way_for_bullet[3];
                }
                else
                {
                    bulletPlace[3].Y = bulletPlace[3].Y + 2 * shootSpeed;
                    bulletPlace[3].X = bulletPlace[3].X + 3 * shootSpeed * way_for_bullet[3];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[3].X + bulletsize, bulletPlace[3].Y, 10, 20);
                }

                if (bulletPlace[4].Y > 750 || bulletPlace[4].X > 600 || bulletPlace[4].X < 0)
                {
                    bulletPlace[4] = new Point(playerX+31, playerY + 89);
                    way_for_bullet[4] = -way_for_bullet[4];
                }
                else
                {
                    bulletPlace[4].Y = bulletPlace[4].Y + 3 * shootSpeed;
                    bulletPlace[4].X = bulletPlace[4].X - 2 * shootSpeed*way_for_bullet[4];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[4].X + bulletsize, bulletPlace[4].Y, 10, 20);
                }
                if (bulletPlace[5].Y > 600)
                {
                    bulletPlace[5] = new Point(playerX + 26, playerY + 89);
                    way_for_bullet[5] = -way_for_bullet[5];
                }
                else
                {
                    if (way_for_bullet[5] == 5) {
                        bulletPlace[5].Y = bulletPlace[5].Y + 4 * shootSpeed;
                        g.DrawImage(Resource1.bullet_temp, bulletPlace[5].X + bulletsize, bulletPlace[5].Y, 10, 20);
                    }
                    else {
                        way_for_bullet[5]++;
                    }                    
                }
            }
        }
    }
}
