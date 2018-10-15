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
using System.IO;
using System.Runtime.InteropServices;

namespace DDNS정보탐색기
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        public static extern int GetPrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string path);

        DataGridView dgv = null;

        public Form1()
        {
            InitializeComponent();
            dgv = this.dataGridView1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry ipHostEntry = Dns.Resolve(this.textBox1.Text);
                dgv.Rows.Add(textBox1.Text, ipHostEntry.HostName, ipHostEntry.AddressList[0].ToString());
                textBox1.Text = null;
            }
            catch
            {
                MessageBox.Show("알수없는 오류가 발생하였습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
        }

        private void closeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }
    }
}
