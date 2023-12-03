using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form2 : Form
    {
        public bool check_sound = true;
        public int sound_value = 70;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sound_Click(object sender, EventArgs e)
        {

            if (check_sound)
            {
                check_sound = false;
                sound.Image = Resource1.sound_limit;
                trackBar1.Enabled = false;
            }
            else {
                check_sound = true;
                sound.Image = Resource1.sound_free;
                trackBar1.Enabled = true;
            }
                
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
            sound_value = trackBar1.Value;
        }
    }
}
