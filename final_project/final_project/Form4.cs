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
    public partial class Form4 : Form
    {
        public Form4(PrivateFontCollection fs)
        {
            
            InitializeComponent();
            Font myfont = new Font(fs.Families[0], 14.0F, label1.Font.Style);
            label1.Font = myfont;
            label2.Font = myfont;
            label3.Font = myfont;
            label4.Font = myfont;
        }

    }
}
