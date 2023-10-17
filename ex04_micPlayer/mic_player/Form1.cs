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
        int[] sheet=new int[]{5,3,3,4,2,2,1,2,3,4,5,5,5,5,3,3,4,2,2,1,3,5,5,3,2,2,2,2,2,3,4,3,3,3,3,3,4,5,5,3,3,4,2,2,1,3,5,5,1};
        int duration = 50;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            step = new Button[]{ Do,Re,Mi,Fa,So,La,Si};
            //sheet=new Button[]{So,Mi,Mi,Fa,Re,Re};
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(860, 660);

            for (int i = 0; i < 7; i++) {
                step[i].Location = new Point(240+80*i,390);
            }
            paintTable();
        }

        private void Do_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[0],duration);
            
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, Do))
                {
                    count += 1;
                    paintTable();
                }
            }
        }

        private void Re_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[1],duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, Re))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[2], duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, Mi))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }

        private void Fa_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[3], duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, Fa))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }

        private void So_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[4], duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, So))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }

        private void La_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[5], duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, La))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }

        private void Si_Click(object sender, EventArgs e)
        {
            Console.Beep(fg[6], duration);
            if (count >= sheet.Length)
            {
                MessageBox.Show("恭喜過關!!");
            }
            else
            {
                if (sheet[count]-1 == Array.IndexOf(step, Si))
                {
                    count += 1;
                    paintTable();
                }
            }
            
        }
        void paintTable() {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(new Pen(Color.Black, 2), minX, minY + 50 * i, maxX, minY+50*i);
                g.DrawLine(new Pen(Color.Black, 2), minX + 80 * i, minY, minX + 80 * i, maxY);
            }
            for (int i = count; i < count+7; i++) {
                if(sheet.Length>i)
                    g.FillRectangle(new SolidBrush(Color.Black), 240+80*(sheet[i]-1), 30+50*(6-i+count), 80, 50);
                //g.FillRectangle(new SolidBrush(Color.Black), 240+80*(Array.IndexOf(step,sheet[i])), 30+50*(6-i), 80, 50);
            }
               
            
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
            else if (e.KeyChar == Char.ToLower((char)Keys.J))
                So_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.K))
                La_Click(sender, e);
            else if (e.KeyChar == Char.ToLower((char)Keys.S))
                Si_Click(sender, e);
        }
    }
}