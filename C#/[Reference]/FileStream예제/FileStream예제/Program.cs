using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileStream예제
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream inStream = new FileStream("a.dat", FileMode.Open);
            int data = inStream.ReadByte();
            Console.WriteLine("Read Data : {0}", data);
            data = inStream.ReadByte();
            Console.WriteLine("Read Data : {0}", data);
            data = inStream.ReadByte();
            Console.WriteLine("Read Data : {0}", data);
            inStream.Seek(5, SeekOrigin.Current);
            Console.WriteLine("Read Data : {0}", inStream.ReadByte());
            Console.ReadLine();
        }
    }
}
