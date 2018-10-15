using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;

namespace _SHY_Skype_Util
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Skype Axskype1 = new Skype();
            textBox1.Text = "아이디 : " + textBox1.Text;
            textBox2.Text = "사유 : " + textBox2.Text;
            Axskype1.SendMessage("sh__y_", textBox1.Text + "\r\n" + textBox2.Text);
            textBox1.Text = "아이디";
            textBox2.Text = "신고사유";
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.LightPink;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            panel2.BackColor = Color.PaleVioletRed;
        }
    }
}
