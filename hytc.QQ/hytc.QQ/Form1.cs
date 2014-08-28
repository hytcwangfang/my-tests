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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Friend me;

        private Panel pnlist;

        public Panel Pnlist
        {
            //加载时便已经被赋值，要防止后面为空（在添加用户控件时，重新赋值）
            get { return pnlist; }
            set { pnlist = this.pn_friendlist; }
        }

        public Listen listen;

        public delegate void UCdelegate(Friend f);

        public void AddFriend(Friend f)
        {
            UC ucli = new UC();
            ucli.Friend = f;
            ucli.Top = this.pn_friendlist.Controls.Count * ucli.Height;
            this.pn_friendlist.Controls.Add(ucli);
            this.Pnlist = this.pn_friendlist;//为Pnlist重新赋值（承上）
            ucli.myDBclick += new EventHandler(ucli_myDBclick);
        }

        void ucli_myDBclick(object sender, EventArgs e)
        {
            UC ucf = (UC)sender;
            Friend f = ucf.Friend;
            ChatFrm chatfrm = new ChatFrm(f);
            chatfrm.Show();
            //throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pb_headImg.Image = this.img_list.Images[4];
            Form1.CheckForIllegalCrossThreadCalls = false;
            listen = new Listen(this);
            Thread receithread = new Thread(new ThreadStart(listen.ReceiveData));
            receithread.IsBackground = true;
            receithread.Start();

            me =new Friend();

            //上线通知
            UdpClient udp = new UdpClient();
            me.NickName = this.lab_nickName.Text;
            me.ShuoShuo = this.lab_shuoshuo.Text;
            me.HeadImg = 4;
            // headimg =  this.img_list.Images[7];
            //int headindex = ; //获取自身头像的下标？？？
            string content = "LOGIN|" + me.NickName + "|" + me.HeadImg + "|" + me.ShuoShuo; //要改为自身头像的下标
            byte[] bytes = Encoding.Default.GetBytes(content);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udp.Send(bytes, bytes.Length, iep);
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //下线通知
            UdpClient udp = new UdpClient();
            //string content = "LOGOUT|" + this.listen.getip(); 
            string content = "LOGOUT|";
            byte[] bytes = Encoding.Default.GetBytes(content);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udp.Send(bytes, bytes.Length, iep);
            Application.Exit();
        }

        
    }
}
