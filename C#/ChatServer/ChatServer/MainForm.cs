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

namespace ChatServer
{
    public partial class MainForm : Form
    {
        TcpListener Server;
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread ListenThread = new Thread(new ThreadStart(Listen));
            ListenThread.Start();
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            txtMessage.AppendText("이쪽" + txtSend.Text + "\r\n");
            Writer.WriteLine(txtSend.Text);
            Writer.Flush();
            txtSend.Clear();
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

            if (Server != null)
            {
                Client.Close();
            }

            if (ReceiveThread != null)
            {
                ReceiveThread.Abort();
            }
        }

        private void Listen()
        {
            AddTextDelegate AddText = new AddTextDelegate(txtMessage.AppendText);

            try
            {
                IPAddress addr = new IPAddress(0);
                int port = 8080;

                Server = new TcpListener(addr, port);

                Server.Start();

                Invoke(AddText, "서버가 시작되었습니다..." + "\r\n");

                Client = Server.AcceptTcpClient();

                Connected = true;

                Invoke(AddText, "클라이언트와 연결되었습니다." + "\r\n");

                stream = Client.GetStream();

                Reader = new StreamReader(stream);
                Writer = new StreamWriter(stream);

                ReceiveThread = new Thread(new ThreadStart(Receive));
                ReceiveThread.Start();
            }
            catch (Exception e)
            {
            }
        }

        private void Receive()
        {
            AddTextDelegate AddText = new AddTextDelegate(txtMessage.AppendText);

            try
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
            catch(Exception e)
            {
            }
        }
    }
}
