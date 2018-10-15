using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Wrapped;

namespace Ping_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
                TcpClient client = new TcpClient("mod.esisca.kr", 38571);
                Wrapped.Wrapped wrapped = new Wrapped.Wrapped(client.GetStream());
                wrapped.writeByte(254);
                wrapped.writeByte(1);
                if (wrapped.readByte() == 255)
                {
                    string mystring = wrapped.readString();
                    string[] mysplit = mystring.Split(((char)(((byte)(0)))));

                    Console.WriteLine("서버오픈");
                }
            //}
            //catch
            //{
            //    Console.ReadLine();
            //}
        }
    }
}
