using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        private static byte[] G_DataBuffer = new byte[1024];
        static void Main(string[] args)
        {
            IPAddress l_IPAddress = IPAddress.Loopback;
            Socket l_ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                l_ClientSocket.Connect(new IPEndPoint(l_IPAddress, 8080));
                Console.WriteLine("连接服务器成功");
            }
            catch(Exception e)
            {
                Console.WriteLine("连接服务器失败");
                Console.WriteLine(e.Message);
                return;
            }

            int l_ReciveLength = l_ClientSocket.Receive(G_DataBuffer);
            Console.WriteLine("接受服务器消息：{0}", Encoding.UTF8.GetString(G_DataBuffer));
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    Thread.Sleep(1000);
                    string l_SendMessage = string.Format("Server 你好，{0}", DateTime.Now.ToShortTimeString());
                    l_ClientSocket.Send(Encoding.UTF8.GetBytes(l_SendMessage));
                    Console.WriteLine("向服务器发送消息：{0}", l_SendMessage);
                }
                catch(Exception e)
                {
                    l_ClientSocket.Shutdown(SocketShutdown.Both);
                    l_ClientSocket.Close();
                    break;
                }
            }
            Console.WriteLine("--发送完毕");
            Console.ReadKey();
        }
    }
}
