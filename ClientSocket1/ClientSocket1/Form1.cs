using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSocket1
{
    public partial class Form1 : Form
    {
        IPAddress G_IP;
        int G_Port;
        Socket G_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] G_DataMessage = new byte[1024];
        public Form1()
        {
            InitializeComponent();
            btn_Connect.Click += Connect;
            btn_Send.Click += Send;
        }

        private void Connect(object sender, EventArgs args)
        {
            if(String.IsNullOrWhiteSpace(tbx_IP.Text) || String.IsNullOrWhiteSpace(tbx_Port.Text))
            {
                rtb_Send.AppendText("\n\r--无效连接");
                return;
            }
            G_Port = int.Parse(tbx_Port.Text);
            G_IP = IPAddress.Parse(tbx_IP.Text);
            try
            {
                G_Client.Connect(new IPEndPoint(G_IP, G_Port));
                rtb_Send.AppendText("\n\r--连接服务器成功");
            }
            catch(Exception e)
            {
                rtb_Send.AppendText(e.Message);
                return;
            }

            Thread l_Thread = new Thread(Recive);
            l_Thread.Start();
        }

        private void Send(object sender, EventArgs args)
        {
            if(string.IsNullOrWhiteSpace(txb_Send.Text))
            {
                rtb_Send.AppendText("\n\r--无效消息");
                return;
            }
            try
            {
                G_Client.Send(Encoding.UTF8.GetBytes(txb_Send.Text));
                rtb_Send.AppendText("\n\r--向服务发送信息：" + txb_Send.Text);
            }
            catch(Exception e)
            {
                rtb_Send.AppendText("\n\r--发送失败");
                rtb_Send.AppendText("\n\r--" + e.Message);
            }
        }

        private void Recive()
        {
            while(true)
            {
                try
                {
                    int l_ReciveLength = G_Client.Receive(G_DataMessage);
                    if (rtb_Recive.InvokeRequired)
                    {
                        Action<string> actionDelegate = (x) => { this.rtb_Recive.AppendText(x.ToString()); };
                        this.rtb_Recive.Invoke(actionDelegate, "\n\r--接受服务器消息：" + Encoding.UTF8.GetString(G_DataMessage, 0, l_ReciveLength));
                    }
                    else
                    {
                        rtb_Recive.AppendText("\n\r--接受服务器消息：" + Encoding.UTF8.GetString(G_DataMessage, 0, l_ReciveLength));
                    }
                }
                catch(Exception e)
                {
                    if (rtb_Recive.InvokeRequired)
                    {
                        Action<string> actionDelegate = (x) => { this.rtb_Recive.AppendText(x.ToString()); };
                        this.rtb_Recive.Invoke(actionDelegate, e.Message);
                    }
                    else
                    {
                        rtb_Recive.AppendText(e.Message);
                    }
                }
            }
    }
}
}
