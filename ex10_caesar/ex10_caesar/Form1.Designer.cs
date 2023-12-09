namespace ex10_caesar
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
            this.oldText = new System.Windows.Forms.TextBox();
            this.newText = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.EnButton = new System.Windows.Forms.RadioButton();
            this.deButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oldText
            // 
            this.oldText.Location = new System.Drawing.Point(12, 28);
            this.oldText.Multiline = true;
            this.oldText.Name = "oldText";
            this.oldText.Size = new System.Drawing.Size(196, 122);
            this.oldText.TabIndex = 0;
            this.oldText.TextChanged += new System.EventHandler(this.oldText_TextChanged);
            // 
            // newText
            // 
            this.newText.Location = new System.Drawing.Point(358, 28);
            this.newText.Multiline = true;
            this.newText.Name = "newText";
            this.newText.Size = new System.Drawing.Size(206, 122);
            this.newText.TabIndex = 1;
            this.newText.TextChanged += new System.EventHandler(this.newText_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(238, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 2;
            // 
            // EnButton
            // 
            this.EnButton.AutoSize = true;
            this.EnButton.Location = new System.Drawing.Point(262, 56);
            this.EnButton.Name = "EnButton";
            this.EnButton.Size = new System.Drawing.Size(47, 16);
            this.EnButton.TabIndex = 3;
            this.EnButton.TabStop = true;
            this.EnButton.Text = "加密";
            this.EnButton.UseVisualStyleBackColor = true;
            this.EnButton.CheckedChanged += new System.EventHandler(this.EnButton_CheckedChanged);
            // 
            // deButton
            // 
            this.deButton.AutoSize = true;
            this.deButton.Location = new System.Drawing.Point(262, 78);
            this.deButton.Name = "deButton";
            this.deButton.Size = new System.Drawing.Size(47, 16);
            this.deButton.TabIndex = 4;
            this.deButton.TabStop = true;
            this.deButton.Text = "解密";
            this.deButton.UseVisualStyleBackColor = true;
            this.deButton.CheckedChanged += new System.EventHandler(this.deButton_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "未加密文字";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "加密文字";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(617, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(59, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "密文:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(59, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "原文:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(59, 468);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "偏移量:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "偏移量";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 562);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deButton);
            this.Controls.Add(this.EnButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.newText);
            this.Controls.Add(this.oldText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldText;
        private System.Windows.Forms.TextBox newText;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RadioButton EnButton;
        private System.Windows.Forms.RadioButton deButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

