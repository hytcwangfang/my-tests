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
        public Friend curfriend;

        public bool isopen = false;

        private string history = "";

        public string History
        {
            get { return history; }
            set
            {
                history = value;
                this.txt_history.Text = value;
            }
        }

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
        public ChatFrm(Friend f)
        {
            InitializeComponent();
            curfriend = f;
        }
      

        private void ChatFrm_Load(object sender, EventArgs e)
        {
            this.Text = curfriend.NickName;
            this.txt_history.Text = history;
            
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            //ChatFrm curfrm = (ChatFrm)sender;
            UdpClient udpclient = new UdpClient();
            IPAddress curip = this.curfriend.ip;
            IPEndPoint iep =new IPEndPoint(curip,9527);

            string content = "MSG|" + this.txt_send.Text;
            byte[] bytes = Encoding.Default.GetBytes(content);
            udpclient.Send(bytes, bytes.Length, iep);
            this.txt_history.Text += "我说：" + this.txt_send.Text + "\r\n";
            this.txt_send.Text = "";
        }
       

        private void ChatFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.isopen = false;
        }
       
    }
}
