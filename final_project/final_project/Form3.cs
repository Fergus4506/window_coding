using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form3 : Form
    {
        Font pixelFont=null;
        main_character player;
        Timer t1,t2;
        Label life;
        public Form3(PrivateFontCollection pixelFontcl,main_character player,Timer t1,Timer t2,Label life)
        {
            InitializeComponent();
            if (pixelFontcl == null)
            {
                pixelFont = new Font(pixelFontcl.Families[0], 28.0F, label1.Font.Style);
            }
            this.player = player;
            t1.Stop();
            t2.Stop();
            this.t1 = t1;
            this.t2 = t2;
            this.life = life;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);
            if (pixelFont!=null) {
                label1.Font = pixelFont;
                label2.Font = pixelFont;
                label3.Font = pixelFont;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            player.shootSpeed += 2;
            t1.Start();
            t2.Start();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            player.bulletSize+=2;
            t1.Start();
            t2.Start();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            player.life += 1;
            life.Text= player.life.ToString();
            t1.Start();
            t2.Start();
            this.Close();
        }
    }
}
