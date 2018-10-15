using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Alpha_Luos_Launcher
{
    public partial class CurrentVersion : Form
    {
        public CurrentVersion()
        {
            InitializeComponent();
        }
        int Move;
        int MvalX;
        int MvalY;

        private void Move_Sector_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            MvalX = e.X;
            MvalY = e.Y;
        }

        private void Move_Sector_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Move_Sector_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - MvalX, MousePosition.Y - MvalY);
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
