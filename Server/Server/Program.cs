using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {


            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(ipAddr, 11000);



            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {

                sListener.Bind(iPEndPoint);
                sListener.Listen(10);


                while (true)
                {
                    Console.WriteLine($"Ожидаем соединение через порт {iPEndPoint}");

                    Socket handler = sListener.Accept();
                    string data = null;

                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    Console.WriteLine("Полученый текст: " + data + "\n\n");


                    string reply = "Спасибо за вопрос в " + data.Length.ToString() + " символов";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    if (data.IndexOf("Цитата") > -1)
                    {
                        Console.WriteLine($"{Print()}") ;
                    }

                    if (data.IndexOf("<TheEnd>") > -1)
                    {
                        Console.WriteLine("Server stoped");
                        break;
                    }
                    if (data.IndexOf("Info") > -1)
                    {
                        Console.WriteLine("Что разум человека может постигнуть и во что он может поверить, того он способен достичь");
                        Console.WriteLine("Стремитесь не к успеху, а к ценностям, которые он дает");
                        Console.WriteLine("Своим успехом я обязана тому, что никогда не оправдывалась и не принимала оправданий от других");
                        Console.WriteLine("Сложнее всего начать действовать, все остальное зависит только от упорства.");
                        Console.WriteLine("Надо любить жизнь больше, чем смысл жизни");
                        Console.WriteLine("Логика может привести Вас от пункта А к пункту Б, а воображение — куда угодно");
                        Console.WriteLine("Начинать всегда стоит с того, что сеет сомнения.");
                        Console.WriteLine("Настоящая ответственность бывает только личной");
                        Console.WriteLine("Неосмысленная жизнь не стоит того, чтобы жить");
                        Console.WriteLine("80% успеха - это появиться в нужном месте в нужное время");
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.Read();
            }
           ////////////////////////////////////////////
            string Print()
            {
                string str="";
                Random ran=new Random();
                int n =ran.Next(10);
                if(n==1)
                {
                    str = "Что разум человека может постигнуть и во что он может поверить, того он способен достичь";
                    
                }
                else if(n==2) 
                {
                    str = "Стремитесь не к успеху, а к ценностям, которые он дает";
                }
                else if (n == 3)
                {
                    str = "Своим успехом я обязана тому, что никогда не оправдывалась и не принимала оправданий от других";
                }
                else if (n == 4)
                {
                    str = "Сложнее всего начать действовать, все остальное зависит только от упорства.";
                }
                else if (n == 5)
                {
                    str = "Надо любить жизнь больше, чем смысл жизни";
                }
                else if (n == 6)
                {
                    str = "Логика может привести Вас от пункта А к пункту Б, а воображение — куда угодно";
                }
                else if (n == 7)
                {
                    str = "Начинать всегда стоит с того, что сеет сомнения.";
                }
                else if (n == 8)
                {
                    str = "Настоящая ответственность бывает только личной";
                }
                else if (n == 9)
                {
                    str = "Неосмысленная жизнь не стоит того, чтобы жить";
                }
                else if (n == 10)
                {
                    str = "80% успеха - это появиться в нужном месте в нужное время";
                }
                return str;
            }
        }
    }
}
