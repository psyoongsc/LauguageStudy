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

namespace _Alpha_Luos_Launcher
{
    public partial class OldVersion : Form
    {
        public OldVersion()
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

        private void Install_Button_Click(object sender, EventArgs e)
        {
            WebClient WC = new WebClient();
            WC.DownloadFile("https://www.dropbox.com/s/l1e62rwqya4uiax/%5BAlpha%5DLuos%20Launcher.exe?dl=1", Application.StartupPath + @"\[Alpha]Luos Launcher_New.EXE");

            MessageBox.Show("새로운버전이 다운로드되었습니다. 프로그램이 종료됩니다.\r\n새로운 파일의 이름은 [Alpha]Luos Launcher_New.EXE입니다.", "설치 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.ExitThread();
        }
    }
}
