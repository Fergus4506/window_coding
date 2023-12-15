using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final_project
{
    public partial class Form3 : Form
    {
        Font pixelFont=null;
        public Form3(PrivateFontCollection pixelFontcl)
        {
            InitializeComponent();
            if (pixelFontcl == null)
            {
                pixelFont = new Font(pixelFontcl.Families[0], 28.0F, label1.Font.Style);
            }
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
    }
}
