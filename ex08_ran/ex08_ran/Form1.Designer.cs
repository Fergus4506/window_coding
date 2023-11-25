namespace ex08_ran
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
            this.draw = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trange_from = new System.Windows.Forms.CheckBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ranColor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(13, 13);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(75, 23);
            this.draw.TabIndex = 0;
            this.draw.Text = "畫出來";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // trange_from
            // 
            this.trange_from.AutoSize = true;
            this.trange_from.Location = new System.Drawing.Point(256, 19);
            this.trange_from.Name = "trange_from";
            this.trange_from.Size = new System.Drawing.Size(48, 16);
            this.trange_from.TabIndex = 2;
            this.trange_from.Text = "菱形";
            this.trange_from.UseVisualStyleBackColor = true;
            this.trange_from.CheckedChanged += new System.EventHandler(this.trange_from_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(13, 42);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(171, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // ranColor
            // 
            this.ranColor.AutoSize = true;
            this.ranColor.Checked = true;
            this.ranColor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ranColor.Location = new System.Drawing.Point(311, 19);
            this.ranColor.Name = "ranColor";
            this.ranColor.Size = new System.Drawing.Size(72, 16);
            this.ranColor.TabIndex = 4;
            this.ranColor.Text = "隨機顏色";
            this.ranColor.UseVisualStyleBackColor = true;
            this.ranColor.CheckedChanged += new System.EventHandler(this.ranColor_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.ranColor);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.trange_from);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.draw);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox trange_from;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.CheckBox ranColor;
    }
}

