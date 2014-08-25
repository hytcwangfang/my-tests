using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace hytc.chat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //以字节发送，接受，阅读前转换为string
            UdpClient udp = new UdpClient();
            string ip = this.txt_ip.Text;
            //int length = this.txt_send.MaxLength;
            string content = "PUBLIC|" + this.txt_send.Text + "|王芳|";
            byte[] bytes = Encoding.Default.GetBytes(content);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            udp.Send(bytes, bytes.Length, iep);
        }
        private void ReceiveData()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint iepclient = new IPEndPoint(IPAddress.Any,0);
                //以字节发送，接受，阅读前转换为string
                byte[] receivestring = uc.Receive(ref iepclient);
                string bytes = Encoding.Default.GetString(receivestring);
                string[] split = bytes.Split('|');
                if (split[0] == "PUBLIC")
                {
                    this.txt_history.Text += split[2] + "说:" + split[1] + "\r\n";
                }
                else if(split[0] == "INROOM"){
                    this.txt_history.Text += split[2] + "上线" + "\r\n";
                }
                //else if(split[0] == "OUTROOM"){
                //    this.txt_history.Text += split[2] + "下线" + "\r\n";
                //}
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //允许跨线程调用
            Form1.CheckForIllegalCrossThreadCalls = false;
            Thread receithread = new Thread(new ThreadStart(ReceiveData));
            receithread.IsBackground = true;
            receithread.Start();

            //上线通知
            UdpClient udp = new UdpClient();
            string ip = this.txt_ip.Text;
            //int length = this.txt_send.MaxLength;
            string content = "INROOM|"  + "|王芳|";
            byte[] bytes = Encoding.Default.GetBytes(content);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            udp.Send(bytes, bytes.Length, iep);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

            //下线通知
            //UdpClient udp = new UdpClient();
            //string ip = this.txt_ip.Text;
            ////int length = this.txt_send.MaxLength;
            //string content = "OUTROOM|" + "|王芳|";
            //byte[] bytes = Encoding.Default.GetBytes(content);
            //IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), 9527);
            //udp.Send(bytes, bytes.Length, iep);
            
        }



       

       
    }
}
