using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPEchoClient
{
	class App
	{
		private const int ServerPort = 5432;

		static void Main()
		{
			try
			{
				Socket clientSocket = new Socket
					(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				IPEndPoint serverEP =
					new IPEndPoint(IPAddress.Loopback, ServerPort);

				clientSocket.Connect(serverEP);
				
				for( int i=0; i<10; i++ )
				{
					Console.Write("서버로 전달한 메세지를 입력하세요");
					Console.WriteLine(" ({0}/10)", i+1);
					byte[] sendBuffer;
					sendBuffer = Encoding.UTF8.GetBytes(Console.ReadLine());
					clientSocket.Send(sendBuffer);

					byte[] receiveBuffer = new byte[512];
					int receivedSize = clientSocket.Receive(receiveBuffer, 512, SocketFlags.None);
					Console.Write("에코 메세지 : ");
					Console.WriteLine(Encoding.UTF8.GetString(receiveBuffer, 0, receivedSize));
				}

				clientSocket.Shutdown(SocketShutdown.Both);
				clientSocket.Close();
			}
			catch( Exception e )
			{
				Console.WriteLine(e.Message);
			}

		}
	}
}
