﻿namespace final_project
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.player_timer = new System.Windows.Forms.Timer(this.components);
            this.opt_timer = new System.Windows.Forms.Timer(this.components);
            this.show_life = new System.Windows.Forms.Label();
            this.game_title = new System.Windows.Forms.Label();
            this.setting_button = new System.Windows.Forms.PictureBox();
            this.start_button = new System.Windows.Forms.PictureBox();
            this.heart_picture = new System.Windows.Forms.PictureBox();
            this.dob_mode_button = new System.Windows.Forms.PictureBox();
            this.chl_mode_button = new System.Windows.Forms.PictureBox();
            this.boss_life = new System.Windows.Forms.ProgressBar();
            this.boss_timer = new System.Windows.Forms.Timer(this.components);
            this.change_step = new System.Windows.Forms.Timer(this.components);
            this.boss_two_life = new System.Windows.Forms.ProgressBar();
            this.gameover = new System.Windows.Forms.Label();
            this.two_player = new System.Windows.Forms.Timer(this.components);
            this.two_player_hat = new System.Windows.Forms.Timer(this.components);
            this.hreat_picture_p2 = new System.Windows.Forms.PictureBox();
            this.show_life_p2 = new System.Windows.Forms.Label();
            this.two_opt_timer = new System.Windows.Forms.Timer(this.components);
            this.two_boss_timer = new System.Windows.Forms.Timer(this.components);
            this.heart_picture_chl_p2 = new System.Windows.Forms.PictureBox();
            this.show_life_p2_chl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.teach_lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.setting_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dob_mode_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chl_mode_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hreat_picture_p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart_picture_chl_p2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // player_timer
            // 
            this.player_timer.Enabled = true;
            this.player_timer.Interval = 50;
            this.player_timer.Tick += new System.EventHandler(this.player_timer_Tick);
            // 
            // opt_timer
            // 
            this.opt_timer.Enabled = true;
            this.opt_timer.Interval = 50;
            this.opt_timer.Tick += new System.EventHandler(this.opt_timer_Tick);
            // 
            // show_life
            // 
            this.show_life.AutoSize = true;
            this.show_life.BackColor = System.Drawing.Color.Transparent;
            this.show_life.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.show_life.ForeColor = System.Drawing.Color.White;
            this.show_life.Location = new System.Drawing.Point(46, 19);
            this.show_life.Name = "show_life";
            this.show_life.Size = new System.Drawing.Size(18, 20);
            this.show_life.TabIndex = 0;
            this.show_life.Text = "3";
            this.show_life.Visible = false;
            // 
            // game_title
            // 
            this.game_title.AutoSize = true;
            this.game_title.BackColor = System.Drawing.Color.Transparent;
            this.game_title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.game_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_title.ForeColor = System.Drawing.Color.Transparent;
            this.game_title.Location = new System.Drawing.Point(137, 121);
            this.game_title.Name = "game_title";
            this.game_title.Size = new System.Drawing.Size(181, 50);
            this.game_title.TabIndex = 1;
            this.game_title.Text = "太空大戰";
            this.game_title.UseCompatibleTextRendering = true;
            this.game_title.Click += new System.EventHandler(this.game_title_Click);
            // 
            // setting_button
            // 
            this.setting_button.BackColor = System.Drawing.Color.Transparent;
            this.setting_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.setting_button.Image = global::final_project.Resource1.setting;
            this.setting_button.Location = new System.Drawing.Point(392, 13);
            this.setting_button.Name = "setting_button";
            this.setting_button.Size = new System.Drawing.Size(30, 30);
            this.setting_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.setting_button.TabIndex = 2;
            this.setting_button.TabStop = false;
            this.setting_button.Click += new System.EventHandler(this.setting_button_Click);
            // 
            // start_button
            // 
            this.start_button.BackColor = System.Drawing.Color.Transparent;
            this.start_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.start_button.Image = global::final_project.Resource1.start_button;
            this.start_button.Location = new System.Drawing.Point(166, 224);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(125, 50);
            this.start_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.start_button.TabIndex = 3;
            this.start_button.TabStop = false;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // heart_picture
            // 
            this.heart_picture.BackColor = System.Drawing.Color.Transparent;
            this.heart_picture.Image = global::final_project.Resource1.pixel_heart;
            this.heart_picture.Location = new System.Drawing.Point(9, 12);
            this.heart_picture.Name = "heart_picture";
            this.heart_picture.Size = new System.Drawing.Size(30, 30);
            this.heart_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart_picture.TabIndex = 4;
            this.heart_picture.TabStop = false;
            this.heart_picture.Visible = false;
            // 
            // dob_mode_button
            // 
            this.dob_mode_button.BackColor = System.Drawing.Color.Transparent;
            this.dob_mode_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dob_mode_button.Image = global::final_project.Resource1.dub_mode_button;
            this.dob_mode_button.Location = new System.Drawing.Point(166, 311);
            this.dob_mode_button.Name = "dob_mode_button";
            this.dob_mode_button.Size = new System.Drawing.Size(125, 50);
            this.dob_mode_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dob_mode_button.TabIndex = 5;
            this.dob_mode_button.TabStop = false;
            this.dob_mode_button.Click += new System.EventHandler(this.dob_mode_button_Click);
            // 
            // chl_mode_button
            // 
            this.chl_mode_button.BackColor = System.Drawing.Color.Transparent;
            this.chl_mode_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chl_mode_button.Image = global::final_project.Resource1.challenge_mode_button;
            this.chl_mode_button.Location = new System.Drawing.Point(166, 404);
            this.chl_mode_button.Name = "chl_mode_button";
            this.chl_mode_button.Size = new System.Drawing.Size(125, 50);
            this.chl_mode_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chl_mode_button.TabIndex = 6;
            this.chl_mode_button.TabStop = false;
            this.chl_mode_button.Click += new System.EventHandler(this.chl_mode_button_Click);
            // 
            // boss_life
            // 
            this.boss_life.Location = new System.Drawing.Point(68, 10);
            this.boss_life.Margin = new System.Windows.Forms.Padding(2);
            this.boss_life.Name = "boss_life";
            this.boss_life.Size = new System.Drawing.Size(319, 11);
            this.boss_life.TabIndex = 7;
            this.boss_life.Visible = false;
            // 
            // boss_timer
            // 
            this.boss_timer.Interval = 50;
            this.boss_timer.Tick += new System.EventHandler(this.boss_timer_Tick);
            // 
            // change_step
            // 
            this.change_step.Tick += new System.EventHandler(this.change_step_Tick);
            // 
            // boss_two_life
            // 
            this.boss_two_life.Location = new System.Drawing.Point(68, 31);
            this.boss_two_life.Margin = new System.Windows.Forms.Padding(2);
            this.boss_two_life.Name = "boss_two_life";
            this.boss_two_life.Size = new System.Drawing.Size(319, 11);
            this.boss_two_life.TabIndex = 8;
            this.boss_two_life.Visible = false;
            // 
            // gameover
            // 
            this.gameover.AutoSize = true;
            this.gameover.BackColor = System.Drawing.Color.Transparent;
            this.gameover.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameover.ForeColor = System.Drawing.Color.Transparent;
            this.gameover.Location = new System.Drawing.Point(111, 171);
            this.gameover.Name = "gameover";
            this.gameover.Size = new System.Drawing.Size(249, 50);
            this.gameover.TabIndex = 9;
            this.gameover.Text = "GAME OVER";
            this.gameover.UseCompatibleTextRendering = true;
            this.gameover.Visible = false;
            // 
            // two_player
            // 
            this.two_player.Interval = 50;
            this.two_player.Tick += new System.EventHandler(this.two_player_Tick);
            // 
            // two_player_hat
            // 
            this.two_player_hat.Interval = 50;
            this.two_player_hat.Tick += new System.EventHandler(this.two_player_shoot_Tick);
            // 
            // hreat_picture_p2
            // 
            this.hreat_picture_p2.BackColor = System.Drawing.Color.Transparent;
            this.hreat_picture_p2.Image = global::final_project.Resource1.pixel_heart;
            this.hreat_picture_p2.Location = new System.Drawing.Point(10, 521);
            this.hreat_picture_p2.Name = "hreat_picture_p2";
            this.hreat_picture_p2.Size = new System.Drawing.Size(30, 30);
            this.hreat_picture_p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hreat_picture_p2.TabIndex = 11;
            this.hreat_picture_p2.TabStop = false;
            this.hreat_picture_p2.Visible = false;
            // 
            // show_life_p2
            // 
            this.show_life_p2.AutoSize = true;
            this.show_life_p2.BackColor = System.Drawing.Color.Transparent;
            this.show_life_p2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.show_life_p2.ForeColor = System.Drawing.Color.White;
            this.show_life_p2.Location = new System.Drawing.Point(46, 528);
            this.show_life_p2.Name = "show_life_p2";
            this.show_life_p2.Size = new System.Drawing.Size(18, 20);
            this.show_life_p2.TabIndex = 10;
            this.show_life_p2.Text = "3";
            this.show_life_p2.Visible = false;
            // 
            // two_opt_timer
            // 
            this.two_opt_timer.Interval = 50;
            this.two_opt_timer.Tick += new System.EventHandler(this.two_opt_timer_Tick);
            // 
            // two_boss_timer
            // 
            this.two_boss_timer.Interval = 50;
            this.two_boss_timer.Tick += new System.EventHandler(this.two_boss_timer_Tick);
            // 
            // heart_picture_chl_p2
            // 
            this.heart_picture_chl_p2.BackColor = System.Drawing.Color.Transparent;
            this.heart_picture_chl_p2.Image = global::final_project.Resource1.pixel_heart;
            this.heart_picture_chl_p2.Location = new System.Drawing.Point(9, 49);
            this.heart_picture_chl_p2.Name = "heart_picture_chl_p2";
            this.heart_picture_chl_p2.Size = new System.Drawing.Size(30, 30);
            this.heart_picture_chl_p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.heart_picture_chl_p2.TabIndex = 13;
            this.heart_picture_chl_p2.TabStop = false;
            this.heart_picture_chl_p2.Visible = false;
            // 
            // show_life_p2_chl
            // 
            this.show_life_p2_chl.AutoSize = true;
            this.show_life_p2_chl.BackColor = System.Drawing.Color.Transparent;
            this.show_life_p2_chl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.show_life_p2_chl.ForeColor = System.Drawing.Color.White;
            this.show_life_p2_chl.Location = new System.Drawing.Point(46, 56);
            this.show_life_p2_chl.Name = "show_life_p2_chl";
            this.show_life_p2_chl.Size = new System.Drawing.Size(18, 20);
            this.show_life_p2_chl.TabIndex = 12;
            this.show_life_p2_chl.Text = "3";
            this.show_life_p2_chl.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::final_project.Resource1.help_icon;
            this.pictureBox1.Location = new System.Drawing.Point(374, 502);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // teach_lab
            // 
            this.teach_lab.AutoSize = true;
            this.teach_lab.BackColor = System.Drawing.Color.Transparent;
            this.teach_lab.Font = new System.Drawing.Font("新細明體", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.teach_lab.ForeColor = System.Drawing.Color.White;
            this.teach_lab.Location = new System.Drawing.Point(376, 480);
            this.teach_lab.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.teach_lab.Name = "teach_lab";
            this.teach_lab.Size = new System.Drawing.Size(49, 19);
            this.teach_lab.TabIndex = 15;
            this.teach_lab.Text = "教學";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::final_project.Resource1._8bitspacebackgroundbirds_eye_viewdont_have_anything_in_upper_middle_area;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(436, 562);
            this.Controls.Add(this.teach_lab);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.heart_picture_chl_p2);
            this.Controls.Add(this.show_life_p2_chl);
            this.Controls.Add(this.hreat_picture_p2);
            this.Controls.Add(this.show_life_p2);
            this.Controls.Add(this.gameover);
            this.Controls.Add(this.boss_two_life);
            this.Controls.Add(this.boss_life);
            this.Controls.Add(this.chl_mode_button);
            this.Controls.Add(this.dob_mode_button);
            this.Controls.Add(this.heart_picture);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.setting_button);
            this.Controls.Add(this.game_title);
            this.Controls.Add(this.show_life);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.setting_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dob_mode_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chl_mode_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hreat_picture_p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart_picture_chl_p2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer player_timer;
        private System.Windows.Forms.Timer opt_timer;
        private System.Windows.Forms.Label show_life;
        private System.Windows.Forms.Label game_title;
        private System.Windows.Forms.PictureBox setting_button;
        private System.Windows.Forms.PictureBox start_button;
        private System.Windows.Forms.PictureBox heart_picture;
        private System.Windows.Forms.PictureBox dob_mode_button;
        private System.Windows.Forms.PictureBox chl_mode_button;
        private System.Windows.Forms.ProgressBar boss_life;
        private System.Windows.Forms.Timer boss_timer;
        private System.Windows.Forms.Timer change_step;
        private System.Windows.Forms.ProgressBar boss_two_life;
        private System.Windows.Forms.Label gameover;
        private System.Windows.Forms.Timer two_player;
        private System.Windows.Forms.Timer two_player_hat;
        private System.Windows.Forms.PictureBox hreat_picture_p2;
        private System.Windows.Forms.Label show_life_p2;
        private System.Windows.Forms.Timer two_opt_timer;
        private System.Windows.Forms.Timer two_boss_timer;
        private System.Windows.Forms.PictureBox heart_picture_chl_p2;
        private System.Windows.Forms.Label show_life_p2_chl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label teach_lab;
    }
}

