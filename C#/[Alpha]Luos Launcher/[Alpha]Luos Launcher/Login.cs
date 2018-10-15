using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic;

namespace _Alpha_Luos_Launcher
{
    public partial class Login : Form
    {
        string PATH = Interaction.Environ("appdata") + @"\Luos\Launcher\LuosOnline.ini";
        public Login()
        {
            InitializeComponent();
            
            IniReadWrite ini = new IniReadWrite();
            ID.Text = ini.IniReadValue("Login", "ID", PATH);
            PW.Text = ini.IniReadValue("Login", "PW", PATH);
        }
        int Move;
        int MvalX;
        int MvalY;

        public class IniReadWrite
        {
            [DllImport("kernel32.dll")]
            private static extern int GetPrivateProfileString(String section, String key, String def, StringBuilder retVal, int size, String filePath);

            [DllImport("kernel32.dll")]
            private static extern long WritePrivateProfileString(String section, String key, String val, String filepath);

            public String IniReadValue(String Section, String Key, String iniPath)
            {
                StringBuilder temp = new StringBuilder(255);
                int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
                return temp.ToString();
            }

            public void IniWriteValue(String Section, String Key, String Value, String iniPath)
            {
                WritePrivateProfileString(Section, Key, Value, iniPath);
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

        private void GameStart_Button_Click(object sender, EventArgs e)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://authserver.mojang.com/authenticate");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"agent\":{\"name\":\"Minecraft\",\"version\":1},\"username\":\"" + ID.Text + "\",\"password\":\"" + PW.Text + "\",\"clientToken\":\"6c9d237d-8fbf-44ef-b46b-0b8a854bf391\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
                try
                {
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();

                        string A = textBox1.Text;
                        A = A.Replace(@"E:\Users\kakao\AppData\Roaming\.minecraft\", Interaction.Environ("appdata") + @"\Luos\");
                        A = A.Replace(@"C:\Users\kakao\AppData\Roaming\.minecraft", Interaction.Environ("appdata") + @"\Luos");
                        A = A.Replace(@"C:\Users\kakao\AppData\Roaming\.minecraft\assets", Interaction.Environ("appdata") + @"\Luos\assets");
                        A = A.Replace("nick", Regex.Split(result, "name")[1].Split('"')[2].Trim());
                        A = A.Replace("-Xmx1G -XX", "-Xmx2G -XX");
                        A = A.Replace(@"E:\바탕화면\마크\runtime\jre-x64\1.8.0_25\bin\", Interaction.Environ("appdata") + @"\Luos\java\bin\");
                        A = A.Replace("--uuid 1", "--uuid " + Regex.Split(result, "id")[1].Split('"')[2].Trim());
                        A = A.Replace("--accessToken 1", "--accessToken " + Regex.Split(result, "accessToken")[1].Split('"')[2].Trim());
                        
                        if (!File.Exists(Interaction.Environ("appdata") + @"\Luos\Launcher\LuosOnline.ini"))
                        {
                            MessageBox.Show("최초로그인에 성공하셨습니다.\r\n이후부터 아이디와 비밀번호가 저장됩니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!Directory.Exists(Interaction.Environ("appdata") + @"\Luos\Launcher"))
                            {
                                Directory.CreateDirectory(Interaction.Environ("appdata") + @"\Luos\Launcher");
                            }
                        }

                        try
                        {
                            Interaction.Shell(A, Constants.vbNormalNoFocus);
                            MessageBox.Show("루오스 온라인을 실행하였습니다. 3~5분이상 무반응이라면 패치를 다시 진행해주시기 바랍니다.");
                            
                            IniReadWrite ini = new IniReadWrite();
                            ini.IniWriteValue("Login", "ID", ID.Text, PATH);
                            ini.IniWriteValue("Login", "PW", PW.Text, PATH);
                        }
                        catch
                        {
                            MessageBox.Show("루오스 온라인을 실행하는동안 오류가 발생하였습니다.\r\n패치를 다시 진행해주시기 바랍니다.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();

                    MessageBox.Show("로그인에 실패하였습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
