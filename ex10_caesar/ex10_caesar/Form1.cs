using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ex10_caesar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
            textBox3.Text = "2";
        }

        private void EnButton_CheckedChanged(object sender, EventArgs e)
        {
            if (EnButton.Checked) {
                En();
            }
        }

        void En() {
            string temp = "";
            int shift = Int32.Parse(textBox3.Text);
            for (int i = 0; i < oldText.Text.Length; i++) {
                int now = (int)oldText.Text[i];
                if (now >= (int)('A') && now <= (int)('Z')) {
                    if (now + shift > (int)('Z'))
                    {
                        now = (now + shift) - 26;
                    }
                    else
                        now = now + shift;
                    temp += ((char)(now)).ToString();
                }
                else if (now >= (int)('a') && now <= (int)('z'))
                {
                    if (now + shift > (int)('z'))
                    {
                        now = (now + shift) - 26;
                    }
                    else
                        now = now + shift;
                    temp += ((char)(now)).ToString();
                }
                else {
                    temp += ((char)(now)).ToString();
                }

            }
            //MessageBox.Show(temp);
            newText.Text = temp;
            label3.Text = "密文:" + newText.Text;
            label4.Text = "原文:" + oldText.Text;
            label5.Text = "偏移量:" + textBox3.Text;
        }

        private void oldText_TextChanged(object sender, EventArgs e)
        {
            if (EnButton.Checked) {
                En();
            }
        }

        void De()
        {
            string temp = "";
            int shift = Int32.Parse(textBox3.Text);
            for (int i = 0; i < newText.Text.Length; i++)
            {
                int now = (int)newText.Text[i];
                if (now >= (int)('A') && now <= (int)('Z'))
                {
                    if (now - shift < (int)('A'))
                    {
                        now = (now - shift) + 26;
                    }
                    else
                        now = now - shift;
                    temp += ((char)(now)).ToString();
                }
                else if (now >= (int)('a') && now <= (int)('z'))
                {
                    if (now - shift < (int)('a'))
                    {
                        now = (now - shift) + 26;
                    }
                    else
                        now = now - shift;
                    temp += ((char)(now)).ToString();
                }
                else
                {
                    temp += ((char)(now)).ToString();
                }

            }
            //MessageBox.Show(temp);
            oldText.Text = temp;
            label3.Text = "密文:"+newText.Text;
            label4.Text = "原文:"+oldText.Text;
            label5.Text = "偏移量:" + textBox3.Text;
        }

        private void deButton_CheckedChanged(object sender, EventArgs e)
        {
            if(deButton.Checked){
                De();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oldText.Text = "";
            newText.Text = "";
        }
    }
}
