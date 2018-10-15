using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPEchoServer
{
	class App
	{
		private const int ServerPort = 5432;

		static void Main()
		{
			try
			{
				Socket listenSocket = new Socket
					(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				try
				{
					IPEndPoint listenEP =
						new IPEndPoint(IPAddress.Any, ServerPort);
					listenSocket.Bind(listenEP);
					listenSocket.Listen(5);

					Socket clientSocket = null;
					byte[] receiveBuffer = new byte[512];

					Console.WriteLine("TCP 에코 서버를 시작합니다");
					while( true )
					{
						clientSocket = listenSocket.Accept();						

						int receiveSize = clientSocket.Receive
							(receiveBuffer, 512, SocketFlags.None);

						while( receiveSize > 0 )
						{
							Console.Write("받은 메세지 : ");
							Console.WriteLine
								(Encoding.UTF8.GetString(receiveBuffer, 0, receiveSize));

							clientSocket.Send(receiveBuffer, receiveSize, SocketFlags.None);
							receiveSize = clientSocket.Receive
								(receiveBuffer, 512, SocketFlags.None);
						}

						clientSocket.Shutdown(SocketShutdown.Both);
						clientSocket.Close();
					}
				}
				finally
				{
					listenSocket.Close();
				}
			}
			catch( Exception e )
			{		
				Console.WriteLine(e.Message);
			}	
		}
	}
}
