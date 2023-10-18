﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mic_player
{
    public partial class Form1 : Form
    {
        int minX = 240, maxX = 800, minY = 30, maxY = 380;
        int count = 0;
        int[] fg = { 440,495,550,587,660,733,825,895 };
        Button[] step;
        //Button[] sheet;
        Label[] key;
        int[] sheet=new int[]{5,3,3,4,2,2,1,2,3,4,5,5,5,5,3,3,4,2,2,1,3,5,5,3,2,2,2,2,2,3,4,3,3,3,3,3,4,5,5,3,3,4,2,2,1,3,5,5,1};
        int[][] sheetList=new int[3][];
        int duration = 50;
        Color set_color= Color.Black;
        Random r=new Random(Guid.NewGuid().GetHashCode());
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            step = new Button[]{ Do,Re,Mi,Fa,So,La,Si};
            key = new Label[] { Do_key,Re_key,Mi_key,Fa_key,So_key,La_key,Si_key };
            sheetList[0]= new int[] { 5, 3, 3, 4, 2, 2, 1, 2, 3, 4, 5, 5, 5, 5, 3, 3, 4, 2, 2, 1, 3, 5, 5, 3, 2, 2, 2, 2, 2, 3, 4, 3, 3, 3, 3, 3, 4, 5, 5, 3, 3, 4, 2, 2, 1, 3, 5, 5, 1 };
            sheetList[1]=new int[] { 1,1,5,5,6,6,5, 4,4,3,3,2,2,1, 5,5,4,4,3,3,2, 5,5,4,4,3,3,2, 1,1,5,5,6,6,5, 4,4,3,3,2,2,1 };
            //sheet=new Button[]{So,Mi,Mi,Fa,Re,Re};
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(860, 660);

            for (int i = 0; i < 7; i++) {
                step[i].Location = new Point(240+80*i,390);
                key[i].Location = new Point(270+80*i,420);
            }
            sheetChoose.Items.Clear();
            sheetChoose.Items.Add("小蜜蜂");
            sheetChoose.Items.Add("小星星");
            sheetChoose.SelectedIndex = 0;
            paintTable();
        }

        private void Do_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[0],duration);

            if (sheet[0] - 1 == Array.IndexOf(step, Do))
            {
                count += 1;
                change_sheet();
                paintTable();
            }
        }

        private void Re_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[1],duration);
            if (sheet[0] - 1 == Array.IndexOf(step, Re))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void Mi_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[2], duration);
            if (sheet[0] - 1 == Array.IndexOf(step, Mi))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void Fa_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[3], duration);
            if (sheet[0] - 1 == Array.IndexOf(step, Fa))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void So_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[4], duration);
            if (sheet[0] - 1 == Array.IndexOf(step, So))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void La_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[5], duration);
            if (sheet[0] - 1 == Array.IndexOf(step, La))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void Si_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[6], duration);
            if (sheet[0] - 1 == Array.IndexOf(step, Si))
            {
                count += 1;
                change_sheet();
                paintTable();
            }

        }

        private void sheetChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sheetChoose.SelectedIndex == 0)
                sheetList[0].CopyTo(sheet, 0);
            else if (sheetChoose.SelectedIndex == 1)
                sheetList[1].CopyTo(sheet, 0);
            else if (sheetChoose.SelectedIndex == 2)
                sheetList[2].CopyTo(sheet, 0);
            timer1.Enabled= false;
            paintTable();
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            play_sound_beep();
            change_sheet();
            paintTable();
        }

        private void startAutoPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopAutoPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        void paintTable() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(new Pen(Color.Black, 2), minX, minY + 50 * i, maxX, minY+50*i);
                g.DrawLine(new Pen(Color.Black, 2), minX + 80 * i, minY, minX + 80 * i, maxY);
            }
            for (int i = 0; i < 7; i++) {
                g.FillRectangle(new SolidBrush(set_color), 240+80*(sheet[i]-1), 30+50*(6-i), 80, 50);
                //g.FillRectangle(new SolidBrush(Color.Black), 240+80*(Array.IndexOf(step,sheet[i])), 30+50*(6-i), 80, 50);
            }
               
            
        }
        void change_sheet() {
            int t = sheet[0];
            for (int i=0;i<sheet.Length-1;i++) {
                sheet[i] = sheet[i+1];
            }
            sheet[sheet.Length - 1] = t;
        }

        private void changeBlockColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            set_color = colorDialog1.Color;
            paintTable();
        }

        private void 重新開始_Click(object sender, EventArgs e)
        {
            sheetList[sheetChoose.SelectedIndex].CopyTo(sheet, 0);
            paintTable();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Char.ToLower((char)Keys.A))
                Do_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.S))
                Re_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.D))
                Mi_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.F))
                Fa_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.G))
                So_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.H))
                La_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.J))
                Si_Click(sender, e);
        }
        void play_sound_beep() {
            Console.Beep(fg[sheet[0]], duration);
        }
        Color random_color() {
            return Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255));
        }
    }
}
