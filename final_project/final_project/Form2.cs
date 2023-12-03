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
        public Form2(WindowsMediaPlayer player)
        {
            InitializeComponent();
            this.player = player;
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
    }
}
