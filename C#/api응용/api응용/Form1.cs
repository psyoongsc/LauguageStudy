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

namespace api응용
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Skype AxxSkype0 = new Skype();
            textBox1.Text = "=" + AxxSkype0.Friends.Count.ToString() + "=";
            foreach (User user in (IUserCollection)AxxSkype0.Friends)
            {
                string before = textBox1.Text;
                textBox1.Text = before.ToString() + "/" + user.Handle;
            }
        }
    }
}
