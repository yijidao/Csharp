using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static Socket G_ServerSocket;
        static byte[] G_DataBuffer = new byte[1024];
        static int G_Port = 8080;
        static void Main(string[] args)
        {
            IPAddress l_IP = IPAddress.Loopback;
            G_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            G_ServerSocket.Bind(new IPEndPoint(l_IP, G_Port));
            G_ServerSocket.Listen(15);

            Console.WriteLine("监听{0}成功", G_ServerSocket.LocalEndPoint.ToString());
            Thread l_Thread = new Thread(ListenClientConnect);
            l_Thread.Start();
        }

        private static void ListenClientConnect()
        {
            while(true)
            {
                Socket l_ClientSocket = G_ServerSocket.Accept();
                l_ClientSocket.Send(Encoding.UTF8.GetBytes("--Client 你好"));
                Thread l_ReciveThread = new Thread(ReciveMessage);
                l_ReciveThread.Start(l_ClientSocket);
            }
        }

        private static void ReciveMessage(object p_ClientSocket)
        {
            if(p_ClientSocket != null)
            {
                Socket l_ClientSocket = p_ClientSocket as Socket;
                while(true)
                {
                    try
                    {
                        int l_ReciveNumber = l_ClientSocket.Receive(G_DataBuffer);
                        Console.WriteLine("接收客户端：{0}，消息：{1}", l_ClientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(G_DataBuffer, 0, l_ReciveNumber));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        l_ClientSocket.Shutdown(SocketShutdown.Both);
                        l_ClientSocket.Close();
                        break;
                    }
                }
            }
        }
    }
}
