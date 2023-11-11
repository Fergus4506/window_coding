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
            this.SuspendLayout();
            // 
            // player_timer
            // 
            this.player_timer.Enabled = true;
            this.player_timer.Tick += new System.EventHandler(this.player_timer_Tick);
            // 
            // opt_timer
            // 
            this.opt_timer.Enabled = true;
            this.opt_timer.Interval = 250;
            this.opt_timer.Tick += new System.EventHandler(this.opt_timer_Tick);
            // 
            // show_life
            // 
            this.show_life.AutoSize = true;
            this.show_life.Location = new System.Drawing.Point(13, 13);
            this.show_life.Name = "show_life";
            this.show_life.Size = new System.Drawing.Size(62, 12);
            this.show_life.TabIndex = 0;
            this.show_life.Text = "剩餘血量:3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(434, 561);
            this.Controls.Add(this.show_life);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer player_timer;
        private System.Windows.Forms.Timer opt_timer;
        private System.Windows.Forms.Label show_life;
    }
}

