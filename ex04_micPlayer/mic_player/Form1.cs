using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace mic_player
{
    public partial class Form1 : Form
    {
        int minX = 240, maxX = 800, minY = 30, maxY = 450;
        int count = 0;
        int[] fg = { 440,495,550,587,660,733,825,895 };
        Button[] step;
        //Button[] sheet;
        Label[] key;
        int[] sheet=new int[999];
        int[][] sheetList=new int[3][];
        Color set_color= Color.Black;
        Random r=new Random(Guid.NewGuid().GetHashCode());
        int drawStep = 0;
        WindowsMediaPlayer player;
        Graphics g;
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
            player = new WindowsMediaPlayer();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(860, 660);

            for (int i = 0; i < 7; i++) {
                step[i].Location = new Point(240+80*i,460);
                key[i].Location = new Point(270+80*i,500);
            }
            sheetChoose.Items.Clear();
            sheetChoose.Items.Add("小蜜蜂");
            sheetChoose.Items.Add("小星星");
            sheetChoose.SelectedIndex = 0;
            Invalidate();
        }

        private void Do_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, Do))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
            }
        }

        private void Re_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, Re))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
            }

        }

        private void Mi_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, Mi))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
            }

        }

        private void Fa_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, Fa))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
            }

        }

        private void So_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, So))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
            }

        }

        private void La_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, La))
            {
                play_sound_beep();
                drawStep +=60;
                change_sheet();
                Invalidate();
            }

        }

        private void Si_Click(object sender, EventArgs e)
        {
            if (sheet[0] - 1 == Array.IndexOf(step, Si))
            {
                play_sound_beep();
                drawStep += 60;
                change_sheet();
                Invalidate();
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
            Invalidate();
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            change_sheet();
            Invalidate();
        }

        private void startAutoPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void stopAutoPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        void paintTable(Graphics g) {
            
            g.Clear(Color.White);
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(new Pen(Color.Black, 2), minX, minY + 60 * i, maxX, minY + 60 * i);
                g.DrawLine(new Pen(Color.Black, 2), minX + 80 * i, minY, minX + 80 * i, maxY);
            }
            for (int i = 0; i < 7+1; i++)
            {
                if (i == 0)
                {
                    g.FillRectangle(new SolidBrush(set_color), 240 + 80 * (sheet[i] - 1), 30 + 60 * (6 - i) + drawStep, 80, 60 - drawStep);
                }
                else if (i == 7)
                {
                    g.FillRectangle(new SolidBrush(set_color), 240 + 80 * (sheet[i] - 1), 30 , 80, drawStep);
                }
                else {
                    g.FillRectangle(new SolidBrush(set_color), 240 + 80 * (sheet[i] - 1), 30 + 60 * (6 - i) + drawStep, 80, 60);
                }
                    
                //g.FillRectangle(new SolidBrush(Color.Black), 240+80*(Array.IndexOf(step,sheet[i])), 30+50*(6-i), 80, 50);
            }
        }
        void change_sheet() {
            if (drawStep < 60)
            {
                drawStep += 10;
                if (drawStep == 20) 
                    play_sound_beep();
            }
            else {
                drawStep = 0;
                int t = sheet[0];
                for (int i = 0; i < sheet.Length - 1; i++)
                {
                    sheet[i] = sheet[i + 1];
                }
                sheet[sheet.Length - 1] = t;
                
            }
            
        }

        private void changeBlockColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            set_color = colorDialog1.Color;
            Invalidate();
        }

        private void 重新開始_Click(object sender, EventArgs e)
        {
            sheetList[sheetChoose.SelectedIndex].CopyTo(sheet, 0);
            drawStep = 0;
            Invalidate();
            timer1.Enabled = false;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g=e.Graphics;
            paintTable(g);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
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
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string path = null;
            if (sheet[0]==1)
                path=Path.GetFullPath(directory + @"\Music_Notes\C.wav");
            else if (sheet[0] == 2)
                path = Path.GetFullPath(directory + @"\Music_Notes\D.wav");
            else if (sheet[0] == 3)
                path = Path.GetFullPath(directory + @"\Music_Notes\E.wav");
            else if (sheet[0] == 4)
                path = Path.GetFullPath(directory + @"\Music_Notes\F.wav");
            else if (sheet[0] == 5)
                path = Path.GetFullPath(directory + @"\Music_Notes\G.wav");
            else if (sheet[0] == 6)
                path = Path.GetFullPath(directory + @"\Music_Notes\A.wav");
            else if (sheet[0] == 7)
                path = Path.GetFullPath(directory + @"\Music_Notes\B.wav");
            player.URL = path;
            player.settings.rate = 2;
            player.controls.play();
        }
        Color random_color() {
            return Color.FromArgb(r.Next(0,255), r.Next(0, 255), r.Next(0, 255));
        }
        
    }
}
