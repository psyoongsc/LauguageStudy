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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Skype Axskype1 = new Skype();
            textBox2.Text = "아이디어 : " + textBox2.Text;
            Axskype1.SendMessage("sh__y_", textBox2.Text);
            textBox2.Text = "아이디어";
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
