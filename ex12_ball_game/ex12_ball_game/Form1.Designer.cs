﻿namespace ex12_ball_game
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
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_point = new System.Windows.Forms.Label();
            this.lbl_gameover = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playground = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.racket = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.playground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_point
            // 
            this.lbl_point.AutoSize = true;
            this.lbl_point.BackColor = System.Drawing.Color.Transparent;
            this.lbl_point.Font = new System.Drawing.Font("新細明體", 14F);
            this.lbl_point.Location = new System.Drawing.Point(13, 13);
            this.lbl_point.Name = "lbl_point";
            this.lbl_point.Size = new System.Drawing.Size(61, 19);
            this.lbl_point.TabIndex = 0;
            this.lbl_point.Text = "分數:0";
            // 
            // lbl_gameover
            // 
            this.lbl_gameover.AutoSize = true;
            this.lbl_gameover.Location = new System.Drawing.Point(334, 172);
            this.lbl_gameover.Name = "lbl_gameover";
            this.lbl_gameover.Size = new System.Drawing.Size(33, 12);
            this.lbl_gameover.TabIndex = 3;
            this.lbl_gameover.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playground
            // 
            this.playground.Controls.Add(this.label2);
            this.playground.Controls.Add(this.label1);
            this.playground.Controls.Add(this.pictureBox1);
            this.playground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playground.Location = new System.Drawing.Point(0, 0);
            this.playground.Name = "playground";
            this.playground.Size = new System.Drawing.Size(784, 761);
            this.playground.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(689, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "pass S to stop";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ex12_ball_game.Resource1.play_button;
            this.pictureBox1.Location = new System.Drawing.Point(702, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // racket
            // 
            this.racket.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.racket.Location = new System.Drawing.Point(196, 308);
            this.racket.Name = "racket";
            this.racket.Size = new System.Drawing.Size(100, 50);
            this.racket.TabIndex = 2;
            this.racket.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 15F);
            this.label2.Location = new System.Drawing.Point(80, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "作弊模式請按F3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.lbl_gameover);
            this.Controls.Add(this.racket);
            this.Controls.Add(this.lbl_point);
            this.Controls.Add(this.playground);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.playground.ResumeLayout(false);
            this.playground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.racket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_point;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.PictureBox racket;
        private System.Windows.Forms.Label lbl_gameover;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel playground;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

