using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace SkypeAPI테스트
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Skype AxSkype1 = new Skype();

        private void Form1_Load(object sender, EventArgs e)
        {
            string text = "abcdefg";
            string searchtext = "fgd";
            MessageBox.Show(text.IndexOf(searchtext).ToString());
            AxSkype1.MessageStatus += new _ISkypeEvents_MessageStatusEventHandler(AxSkype1_MessageStatus);
            AxSkype1.User["yangdar"].IsAuthorized = true;
        }

        private void AxSkype1_MessageStatus(ChatMessage pMessage, TChatMessageStatus Status)
        {
            if (Status == TChatMessageStatus.cmsSent)
            {
                    string Behind = pMessage.Body.Split('#')[1].Trim();
                    string Front = pMessage.Body.Split('#')[0].Trim();
                    if (Front == "검색")
                    {
                        pMessage.Body = "[방인원리스트]";
                            for (int i = 1; i <= pMessage.Chat.Members.Count; i++)
                            {
                                pMessage.Body = pMessage.Body + "\r\n" + pMessage.Chat.MemberObjects[i].Handle + " (" + pMessage.Chat.Members[i].FullName + ")" + " [" + pMessage.Chat.MemberObjects[i].Role + "]";
                            }
                        }
                    
                }
            
        }
    }
}
