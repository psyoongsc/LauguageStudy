using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FTPConsole
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StatusBox.Items.Add("[InitControl]Loading...");
            InitControl();
            StatusBox.Items.Add("[EventHandler]Loading...");
            EventHandler();
        }

        FileSystemWatcher fswTEST = null;

        private void InitControl()
        {
            fswTEST = new FileSystemWatcher();
            // 파일을 감시할 경로 설정
            fswTEST.Path = @"C:\MAMMO\check";
            StatusBox.Items.Add("[InitControl]경로가'" + fswTEST.Path.ToString() + "'로 설정되었습니다.");
            StatusBox.Items.Add("[InitControl]Load Complete");
        }

        private void EventHandler()
        {
            // 이벤트 핸들러 설정
            fswTEST.Created += new FileSystemEventHandler(fswTEST_Created);
            StatusBox.Items.Add("[EventHandler]FileCreatedEvent has been set");
            // 이벤트 동작여부 설명
            fswTEST.EnableRaisingEvents = true;
            StatusBox.Items.Add("[EventHandler]EventHandler has been started");
            StatusBox.Items.Add("[EvenHandler]Load Complete");
        }

        private void fswTEST_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            Process.Start(@"C:\Users\psyoo\Documents\AllFiles\FAIRE\[1.7.2]페르팜(빌드팜)\페르팜 시즌4 1.7.2.bat");
            System.IO.File.Delete(@"C:\MAMMO\check\" + e.Name);
        }
    }
}
