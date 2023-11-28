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
        main_character main_player = null;//目前玩家的物件
        std_opt[] std_Opt = null;//敵人的陣列(儲存敵人實作物件的陣列)
        int[] keyPressStore = new int[] { 0, 0, 0, 0 };//判斷目前有哪些按鈕被按下的陣列
        int shootDelay = 500;
        int rebirth = 50;//敵人復活的CD
        int delifeDelay = 20;//玩家受傷時的無敵時間
        Random howManyOpt = new Random();
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
            repaint_image_player(g);//重畫玩家

            //如果敵人未處於死亡cd的話重畫敵人
            if(rebirth==50)
                repaint_image_std_opt(g);

            //如果玩家射擊cd轉好後執行畫子彈的位置(包括重劃子彈)
            if (shootDelay == 500)
                main_player.shoot(g);

            //如果敵人射擊cd轉好後且敵人沒有全部被擊敗時畫敵人的子彈位置(包括重畫子彈)
            if (shootDelay == 500 && std_Opt != null)
                for (int i = 0; i < std_Opt.Length; i++) {
                    if(std_Opt[i]!=null)
                        std_Opt[i].shoot(g);
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
                std_Opt = new std_opt[howManyOpt.Next(1, 5)];
                for (int i = 0; i < std_Opt.Length; i++)
                {
                    std_Opt[i] = new std_opt(g);
                }
            }
            else {
                //如果敵人還有沒陣亡的就重畫他的位置，並且計算有幾個敵人陣亡了
                int checkHowManyOptExist=0;
                for (int i = 0; i < std_Opt.Length; i++)
                {
                    if (std_Opt[i] == null)
                    {
                        checkHowManyOptExist += 1;
                    }
                    else {
                        std_Opt[i].repaint_place(g);
                    }
                }

                //如果判定到所有敵人都陣亡了則把std_Opt陣列改為null
                if (checkHowManyOptExist == std_Opt.Length) {
                    std_Opt = null;
                    rebirth = 0;
                }
                    
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
            if (delifeDelay < 20) {
                if (main_player.change_state == 0)
                    main_player.plane = Resource1.spaceship_beack;
                else
                    main_player.plane = Resource1.spaceship;
                main_player.change_state = (main_player.change_state + 1) % 2;
                delifeDelay += 5;
            }
                
            //判斷玩家是否擊中敵人和擊中哪一個敵人
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

            //判斷敵人是否被敵人擊中
            if (main_player != null && std_Opt!=null) {
                for (int i = 0; i < std_Opt.Length; i++) {
                    if (std_Opt[i] != null) {
                        if (main_player.being_attacked(std_Opt[i]) && delifeDelay == 20)
                        {
                            delifeDelay = 0;
                            main_player.life -= 1;
                            show_life.Text = "剩餘血量:" + main_player.life;
                        }
                    }
                }
            }
        }
    }

    //玩家物件
    public class main_character
    {
        int shootSpeed = 5;//玩家的射擊速度

        //playerX、Y為玩家操縱的腳色所在的位置
        //change_state為玩家目前的狀態(被擊中的狀態、死亡的狀態等等)
        public int playerX = 200, playerY = 375,life=3,change_state=0;

        public Point bulletPlace;//子彈位置
        public Image plane = Resource1.spaceship;//玩家的飛船圖式
        Image bullet = Resource1.bullet_temp;//子彈的樣式

        //開始時重畫玩家的建構子
        public main_character(Graphics g)
        {
            g.DrawImage(plane, 200, 375, 50, 50);
        }

        //重畫玩家的位置(因為會有移動的需求)
        public void repaint_place(Graphics g)
        {
            g.DrawImage(plane, playerX,playerY, 50, 50);
        }

        //玩家子彈射擊的函式
        public void shoot(Graphics g)
        {
            
            //如果目前沒有子彈存在的畫則重畫
            if (bulletPlace.IsEmpty)
                bulletPlace = new Point(playerX, playerY - 10);
            else {
                //如果子彈超過了視窗Y軸的上限話則把子彈消失，不然就讓子彈繼續往Y軸走
                bulletPlace.Y -= 5*shootSpeed;
                if (bulletPlace.Y <= 0)
                    bulletPlace = Point.Empty;
                else
                    g.DrawImage(bullet, bulletPlace.X + 20, bulletPlace.Y, 10, 20);
            }

        }

        //去判斷玩家是否被敵人的子彈打中(用數學的方式去算實際有沒有重疊)
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

    //一般敵人的物件
    public class std_opt{
        float shootSpeed = 5;
        public int playerX = 200, playerY = 0;
        public Point bulletPlace;
        Random R = new Random();//敵人生成位置的隨機變數
        Image opt_image= Resource1.ufo_1;
        Image bullet = Resource1.bullet_temp;

        //新建敵人時的建構子(在敵人被全部擊敗時會被呼叫)
        public std_opt(Graphics g)
        {
            playerX = R.Next(0, 400);
            g.DrawImage(opt_image, playerX, 0, 30, 30);
        }

        //重畫敵人的位置(敵人行為模式的函示)
        public void repaint_place(Graphics g)
        {
            g.DrawImage(opt_image, playerX, playerY, 30, 30);
        }

        //敵人的子彈射擊函式
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

        //敵人判定是否被擊中的函式
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
