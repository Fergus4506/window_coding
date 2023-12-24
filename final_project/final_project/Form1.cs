using System;
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
        public int[] keyPressStore_p2 = new int[] { 0, 0, 0, 0 };//判斷目前有哪些按鈕被按下的陣列
        int shootDelay = 500;
        int rebirth = 50;//敵人復活的CD
        int delifeDelay = 40;//玩家受傷時的無敵時間
        Random howManyOpt = new Random();
        Random Opt_place = new Random();
        bool check_game_start = false;//確定有沒有開始遊戲(沒有不做timer)
        WindowsMediaPlayer player;//背景音樂播放器
        public int level;
        public int step;
        PrivateFontCollection pfc;
        bool upCk = true;
        public boss_1[] boss_1s = null;
        int boosStep = 2;
        public bool check_two_boss = false;
        public main_character[] two_player_mode=null;
        public bool check_two_player_mode = false;
        public int[] two_delay=new int[] {50,50};
        public bool check_two_player_chl=false;
        public int[] shoot_delay_to_two =new int[] { 0 ,0};
        public bool change_step_anim=false;
        public int trsp_back_value = 0;
        public bool show_back_in_change=false;
        public bool player_out_of_form = false;
        public Image[] trsp_step1_back= null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            opt_timer.Enabled = false;
            player_timer.Enabled = false;
            trsp_step1_back=new Image[10] { 
                Resource1.background_step1_90,
                Resource1.background_step1_85,
                Resource1.background_step1_80,
                Resource1.background_step1_70,
                Resource1.background_step1_60,
                Resource1.background_step1_50,
                Resource1.background_step1_40,
                Resource1.background_step1_30,
                Resource1.background_step1_20,
                Resource1.background_step1_10
            };

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
            show_life_p2.Font = new Font(pfc.Families[0], 12.0F, show_life_p2.Font.Style);
            show_life_p2_chl.Font = new Font(pfc.Families[0], 12.0F, show_life_p2_chl.Font.Style);
            gameover.Font = new Font(pfc.Families[0], 28.0F, gameover.Font.Style);
            teach_lab.Font = new Font(pfc.Families[0], 14.0F, teach_lab.Font.Style);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (check_game_start)
            {
                g = e.Graphics;
                repaint_image_player(g);//重畫玩家

                //如果敵人未處於死亡cd的話重畫敵人
                if (rebirth == 50 && level != boosStep)
                    repaint_image_std_opt(g);

                //如果玩家射擊cd轉好後執行畫子彈的位置(包括重劃子彈)
                if (main_player != null)
                {
                    if (shootDelay == 500 && main_player.life > 0)
                        main_player.shoot(g);
                }


                //如果敵人射擊cd轉好後且敵人沒有全部被擊敗時畫敵人的子彈位置(包括重畫子彈)
                if (shootDelay == 500 && std_Opt != null && level != boosStep)
                    for (int i = 0; i < std_Opt.Length; i++)
                    {
                        if (std_Opt[i] != null)
                            std_Opt[i].shoot(g, level, i);
                    }


                if (level == boosStep)
                {
                    repaint_image_boss(g);
                }
            }
            else if (check_two_player_mode)
            {
                g = e.Graphics;
                if (two_player_mode == null)
                {
                    two_player_mode = new main_character[2];
                    for (int i = 0; i < 2; i++)
                    {
                        two_player_mode[i] = new main_character(g, i);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        two_player_mode[i].repaint_place(g);
                        if (i == 0)
                            two_player_mode[i].shoot(g);
                        else
                            two_player_mode[i].shoot(g, i);
                    }
                }

            }
            else if (check_two_player_chl)
            {
                g = e.Graphics;
                if (two_player_mode == null)
                {
                    two_player_mode = new main_character[2];
                    for (int i = 0; i < 2; i++)
                    {
                        two_player_mode[i] = new main_character(g);
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (two_player_mode[i] != null)
                        {
                            two_player_mode[i].repaint_place(g);
                            if (shootDelay == 500 && two_player_mode[i].life > 0)
                            {
                                two_player_mode[i].shoot(g);
                            }
                        }


                    }
                }
                //如果敵人未處於死亡cd的話重畫敵人
                if (rebirth == 50 && level != boosStep)
                    repaint_image_std_opt(g, 0);

                //如果敵人射擊cd轉好後且敵人沒有全部被擊敗時畫敵人的子彈位置(包括重畫子彈)
                if (shootDelay == 500 && std_Opt != null && level != boosStep)
                    for (int i = 0; i < std_Opt.Length; i++)
                    {
                        if (std_Opt[i] != null)
                            std_Opt[i].shoot(g, level, i);
                    }
                if (level == boosStep)
                {
                    repaint_image_boss(g, 0);
                }
            }
            else if (change_step_anim)
            {
                g = e.Graphics;
                repaint_image_player(g);
            }
        }

        //畫玩家位置的函式(如果沒有玩家物件的畫則新增)
        void repaint_image_player(Graphics g)
        {
            if (main_player == null)
                main_player = new main_character(g);
            else
                main_player.repaint_place(g);
            main_player.life = 100;
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

        void repaint_image_std_opt(Graphics g,int id)
        {
            //如果敵人全部陣亡(std_Opt的陣列為null)則重新新增敵人的數量和實作敵人物件
            if (std_Opt == null)
            {
                level++;
                upCk = true;
                std_Opt = new std_opt[howManyOpt.Next((2 + Math.Min(level % 10, 3))*2,( Math.Max(5, Math.Min(level, 10)))*3)];

                for (int i = 0; i < std_Opt.Length; i++)
                {
                    std_Opt[i] = new std_opt(g, Opt_place, level, i);
                    std_Opt[i].shootSpeed = 1;
                }
                //show_life.Text=level.ToString();
            }
            else
            {
                //如果敵人還有沒陣亡的就重畫他的位置，並且計算有幾個敵人陣亡了
                int checkHowManyOptExist = 0;
                for (int i = 0; i < std_Opt.Length; i++)
                {
                    if (std_Opt[i] == null)
                    {
                        checkHowManyOptExist += 1;
                    }
                    else if (std_Opt[i].playerY >= 600)
                    {
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
                if (checkHowManyOptExist == std_Opt.Length)
                {
                    std_Opt = null;
                    rebirth = 0;
                }
            }
        }

        void repaint_image_boss(Graphics g)
        {
            if (boss_1s == null)
            {
                boss_1s = new boss_1[2];
                boss_1s[0] = new boss_1(g);
                boss_1s[1] = null;
            }
            else
            {
                if (check_two_boss && boss_1s[1] == null)
                {
                    boss_1s[1] = new boss_1(g, 1);
                }
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (i == 0)
                        {
                            boss_1s[i].repaint_place(g);
                            boss_1s[i].shoot(g, level, i);
                        }
                        else
                        {
                            boss_1s[i].repaint_place(g,i);
                            boss_1s[i].shoot(g, level, i);
                        }


                    }
                }

            }
        }

        void repaint_image_boss(Graphics g,int d) {
            if (boss_1s== null)
            {
                boss_1s = new boss_1[2];
                boss_1s[0] = new boss_1(g);
                if (check_two_player_chl) {
                    boss_1s[0].life = 40;
                }
                boss_1s[1] = null;
            }
            else {
                if (check_two_boss && boss_1s[1] == null)
                {
                    boss_1s[1]= new boss_1(g,1);
                    if (check_two_player_chl)
                    {
                        boss_1s[1].life = 40;
                        boss_1s[1].shootSpeed = 1;
                    }
                }
                for (int i = 0; i < boss_1s.Length; i++) { 
                    if (boss_1s[i] != null) {
                        if (i == 0)
                        {
                            boss_1s[i].repaint_place(g);
                            if (shoot_delay_to_two[i] == 1)
                            {
                                boss_1s[i].shoot(g, level, i);
                                shoot_delay_to_two[i] = 0;
                            }
                            else {
                                boss_1s[i].shoot_in_time_delay(g);
                                shoot_delay_to_two[i]++;
                            }
                                
                        }
                        else {
                            boss_1s[i].repaint_place(g, 1);
                            boss_1s[i].shoot(g, level, i);
                        }
                            
                        
                    }
                }
                
            }
        }

        //根據陣列去判斷按下按下的按鍵再去做位移的動作(為了讓他可以斜對角移動所以才這樣寫)
        //簡單來說就是玩家的操作控制器
        private void main_move()
        {
            if (check_game_start)
            {
                if (keyPressStore[0] == 1 && main_player.playerY>0)
                    main_player.playerY -= 10;
                if (keyPressStore[1] == 1 && main_player.playerY < 500)
                    main_player.playerY += 10;
                if (keyPressStore[2] == 1 && main_player.playerX>-20)
                    main_player.playerX -= 10;
                if (keyPressStore[3] == 1 && main_player.playerX < 400)
                    main_player.playerX += 10;
            }
            else if (check_two_player_mode)
            {
                if (keyPressStore[0] == 1 && two_player_mode[0].playerY > 0)
                    two_player_mode[0].playerY -= 10;
                if (keyPressStore[1] == 1 && two_player_mode[0].playerY < 500)
                    two_player_mode[0].playerY += 10;
                if (keyPressStore[2] == 1 && two_player_mode[0].playerX > -20)
                    two_player_mode[0].playerX -= 10;
                if (keyPressStore[3] == 1 && two_player_mode[0].playerX < 400)
                    two_player_mode[0].playerX += 10;

                if (keyPressStore_p2[0] == 1 && two_player_mode[1].playerY > 0)
                    two_player_mode[1].playerY -= 10;
                if (keyPressStore_p2[1] == 1 && two_player_mode[1].playerY < 500)
                    two_player_mode[1].playerY += 10;
                if (keyPressStore_p2[2] == 1 && two_player_mode[1].playerX > -20)
                    two_player_mode[1].playerX -= 10;
                if (keyPressStore_p2[3] == 1 && two_player_mode[1].playerX < 400)
                    two_player_mode[1].playerX += 10;
            }
            else if (check_two_player_chl) {
                if (two_player_mode[0] != null) {
                    if (keyPressStore[0] == 1 && two_player_mode[0].playerY > 0)
                        two_player_mode[0].playerY -= 10;
                    if (keyPressStore[1] == 1 && two_player_mode[0].playerY < 500)
                        two_player_mode[0].playerY += 10;
                    if (keyPressStore[2] == 1 && two_player_mode[0].playerX > -20)
                        two_player_mode[0].playerX -= 10;
                    if (keyPressStore[3] == 1 && two_player_mode[0].playerX < 400)
                        two_player_mode[0].playerX += 10;
                }

                if (two_player_mode[1] != null) {
                    if (keyPressStore_p2[0] == 1 && two_player_mode[1].playerY > 0)
                        two_player_mode[1].playerY -= 10;
                    if (keyPressStore_p2[1] == 1 && two_player_mode[1].playerY < 500)
                        two_player_mode[1].playerY += 10;
                    if (keyPressStore_p2[2] == 1 && two_player_mode[1].playerX > -20)
                        two_player_mode[1].playerX -= 10;
                    if (keyPressStore_p2[3] == 1 && two_player_mode[1].playerX < 400)
                        two_player_mode[1].playerX += 10;
                }
                
            }
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
            if (e.KeyValue == (int)Keys.Up)
                keyPressStore_p2[0]=1;
            else if (e.KeyValue == (int)Keys.Down)
                keyPressStore_p2[1] = 1;
            if (e.KeyValue == (int)Keys.Left)
                keyPressStore_p2[2] = 1;
            else if (e.KeyValue == (int)Keys.Right)
                keyPressStore_p2[3] = 1;
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
            if (e.KeyValue == (int)Keys.Up)
                keyPressStore_p2[0] = 0;
            else if (e.KeyValue == (int)Keys.Down)
                keyPressStore_p2[1] = 0;
            if (e.KeyValue == (int)Keys.Left)
                keyPressStore_p2[2] = 0;
            else if (e.KeyValue == (int)Keys.Right)
                keyPressStore_p2[3] = 0;
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
            if (main_player.life <= 0)
            {
                if (main_player.die(this))
                {
                    gameover.Visible = true;
                    gameover.Text = "GAME OVER";
                    gameover.Location = new Point(120, 150);
                    opt_timer.Stop();
                    boss_timer.Stop();
                    player_timer.Stop();
                    main_player = null;
                    std_Opt = null;
                    boss_1s = null;
                    start_button.Visible = true;
                    start_button.Image = Resource1.restart_mode_button;
                    dob_mode_button.Visible = true;
                    dob_mode_button.Image = Resource1.dub_mode_button;
                    chl_mode_button.Visible = true;
                    level = 0;
                    boss_life.Visible = false;
                    boss_two_life.Visible = false;
                    check_two_boss = false;
                }
            }
            if (level % 5 == 0 && upCk && main_player!=null && level!=0) {
                main_player.playerUp(pfc, main_player, player_timer, opt_timer, show_life, this);
                upCk = false;
            }
            if (level == boosStep) {
                opt_timer.Stop();
                boss_timer.Start();
                boss_life.Visible = true;
                boss_life.Maximum = 20;
                boss_life.Minimum = 0;
                boss_life.Value = 20;
                boss_two_life.Maximum = 20;
                boss_two_life.Minimum = 0;
                boss_two_life.Value = 20;
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
            gameover.Visible = false;
            show_life.Text = "3";
            show_life_p2.Visible = false;
            hreat_picture_p2.Visible = false;
            two_player_mode = null;
            check_two_player_chl = false;
        }

        private void setting_button_Click(object sender, EventArgs e)
        {
            //呼叫Form2去改變聲音大小
            Form2 f = new Form2(player, player_timer, opt_timer);
            f.Show();
        }

        private void boss_timer_Tick(object sender, EventArgs e)
        {

            if (delifeDelay < 50)
            {
                if (main_player.change_state == 0)
                    main_player.plane = Resource1.spaceship_mode1_full_hat;
                else
                    main_player.plane = Resource1.spaceship_mode1_full_h;
                main_player.change_state = (main_player.change_state + 1) % 2;
                delifeDelay += 5;
            }

            if (main_player.life <= 0) {
                if (main_player.die(this))
                {
                    gameover.Visible = true;
                    gameover.Text = "GAME OVER";
                    gameover.Location = new Point(120,150);
                    opt_timer.Stop();
                    boss_timer.Stop();
                    player_timer.Stop();
                    main_player = null;
                    std_Opt = null;
                    boss_1s = null;
                    start_button.Visible = true;
                    start_button.Image = Resource1.restart_mode_button;
                    dob_mode_button.Visible = true;
                    dob_mode_button.Image = Resource1.dub_mode_button;
                    chl_mode_button.Visible = true;
                    level = 0;
                    boss_life.Visible = false;
                    boss_two_life.Visible = false;
                    check_two_boss = false;
                }
            }
            

            if (main_player != null && boss_1s != null)
            {
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (main_player.being_attacked(boss_1s[i]) && delifeDelay == 50 && i == 0 && main_player.life!=0)
                        {
                            delifeDelay = 0;
                            main_player.life -= 1;
                            show_life.Text = main_player.life.ToString();
                        }
                        else if (main_player.being_attacked(boss_1s[i],1) && delifeDelay == 50 && main_player.life != 0) {
                            delifeDelay = 0;
                            main_player.life -= 3;
                            show_life.Text = main_player.life.ToString();
                        }
                    }
                }
            }
            int count_all_boss_die = 0;
            if (boss_1s != null)
            {
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (boss_1s[i].life > -1 && i == 0)
                        {
                            if (boss_1s[i].being_attacked(main_player)) {
                                boss_life.Value = boss_1s[i].life;
                            }
                            
                        }
                        else if (boss_1s[i].life > -1)
                        {
                            if (boss_1s[i].being_attacked(main_player))
                            {
                                boss_two_life.Value = boss_1s[i].life;
                            }
                        }

                        if (i == 0 && boss_1s[0].life == 10 && boss_1s[1] == null & boss_1s[0] != null)
                        {
                            check_two_boss = true;
                            boss_two_life.Visible = true;
                            
                        }
                        if (boss_1s[i].life == 0)
                        {
                            if (i == 0)
                            {
                                if (boss_1s[i].die(this, boss_life))
                                {
                                    boss_1s[i] = null;
                                }
                            }
                            else {
                                if (boss_1s[i].die(this, boss_two_life))
                                {
                                    boss_1s[i] = null;
                                    check_two_boss = false;
                                }
                            }
                            
                        }
                        
                    }
                    else { 
                        count_all_boss_die++;
                    }
                }
                if (count_all_boss_die == boss_1s.Length) {
                    //MessageBox.Show("boss end");
                    level = 0;
                    rebirth = -10;
                    boss_1s = null;
                    boss_timer.Stop();
                    player_timer.Stop();
                    change_step.Start();
                    check_two_boss = false;
                    check_game_start = false;
                    change_step_anim = true;
                }

            }

        }

        private void change_step_Tick(object sender, EventArgs e)
        {   
            if (player_out_of_form)
            {
                main_player = null;
                if (show_back_in_change)
                {
                    if (trsp_back_value < 10) {
                        this.BackgroundImage = trsp_step1_back[trsp_back_value];
                        trsp_back_value += 1;
                    }
                        
                    
                }
               
            }
            else {
                show_back_in_change = true;
                if (main_player.playerY>=-100)
                {
                    main_player.change_step();
                    Invalidate();
                }
                else
                {
                    //MessageBox.Show("??");
                    player_out_of_form = true;
                    change_step_anim=false;
                }
            }
            
        }

        private void dob_mode_button_Click(object sender, EventArgs e)
        {
            two_player.Start();
            two_player_hat.Start();
            two_player_mode = null;
            check_two_player_mode = true;
            start_button.Visible = false;
            game_title.Visible = false;
            dob_mode_button.Visible = false;
            chl_mode_button.Visible = false;
            gameover.Visible = false;
            check_game_start = false;
            heart_picture.Visible = true;
            hreat_picture_p2.Visible = true;
            show_life.Visible = true;
            show_life_p2.Visible=true;
            show_life.Text = "3";
            show_life_p2.Text = "3";
        }

        private void two_player_Tick(object sender, EventArgs e)
        {
            main_move();
        }

        private void two_player_shoot_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                if (two_delay[i] < 50 && two_player_mode[i] != null)
                {
                    if (i == 0)
                    {
                        if (two_player_mode[i].change_state == 0)
                            two_player_mode[i].plane = Resource1.spaceship_mode1_full_hat;
                        else
                            two_player_mode[i].plane = Resource1.spaceship_mode1_full_h;
                    }
                    else
                    {
                        if (two_player_mode[i].change_state == 0)
                            two_player_mode[i].plane = Resource1.Main_Ship___Base___Full_health_hat_p2;
                        else
                            two_player_mode[i].plane = Resource1.Main_Ship___Base___Full_health_p2;
                    }
                    two_player_mode[i].change_state = (two_player_mode[i].change_state + 1) % 2;
                    two_delay[i] += 5;
                }

            }
            for (int i = 0; i < 2; i++) {
                if (two_player_mode[i] != null)
                {
                    if (i == 0)
                    {
                        if (two_player_mode[i].being_attacked(two_player_mode[1]) && two_delay[i] == 50)
                        {
                            two_delay[i] = 0;
                            two_player_mode[i].life -= 1;
                            show_life_p2.Text = two_player_mode[i].life.ToString();
                        }
                    }
                    else if (i == 1) {
                        if (two_player_mode[i].being_attacked(two_player_mode[0]) && two_delay[i] == 50)
                        {
                            two_delay[i] = 0;
                            two_player_mode[i].life -= 1;
                            show_life.Text = two_player_mode[i].life.ToString();
                        }
                    }
                }
                
            }
            for (int i = 0; i < 2; i++) {
                if (two_player_mode[i].life <= 0)
                {
                    if (two_player_mode[i].die(this))
                    {
                        gameover.Visible = true;
                        two_player_hat.Stop();
                        two_player.Stop();
                        if (two_player_mode[1 - i].life == two_player_mode[i].life) 
                        {
                            gameover.Text = "平局";
                            gameover.Location = new Point(150,215);
                        }
                        else {
                            gameover.Location = new Point(80, 150);
                            gameover.Text = "P" + (2 - i).ToString() + " Win the game";
                        }
                        
                        two_player_mode = null;
                        start_button.Visible = true;
                        start_button.Image = Resource1.std_button;
                        dob_mode_button.Visible = true;
                        dob_mode_button.Image= Resource1.restart_mode_button;
                        chl_mode_button.Visible = true;
                        chl_mode_button.Image = Resource1.challenge_mode_button;
                        level = 0;
                        boss_life.Visible = false;
                        boss_two_life.Visible = false;
                        check_two_boss = false;
                        close_all();
                        break;
                    }
                }
            }
            
        }

        private void chl_mode_button_Click(object sender, EventArgs e)
        {
            check_two_player_chl = true;
            check_two_player_mode = false;
            check_game_start = false;

            start_button.Visible = false;
            dob_mode_button.Visible = false;
            chl_mode_button.Visible = false;

            game_title.Visible = false;
            gameover.Visible = false;
            show_life.Visible = true;
            show_life.Text = "3";
            heart_picture.Visible = true;
            show_life_p2.Visible = false;
            hreat_picture_p2.Visible = false;
            show_life_p2_chl.Visible = true;
            show_life_p2_chl.Text = "3";
            heart_picture_chl_p2.Visible = true;

            player_timer.Enabled = true;
            two_opt_timer.Enabled = true;
            two_player.Enabled = false;
            boss_timer.Enabled = false;
            two_boss_timer.Enabled = false;

            main_player = null;
            two_player_mode = null;







        }

        private void two_opt_timer_Tick(object sender, EventArgs e)
        {
            //敵人復活的CD時間
            if (rebirth < 50)
                rebirth += 5;

            int count_player_die = 0;
            for (int x = 0; x < 2; x++) {
                if (two_player_mode[x] == null) { 
                    count_player_die++;
                    continue;
                }
                //玩家被敵人擊中時的動畫
                if (two_delay[x] < 50 && two_player_mode[x]!=null)
                {
                    if (two_player_mode[x].change_state == 0)
                        two_player_mode[x].plane = Resource1.spaceship_mode1_full_hat;
                    else
                        two_player_mode[x].plane = Resource1.spaceship_mode1_full_h;
                    two_player_mode[x].change_state = (two_player_mode[x].change_state + 1) % 2;
                    two_delay[x] += 5;
                }

                //判斷玩家是否擊中敵人和擊中哪一個敵人和敵人移動的方式
                if (std_Opt != null)
                {
                    for (int i = 0; i < std_Opt.Length; i++)
                    {
                        if (std_Opt[i] != null)
                        {
                            std_Opt[i].playerY += 1;
                            if (std_Opt[i].being_attacked(two_player_mode[x]))
                            {
                                std_Opt[i] = null;
                            }
                        }
                    }
                }

                //判斷玩家是否被敵人擊中
                if (two_player_mode[x] != null && std_Opt != null)
                {
                    for (int i = 0; i < std_Opt.Length; i++)
                    {
                        if (std_Opt[i] != null)
                        {
                            if (two_player_mode[x].being_attacked(std_Opt[i]) && two_delay[x] == 50)
                            {
                                two_delay[x] = 0;
                                two_player_mode[x].life -= 1;
                                if (x == 0)
                                {
                                    show_life.Text = two_player_mode[x].life.ToString();
                                }
                                else { 
                                    show_life_p2_chl.Text = two_player_mode[x].life.ToString();
                                }
                                
                            }
                        }
                    }
                }
                if (two_player_mode[x] != null) {
                    if (two_player_mode[x].life <= 0)
                    {
                        if (two_player_mode[x].die(this))
                        {
                            count_player_die++;
                            two_player_mode[x]= null;

                        }
                    }
                }
                
                if (level % 5 == 0 && upCk && two_player_mode[x] != null && level != 0)
                {
                    two_player_mode[x].playerUp(pfc, two_player_mode[x], player_timer, two_opt_timer, show_life, this);
                    if (x == 1) {
                        upCk = false;
                    }
                    
                }
            }
            if (count_player_die == 2) {
                gameover.Visible = true;
                gameover.Text = "GAME OVER";
                gameover.Location = new Point(120, 150);

                start_button.Visible = true;
                start_button.Image = Resource1.std_button;
                dob_mode_button.Visible = true;
                dob_mode_button.Image = Resource1.dub_mode_button;
                chl_mode_button.Visible = true;
                chl_mode_button.Image = Resource1.restart_mode_button;
                close_all();
            }
            
            if (level == boosStep)
            {
                two_opt_timer.Stop();
                two_boss_timer.Start();
                boss_life.Visible = true;
                boss_life.Maximum = 40;
                boss_life.Minimum = 0;
                boss_life.Value = 40;
                boss_two_life.Maximum = 40;
                boss_two_life.Minimum = 0;
                boss_two_life.Value = 40;
            }
        }

        private void two_boss_timer_Tick(object sender, EventArgs e)
        {
            int die_player_count = 0;
            for (int x = 0; x < 2; x++) {
                if (two_player_mode[x] == null) { 
                    die_player_count++;
                    continue;
                }
                if (two_delay[x] < 50)
                {
                    if (two_player_mode[x].change_state == 0)
                        two_player_mode[x].plane = Resource1.spaceship_mode1_full_hat;
                    else
                        two_player_mode[x].plane = Resource1.spaceship_mode1_full_h;
                    two_player_mode[x].change_state = (two_player_mode[x].change_state + 1) % 2;
                    two_delay[x] += 5;
                }

                if (two_player_mode[x].life <= 0)
                {
                    if (two_player_mode[x].die(this))
                    {
                        two_player_mode[x] = null;
                    }
                }


                if (two_player_mode[x] != null && boss_1s != null)
                {
                    for (int i = 0; i < boss_1s.Length; i++)
                    {
                        if (boss_1s[i] != null)
                        {
                            if (two_player_mode[x].being_attacked(boss_1s[i]) && two_delay[x] == 50 && i == 0 && two_player_mode[x].life >= 0)
                            {
                                
                                two_delay[x] = 0;
                                two_player_mode[x].life -= 1;
                                if (x==0)
                                    show_life.Text = two_player_mode[x].life.ToString();
                                else
                                    show_life_p2_chl.Text = two_player_mode[x].life.ToString();

                            }
                            else if (two_player_mode[x].being_attacked(boss_1s[i], 1) && two_delay[x] == 50 && two_player_mode[x].life >= 0)
                            {
                                two_delay[x] = 0;
                                two_player_mode[x].life -= 3;
                                if (x == 0)
                                    show_life.Text = two_player_mode[x].life.ToString();
                                else
                                    show_life_p2_chl.Text = two_player_mode[x].life.ToString();
                            }
                        }
                    }
                }
            }
            if (die_player_count == 2) {
                gameover.Visible = true;
                gameover.Text = "GAME OVER";
                gameover.Location = new Point(120, 150);
                
                start_button.Visible = true;
                start_button.Image = Resource1.std_button;
                dob_mode_button.Visible = true;
                dob_mode_button.Image = Resource1.dub_mode_button;
                chl_mode_button.Visible = true;
                chl_mode_button.Image = Resource1.restart_mode_button;
                close_all();
            }
            int count_all_boss_die = 0;
            if (boss_1s != null)
            {
                for (int i = 0; i < boss_1s.Length; i++)
                {
                    if (boss_1s[i] != null)
                    {
                        if (boss_1s[i].life > -1 && i == 0)
                        {
                            for (int x = 0; x < 2; x++) {
                                if (boss_1s[i].being_attacked(two_player_mode[x]))
                                {
                                    boss_life.Value = boss_1s[i].life;
                                }
                            }
                            

                        }
                        else if (boss_1s[i].life > -1)
                        {
                            for (int x = 0; x < 2; x++)
                            {
                                if (boss_1s[i].being_attacked(two_player_mode[x]))
                                {
                                    boss_two_life.Value = boss_1s[i].life;
                                }
                            }
                        }

                        if (i == 0 && boss_1s[0].life == 20 && boss_1s[1] == null & boss_1s[0] != null)
                        {
                            check_two_boss = true;
                            boss_two_life.Visible = true;

                        }
                        if (boss_1s[i].life == 0)
                        {
                            if (i == 0)
                            {
                                if (boss_1s[i].die(this, boss_life))
                                {
                                    boss_1s[i] = null;
                                }
                            }
                            else
                            {
                                if (boss_1s[i].die(this, boss_two_life))
                                {
                                    boss_1s[i] = null;
                                    check_two_boss = false;
                                }
                            }

                        }

                    }
                    else
                    {
                        count_all_boss_die++;
                    }
                }
                if (count_all_boss_die == boss_1s.Length)
                {
                    //MessageBox.Show("boss end");
                    level = 0;
                    rebirth = -10;
                    boss_1s = null;
                    boss_timer.Stop();
                    player_timer.Start();
                    check_two_boss = false;
                }

            }
        }
        void close_all() {
            level = 0;
            boss_life.Visible = false;
            boss_two_life.Visible = false;
            check_two_boss = false;
            show_life.Visible = false;
            show_life_p2.Visible = false;
            show_life_p2_chl.Visible = false;
            heart_picture.Visible = false;
            heart_picture_chl_p2.Visible = false;
            hreat_picture_p2.Visible = false;
            opt_timer.Stop();
            boss_timer.Stop();
            player_timer.Stop();
            two_player.Stop();
            two_player_hat.Stop();
            two_opt_timer.Stop();
            two_boss_timer.Stop();
            std_Opt = null;
            boss_1s = null;
            two_player_mode = null;
            main_player = null;



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 f4=new Form4(pfc);
            f4.Show();
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
        public Point[] bulletPlace;//子彈位置
        public bool[] bulletshootck;
        public Image plane = Resource1.spaceship_mode1_full_h;//玩家的飛船圖式
        Image bullet = Resource1.bullet_temp;//子彈的樣式
        int die_step;
        int die_delay; 
        public Image[] die_list;
        int shshsh=-1;
        public int change_step_state;
        int shoot_mode = 0;


        //開始時重畫玩家的建構子
        public main_character(Graphics g)
        {
            g.DrawImage(plane, 200, 375, 60, 60);
            die_list = new Image[3];
            die_list[0] = Resource1.main_ship_die_0;
            die_list[1] = Resource1.main_ship_die_1;
            die_list[2] = Resource1.main_ship_die_2;
        }
        public main_character(Graphics g, int id) {
            shootSpeed = 3;
            if (id == 1)
            {
                //life = 100;
                playerX = 100;
                playerY = 100;
                g.DrawImage(plane, playerX, playerY, 60, 60);
                plane = Resource1.Main_Ship___Base___Full_health_p2;
                die_list = new Image[3];
                die_list[0] = Resource1.main_ship_die_0_p2;
                die_list[1] = Resource1.main_ship_die_1_p2;
                die_list[2] = Resource1.main_ship_die_2_p2;
            }
            else {
                
                playerX = 300;
                playerY = 375;
                //life = 100;
                g.DrawImage(plane,playerX,playerY, 60, 60);
                die_list = new Image[3];
                die_list[0] = Resource1.main_ship_die_0;
                die_list[1] = Resource1.main_ship_die_1;
                die_list[2] = Resource1.main_ship_die_2;
            }
            
        }
        //重畫玩家的位置(因為會有移動的需求)
        public void repaint_place(Graphics g)
        {
            g.DrawImage(plane, playerX, playerY, 60, 60);
           
        }

        //玩家子彈射擊的函式
        public void shoot(Graphics g)
        {
            if (shoot_mode == 0)
                shoot_mode_1(g);
        }

        public void shoot_mode_1(Graphics g) {
            //如果目前沒有子彈存在的畫則重畫
            if (bulletPlace == null) {
                bulletPlace = new Point[1];
                bulletPlace[0] = new Point(playerX + 30 - bulletSize / 2, playerY - 10);
            }
            else
            {
                //如果子彈超過了視窗Y軸的上限話則把子彈消失，不然就讓子彈繼續往Y軸走
                bulletPlace[0].Y -= 1 * shootSpeed;
                if (bulletPlace[0].Y <= 0)
                    bulletPlace = null;
                else
                    g.DrawImage(bullet, bulletPlace[0].X, bulletPlace[0].Y, bulletSize, 20);
            }
        }
        public void shoot_mode_2(Graphics g)
        {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[3];
                bulletshootck = new bool[3];
                for (int i = 0; i < 3; i++)
                {
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
                else
                {
                    bulletPlace[0].Y = bulletPlace[0].Y + 2 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[0].X + bulletSize, bulletPlace[0].Y, 10, 20);
                }



                if (bulletPlace[1].Y > 600 || bulletPlace[1].X > 450 || bulletshootck[1])
                {
                    bulletshootck[1] = true;
                    count_how_bullet_out++;
                }
                else
                {
                    bulletPlace[1].Y = bulletPlace[1].Y + 1 * shootSpeed;
                    bulletPlace[1].X = bulletPlace[1].X + 1 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[1].X + bulletSize, bulletPlace[1].Y, 10, 20);
                }



                if (bulletPlace[2].Y > 600 || bulletPlace[2].X < 0 || bulletshootck[2])
                {

                    bulletshootck[2] = true;
                    count_how_bullet_out++;
                }
                else
                {
                    bulletPlace[2].Y = bulletPlace[2].Y + 1 * shootSpeed;
                    bulletPlace[2].X = bulletPlace[2].X - 1 * shootSpeed;
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[2].X + bulletSize, bulletPlace[2].Y, 10, 20);
                }


                //如果三點都超界了就去重劃射擊
                if (count_how_bullet_out == 3)
                {
                    bulletPlace = null;
                    bulletshootck = null;
                }
            }
        }

        public void shoot(Graphics g,int id)
        {

            //如果目前沒有子彈存在的畫則重畫
            if (bulletPlace == null) {
                bulletPlace = new Point[1];
                bulletPlace[0] = new Point(playerX + 30 - bulletSize / 2, playerY + 60);
            }
            else
            {
                //如果子彈超過了視窗Y軸的上限話則把子彈消失，不然就讓子彈繼續往Y軸走
                bulletPlace[0].Y += 1 * shootSpeed;
                if (bulletPlace[0].Y > 600)
                    bulletPlace = null;
                else {
                    g.DrawImage(bullet, bulletPlace[0].X, bulletPlace[0].Y, bulletSize, 20);
                    //MessageBox.Show("??");
                }
                    
            }

        }

        //去判斷玩家是否被敵人的子彈打中(用數學的方式去算實際有沒有重疊)
        public bool being_attacked(std_opt Opt)
        {
            if (Opt.bulletPlace != null) {
                for (int i = 0; i < Opt.bulletPlace.Length; i++)
                {
                    if (Opt.bulletPlace[i] != Point.Empty) {
                        if (Opt.bulletPlace[i].X < playerX+50 && Opt.bulletPlace[i].X+Opt.bulletsize-5 > playerX && Opt.bulletPlace[i].Y <= playerY+40 && Opt.bulletPlace[i].Y >= playerY)
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
        public bool being_attacked(main_character Opt)
        {
            if (Opt.bulletPlace != null)
            {
                for (int i = 0; i < Opt.bulletPlace.Length; i++)
                {
                    if (Opt.bulletPlace[i] != Point.Empty)
                    {
                        if (Opt.bulletPlace[i].X < playerX + 50 && Opt.bulletPlace[i].X + Opt.bulletSize - 5 > playerX && Opt.bulletPlace[i].Y <= playerY + 40 && Opt.bulletPlace[i].Y >= playerY)
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
                    if (Opt.bulletPlace[i].X < playerX + 50 && Opt.bulletPlace[i].X + Opt.bulletsize - 5 > playerX && Opt.bulletPlace[i].Y <= playerY + 40 && Opt.bulletPlace[i].Y >= playerY)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        public bool being_attacked(boss_1 Opt,int n)
        {
            if (Opt.beam_delay_time>100)
            {
                if (Opt.beamPlace.X < playerX + 20 && Opt.beamPlace.X + 20 > playerX)
                {
                        return true;
                }
            }
            return false;
        }
        public void playerUp(PrivateFontCollection pfc, main_character player, Timer t1, Timer t2, Label life, Form1 f1) {
            Form temp = new Form3(pfc, player, t1, t2, life, f1);
            temp.Show();
        }
        public bool die(Form1 f)
        {

            if (die_step == 3)
            {
                return true;
            }
            else
            {
                //dwMessageBox.Show("??");
                if (die_delay < 15)
                {
                    die_delay += 1;
                }
                else
                {
                    plane = die_list[die_step];
                    die_step += 1;
                    die_delay = 0;
                }
                return false;
            }
        }
        public bool change_step() {
            if (playerY>-150)
            {
                shshsh *= 2;
                playerY += shshsh;
                return true;
            }
            else
            {
                change_step_state = 1;
                return false;
            }
        }
    }

    //一般敵人的物件
    public class std_opt {
        public int shootSpeed = 2;
        public int playerX, playerY = 0;
        public Point[] bulletPlace;
        public int bulletsize = 10;
        bool[] bulletshootck;
        Image opt_image;
        Image bullet = Resource1.bullet_temp;
        public int move_state = 0;
        public int inx=1,iny=1;

        //新建敵人時的建構子(在敵人被全部擊敗時會被呼叫)
        public std_opt(Graphics g, Random R,int level,int id_opt)
        {
            playerX = R.Next(0, 400);
            playerY = R.Next(-100, -1);
            if (level > 5 && id_opt % 2 == 0)
            {
                opt_image = Resource1.opt_kind2_stage1;
                move_state = 1;
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
            if (move_state == 1) {
                if (playerX + 60 > 450 || playerX < 0) { 
                    inx = -inx;
                }
                playerX += inx;
            }
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
            if (player.bulletPlace != null) {
                if (player.bulletPlace[0].X > playerX - player.bulletSize && player.bulletPlace[0].X < playerX + 40 && player.bulletPlace[0].Y < playerY + 30 && player.bulletPlace[0].Y > playerY)
                {
                    //MessageBox.Show("重");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            
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
                bulletPlace[0].Y = bulletPlace[0].Y + 1 * shootSpeed;
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
                    bulletPlace[0].Y = bulletPlace[0].Y + 1 * shootSpeed;
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
        public int shootSpeed = 1;
        public int playerX, playerY = 0;
        public int life = 20;
        public int nextX=1, nextY=1;
        public Point[] bulletPlace;
        public Point beamPlace;
        public Point beam_Prepare;
        public int[] way_for_bullet;
        Image opt_image = Resource1.boss_kind1_stage1;
        Image bullet = Resource1.bullet_temp;
        public int bulletsize = 10;
        public int die_step = 0;
        public Image[] die_list;
        public int die_delay = 0;
        public bool check_in_battle=false;
        public int beam_delay_time = 10;
        int beam_shoot_time = 0;
        public boss_1(Graphics g) {
            playerX = new Random().Next(100,300);
            playerY = -100;
            g.DrawImage(opt_image, playerX, playerY, 72, 89);
            die_list = new Image[6];
            die_list[0] = Resource1.boss_kind1_stage1_die1;
            die_list[1] = Resource1.boss_kind1_stage1_die2;
            die_list[2] = Resource1.boss_kind1_stage1_die3;
            die_list[3] = Resource1.boss_kind1_stage1_die4;
            die_list[4] = Resource1.boss_kind1_stage1_die5;
            die_list[5] = Resource1.boss_kind1_stage1_die6;
        }
        public boss_1(Graphics g,int n)
        {
            playerX = 200;
            playerY = -100;
            opt_image = Resource1.boss_kind2_stage1;
            g.DrawImage(opt_image, playerX, playerY, 72, 89);
            die_list = new Image[6];
            die_list[0] = Resource1.boss_kind2_stage1_die1;
            die_list[1] = Resource1.boss_kind2_stage1_die2;
            die_list[2] = Resource1.boss_kind2_stage1_die3;
            die_list[3] = Resource1.boss_kind2_stage1_die4;
            die_list[4] = Resource1.boss_kind2_stage1_die5;
            die_list[5] = Resource1.boss_kind2_stage1_die6;
        }
        public void repaint_place(Graphics g)
        {
            if (check_in_battle)
            {
                if (playerX + 72 >= 450 || playerX <= 0)
                {
                    nextX = -nextX;
                }
                if (playerY >= 200 || playerY < 0)
                {
                    nextY = -nextY;
                }
                playerX = playerX + nextX;
                playerY = playerY + nextY;
                g.DrawImage(opt_image, playerX, playerY, 72, 89);
            }
            else {
                if (playerY > 50) {
                    check_in_battle = true;   
                }
                playerY = playerY + nextY;
                g.DrawImage(opt_image, playerX, playerY, 72, 89);
            }
            
            //g.FillEllipse(new SolidBrush(Color.Black), playerX , playerY,5,5);
        }
        public void repaint_place(Graphics g,int n) {
            if (check_in_battle)
            {
                if (playerX + 72 >= 450 || playerX <= 0)
                {
                    nextX = -nextX;
                }
                playerX = playerX + nextX;
                g.DrawImage(opt_image, playerX, playerY, 72, 89);
            }
            else
            {
                if (playerY > 50)
                {
                    check_in_battle = true;
                }
                playerY = playerY + nextY;
                g.DrawImage(opt_image, playerX, playerY, 72, 89);
            }
        }
        
        public bool being_attacked(main_character player)
        {
            if (player!=null)
            {
                if (player.bulletPlace!=null)
                {
                    if (player.bulletPlace[0].X > playerX - player.bulletSize && player.bulletPlace[0].X < playerX + 100 && player.bulletPlace[0].Y < playerY + 89 && player.bulletPlace[0].Y > playerY && life != 0)
                    {
                        //MessageBox.Show("重");
                        player.bulletPlace = null;
                        this.life -= 1;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
            return false;
            
        }
        public void shoot(Graphics g, int level, int id_opt)
        {
            if (id_opt == 0)
            {
                if (life <= 10)
                {
                    shoot_mode_3(g);
                }
                else {
                    shoot_mode_1(g);
                }
                
            }
            else {
                shoot_mode_2(g);
            }
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
                    bulletPlace[0] = new Point(playerX + 31, playerY + 89);
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
                    bulletPlace[3].Y = bulletPlace[3].Y + 3 * shootSpeed;
                    bulletPlace[3].X = bulletPlace[3].X + 1 * shootSpeed * way_for_bullet[3];
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
                        bulletPlace[5].Y = bulletPlace[5].Y + 2 * shootSpeed;
                        g.DrawImage(Resource1.bullet_temp, bulletPlace[5].X + bulletsize, bulletPlace[5].Y, 10, 20);
                    }
                    else {
                        way_for_bullet[5]++;
                    }                    
                }
            }
        }
        public void shoot_mode_2(Graphics g) {
            beamPlace = new Point(playerX + 72 / 2 - 10, playerY + 89);
            if (beam_delay_time > 100)
            {
                if (beam_shoot_time < 60)
                {
                    g.DrawImage(bullet, beamPlace.X, beamPlace.Y, 20, 1000);
                    beam_shoot_time += 1;
                }
                else { 
                    beam_shoot_time = 0;
                    beam_delay_time = 0;
                }
            }
            else {
                beam_delay_time += 1;
                g.FillRectangle(new SolidBrush(Color.FromArgb(beam_delay_time+50, 255, 0, 0)), beamPlace.X, beamPlace.Y, 20, 1000);
            }
        }
        public void shoot_mode_3(Graphics g)
        {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[6];
                way_for_bullet = new int[6];
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
                    bulletPlace[0].Y = bulletPlace[0].Y + 3 * shootSpeed * way_for_bullet[0];
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
                    bulletPlace[4] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[4] = -way_for_bullet[4];
                }
                else
                {
                    bulletPlace[4].Y = bulletPlace[4].Y + 3 * shootSpeed;
                    bulletPlace[4].X = bulletPlace[4].X - 2 * shootSpeed * way_for_bullet[4];
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[4].X + bulletsize, bulletPlace[4].Y, 10, 20);
                }
                if (bulletPlace[5].Y > 600)
                {
                    bulletPlace[5] = new Point(playerX + 26, playerY + 89);
                    way_for_bullet[5] = -way_for_bullet[5];
                }
                else
                {
                    if (way_for_bullet[5] == 5)
                    {
                        bulletPlace[5].Y = bulletPlace[5].Y + 2 * shootSpeed;
                        g.DrawImage(Resource1.bullet_temp, bulletPlace[5].X + bulletsize, bulletPlace[5].Y, 10, 20);
                    }
                    else
                    {
                        way_for_bullet[5]++;
                    }
                }
            }
        }
        public bool die(Form1 f,ProgressBar life_show) {
            
            if (die_step == 6)
            {
                life_show.Visible = false;
                return true;
            }
            else {
                //dwMessageBox.Show("??");
                if (die_delay <5)
                {
                    die_delay += 1;
                }
                else {
                    opt_image = die_list[die_step];
                    die_step += 1;
                    die_delay = 0;
                }
                return false;
            }
        }
        public void shoot_in_time_delay(Graphics g) {
            if (bulletPlace == null)
            {
                bulletPlace = new Point[6];
                way_for_bullet = new int[6];
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
                    bulletPlace[0] = new Point(playerX + 31, playerY + 89);
                }
                else
                {
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[0].X + bulletsize, bulletPlace[0].Y, 10, 20);
                }

                if (bulletPlace[1].Y > 750 || bulletPlace[1].X > 600 || bulletPlace[1].X < 0)
                {
                    bulletPlace[1] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[1] = -way_for_bullet[1];
                }
                else
                { 
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[1].X + bulletsize, bulletPlace[1].Y, 10, 20);
                }

                if (bulletPlace[2].Y > 750 || bulletPlace[2].X < 0 || bulletPlace[2].X > 600)
                {

                    bulletPlace[2] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[2] = -way_for_bullet[2];
                }
                else
                {
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[2].X + bulletsize, bulletPlace[2].Y, 10, 20);
                }

                if (bulletPlace[3].Y > 750 || bulletPlace[3].X > 600 || bulletPlace[3].X < 0)
                {
                    bulletPlace[3] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[3] = -way_for_bullet[3];
                }
                else
                {
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[3].X + bulletsize, bulletPlace[3].Y, 10, 20);
                }

                if (bulletPlace[4].Y > 750 || bulletPlace[4].X > 600 || bulletPlace[4].X < 0)
                {
                    bulletPlace[4] = new Point(playerX + 31, playerY + 89);
                    way_for_bullet[4] = -way_for_bullet[4];
                }
                else
                {
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[4].X + bulletsize, bulletPlace[4].Y, 10, 20);
                }
                if (bulletPlace[5].Y > 600)
                {
                    bulletPlace[5] = new Point(playerX + 26, playerY + 89);
                    way_for_bullet[5] = -way_for_bullet[5];
                }
                else
                {
                    g.DrawImage(Resource1.bullet_temp, bulletPlace[5].X + bulletsize, bulletPlace[5].Y, 10, 20);
                }
            }
        }
    }

    public class Props {
        int kind;
        Image[] props_image = new Image[3];
        Image nowProps;
        int x = 5, y = 5;
        Random r = new Random();
        public Point place=new Point();
        public Props()
        {
            kind=r.Next(1,3);
            nowProps = props_image[kind];
            place.X=r.Next(100,400);
            place.Y = r.Next(100, 500);
        }
        public void replace_props(Graphics g) {
            if (place.X > 560 || place.X < 0)
                x = -x;
            if(place.Y>660|| place.Y<0)
                y = -y;
            place.X = place.X + x;
            place.Y = place.Y + y;
            g.DrawImage(nowProps,place.X,place.Y,40,40);
        
        }

        
    }
}
