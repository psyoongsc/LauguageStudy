using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _Alpha_Luos_Launcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            UpdateCheck();
        }
        int Move;
        int MvalX;
        int MvalY;

        bool newlauncher;

        private void UpdateCheck()
        {
            try
            {
                WebClient WC = new WebClient();
                string[] lasting = WC.DownloadString(new Uri("https://www.dropbox.com/s/fftm3sn9xr01fpx/Version.txt?dl=1")).Split('/');
                if (lasting[1].ToString() != "1.0.0.0")
                {
                    MessageBox.Show("새로운 버전이 있습니다.\r\n업데이트 해주시기 바랍니다.", "새로운 버전 알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    newlauncher = true;
                }
                else if (lasting[1].ToString() == "updating")
                {
                    MessageBox.Show("해당 런처에 문제가 발견되어 현재 수정중입니다. 이용에 불편을 끼쳐드려 죄송합니다.\r\n자세한 내용은 카페를 참고해주시기바랍니다.", "업데이트중", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.ExitThread();
                }
            }
            catch
            {
                MessageBox.Show("인터넷 연결상태가 좋지 않습니다.", "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateCheck_1()
        {
            try
            {
                WebClient WC = new WebClient();
                string[] lasting = WC.DownloadString(new Uri("https://www.dropbox.com/s/fftm3sn9xr01fpx/Version.txt?dl=1")).Split('/');
                if (lasting[1].ToString() != "1.0.0.0")
                {
                    newlauncher = true;
                }
                else if (lasting[1].ToString() == "updating")
                {
                    MessageBox.Show("해당 런처에 문제가 발견되어 현재 수정중입니다. 이용에 불편을 끼쳐드려 죄송합니다.\r\n자세한 내용은 카페를 참고해주시기바랍니다.", "업데이트중", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.ExitThread();
                }
            }
            catch
            {
                MessageBox.Show("인터넷 연결상태가 좋지 않습니다.", "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void Shutdown_Button_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Notice_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://cafe.naver.com/ArticleList.nhn?search.clubid=26924852&search.menuid=79&search.boardtype=L");
            }
            catch
            {
                MessageBox.Show("인터넷 연결상태가 좋지 않습니다.", "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PatchNote_Button_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://cafe.naver.com/ArticleList.nhn?search.clubid=26924852&search.menuid=84&search.boardtype=L");
            }
            catch
            {
                MessageBox.Show("인터넷 연결상태가 좋지 않습니다.", "연결 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GameStart_Button_Click(object sender, EventArgs e)
        {
            updateCheck_1();
            if (!newlauncher)
            {
                Login loginform = new Login();
                loginform.Show();
            }
            else
            {
                MessageBox.Show("업데이트를 진행해주세요.", "업데이트", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            updateCheck_1();
            if (!newlauncher)
            {
                CurrentVersion CVform = new CurrentVersion();
                CVform.Show();
            }
            else
            {
                OldVersion OVform = new OldVersion();
                OVform.Show();
            }
        }
    }
}
