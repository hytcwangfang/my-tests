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

namespace hytc.QQ
{
    public partial class ChatFrm : Form
    {
        private Friend curfriend;

        //private Friend me;

        private Listen mylisten;

        public ChatFrm()
        {
            InitializeComponent();
        }
        //public ChatFrm(Friend f,Listen listen,Friend m)
        //{
        //    InitializeComponent();
        //    curfriend = f;
        //    mylisten = listen;
        //    me = m;
        //}
        public ChatFrm(Friend f, Listen listen)
        {
            InitializeComponent();
            curfriend = f;
            mylisten = listen;
        }
      

        private void ChatFrm_Load(object sender, EventArgs e)
        {
            this.Text = curfriend.NickName;
            
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            UdpClient udpclient = new UdpClient();
            IPAddress curip = this.curfriend.ip;
            IPEndPoint iep =new IPEndPoint(curip,9527);
            //string content = "Talk|" + me.NickName + "|" + me.ShuoShuo + "|" + me.HeadImg + "|" + this.txt_history.Text + "|" + mylisten.getip();
            string content = "Talk|" + this.txt_history.Text + "|" + mylisten.getip();
            byte[] bytes = Encoding.Default.GetBytes(content);
            udpclient.Send(bytes, bytes.Length, iep);
            this.txt_history.Text += this.txt_send.Text;
            this.txt_send.Text = "";
        }
    }
}
