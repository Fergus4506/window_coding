namespace Pic_edi
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
            this.loadImageBtn = new System.Windows.Forms.Button();
            this.filpHorizontalBtn = new System.Windows.Forms.Button();
            this.flipVerticalbtn = new System.Windows.Forms.Button();
            this.L_rotate = new System.Windows.Forms.Button();
            this.control = new System.Windows.Forms.GroupBox();
            this.R_rotate = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.drawGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.penColor = new System.Windows.Forms.Label();
            this.colorPicker = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.nextImageBtn = new System.Windows.Forms.Button();
            this.imagePicturebox = new System.Windows.Forms.PictureBox();
            this.previousImageBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.control.SuspendLayout();
            this.drawGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).BeginInit();
            this.imageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // loadImageBtn
            // 
            this.loadImageBtn.Location = new System.Drawing.Point(19, 17);
            this.loadImageBtn.Name = "loadImageBtn";
            this.loadImageBtn.Size = new System.Drawing.Size(117, 23);
            this.loadImageBtn.TabIndex = 0;
            this.loadImageBtn.Text = "Load Image";
            this.loadImageBtn.UseVisualStyleBackColor = true;
            this.loadImageBtn.Click += new System.EventHandler(this.loadImageBtn_Click);
            // 
            // filpHorizontalBtn
            // 
            this.filpHorizontalBtn.Location = new System.Drawing.Point(19, 46);
            this.filpHorizontalBtn.Name = "filpHorizontalBtn";
            this.filpHorizontalBtn.Size = new System.Drawing.Size(117, 23);
            this.filpHorizontalBtn.TabIndex = 1;
            this.filpHorizontalBtn.Text = "filp Horizontal";
            this.filpHorizontalBtn.UseVisualStyleBackColor = true;
            this.filpHorizontalBtn.Click += new System.EventHandler(this.filpHorizontalBtn_Click);
            // 
            // flipVerticalbtn
            // 
            this.flipVerticalbtn.Location = new System.Drawing.Point(19, 76);
            this.flipVerticalbtn.Name = "flipVerticalbtn";
            this.flipVerticalbtn.Size = new System.Drawing.Size(117, 23);
            this.flipVerticalbtn.TabIndex = 2;
            this.flipVerticalbtn.Text = "flip Vertical";
            this.flipVerticalbtn.UseVisualStyleBackColor = true;
            this.flipVerticalbtn.Click += new System.EventHandler(this.flipVerticalbtn_Click);
            // 
            // L_rotate
            // 
            this.L_rotate.Location = new System.Drawing.Point(19, 106);
            this.L_rotate.Name = "L_rotate";
            this.L_rotate.Size = new System.Drawing.Size(58, 23);
            this.L_rotate.TabIndex = 3;
            this.L_rotate.Text = "L_rotate";
            this.L_rotate.UseVisualStyleBackColor = true;
            this.L_rotate.Click += new System.EventHandler(this.L_rotate_Click);
            // 
            // control
            // 
            this.control.Controls.Add(this.R_rotate);
            this.control.Controls.Add(this.saveBtn);
            this.control.Controls.Add(this.flipVerticalbtn);
            this.control.Controls.Add(this.L_rotate);
            this.control.Controls.Add(this.loadImageBtn);
            this.control.Controls.Add(this.filpHorizontalBtn);
            this.control.Location = new System.Drawing.Point(27, 28);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(200, 176);
            this.control.TabIndex = 4;
            this.control.TabStop = false;
            this.control.Text = "control";
            // 
            // R_rotate
            // 
            this.R_rotate.Location = new System.Drawing.Point(82, 106);
            this.R_rotate.Name = "R_rotate";
            this.R_rotate.Size = new System.Drawing.Size(54, 23);
            this.R_rotate.TabIndex = 5;
            this.R_rotate.Text = "R_rotate";
            this.R_rotate.UseVisualStyleBackColor = true;
            this.R_rotate.Click += new System.EventHandler(this.R_rotate_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(119, 147);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // drawGroup
            // 
            this.drawGroup.Controls.Add(this.label1);
            this.drawGroup.Controls.Add(this.trackBar1);
            this.drawGroup.Controls.Add(this.penColor);
            this.drawGroup.Controls.Add(this.colorPicker);
            this.drawGroup.Controls.Add(this.clearButton);
            this.drawGroup.Location = new System.Drawing.Point(27, 241);
            this.drawGroup.Name = "drawGroup";
            this.drawGroup.Size = new System.Drawing.Size(200, 176);
            this.drawGroup.TabIndex = 5;
            this.drawGroup.TabStop = false;
            this.drawGroup.Text = "draw";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15F);
            this.label1.Location = new System.Drawing.Point(44, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pen size";
            // 
            // trackBar1
            // 
            this.trackBar1.AllowDrop = true;
            this.trackBar1.Location = new System.Drawing.Point(19, 99);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(151, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // penColor
            // 
            this.penColor.AutoSize = true;
            this.penColor.Font = new System.Drawing.Font("新細明體", 15F);
            this.penColor.Location = new System.Drawing.Point(26, 30);
            this.penColor.Name = "penColor";
            this.penColor.Size = new System.Drawing.Size(83, 20);
            this.penColor.TabIndex = 6;
            this.penColor.Text = "Pen Color";
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(133, 15);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(37, 35);
            this.colorPicker.TabIndex = 5;
            this.colorPicker.TabStop = false;
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(6, 147);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(188, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Controls.Add(this.nextImageBtn);
            this.imageGroupBox.Controls.Add(this.imagePicturebox);
            this.imageGroupBox.Controls.Add(this.previousImageBtn);
            this.imageGroupBox.Location = new System.Drawing.Point(308, 28);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(635, 383);
            this.imageGroupBox.TabIndex = 6;
            this.imageGroupBox.TabStop = false;
            // 
            // nextImageBtn
            // 
            this.nextImageBtn.Location = new System.Drawing.Point(553, 341);
            this.nextImageBtn.Name = "nextImageBtn";
            this.nextImageBtn.Size = new System.Drawing.Size(64, 23);
            this.nextImageBtn.TabIndex = 6;
            this.nextImageBtn.Text = "next";
            this.nextImageBtn.UseVisualStyleBackColor = true;
            this.nextImageBtn.Click += new System.EventHandler(this.nextImageBtn_Click);
            // 
            // imagePicturebox
            // 
            this.imagePicturebox.Location = new System.Drawing.Point(19, 21);
            this.imagePicturebox.Name = "imagePicturebox";
            this.imagePicturebox.Size = new System.Drawing.Size(598, 282);
            this.imagePicturebox.TabIndex = 5;
            this.imagePicturebox.TabStop = false;
            this.imagePicturebox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imagePicturebox_MouseDown);
            this.imagePicturebox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imagePicturebox_MouseMove);
            this.imagePicturebox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imagePicturebox_MouseUp);
            // 
            // previousImageBtn
            // 
            this.previousImageBtn.Location = new System.Drawing.Point(28, 341);
            this.previousImageBtn.Name = "previousImageBtn";
            this.previousImageBtn.Size = new System.Drawing.Size(64, 23);
            this.previousImageBtn.TabIndex = 4;
            this.previousImageBtn.Text = "previous";
            this.previousImageBtn.UseVisualStyleBackColor = true;
            this.previousImageBtn.Click += new System.EventHandler(this.previousImageBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.imageGroupBox);
            this.Controls.Add(this.drawGroup);
            this.Controls.Add(this.control);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.control.ResumeLayout(false);
            this.drawGroup.ResumeLayout(false);
            this.drawGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPicker)).EndInit();
            this.imageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadImageBtn;
        private System.Windows.Forms.Button filpHorizontalBtn;
        private System.Windows.Forms.Button flipVerticalbtn;
        private System.Windows.Forms.Button L_rotate;
        private System.Windows.Forms.GroupBox control;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox drawGroup;
        private System.Windows.Forms.Label penColor;
        private System.Windows.Forms.PictureBox colorPicker;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.Button nextImageBtn;
        private System.Windows.Forms.PictureBox imagePicturebox;
        private System.Windows.Forms.Button previousImageBtn;
        private System.Windows.Forms.Button R_rotate;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
    }
}

