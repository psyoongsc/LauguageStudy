using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace _Alpha_Luos_Launcher
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew;
            Mutex dup = new Mutex(true, "[Alpha]Luos Launcher", out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (Application.ExecutablePath != Application.StartupPath + @"\[Alpha]Luos Launcher.EXE")
                {
                    MessageBox.Show("파일 이름이 변경되어있습니다.\r\n파일의 이름을 [Alpha]Luos Launcher.EXE로 변경해주세요.", "파일변조 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.ExitThread();
                }
                else
                {
                    Application.Run(new Main());
                }

                try
                {
                    dup.ReleaseMutex();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가발생하여서 프로그램을 종료합니다. 재시작해주시기바랍니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                    Application.ExitThread();
                }
            }
            else
            {
                //중복실행에 대한 처리
                MessageBox.Show("프로그램이 이미 실행중에 있습니다.", "실행중", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }
        }
    }
}
