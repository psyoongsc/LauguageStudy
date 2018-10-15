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
using SKYPE4COMLib;

namespace api참고자료
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
            Skype AxxSkype01 = new Skype();
        private void Form1_Load(object sender, EventArgs e)
        {
            AxxSkype01.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(AxxSkype01_MessageStatus);
            textBox1.Text = AxxSkype01.CurrentUserHandle.ToString();
            AxxSkype01.OnlineStatus += new _ISkypeEvents_OnlineStatusEventHandler(AxxSkype01_OnlineStatus);
            AxxSkype01.UserMood += new _ISkypeEvents_UserMoodEventHandler(AxxSkype01_UserMood);
        }

        private void AxxSkype01_UserMood(User pUser, string MoodText)
        {
            textBox2.Text = "Mood:" + pUser.Handle + " " + MoodText;
        }

        private void AxxSkype01_OnlineStatus(User pUser, TOnlineStatus Status)
        {
            textBox2.Text = textBox2.Text + "\r\nOnline:" + pUser.Handle + " " + Status;
        }

        private void AxxSkype01_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            Console.WriteLine("Class login OK");
            if (Status == TChatMessageStatus.cmsSending)
            {
                Console.WriteLine("checked sent message");
                if (pMessage.Body != "")
                {
                    Console.WriteLine("isn't empty");
                    MessageBox.Show(pMessage.Body + " << 라는 메시지를 전송하셨습니다.");
                }
            }
        }
    }
}
