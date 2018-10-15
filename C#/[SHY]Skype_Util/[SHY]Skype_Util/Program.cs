using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace _SHY_Skype_Util
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
            Mutex dup = new Mutex(true, "SKYPE ManageMent Premium", out createdNew);
            if (createdNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

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
                MessageBox.Show("프로그램이 이미 실행중에 있습니다.", "실행중");
                Application.Exit();
                return;
            }
        }
    }
}
