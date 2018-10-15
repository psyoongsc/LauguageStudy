using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace 내_IPv4주소
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void GET_IPv4_Address()
        {
            try
            {
                WebClient WC = new WebClient();
                string LOAD = WC.DownloadString("http://www.ipip.kr/");

                string result = LOAD.Split('>')[2].Split(' ')[3].Split('<')[0].Trim();

                textBox1.Text = result;
            }
            catch
            {
                MessageBox.Show("I can't get your IPv4 Address... try again!", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "Unknown IPv4";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GET_IPv4_Address();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GET_IPv4_Address();
        }

        private void closeXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
