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
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        TcpClient Client;
        StreamReader Reader;
        StreamWriter Writer;
        NetworkStream stream;
        Thread ReceiveThread;
        bool Connected;

        private delegate void AddTextDelegate(string strText);

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Connected = false;
            if (Reader != null)
            {
                Reader.Close();
            }

            if (Writer != null)
            {
                Writer.Close();
            }

            if (Client != null)
            {
                Client.Close();
            }
            
            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
            }
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            txtMessage.AppendText("이쪽" + txtSend.Text + "\r\n");
            Writer.WriteLine(txtSend.Text);
            Writer.Flush();

            txtSend.Clear();
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == "")
            {
                MessageBox.Show("서버IP 주소를 입력해 주세요.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                String IP = txtIP.Text;
                int port = 8080;

                Client = new TcpClient();
                Client.Connect(IP, port);

                stream = Client.GetStream();
                Connected = true;
                txtMessage.AppendText("서버와 연결되었습니다" + "\r\n");

                Reader = new StreamReader(stream);
                Writer = new StreamWriter(stream);

                ReceiveThread = new Thread(new ThreadStart(Receive));
                ReceiveThread.Start();
            }
            catch(Exception ConnE)
            {
                txtMessage.AppendText("서버에 연결할 수없습니다." + "\r\n");
            }
        }

        private void Receive()
        {
            AddTextDelegate AddText = new AddTextDelegate(txtMessage.AppendText);

            try
            {
                while(Connected)
                {
                    Thread.Sleep(1);

                    if (stream.CanRead)
                    {
                        string tempStr = Reader.ReadLine();

                        if (tempStr.Length > 0)
                        {
                            Invoke(AddText, "저쪽:" + tempStr + "\r\n");
                            Panel_1.Text = "메시지도착시간:" + DateTime.Now;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
