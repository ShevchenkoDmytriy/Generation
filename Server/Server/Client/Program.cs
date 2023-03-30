using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SendMessageFromSocket(11000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        static void SendMessageFromSocket(int port)
        {

            byte[] buffer = new byte[1024];


            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddr, port);


            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            sender.Connect(iPEndPoint);


            Console.WriteLine("Enter massage:");
            string message = Console.ReadLine();


            byte[] msg = Encoding.UTF8.GetBytes(message);


            int byteSend = sender.Send(msg);

            int byteRecv = sender.Receive(buffer);


            Console.WriteLine($"Ответ от сервера: {Encoding.UTF8.GetString(buffer, 0, byteRecv)}");
            if (message.IndexOf("<TheEnd>") == -1)
            {
                SendMessageFromSocket(port);
            }
            if (message.IndexOf("Цитата") == -1)
            {
                SendMessageFromSocket(port);
            }
            if (message.IndexOf("Info") == -1)
            {
                SendMessageFromSocket(port);
            }
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
