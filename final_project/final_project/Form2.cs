using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace final_project
{
    public partial class Form2 : Form
    {
        public bool check_sound = true;
        public int sound_value = 70;
        WindowsMediaPlayer player;
        Timer t1,t2;
        bool lastck=false;
        public Form2(WindowsMediaPlayer player,Timer t1,Timer t2)
        {
            InitializeComponent();
            this.player = player;
            this.t1 = t1;
            this.t2 = t2;
            lastck = t1.Enabled;
            t1.Enabled = false;
            t2.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sound_Click(object sender, EventArgs e)
        {

            if (check_sound)
            {
                player.settings.volume = 0;
                sound.Image = Resource1.sound_limit;
                trackBar1.Enabled = false;
                check_sound = false;
            }
            else {
                check_sound=true;
                sound.Image = Resource1.sound_free;
                trackBar1.Enabled = true;
                player.settings.volume = trackBar1.Value;
            }
                
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = trackBar1.Value;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            t1.Enabled = lastck;
            t2.Enabled = lastck;
        }
    }
}
