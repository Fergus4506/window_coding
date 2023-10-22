namespace mic_player
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
            this.Do = new System.Windows.Forms.Button();
            this.Re = new System.Windows.Forms.Button();
            this.Mi = new System.Windows.Forms.Button();
            this.Fa = new System.Windows.Forms.Button();
            this.So = new System.Windows.Forms.Button();
            this.La = new System.Windows.Forms.Button();
            this.Si = new System.Windows.Forms.Button();
            this.Do_key = new System.Windows.Forms.Label();
            this.Re_key = new System.Windows.Forms.Label();
            this.Mi_key = new System.Windows.Forms.Label();
            this.Fa_key = new System.Windows.Forms.Label();
            this.So_key = new System.Windows.Forms.Label();
            this.La_key = new System.Windows.Forms.Label();
            this.Si_key = new System.Windows.Forms.Label();
            this.sheetChoose = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.startAutoPlay = new System.Windows.Forms.Button();
            this.stopAutoPlay = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.changeBlockColor = new System.Windows.Forms.Button();
            this.重新開始 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Do
            // 
            this.Do.Location = new System.Drawing.Point(264, 481);
            this.Do.Name = "Do";
            this.Do.Size = new System.Drawing.Size(75, 23);
            this.Do.TabIndex = 0;
            this.Do.Text = "Do";
            this.Do.UseVisualStyleBackColor = true;
            this.Do.Click += new System.EventHandler(this.Do_Click);
            // 
            // Re
            // 
            this.Re.Location = new System.Drawing.Point(345, 481);
            this.Re.Name = "Re";
            this.Re.Size = new System.Drawing.Size(75, 23);
            this.Re.TabIndex = 1;
            this.Re.Text = "Re";
            this.Re.UseVisualStyleBackColor = true;
            this.Re.Click += new System.EventHandler(this.Re_Click);
            // 
            // Mi
            // 
            this.Mi.Location = new System.Drawing.Point(426, 481);
            this.Mi.Name = "Mi";
            this.Mi.Size = new System.Drawing.Size(75, 23);
            this.Mi.TabIndex = 2;
            this.Mi.Text = "Mi";
            this.Mi.UseVisualStyleBackColor = true;
            this.Mi.Click += new System.EventHandler(this.Mi_Click);
            // 
            // Fa
            // 
            this.Fa.Location = new System.Drawing.Point(507, 481);
            this.Fa.Name = "Fa";
            this.Fa.Size = new System.Drawing.Size(75, 23);
            this.Fa.TabIndex = 3;
            this.Fa.Text = "Fa";
            this.Fa.UseVisualStyleBackColor = true;
            this.Fa.Click += new System.EventHandler(this.Fa_Click);
            // 
            // So
            // 
            this.So.Location = new System.Drawing.Point(588, 481);
            this.So.Name = "So";
            this.So.Size = new System.Drawing.Size(75, 23);
            this.So.TabIndex = 4;
            this.So.Text = "So";
            this.So.UseVisualStyleBackColor = true;
            this.So.Click += new System.EventHandler(this.So_Click);
            // 
            // La
            // 
            this.La.Location = new System.Drawing.Point(669, 481);
            this.La.Name = "La";
            this.La.Size = new System.Drawing.Size(75, 23);
            this.La.TabIndex = 5;
            this.La.Text = "La";
            this.La.UseVisualStyleBackColor = true;
            this.La.Click += new System.EventHandler(this.La_Click);
            // 
            // Si
            // 
            this.Si.Location = new System.Drawing.Point(750, 481);
            this.Si.Name = "Si";
            this.Si.Size = new System.Drawing.Size(75, 23);
            this.Si.TabIndex = 6;
            this.Si.Text = "Si";
            this.Si.UseVisualStyleBackColor = true;
            this.Si.Click += new System.EventHandler(this.Si_Click);
            // 
            // Do_key
            // 
            this.Do_key.AutoSize = true;
            this.Do_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.Do_key.Location = new System.Drawing.Point(284, 537);
            this.Do_key.Name = "Do_key";
            this.Do_key.Size = new System.Drawing.Size(18, 16);
            this.Do_key.TabIndex = 7;
            this.Do_key.Text = "A";
            // 
            // Re_key
            // 
            this.Re_key.AutoSize = true;
            this.Re_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.Re_key.Location = new System.Drawing.Point(374, 537);
            this.Re_key.Name = "Re_key";
            this.Re_key.Size = new System.Drawing.Size(15, 16);
            this.Re_key.TabIndex = 8;
            this.Re_key.Text = "S";
            // 
            // Mi_key
            // 
            this.Mi_key.AutoSize = true;
            this.Mi_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.Mi_key.Location = new System.Drawing.Point(453, 537);
            this.Mi_key.Name = "Mi_key";
            this.Mi_key.Size = new System.Drawing.Size(18, 16);
            this.Mi_key.TabIndex = 9;
            this.Mi_key.Text = "D";
            // 
            // Fa_key
            // 
            this.Fa_key.AutoSize = true;
            this.Fa_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.Fa_key.Location = new System.Drawing.Point(537, 537);
            this.Fa_key.Name = "Fa_key";
            this.Fa_key.Size = new System.Drawing.Size(15, 16);
            this.Fa_key.TabIndex = 10;
            this.Fa_key.Text = "F";
            // 
            // So_key
            // 
            this.So_key.AutoSize = true;
            this.So_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.So_key.Location = new System.Drawing.Point(615, 537);
            this.So_key.Name = "So_key";
            this.So_key.Size = new System.Drawing.Size(18, 16);
            this.So_key.TabIndex = 11;
            this.So_key.Text = "G";
            // 
            // La_key
            // 
            this.La_key.AutoSize = true;
            this.La_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.La_key.Location = new System.Drawing.Point(696, 537);
            this.La_key.Name = "La_key";
            this.La_key.Size = new System.Drawing.Size(18, 16);
            this.La_key.TabIndex = 12;
            this.La_key.Text = "H";
            // 
            // Si_key
            // 
            this.Si_key.AutoSize = true;
            this.Si_key.Font = new System.Drawing.Font("新細明體", 12F);
            this.Si_key.Location = new System.Drawing.Point(780, 537);
            this.Si_key.Name = "Si_key";
            this.Si_key.Size = new System.Drawing.Size(13, 16);
            this.Si_key.TabIndex = 13;
            this.Si_key.Text = "J";
            // 
            // sheetChoose
            // 
            this.sheetChoose.FormattingEnabled = true;
            this.sheetChoose.Location = new System.Drawing.Point(39, 44);
            this.sheetChoose.Name = "sheetChoose";
            this.sheetChoose.Size = new System.Drawing.Size(121, 20);
            this.sheetChoose.TabIndex = 14;
            this.sheetChoose.SelectedIndexChanged += new System.EventHandler(this.sheetChoose_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // startAutoPlay
            // 
            this.startAutoPlay.Location = new System.Drawing.Point(39, 83);
            this.startAutoPlay.Name = "startAutoPlay";
            this.startAutoPlay.Size = new System.Drawing.Size(121, 23);
            this.startAutoPlay.TabIndex = 15;
            this.startAutoPlay.Text = "開始自動撥放";
            this.startAutoPlay.UseVisualStyleBackColor = true;
            this.startAutoPlay.Click += new System.EventHandler(this.startAutoPlay_Click);
            // 
            // stopAutoPlay
            // 
            this.stopAutoPlay.Location = new System.Drawing.Point(39, 112);
            this.stopAutoPlay.Name = "stopAutoPlay";
            this.stopAutoPlay.Size = new System.Drawing.Size(121, 23);
            this.stopAutoPlay.TabIndex = 16;
            this.stopAutoPlay.Text = "停止自動撥放";
            this.stopAutoPlay.UseVisualStyleBackColor = true;
            this.stopAutoPlay.Click += new System.EventHandler(this.stopAutoPlay_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            // 
            // changeBlockColor
            // 
            this.changeBlockColor.Location = new System.Drawing.Point(39, 170);
            this.changeBlockColor.Name = "changeBlockColor";
            this.changeBlockColor.Size = new System.Drawing.Size(121, 23);
            this.changeBlockColor.TabIndex = 17;
            this.changeBlockColor.Text = "改變方塊顏色";
            this.changeBlockColor.UseVisualStyleBackColor = true;
            this.changeBlockColor.Click += new System.EventHandler(this.changeBlockColor_Click);
            // 
            // 重新開始
            // 
            this.重新開始.Location = new System.Drawing.Point(39, 141);
            this.重新開始.Name = "重新開始";
            this.重新開始.Size = new System.Drawing.Size(121, 23);
            this.重新開始.TabIndex = 18;
            this.重新開始.Text = "重新開始";
            this.重新開始.UseVisualStyleBackColor = true;
            this.重新開始.Click += new System.EventHandler(this.重新開始_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 577);
            this.Controls.Add(this.重新開始);
            this.Controls.Add(this.changeBlockColor);
            this.Controls.Add(this.stopAutoPlay);
            this.Controls.Add(this.startAutoPlay);
            this.Controls.Add(this.sheetChoose);
            this.Controls.Add(this.Si_key);
            this.Controls.Add(this.La_key);
            this.Controls.Add(this.So_key);
            this.Controls.Add(this.Fa_key);
            this.Controls.Add(this.Mi_key);
            this.Controls.Add(this.Re_key);
            this.Controls.Add(this.Do_key);
            this.Controls.Add(this.Si);
            this.Controls.Add(this.La);
            this.Controls.Add(this.So);
            this.Controls.Add(this.Fa);
            this.Controls.Add(this.Mi);
            this.Controls.Add(this.Re);
            this.Controls.Add(this.Do);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Do;
        private System.Windows.Forms.Button Re;
        private System.Windows.Forms.Button Mi;
        private System.Windows.Forms.Button Fa;
        private System.Windows.Forms.Button So;
        private System.Windows.Forms.Button La;
        private System.Windows.Forms.Button Si;
        private System.Windows.Forms.Label Do_key;
        private System.Windows.Forms.Label Re_key;
        private System.Windows.Forms.Label Mi_key;
        private System.Windows.Forms.Label Fa_key;
        private System.Windows.Forms.Label So_key;
        private System.Windows.Forms.Label La_key;
        private System.Windows.Forms.Label Si_key;
        private System.Windows.Forms.ComboBox sheetChoose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button startAutoPlay;
        private System.Windows.Forms.Button stopAutoPlay;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button changeBlockColor;
        private System.Windows.Forms.Button 重新開始;
    }
}

