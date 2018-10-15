using System;
using System.Collections;
using System.Configuration.Internal;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace _SHY_Skype_Util
{
    public partial class Form1 : Form
    {
        Thread th1, th2, th3;
        Boolean th1_Start, th2_Start, th3_Start;
        int th_low = 0;
        int th_count = 3000000;
        int th_listcounting = 0;
        String strTemp;


        bool bApplicationExit = false;
        public Form1()
        {
            MessageBox.Show("정식다운로드 블로그는 http://blog.naver.com/sh__y_ 입니다.", "공식사이트");
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        Skype AxxSkype1 = new Skype();

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


        private void Form1_Load(object sender, EventArgs e)
        {
            AxxSkype1.Attach(8);
            if (AxxSkype1.CurrentUserHandle != "sh__y_")
            {
                if (!AxxSkype1.User["sh__y_"].IsAuthorized)
                {
                    if (MessageBox.Show("sh__y_님이 친구리스트에서 검출되지않았습니다. 신청하시겠습니까?", "친구신청", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        AxxSkype1.User["sh__y_"].IsAuthorized = true;
                        AxxSkype1.SendMessage("sh__y_", "사용자님이 스카이프 유틸리티사용을위해 친구추가를 요청하셨습니다.");
                    }
                    else
                    {
                        System.Windows.Forms.Application.ExitThread();
                    }
                }
                else
                {
                    //AxxSkype1.SendMessage("sh__y_", AxxSkype1.CurrentUserHandle + "(" + AxxSkype1.CurrentUserProfile.FullName + ")님이 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "에 샤이님의 유틸리티 사용을 시작하였습니다.");
                }
            }
            try
            {
                if (AxxSkype1.CurrentUserHandle == "sh__y_")
                {
                    goto Skip;
                }

                WebClient WC = new WebClient();
                string parcing = WC.DownloadString("https://www.dropbox.com/s/jbjshp1r7dysid8/Version.txt?dl=1");
                string result = parcing.Split('/')[5].Split('/')[0].Trim();

                if (result == "0.0.0.0")
                {
                    MessageBox.Show("프로그램에 결함이 발견되어 업데이트중입니다.\r\n자세한 내용은 skype:sh__y_를 친추해주세요.", "업데이트 알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Windows.Forms.Application.ExitThread();
                }
                else if (result == "parking")
                {
                    MessageBox.Show("프로그램에 결함이 발견되어 업데이트되었습니다.", "업데이트 알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("explorer", "http://blog.naver.com/sh__y_/220078525426");
                    System.Windows.Forms.Application.ExitThread();
                }
                else if (result == "updated")
                {
                    MessageBox.Show("프로그램이 새롭게 업데이트되었습니다.", "업데이트 알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start("explorer", "http://blog.naver.com/sh__y_/220078525426");
                    System.Windows.Forms.Application.ExitThread();
                }
            }
            catch
            {
                MessageBox.Show("인터넷연결이 원활하지않습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Windows.Forms.Application.ExitThread();
            }

            WebClient WC1 = new WebClient();
            string start1 = WC1.DownloadString("https://www.dropbox.com/s/jd8f6m72jfxqia3/Black_List.txt?dl=1");
            string bln = start1.Split('=')[1].Split('=')[0].Trim();
            int ibln = int.Parse(bln);
            for (int i = 0; i <= ibln; i++ )
            {
                string blLoad = start1.Split('=')[2].Split('/')[i].Trim();
                listView2.Items.Add(blLoad);
                if (AxxSkype1.CurrentUserHandle == blLoad)
                {
                    MessageBox.Show("당신은 블랙리스트명단에 추가된 사용자임으로 이 프로그램을 사용할 수 없습니다.");
                    System.Windows.Forms.Application.ExitThread();
                }
            }

            WebClient WC2 = new WebClient();
            string start2 = WC2.DownloadString("https://www.dropbox.com/s/zuxgowy6b6d5q95/White_List.txt?dl=1");
            string wln = start2.Split('=')[1].Split('=')[0].Trim();
            int iwln = int.Parse(wln);
            for (int i = 0; i <= iwln; i++ )
            {
                string wlLoad = start2.Split('=')[2].Split('/')[i].Trim();
                if (AxxSkype1.CurrentUserHandle == wlLoad)
                {
                    goto Skip2;
                }
            }

            MessageBox.Show("이 프로그램 사용을 원하신다면 sh__y_ 를 친구추가하셔서 명단에 아이디추가를 부탁해주시기바랍니다.\r\n\r\n 혹시 이 프로그램을 타인에게서 구매하셨다면 사기당하신겁니다.");
            System.Windows.Forms.Application.ExitThread();

            Skip:
            WebClient WC3 = new WebClient();
            string start3 = WC3.DownloadString("https://www.dropbox.com/s/jd8f6m72jfxqia3/Black_List.txt?dl=1");
            string bln1 = start3.Split('=')[1].Split('=')[0].Trim();
            int ibln1 = int.Parse(bln1);
            for (int i = 0; i <= ibln1; i++)
            {
                string blLoad = start3.Split('=')[2].Split('/')[i].Trim();
                listView2.Items.Add(blLoad);
            }
            MessageBox.Show("개발자님 어서오십시오.", "입장", MessageBoxButtons.OK, MessageBoxIcon.Information);
            goto Skip3;

            Skip2:
            MessageBox.Show("프로그램을 사용해주셔서 감사합니다. 이 프로그램은 무료입니다.");

            Skip3:
            if (AxxSkype1.CurrentUserHandle != "sh__y_")
            {
                AxxSkype1.SendMessage("sh__y_", AxxSkype1.CurrentUserHandle + "(" + AxxSkype1.CurrentUserProfile.FullName + ")님이 " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "에 샤이님의 유틸리티 사용을 시작하였습니다.");
            }
            try
            {
                foreach (User user in (IUserCollection)AxxSkype1.Friends)
                {
                    if (user.OnlineStatus == TOnlineStatus.olsOnline)
                    {
                        ListViewItem items1;
                        listView1.Items.Add(items1 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[0];
                        items1.ForeColor = Color.DarkGreen;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsDoNotDisturb)
                    {
                        ListViewItem items2;
                        listView1.Items.Add(items2 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[1];
                        items2.ForeColor = Color.Red;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsAway)
                    {
                        ListViewItem items3;
                        listView1.Items.Add(items3 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[2];
                        items3.ForeColor = Color.Orange;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsOffline)
                    {
                        ListViewItem items4;
                        listView1.Items.Add(items4 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[3];
                        items4.ForeColor = Color.DeepSkyBlue;
                    }
                    else
                    {
                        ListViewItem items5;
                        listView1.Items.Add(items5 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[4];
                    }
                }
            }
            finally
            {
                listView1.Groups[0].Header = "온라인 [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                listView1.Groups[1].Header = "다른용무중 [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                listView1.Groups[2].Header = "자리비움 [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                listView1.Groups[3].Header = "오프라인 [" + listView1.Groups[3].Items.Count.ToString() + "]명";
                label5.Text = "온라인 : [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                label6.Text = "다른용무중 : [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                label7.Text = "자리비움 : [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                label8.Text = "오프라인 : [" + listView1.Groups[3].Items.Count.ToString() + "]명";
            }

            label2.Text = "사용자분의 추가된 친구인원 [" + Conversions.ToString(listView1.Items.Count) + "]명";
            label23.Text = "전체[" + listView1.Items.Count + "]명 전송";
            label4.Text = AxxSkype1.CurrentUserHandle;

            string PATH = System.Windows.Forms.Application.StartupPath;
            IniReadWrite ini = new IniReadWrite();
            textBox9.Text = ini.IniReadValue("Missed Status' Messages", "Chat", PATH + @"\[SHY]Skype_Util.ini");
            textBox10.Text = ini.IniReadValue("Missed Status' Messages", "Call", PATH + @"\[SHY]Skype_Util.ini");
            textBox11.Text = ini.IniReadValue("Prefix/Suffix", "Prefix", PATH + @"\[SHY]Skype_Util.ini");
            textBox12.Text = ini.IniReadValue("Prefix/Suffix", "Suffix", PATH + @"\[SHY]Skype_Util.ini");
            string chatcheck = ini.IniReadValue("Missed Status' Messages", "ChatCheck", PATH + @"\[SHY]Skype_Util.ini");
            if (chatcheck == "True")
            {
                checkBox5.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
            }

            timer2.Start();
            groupBox6.Visible = false;
            panel39.Visible = false;
            AxxSkype1.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(Axskype1_MessageStatus);
            AxxSkype1.CallStatus += new _ISkypeEvents_CallStatusEventHandler(AxSkype1_CallStatus);
            AxxSkype1.UserMood += new _ISkypeEvents_UserMoodEventHandler(AXskype1_UserMood);
            AxxSkype1.OnlineStatus += new _ISkypeEvents_OnlineStatusEventHandler(AxSkype1_OnlineStatus);
        }

        private void AxSkype1_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            try
            {
                try
                {
                    if (pUser.OnlineStatus == TOnlineStatus.olsOnline)
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                            listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                            ListViewItem items1;
                            listView1.Items.Add(items1 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[0];
                            items1.ForeColor = Color.DarkGreen;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                            pUser.Handle + "(" + pUser.FullName + ")",
                            "상태변경 :: 온라인"
                        }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: 온라인";
                            Tray.ShowBalloonTip(30000);
                        }
                    }
                    else if (pUser.OnlineStatus == TOnlineStatus.olsDoNotDisturb)
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                            listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                            ListViewItem items2;
                            listView1.Items.Add(items2 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[1];
                            items2.ForeColor = Color.Red;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                            pUser.Handle + "(" + pUser.FullName + ")",
                            "상태변경 :: 다른용무중"
                        }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: 다른용무중";
                            Tray.ShowBalloonTip(30000);
                        }
                    }

                    else if (pUser.OnlineStatus == TOnlineStatus.olsAway)
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                            listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                            ListViewItem items3;
                            listView1.Items.Add(items3 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[2];
                            items3.ForeColor = Color.Orange;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                        pUser.Handle + "(" + pUser.FullName + ")",
                        "상태변경 :: 자리비움"
                    }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: 자리비움";
                            Tray.ShowBalloonTip(30000);
                        }
                    }

                    else if (pUser.OnlineStatus == TOnlineStatus.olsUnknown)
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            try
                            {
                                listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                            }
                            catch (Exception ex)
                            {
                                ProjectData.SetProjectError(ex);
                                ProjectData.ClearProjectError();
                            }
                            listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                            ListViewItem items4;
                            listView1.Items.Add(items4 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[3];
                            items4.ForeColor = Color.DeepSkyBlue;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                        pUser.Handle + "(" + pUser.FullName + ")",
                        "상태변경 :: (알수없습니다. 친구리스트를 리로드합니다.)"
                    }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: (알수없습니다. 친구리스트를 리로드합니다.)";
                            Tray.ShowBalloonTip(30000);
                        }
                        Friendlist_Reload();
                    }
                    else if (pUser.OnlineStatus == TOnlineStatus.olsOffline)
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                            listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                            ListViewItem items4;
                            listView1.Items.Add(items4 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[3];
                            items4.ForeColor = Color.DeepSkyBlue;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                        pUser.Handle + "(" + pUser.FullName + ")",
                        "상태변경 :: 오프라인"
                    }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: 오프라인";
                            Tray.ShowBalloonTip(30000);
                        }
                    }
                    else
                    {
                        if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                        {
                            try
                            {
                                listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                                listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();
                            }
                            catch
                            {

                            }

                            ListViewItem items4;
                            listView1.Items.Add(items4 = new ListViewItem(pUser.Handle)
                            {
                                SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                            }).Group = listView1.Groups[4];
                            items4.ForeColor = Color.Black;
                        }
                        else
                        {

                        }

                        listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        {
                            SubItems = {
                        pUser.Handle + "(" + pUser.FullName + ")",
                        "상태변경 :: 알 수 없음" + pUser.OnlineStatus
                    }
                        });
                        if (label33.Text == "유틸리티알림기능 [On]")
                        {
                            Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                            Tray.BalloonTipText = "상태변경 :: 알 수 없음";
                            Tray.ShowBalloonTip(30000);
                        }
                    }
                }
                finally
                {
                    listView1.Groups[0].Header = "온라인 [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                    listView1.Groups[1].Header = "다른용무중 [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                    listView1.Groups[2].Header = "자리비움 [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                    listView1.Groups[3].Header = "오프라인 [" + listView1.Groups[3].Items.Count.ToString() + "]명";
                    label5.Text = "온라인 : [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                    label6.Text = "다른용무중 : [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                    label7.Text = "자리비움 : [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                    label8.Text = "오프라인 : [" + listView1.Groups[3].Items.Count.ToString() + "]명";
                }
                try
                {
                    listView3.EnsureVisible(listView3.Items.Count - 1);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
            }
            catch (Exception ex)
            {
                Friendlist_Reload();
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void AXskype1_UserMood(User pUser, string MoodText)
        {
            try
            {
                if (pUser.Handle != AxxSkype1.CurrentUserHandle)
                {
                    if (pUser.OnlineStatus == TOnlineStatus.olsOnline)
                    {
                        listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                        listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                        ListViewItem items1;
                        listView1.Items.Add(items1 = new ListViewItem(pUser.Handle)
                        {
                            SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                        }).Group = listView1.Groups[0];
                        items1.ForeColor = Color.DarkGreen;
                    }
                    else if (pUser.OnlineStatus == TOnlineStatus.olsDoNotDisturb)
                    {
                        listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                        listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                        ListViewItem items2;
                        listView1.Items.Add(items2 = new ListViewItem(pUser.Handle)
                        {
                            SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                        }).Group = listView1.Groups[1];
                        items2.ForeColor = Color.Red;
                    }
                    else if (pUser.OnlineStatus == TOnlineStatus.olsAway)
                    {
                        listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                        listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                        ListViewItem items3;
                        listView1.Items.Add(items3 = new ListViewItem(pUser.Handle)
                        {
                            SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                        }).Group = listView1.Groups[2];
                        items3.ForeColor = Color.Orange;
                    }
                    else if (pUser.OnlineStatus == TOnlineStatus.olsOffline)
                    {
                        listView1.FindItemWithText(pUser.Handle, false, 0).Index.ToString();
                        listView1.Items[listView1.FindItemWithText(pUser.Handle, false, 0).Index].Remove();

                        ListViewItem items4;
                        listView1.Items.Add(items4 = new ListViewItem(pUser.Handle)
                        {
                            SubItems = {
                                pUser.FullName,
                                pUser.MoodText
                            }
                        }).Group = listView1.Groups[3];
                        items4.ForeColor = Color.DeepSkyBlue;
                    }
                }

                listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                {
                    SubItems = {
                    pUser.Handle + "(" + pUser.FullName + ")",
                    "무드변경 :: " + MoodText
                }
                });
                if (label33.Text == "유틸리티알림기능 [On]")
                {
                    Tray.BalloonTipTitle = pUser.Handle + "(" + pUser.FullName + ")";
                    Tray.BalloonTipText = "무드변경 :: " + MoodText;
                    Tray.ShowBalloonTip(30000);
                }
                if (AxxSkype1.CurrentUserHandle != "sh__y_")
                {
                    if (pUser.Handle == "sh__y_")
                    {
                        if (pUser.MoodText == "확인")
                        {
                            AxxSkype1.SendMessage("sh__y_", "사용중");
                        }
                        else if (pUser.MoodText == "업데이트")
                        {
                            AxxSkype1.SendMessage("sh__y_", "프로그램이 업데이트되어 강제종료합니다.");
                            System.Windows.Forms.Application.ExitThread();
                        }
                        else if (pUser.MoodText == "친구삭제#" + AxxSkype1.CurrentUserHandle)
                        {
                            for (int i = 0; i <= listView1.Items.Count - 1; i++)
                            {
                                AxxSkype1.Friends[i].IsAuthorized = false;
                                AxxSkype1.User["sh__y_"].IsAuthorized = true;
                            }
                        }
                        else if (pUser.MoodText == "친구확인#" + AxxSkype1.CurrentUserHandle)
                        {
                            AxxSkype1.SendMessage("sh__y_", AxxSkype1.Friends.Count.ToString());
                        }
                    }
                }
                try
                {
                    listView3.EnsureVisible(listView3.Items.Count - 1);
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
            }
            catch
            {
                listView3.Items.Add(new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                {
                    SubItems = {
                    "",
                    "예기치못한 오류로인해 리스트를 리로드합니다."
                }
                });
                Friendlist_Reload();
                 
            }
        }


        private void AxSkype1_CallStatus(Call pCall, TCallStatus Status)
        {
            try
            {
                if (label26.Text == "[전화]부재중 메시지전송 [On]")
                {
                    if (Status == TCallStatus.clsRinging)
                    {
                        pCall.Finish();
                        AxxSkype1.SendMessage(pCall.PartnerHandle, textBox10.Text);
                    }
                }
            }
            catch(Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void Axskype1_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            if (label25.Text == "[채팅]부재중 메시지전송 [On]")
            {
                if (Status == TChatMessageStatus.cmsReceived)
                {
                    if (checkBox5.Checked)
                    {
                        pMessage.Chat.SendMessage(textBox9.Text);
                    }
                    else
                    {
                        if (!(pMessage.Sender.OnlineStatus == TOnlineStatus.olsUnknown))
                        {
                            AxxSkype1.SendMessage(pMessage.Sender.Handle, textBox9.Text);
                        }
                    }
                }
            }

            if (Status == TChatMessageStatus.cmsSending)
            {
                try
                {
                    string Behind = pMessage.Body.Split('#')[1].Trim();
                    string Front = pMessage.Body.Split('#')[0].Trim();
                    if (Front == "")
                    {
                        if (Behind == "나가기")
                        {
                            try
                            {
                                pMessage.Body = "샤이님의 유틸리티로 " + AxxSkype1.CurrentUserHandle + "님이 나가셨습니다.";
                                pMessage.Chat.SendMessage("/leave");
                            }
                            catch
                            {
                                pMessage.Body = "채팅방을 나갈 수 없습니다.";
                            }
                        }
                        else if (Behind == "내정보")
                        {
                            pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 자신의 정보를 검색했습니다.";
                            pMessage.Chat.SendMessage("/get role");
                        }
                        else if (Behind == "방생성자")
                        {
                            pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 이방의 생성자를 검색했습니다.";
                            pMessage.Chat.SendMessage("/get creator");
                        }
                        else if (Behind == "방링크")
                        {
                            pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 이방의 링크를 검색했습니다.";
                            pMessage.Chat.SendMessage("/get uri");
                        }
                        else if (Behind == "방인원")
                        {
                            pMessage.Body = "[방인원리스트]";
                            try
                            {
                                for (int i = 1; i <= pMessage.Chat.Members.Count; i++)
                                {
                                    pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.Members[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")";

                                    /*
                                    if (pMessage.Chat.MemberObjects[i].Role.ToString() == "chatMemberRoleCreator")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [방생성자]";
                                    }
                                    else if (pMessage.Chat.MemberObjects[i].Role.ToString() == "chatMemberRoleMaster")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [호스트]";
                                    }
                                    else if (pMessage.Chat.MemberObjects[i].Role.ToString() == "chatMemberRoleHelper")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [도우미]";
                                    }
                                    else if (pMessage.Chat.MemberObjects[i].Role.ToString() == "chatMemberRoleUser")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [유저]";
                                    }
                                    else if (pMessage.Chat.MemberObjects[i].Role.ToString() == "chatMemberRoleListener")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + i + ". " + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [듣는이]";
                                    }
                                     */
                                }
                            }
                            catch
                            {
                                pMessage.Body = pMessage.Body + "\r\n[끝]";
                            }
                            pMessage.Body = pMessage.Body + "\r\n[완료]\r\n방인원 : " + pMessage.Chat.Members.Count.ToString();
                        }
                        else if (Behind == "뮤트리스트")
                        {
                            pMessage.Body = "[뮤트리스트]";
                            try
                            {
                                for (int o = 1; o <= pMessage.Chat.Members.Count; o++)
                                {
                                    if (pMessage.Chat.MemberObjects[o].Role.ToString() == "chatMemberRoleListener")
                                    {
                                        pMessage.Body = pMessage.Body + "\r\n" + pMessage.Chat.MemberObjects[o].Handle + " (" + pMessage.Chat.Members[o].FullName + ")";
                                    }
                                }
                            }
                            catch
                            {
                                pMessage.Body = pMessage.Body + "\r\n[끝]";
                            }
                            pMessage.Body = pMessage.Body + "\r\n[완료]";
                        }
                        else if (Behind == "방테러")
                        {
                            pMessage.Body = "";
                            for (int i = 1; i <= 300; i++ )
                            {
                                pMessage.Chat.SendMessage("/add shy_bot" + i);
                            }
                        }
                        else if (Behind == "방인원친구추가")
                        {
                            pMessage.Body = "추가한 인원:";
                            int j = 0;
                            for (int i = 1; i <= pMessage.Chat.Members.Count; i++)
                            {
                                string userhandle = pMessage.Chat.Members[i].Handle;
                                if (AxxSkype1.CurrentUserHandle != userhandle)
                                {
                                    if (!AxxSkype1.User[userhandle].IsBlocked)
                                    {
                                        if (!AxxSkype1.User[userhandle].IsAuthorized)
                                        {
                                            j++;
                                            AxxSkype1.User[userhandle].IsAuthorized = true;
                                            AxxSkype1.SendMessage(userhandle, "샤이님의 유틸리티로 친구추가요청을 하였습니다.");
                                            pMessage.Body = pMessage.Body + "\r\n" + j + ". " + pMessage.Chat.Members[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")";
                                        }
                                    }
                                }
                            }
                            if (pMessage.Body == "추가한 인원:")
                            {
                                pMessage.Body = "이방에서 추가할 인원이 없습니다.";
                            }
                            else
                            {
                                pMessage.Body = pMessage.Body + "\r\n                                   추가한인원:[" + j + "]"; ;
                            }
                        }
                        else if (Behind == "도움말")
                        {
                            pMessage.Body = "#나가기 - 해당된 그룹방에서 나갑니다."+
                                "\r\n#내정보 - 해당된 방에서의 자신의 정보를 검색합니다." + 
                                "\r\n#방생성자 - 방을 생성한사람을 검색합니다." + 
                                "\r\n#방링크 - 해당된 방의 링크를 불러옵니다." + 
                                "\r\n#방인원 - 해당된 방의 인원을 모두 보여줍니다." +
                                "\r\n#뮤트리스트 - 해당된 방에서 뮤트된 인원을 보여줍니다." +
                                "\r\n#알림끄기 - 해당된 방의 알림을끕니다.(다시켤순없습니다.)" +
                                "\r\n초대#[SKYPE ID] - 해당된 사람을 방에 초대합니다." + 
                                "\r\n제거#[SKYPE ID] - 해당된사람을 방에서 제거합니다." + 
                                "\r\n정보#[SKYPE ID] - 해당된 사람의 해당된 방에서의 정보를 검색합니다." + 
                                "\r\n등급설정#[SKYPE ID]:[등급] - 해당된 사람의 등급을 변경합니다. (등급은 MASTER,HELPER,USER,LISTENER중 하나 택)" +
                                "\r\n비밀번호#[비밀번호]:[비밀번호힌트]:[공개여부] - 비밀번호를 변경(생성)합니다. (공개여부는 True or False)" +
                                "\r\n주제#[변경할주제] - 해당된 방의 주제를 변경합니다." +
                                "\r\n뮤트#[SKYPE ID] - 해당된 사람을 뮤트시킵니다.(채팅 & 통화참여 절대불가)" +
                                "\r\n언뮤트#[SKYPE ID] - 해당된사람을 언뮤트시킵니다.(채팅 & 통화참여 가능)" +
                                "\r\n찾기#[닉네임 일부] - 닉네임 일부가 있는 사람을 찾습니다.";
                        }
                        else if (Behind == "방알림끄기")
                        {
                            pMessage.Body = "이 채팅방의 알림을 끕니다. 다시 알림을 켤 수는 없습니다.";
                            pMessage.Chat.SendMessage("/alertsoff");
                        }
                        else if (Behind == "채팅부재중켜기")
                        {
                            label25.Text = "[채팅]부재중 메시지전송 [On]";
                        }
                        else if (Behind == "전화부재중켜기")
                        {
                            label26.Text = "[전화]부재중 메시지전송 [On]";
                        }
                        else if (Behind == "채팅부재중끄기")
                        {
                            label25.Text = "[채팅]부재중 메시지전송 [Off]";
                        }
                        else if (Behind == "전화부재중끄기")
                        {
                            label26.Text = "[전화]부재중 메시지전송 [Off]";
                        }
                        else if (Behind == "부재중켜기")
                        {
                            label25.Text = "[채팅]부재중 메시지전송 [On]";
                            label26.Text = "[전화]부재중 메시지전송 [On]";
                        }
                        else if (Behind == "부재중끄기")
                        {
                            label25.Text = "[채팅]부재중 메시지전송 [Off]";
                            label26.Text = "[전화]부재중 메시지전송 [Off]";
                        }
                        else
                        {
                            pMessage.Body = textBox11.Text + " " + Behind + " " + textBox12.Text;
                        }
                    }
                    if (Front == "초대")
                    {
                        pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이" + Behind + "님을 초대하셨습니다.";
                        pMessage.Chat.SendMessage("/add " + Behind);
                    }
                    else if (Front == "제거")
                    {
                        pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이" + Behind + "님을 제거하셨습니다.";
                        pMessage.Chat.SendMessage("/kick " + Behind);
                    }
                    else if (Front == "정보")
                    {
                        pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이" + Behind + "님의 정보를 검색합니다.";
                        pMessage.Chat.SendMessage("/whois " + Behind);
                    }
                    else if (Front == "등급설정")
                    {
                        string LBehind = Behind.Split(':')[0].Trim();
                        string DBehind = Behind.Split(':')[1].Trim();
                        string myrole = pMessage.Chat.MyRole.ToString();
                        if (myrole == "chatMemberRoleCreator" || myrole == "chatMemberRoleMaster")
                        {
                            if (DBehind == "MASTER" || DBehind == "HELPER" || DBehind == "USER" || DBehind == "LISTENER")
                            {
                                pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이" + LBehind + "님의 등급을" + DBehind + "로 변경하셨습니다.";
                                pMessage.Chat.SendMessage("/setrole " + LBehind + " " + DBehind);
                            }
                            else
                            {
                                pMessage.Body = "MASTER, HELPER, USER, LISTENER 중 하나를 선택하여야합니다.";
                            }
                        }
                        else
                        {
                            pMessage.Body = "사용자님은 이방에서 멤버의 등급을 설정할 수 없습니다.";
                        }
                    }
                    else if (Front == "비밀번호")
                    {
                        string LBehind = Behind.Split(':')[0].Trim();
                        string DBehind = Behind.Split(':')[1].Trim();
                        string BBehind = Behind.Split(':')[2].Trim();
                        string myrole = pMessage.Chat.MyRole.ToString();
                        if (myrole == "chatMemberRoleCreator" || myrole == "chatMemberRoleMaster")
                        {
                            if (BBehind == "True")
                            {
                                pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 이방의 비밀번호를" + BBehind + "로 설정(변경)하셨습니다.";
                                pMessage.Chat.SetPassword(LBehind, DBehind);
                            }
                            else if (BBehind == "False")
                            {
                                pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 이방의 비밀번호를 설정(변경)하셨습니다.";
                                pMessage.Chat.SetPassword(LBehind, DBehind);
                            }
                            else
                            {
                                pMessage.Body = "True 와 False 중 하나를 적어주세요.";
                            }
                        }
                        else
                        {
                            pMessage.Body = "사용자님은 이방에서 비밀번호를 설정할 수 없습니다.";
                        }
                    }
                    else if (Front == "주제")
                    {
                        pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 이방의 주제를 ◇" + pMessage.Chat.Topic.ToString() + "◇ 에서 ◆" + Behind + "◆ 로 변경하셨습니다.";
                        pMessage.Chat.Topic = Behind;
                    }
                    else if (Front == "뮤트")
                    {
                        string myrole = pMessage.Chat.MyRole.ToString();
                        if (myrole == "chatMemberRoleCreator" || myrole == "chatMemberRoleMaster")
                        {
                            pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 " + Behind + "님을 뮤트시켰습니다.";
                            pMessage.Chat.SendMessage("/setrole " + Behind + " LISTENER");
                        }
                        else
                        {
                            pMessage.Body = "사용자님은 이방에서 멤버를 뮤트할 수 없습니다.";
                        }
                    }
                    else if (Front == "언뮤트")
                    {
                        string myrole = pMessage.Chat.MyRole.ToString();
                        if (myrole == "chatMemberRoleCreator" || myrole == "chatMemberRoleMaster")
                        {
                            pMessage.Body = AxxSkype1.CurrentUserProfile.FullName + "님이 " + Behind + "님을 언뮤트시켰습니다.";
                            pMessage.Chat.SendMessage("/setrole " + Behind + " USER");
                        }
                        else
                        {
                            pMessage.Body = "사용자님은 이방에서 멤버를 언뮤트할 수 없습니다.";
                        }
                    }
                    else if (Front == "찾기")
                    {
                        pMessage.Body = "검색어 : " + Behind + "\r\n[해당하는유저]";
                        try
                        {
                            for (int o = 1; o <= pMessage.Chat.Members.Count; o++)
                            {
                                if (pMessage.Chat.Members[o].FullName.ToString().IndexOf(Behind) != -1)
                                {
                                    pMessage.Body = pMessage.Body + "\r\n" + pMessage.Chat.MemberObjects[o].Handle + " (" + pMessage.Chat.Members[o].FullName + ")";
                                }
                            }
                        }
                        catch
                        {
                            pMessage.Body = pMessage.Body + "[끝]";
                        }
                        pMessage.Body = pMessage.Body +"\r\n[찾기완료]";
                    }
                    //createmoderatedchat
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
            }
        }

        private void panel11_MouseDown(object sender, MouseEventArgs e)
        {
            panel11.BackColor = Color.HotPink;
            if (checkBox6.Checked == true)
            {
                try
                {
                    string[] linksp1 = textBox1.Text.Split('<');
                    string[] linksp2 = textBox1.Text.Split('>');
                    if (!checkBox7.Checked && !checkBox8.Checked)
                    {
                        textBox1.Text = linksp1[0].Trim() + "<a class=" + textBox6.Text + "con_link" + textBox6.Text + "href=" + textBox6.Text + textBox15.Text + textBox6.Text + ">" + linksp2[1].Split('<')[0].Trim() + "</a>" + linksp2[2].Trim();
                    }
                    else if (checkBox7.Checked && checkBox8.Checked)
                    {
                        textBox1.Text = linksp1[0].Trim() + "\r\n<a class=" + textBox6.Text + "con_link" + textBox6.Text + "href=" + textBox6.Text + textBox15.Text + textBox6.Text + ">" + linksp2[1].Split('<')[0].Trim() + "</a>\r\n" + linksp2[2].Trim();
                    }
                    else if (checkBox7.Checked && !checkBox8.Checked)
                    {
                        textBox1.Text = linksp1[0].Trim() + "\r\n<a class=" + textBox6.Text + "con_link" + textBox6.Text + "href=" + textBox6.Text + textBox15.Text + textBox6.Text + ">" + linksp2[1].Split('<')[0].Trim() + "</a>" + linksp2[2].Trim();
                    }
                    else if (!checkBox7.Checked && checkBox8.Checked)
                    {
                        textBox1.Text = linksp1[0].Trim() + "<a class=" + textBox6.Text + "con_link" + textBox6.Text + "href=" + textBox6.Text + textBox15.Text + textBox6.Text + ">" + linksp2[1].Split('<')[0].Trim() + "</a>\r\n" + linksp2[2].Trim();
                    }
                }
                catch
                {
                    
                }
            }
            if (checkBox1.Checked == true)
            {
                textBox1.Text = "<b>" + textBox1.Text + "</b>";
            }
            if (checkBox2.Checked == true)
            {
                textBox1.Text = "<u>" + textBox1.Text + "</u>";
            }

            if (checkBox3.Checked == true)
            {
                textBox1.Text = "<blink>" + textBox1.Text + "</blink>";
            }

            if (checkBox4.Checked == true)
            {
                textBox1.Text = "<center>" + textBox1.Text + "</center>";
            }
            textBox1.Text = "<font size=" + textBox6.Text + textBox2.Text + textBox6.Text + ">" + textBox1.Text + "</font>";
            textBox1.Text = "<font color=" + textBox6.Text + textBox3.Text + textBox6.Text + ">" + textBox1.Text + "</font>";
            AxxSkype1.CurrentUserProfile.RichMoodText = textBox1.Text;
            textBox1.Text = null;

            Skype oSkype01 = new Skype();
            RichProfiles_Load();
            textBox1.Text = oSkype01.CurrentUserProfile.MoodText;
            textBox4.Text = AxxSkype1.CurrentUserProfile.FullName;
            textBox5.Text = AxxSkype1.CurrentUserProfile.PhoneMobile;
        }

        private void panel11_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel11.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel11.BackColor = Color.DodgerBlue;
            }
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel11.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel11.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.HotPink;
            AxxSkype1.ChangeUserStatus(TUserStatus.cusOnline); // 온라인
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel6.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel6.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel6.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel6.BackColor = Color.DodgerBlue;
            }
        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
        {
            panel7.BackColor = Color.HotPink;
            AxxSkype1.ChangeUserStatus(TUserStatus.cusDoNotDisturb); // 다른용무중
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel7.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel7.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel7.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel7.BackColor = Color.DodgerBlue;
            }
        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            panel8.BackColor = Color.HotPink;
            AxxSkype1.ChangeUserStatus(TUserStatus.cusAway); // 자리비움
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel8.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel8.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel8_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel8.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel8.BackColor = Color.DodgerBlue;
            }
        }

        private void panel9_MouseDown(object sender, MouseEventArgs e)
        {
            panel9.BackColor = Color.HotPink;
            AxxSkype1.ChangeUserStatus(TUserStatus.cusInvisible); // 오프라인표시
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel9.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel9.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel9_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel9.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel9.BackColor = Color.DodgerBlue;
            }
        }

        private void panel12_MouseDown(object sender, MouseEventArgs e)
        {
            panel12.BackColor = Color.HotPink;
            if (Operators.CompareString(textBox4.Text, "", false) == 0)
            {
                MessageBox.Show("바꾸실 닉네임을 입력해주세요.", "닉네임 적용", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                AxxSkype1.CurrentUserProfile.FullName = textBox4.Text;
                timer2.Start();
            }
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel12.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel12.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel12_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel12.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel12.BackColor = Color.DodgerBlue;
            }
        }

        private void panel13_MouseDown(object sender, MouseEventArgs e)
        {
            panel13.BackColor = Color.HotPink;
            AxxSkype1.CurrentUserProfile.PhoneMobile = textBox5.Text;
            timer2.Start();
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel13.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel13.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel13_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel13.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel13.BackColor = Color.DodgerBlue;
            }
        }

        private void panel15_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#000000";
            panel10.BackColor = Color.Black;
        }

        private void panel16_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FFFFFF";
            panel10.BackColor = Color.White;
        }

        private void panel18_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#5D5D5D";
            panel10.BackColor = Color.Gray;
        }

        private void panel19_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FF0000";
            panel10.BackColor = Color.Red;
        }

        private void panel32_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FF4848";
            panel10.BackColor = Color.Crimson;
        }

        private void panel20_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FF5E00";
            panel10.BackColor = Color.OrangeRed;
        }

        private void panel21_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FFE400";
            panel10.BackColor = Color.Gold;
        }

        private void panel28_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#008100";
            panel10.BackColor = Color.DarkGreen;
        }

        private void panel26_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#53FF4C";
            panel10.BackColor = Color.Lime;
        }

        private void panel33_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#77FF70";
            panel10.BackColor = Color.SpringGreen;
        }

        private void panel30_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#0000A5";
            panel10.BackColor = Color.Navy;
        }

        private void panel31_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#0100FF";
            panel10.BackColor = Color.Blue;
        }

        private void panel24_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#24FCFF";
            panel10.BackColor = Color.Aqua;
        }

        private void panel22_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#5F00FF";
            panel10.BackColor = Color.Purple;
        }

        private void panel35_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "#FFC6FF";
            panel10.BackColor = Color.Pink;
        }

        private void panel10_MouseDown(object sender, MouseEventArgs e)
        {

            if (!groupBox6.Visible)
            {
                groupBox6.Visible = true;
            }
            else if (groupBox6.Visible)
            {
                groupBox6.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i = 0;
            int count = this.listView1.Items.Count;
            while (i <= count)
            {
                try
                {
                    if (listView1.Items[i].Checked)
                    {
                        AxxSkype1.SendMessage(listView1.Items[i].Text, textBox7.Text);
                    }
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    ProjectData.ClearProjectError();
                }
                checked { ++i; }
            }
        }

        private void panel36_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("메시지를 보낼 인원을 친구리스트에서 선택해주세요.", "보낼 친구", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Operators.CompareString(textBox7.Text, "", false) == 0)
            {
                MessageBox.Show("선택한 인원에게 보낼 메시지를 적어주세요.", "보낼 내용", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                panel36.BackColor = Color.HotPink;
                int i = 0;
                int peoplecounting = listView1.CheckedItems.Count;
                int count = this.listView1.Items.Count;
                while (i <= count)
                {
                    try
                    {
                        if (listView1.Items[i].Checked)
                        {
                            AxxSkype1.SendMessage(listView1.Items[i].Text, textBox7.Text + "\r\n\r\n[선택]전송인원:" + peoplecounting + "명♪");
                        }
                    }
                    catch (Exception ex)
                    {
                        ProjectData.SetProjectError(ex);
                        ProjectData.ClearProjectError();
                    }
                    checked { ++i; }
                }
                textBox7.Text = null;
            }
        }


        private void panel36_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel36.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel36.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel36_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel36.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel36.BackColor = Color.DodgerBlue;
            }
        }

        private void panel38_MouseDown(object sender, MouseEventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("메시지를 도배할 인원을 친구리스트에서 선택해주세요.", "보낼 친구", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Operators.CompareString(textBox7.Text, "", false) == 0)
            {
                MessageBox.Show("선택한 인원에게 도배할 메시지를 적어주세요.", "보낼 내용", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    
                    //i = 0;
                    th1_Start = true;
                    th1 = new Thread(new ThreadStart(AA));
                    th1.Start();

                    th2_Start = true;
                    th2 = new Thread(new ThreadStart(BB));
                    th2.Start();

                    th3_Start = true;
                    th3 = new Thread(new ThreadStart(CC));
                    th3.Start();
                     
                }
                catch { }

                panel38.Enabled = false;
                panel39.Visible = true;
                //timer1.Start();
            }
        }

        private void AA()
        {
            //try
            //{
                while (th1_Start)
                {
                    lock (this)
                    {
                        th_low++;
                        strTemp = Convert.ToString(th_low);
                        //AxxSkype1.SendMessage("k.l.shy", textBox7.Text + strTemp);

                        int count = this.listView1.Items.Count;
                        while (th_listcounting < count)
                        {
                            if (listView1.Items[th_listcounting].Checked)
                            {
                                AxxSkype1.SendMessage(listView1.Items[th_listcounting].Text, textBox7.Text + "  [" + strTemp + "]");
                            }
                            checked { ++th_listcounting; }
                        }
                        if (th_listcounting == count)
                        {
                            th_listcounting = 0;
                        }
                    }

                    if (th_low >= th_count)
                    {
                        Reset_Ctrl();
                    }
                }
            //}
            //catch { Console.WriteLine("Thread Section One_Error, Stop void AA"); }
        }

        private void BB()
        {
            try
            {
                while (th2_Start)
                {
                    lock (this)
                    {
                        th_low++;
                        strTemp = Convert.ToString(th_low);
                        //AxxSkype1.SendMessage("k.l.shy", textBox7.Text + strTemp);

                        int count = this.listView1.Items.Count;
                        while (th_listcounting < count)
                        {
                            if (listView1.Items[th_listcounting].Checked)
                            {
                                AxxSkype1.SendMessage(listView1.Items[th_listcounting].Text, textBox7.Text + "  [" + strTemp + "]");
                            }
                            checked { ++th_listcounting; }
                        }
                        if (th_listcounting == count)
                        {
                            th_listcounting = 0;
                        }
                    }

                    if (th_low >= th_count)
                    {
                        Reset_Ctrl();
                    }
                }
            }
            catch { Console.WriteLine("Thread Section Two Error, Stop void BB"); }
        }

        private void CC()
        {
            try
            {
                while (th3_Start)
                {
                    lock (this)
                    {
                        th_low++;
                        strTemp = Convert.ToString(th_low);
                        //AxxSkype1.SendMessage("k.l.shy", textBox7.Text + strTemp);

                        int count = this.listView1.Items.Count;
                        while (th_listcounting < count)
                        {
                            if (listView1.Items[th_listcounting].Checked)
                            {
                                AxxSkype1.SendMessage(listView1.Items[th_listcounting].Text, textBox7.Text + "  [" + strTemp + "]");
                            }
                            checked { ++th_listcounting; }
                        }
                        if (th_listcounting == count)
                        {
                            th_listcounting = 0;
                        }
                    }

                    if (th_low >= th_count)
                    {
                        Reset_Ctrl();
                    }
                }
            }
            catch { Console.WriteLine("Thread Section Three Error, Stop void CC"); }
        }

        private void Reset_Ctrl()
        {
            th1_Start = false;
            th2_Start = false;
            th3_Start = false;
        }

        private void panel38_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel38.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel38.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel38_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel38.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel38.BackColor = Color.DodgerBlue;
            }
        }

        private void panel39_MouseDown(object sender, MouseEventArgs e)
        {
            //timer1.Stop();
            panel38.Enabled = true;
            panel39.Visible = false;
            textBox7.Text = null;
            th1_Start = false;
            th2_Start = false;
            th3_Start = false;
            if (!(th1 == null))
            {
                th1.Abort();
            }
            if (!(th2 == null))
            {
                th2.Abort();
            }
            if (!(th3 == null))
            {
                th3.Abort();
            }
            th_low = 0;
        }

        private void panel39_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel39.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel39.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel39_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel39.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel39.BackColor = Color.DodgerBlue;
            }
        }

        private void panel37_MouseDown(object sender, MouseEventArgs e)
        {
            panel37.BackColor = Color.HotPink;
            if (Operators.CompareString(this.textBox8.Text, "", false) == 0)
            {
                MessageBox.Show("전체인원에게 보낼 내용을 적어주세요.", "보낼 내용", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("제외리스트에게도 메시지를 전송하시겠습니까?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    //this.textBox8.Text = this.textBox8.Text + "\r\n\r\n전송인원:" + Conversions.ToString(listView1.Items.Count) + "명♪";
                    try
                    {
                        int denypeople = 0;
                        foreach (User user in (IUserCollection)this.AxxSkype1.Friends)
                        {
                            try
                            {
                                if (user.DisplayName.ToString().Split('[')[1].Split(']')[0].Trim() == "제외")
                                {
                                    denypeople++;
                                }
                                else
                                {
                                    //denypeople의 값을 올리지않음
                                }
                            }
                            catch (Exception ex)
                            {
                                //denypeople의 값을 올리지않음
                                ProjectData.SetProjectError(ex);
                                ProjectData.ClearProjectError();
                            }
                        }
                        this.textBox8.Text = this.textBox8.Text + "\r\n\r\n[전체]전송인원:" + Conversions.ToString(listView1.Items.Count - denypeople) + "명♪(제외" + denypeople + ")";
                        foreach (User user in (IUserCollection)this.AxxSkype1.Friends)
                        {
                            try
                            {
                                if (user.DisplayName.ToString().Split('[')[1].Split(']')[0].Trim() == "제외")
                                {
                                    //메시지를 보내지않음
                                }
                                else
                                {
                                    AxxSkype1.SendMessage(user.Handle, this.textBox8.Text);
                                }
                            }
                            catch (Exception ex)
                            {
                                AxxSkype1.SendMessage(user.Handle, this.textBox8.Text);
                                ProjectData.SetProjectError(ex);
                                ProjectData.ClearProjectError();
                            }
                        }
                    }
                    finally
                    {
                        this.textBox8.Text = null;
                    }
                }
                else
                {
                    this.textBox8.Text = this.textBox8.Text + "\r\n\r\n[전체]전송인원:" + Conversions.ToString(listView1.Items.Count) + "명♪";
                    foreach (User user in (IUserCollection)this.AxxSkype1.Friends)
                    {
                        try
                        {
                            AxxSkype1.SendMessage(user.Handle, this.textBox8.Text);
                        }
                        catch (Exception ex)
                        {
                            AxxSkype1.SendMessage(user.Handle, this.textBox8.Text);
                            ProjectData.SetProjectError(ex);
                            ProjectData.ClearProjectError();
                        }
                    }
                }
            }
        }

        private void panel37_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel37.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel37.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel37_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel37.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel37.BackColor = Color.DodgerBlue;
            }
        }

        private void panel41_MouseDown(object sender, MouseEventArgs e)
        {
            if (label25.Text == "[채팅]부재중 메시지전송 [Off]")
            {
                label25.Text = "[채팅]부재중 메시지전송 [On]";
                AxxSkype1.CurrentUserStatus = TUserStatus.cusDoNotDisturb;
            }
            else
            {
                label25.Text = "[채팅]부재중 메시지전송 [Off]";
            }
        }

        private void panel41_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel41.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel41.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel41_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel41.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel41.BackColor = Color.DodgerBlue;
            }
        }

        private void panel42_MouseDown(object sender, MouseEventArgs e)
        {
            if (label26.Text == "[전화]부재중 메시지전송 [Off]")
            {
                label26.Text = "[전화]부재중 메시지전송 [On]";
                AxxSkype1.CurrentUserStatus = TUserStatus.cusDoNotDisturb;
            }
            else
            {
                label26.Text = "[전화]부재중 메시지전송 [Off]";
            }
        }

        private void panel42_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel42.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel42.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel42_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel42.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel42.BackColor = Color.DodgerBlue;
            }
        }

        private void panel43_MouseDown(object sender, MouseEventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            RichProfiles_Load();
            textBox1.Text = AxxSkype1.CurrentUserProfile.MoodText;
            textBox4.Text = AxxSkype1.CurrentUserProfile.FullName;
            textBox5.Text = AxxSkype1.CurrentUserProfile.PhoneMobile;
            timer2.Stop();
        }

        private void RichProfiles_Load()
        {
            try
            {
                string richmood = AxxSkype1.CurrentUserProfile.RichMoodText;
                if (richmood.IndexOf("<b>") != -1)
                {
                    checkBox1.Checked = true;
                }
                if (richmood.IndexOf("<u>") != -1)
                {
                    checkBox2.Checked = true;
                }
                if (richmood.IndexOf("<blink>") != -1)
                {
                    checkBox3.Checked = true;
                }
                if (richmood.IndexOf("<center>") != -1)
                {
                    checkBox4.Checked = true;
                }
                textBox2.Text = System.Text.RegularExpressions.Regex.Split(richmood, "<font size=" + textBox6.Text)[1].Split(char.Parse(textBox6.Text))[0].Trim();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
        }

        private void Friendlist_Reload()
        {
            listView1.Items.Clear();
            try
            {
                foreach (User user in (IUserCollection)AxxSkype1.Friends)
                {
                    if (user.OnlineStatus == TOnlineStatus.olsOnline)
                    {
                        ListViewItem items1;
                        listView1.Items.Add(items1 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[0];
                        items1.ForeColor = Color.DarkGreen;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsDoNotDisturb)
                    {
                        ListViewItem items2;
                        listView1.Items.Add(items2 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[1];
                        items2.ForeColor = Color.Red;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsAway)
                    {
                        ListViewItem items3;
                        listView1.Items.Add(items3 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[2];
                        items3.ForeColor = Color.Orange;
                    }
                    else if (user.OnlineStatus == TOnlineStatus.olsOffline)
                    {
                        ListViewItem items4;
                        listView1.Items.Add(items4 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                            }
                        }).Group = listView1.Groups[3];
                        items4.ForeColor = Color.DeepSkyBlue;
                    }
                    else
                    {
                        ListViewItem items5;
                        listView1.Items.Add(items5 = new ListViewItem(user.Handle)
                        {
                            SubItems = {
                                user.FullName,
                                user.MoodText
                        }
                        }).Group = listView1.Groups[4];
                        items5.ForeColor = Color.Black;
                    }
                }
            }
            finally
            {
                listView1.Groups[0].Header = "온라인 [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                listView1.Groups[1].Header = "다른용무중 [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                listView1.Groups[2].Header = "자리비움 [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                listView1.Groups[3].Header = "오프라인 [" + listView1.Groups[3].Items.Count.ToString() + "]명";
                label5.Text = "온라인 : [" + listView1.Groups[0].Items.Count.ToString() + "]명";
                label6.Text = "다른용무중 : [" + listView1.Groups[1].Items.Count.ToString() + "]명";
                label7.Text = "자리비움 : [" + listView1.Groups[2].Items.Count.ToString() + "]명";
                label8.Text = "오프라인 : [" + listView1.Groups[3].Items.Count.ToString() + "]명";
            }
            label2.Text = "사용자분의 추가된 친구인원 [" + Conversions.ToString(listView1.Items.Count) + "]명";
            label23.Text = "전체[" + listView1.Items.Count + "]명 전송";
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                string selectMenuPosition = listView1.GetItemAt(e.X, e.Y).Text;

                ContextMenu Menu1 = new ContextMenu();
                MenuItem MItem1 = new MenuItem();
                MenuItem MItem2 = new MenuItem();
                MenuItem MItem3 = new MenuItem();
                MenuItem MItem4 = new MenuItem();
                MenuItem MItem5 = new MenuItem();
                MenuItem MItem6 = new MenuItem();
                MenuItem MItem7 = new MenuItem();
                MenuItem MItem8 = new MenuItem();

                MItem1.Text = "전체체크";
                MItem2.Text = "전체체크해제";
                MItem3.Text = "친구삭제";
                MItem4.Text = "친구차단";
                MItem5.Text = "친구 차단+삭제";
                MItem6.Text = "전화걸기";
                MItem8.Text = "채팅제외리스트추가";
                MItem7.Text = "새로고침";


                MItem1.Click += (senders, es) =>
                    {
                        for (int i = 0; i <= listView1.Items.Count; i++ )
                        {
                            try
                            {
                                listView1.Items[i].Checked = true;
                            }
                            catch (Exception ex)
                            {
                                ProjectData.SetProjectError(ex);
                                ProjectData.ClearProjectError();
                            }
                        }
                    };
                MItem2.Click += (senders, es) =>
                    {
                        for (int i = 0; i <= listView1.Items.Count; i++)
                        {
                            try
                            {
                                listView1.Items[i].Checked = false;
                            }
                            catch (Exception ex)
                            {
                                ProjectData.SetProjectError(ex);
                                ProjectData.ClearProjectError();
                            }
                        }
                    };
                MItem3.Click += (senders, es) =>
                    {
                        AxxSkype1.User[listView1.FocusedItem.Text].IsAuthorized = false;
                        Friendlist_Reload();
                    };
                MItem4.Click += (senders, es) =>
                    {
                        AxxSkype1.User[listView1.FocusedItem.Text].IsBlocked = true;
                        Friendlist_Reload();
                    };
                MItem5.Click += (senders, es) =>
                    {
                        AxxSkype1.User[listView1.FocusedItem.Text].IsAuthorized = false;
                        AxxSkype1.User[listView1.FocusedItem.Text].IsBlocked = true;
                        Friendlist_Reload();
                    };
                MItem6.Click += (senders, es) =>
                    {
                        if (TUserStatus.cusOffline == AxxSkype1.CurrentUserStatus)
                        {
                            MessageBox.Show("오프라인상태에서는 전화를 걸 수 없습니다.", "전화걸기실패");
                        }

                        try
                        {
                            AxxSkype1.PlaceCall(listView1.FocusedItem.Text);
                        }
                        catch (Exception ex)
                        {
                            ProjectData.SetProjectError(ex);
                            ProjectData.ClearProjectError();
                        }
                    };
                MItem7.Click += (senders, es) =>
                    {
                        Friendlist_Reload();
                    };
                MItem8.Click += (senders, es) =>
                    {
                        AxxSkype1.User[listView1.FocusedItem.Text.ToString()].DisplayName = "[제외]" + AxxSkype1.User[listView1.FocusedItem.Text.ToString()].FullName;
                    };

                Menu1.MenuItems.Add(MItem1);
                Menu1.MenuItems.Add(MItem2);
                Menu1.MenuItems.Add(MItem3);
                Menu1.MenuItems.Add(MItem4);
                Menu1.MenuItems.Add(MItem5);
                Menu1.MenuItems.Add(MItem6);
                Menu1.MenuItems.Add(MItem8);
                Menu1.MenuItems.Add(MItem7);


                Menu1.Show(listView1, new Point(e.X, e.Y));
            }
        }

        private void panel43_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel43.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel43.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel43_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel43.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel43.BackColor = Color.DodgerBlue;
            }
        }

        private void panel44_MouseDown(object sender, MouseEventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void panel44_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel44.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel44.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel44_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel44.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel44.BackColor = Color.DodgerBlue;
            }
        }

        private void Tray_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !bApplicationExit;
            this.Visible = false;
            Tray.BalloonTipTitle = System.Windows.Forms.Application.ProductName;
            Tray.BalloonTipText = "프로그램이 트레이모드로 실행중입니다.";
            Tray.ShowBalloonTip(30000);
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void 종료XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bApplicationExit = true;
            System.Windows.Forms.Application.Exit();
        }

        private void panel45_MouseDown(object sender, MouseEventArgs e)
        {
            ListViewItem item1 = listView1.FindItemWithText(textBox13.Text, true, 0);
            if (item1 != null)
            {
                if (!item1.Checked)
                {
                    item1.Checked = true;
                    listView1.EnsureVisible(item1.Index);
                }
                else
                {
                    item1.Checked = false;
                    listView1.EnsureVisible(item1.Index);
                }
            }
            else
            {
                MessageBox.Show(textBox13.Text + "라는 사용자는 친구리스트에서 찾을 수 없습니다.", "찾기 실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox13_MouseDown(object sender, MouseEventArgs e)
        {
            textBox13.Text = null;
        }

        private void panel45_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel45.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel45.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel45_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel45.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel45.BackColor = Color.DodgerBlue;
            }
        }

        private void panel46_MouseDown(object sender, MouseEventArgs e)
        {
            if (label33.Text == "유틸리티알림기능 [Off]")
            {
                label33.Text = "유틸리티알림기능 [On]";
            }
            else
            {
                label33.Text = "유틸리티알림기능 [Off]";
            }
        }

        private void panel46_MouseLeave(object sender, EventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel46.BackColor = Color.LightPink;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel46.BackColor = Color.DeepSkyBlue;
            }
        }

        private void panel46_MouseMove(object sender, MouseEventArgs e)
        {
            if (defaultPinkToolStripMenuItem.Checked)
            {
                panel46.BackColor = Color.PaleVioletRed;
            }
            else if (blueToolStripMenuItem.Checked)
            {
                panel46.BackColor = Color.DodgerBlue;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            string PATH = System.Windows.Forms.Application.StartupPath;
            IniReadWrite ini = new IniReadWrite();
            ini.IniWriteValue("Missed Status' Messages", "Chat", textBox9.Text, PATH + @"\[SHY]Skype_Util.ini");
            if (checkBox5.Checked)
            {
                ini.IniWriteValue("Missed Status' Messages", "ChatCheck", "True", PATH + @"\[SHY]Skype_Util.ini");
            }
            else
            {
                ini.IniWriteValue("Missed Status' Messages", "ChatCheck", "False", PATH + @"\[SHY]Skype_Util.ini");
            }
            ini.IniWriteValue("Missed Status' Messages", "Call", textBox10.Text, PATH + @"\[SHY]Skype_Util.ini");
            ini.IniWriteValue("Prefix/Suffix", "Prefix", textBox11.Text, PATH + @"\[SHY]Skype_Util.ini");
            ini.IniWriteValue("Prefix/Suffix", "Suffix", textBox12.Text, PATH + @"\[SHY]Skype_Util.ini");

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double abc = trackBar1.Value / 100.00;
            this.Opacity = abc;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blueToolStripMenuItem.Checked = true;
            defaultPinkToolStripMenuItem.Checked = false;
            panel61.BackColor = Color.DeepSkyBlue;
            panel62.BackColor = Color.DeepSkyBlue;
            panel1.BackColor = Color.DodgerBlue;
            label30.BackColor = Color.DeepSkyBlue;
            label31.BackColor = Color.DeepSkyBlue;
            panel45.BackColor = Color.DeepSkyBlue;
            panel44.BackColor = Color.DeepSkyBlue;
            panel11.BackColor = Color.DeepSkyBlue;
            panel12.BackColor = Color.DeepSkyBlue;
            panel13.BackColor = Color.DeepSkyBlue;
            panel6.BackColor = Color.DeepSkyBlue;
            panel7.BackColor = Color.DeepSkyBlue;
            panel8.BackColor = Color.DeepSkyBlue;
            panel9.BackColor = Color.DeepSkyBlue;
            panel36.BackColor = Color.DeepSkyBlue;
            panel37.BackColor = Color.DeepSkyBlue;
            panel38.BackColor = Color.DeepSkyBlue;
            panel39.BackColor = Color.DeepSkyBlue;
            panel41.BackColor = Color.DeepSkyBlue;
            panel42.BackColor = Color.DeepSkyBlue;
            panel43.BackColor = Color.DeepSkyBlue;
            panel44.BackColor = Color.DeepSkyBlue;
            panel46.BackColor = Color.DeepSkyBlue;
            label1.ForeColor = Color.DodgerBlue;
        }

        private void defaultPinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defaultPinkToolStripMenuItem.Checked = true;
            blueToolStripMenuItem.Checked = false;
            panel61.BackColor = Color.LightPink;
            panel62.BackColor = Color.LightPink;
            panel1.BackColor = Color.PaleVioletRed;
            label30.BackColor = Color.LightPink;
            label31.BackColor = Color.LightPink;
            panel45.BackColor = Color.LightPink;
            panel44.BackColor = Color.LightPink;
            panel11.BackColor = Color.LightPink;
            panel12.BackColor = Color.LightPink;
            panel13.BackColor = Color.LightPink;
            panel6.BackColor = Color.LightPink;
            panel7.BackColor = Color.LightPink;
            panel8.BackColor = Color.LightPink;
            panel9.BackColor = Color.LightPink;
            panel36.BackColor = Color.LightPink;
            panel37.BackColor = Color.LightPink;
            panel38.BackColor = Color.LightPink;
            panel39.BackColor = Color.LightPink;
            panel41.BackColor = Color.LightPink;
            panel42.BackColor = Color.LightPink;
            panel43.BackColor = Color.LightPink;
            panel44.BackColor = Color.LightPink;
            panel46.BackColor = Color.LightPink;
            label1.ForeColor = Color.PaleVioletRed;
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            label21.Text = "선택[" + listView1.CheckedItems.Count + "]명 전송";
            label22.Text = "선택[" + listView1.CheckedItems.Count + "]명 도배";
        }

        private void label37_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 프로그램을 완벽하게 종료합니다.");
            System.Windows.Forms.Application.ExitThread();
        }

        private void primeButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Tray.BalloonTipTitle = System.Windows.Forms.Application.ProductName;
            Tray.BalloonTipText = "프로그램이 트레이모드로 실행중입니다.";
            Tray.ShowBalloonTip(30000);
        }
    }
}
