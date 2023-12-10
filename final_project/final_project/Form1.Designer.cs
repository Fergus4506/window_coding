namespace final_project
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
            ((System.ComponentModel.ISupportInitialize)(this.setting_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heart_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dob_mode_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chl_mode_button)).BeginInit();
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
            this.show_life.Font = new System.Drawing.Font("俐方体11号", 12F);
            this.show_life.ForeColor = System.Drawing.Color.White;
            this.show_life.Location = new System.Drawing.Point(46, 19);
            this.show_life.Name = "show_life";
            this.show_life.Size = new System.Drawing.Size(17, 18);
            this.show_life.TabIndex = 0;
            this.show_life.Text = "3";
            this.show_life.Visible = false;
            // 
            // game_title
            // 
            this.game_title.AutoSize = true;
            this.game_title.BackColor = System.Drawing.Color.Transparent;
            this.game_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_title.ForeColor = System.Drawing.Color.Transparent;
            this.game_title.Location = new System.Drawing.Point(137, 121);
            this.game_title.Name = "game_title";
            this.game_title.Size = new System.Drawing.Size(181, 50);
            this.game_title.TabIndex = 1;
            this.game_title.Text = "太空大戰";
            this.game_title.UseCompatibleTextRendering = true;
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
            this.start_button.Location = new System.Drawing.Point(166, 214);
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
            this.dob_mode_button.Image = global::final_project.Resource1.dub_mode_button;
            this.dob_mode_button.Location = new System.Drawing.Point(166, 311);
            this.dob_mode_button.Name = "dob_mode_button";
            this.dob_mode_button.Size = new System.Drawing.Size(125, 50);
            this.dob_mode_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dob_mode_button.TabIndex = 5;
            this.dob_mode_button.TabStop = false;
            // 
            // chl_mode_button
            // 
            this.chl_mode_button.BackColor = System.Drawing.Color.Transparent;
            this.chl_mode_button.Image = global::final_project.Resource1.challenge_mode_button;
            this.chl_mode_button.Location = new System.Drawing.Point(166, 404);
            this.chl_mode_button.Name = "chl_mode_button";
            this.chl_mode_button.Size = new System.Drawing.Size(125, 50);
            this.chl_mode_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.chl_mode_button.TabIndex = 6;
            this.chl_mode_button.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::final_project.Resource1._8bitspacebackgroundbirds_eye_viewdont_have_anything_in_upper_middle_area;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(434, 561);
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
    }
}

