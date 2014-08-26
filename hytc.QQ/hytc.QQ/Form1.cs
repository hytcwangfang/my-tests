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

        public delegate void UCdelegate(Friend f);
        private void AddFriend(Friend f)
        {
                UC ucli = new UC();
                ucli.Friend = f;
                ucli.Top = this.pn_friendlist.Controls.Count * ucli.Height;
                this.pn_friendlist.Controls.Add(ucli);
        }

        private void ReceiveData()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint iepclient = new IPEndPoint(IPAddress.Any, 0);
                //以字节发送，接受，阅读前转换为string
                byte[] receivestring = uc.Receive(ref iepclient);
                string bytes = Encoding.Default.GetString(receivestring);
                string[] split = bytes.Split('|');
                if (split[0] == "LOGIN")
                {
                    Friend friend = new Friend();
                    friend.NickName = split[1];
                    friend.ShuoShuo = split[2];
                    int curindex = Convert.ToInt32(split[3]);
                    if (curindex < 0 || curindex >= this.img_list.Images.Count)
                    {
                        friend.HeadImg = 1;
                    }
                    else {
                        friend.HeadImg = curindex;
                    }
                    object[] paras = new object[1];
                    paras[0] = friend;
                    this.Invoke(new UCdelegate(this.AddFriend), paras);
                    //this.pn_friendlist.Controls.Add(ucli);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pb_headImg.Image = this.img_list.Images[7];
            Form1.CheckForIllegalCrossThreadCalls = false;
            Thread receithread = new Thread(new ThreadStart(ReceiveData));
            receithread.IsBackground = true;
            receithread.Start();

            
        }


        private void btn_login_Click(object sender, EventArgs e)
        {
            //上线通知
            UdpClient udp = new UdpClient();
            string nickname = this.lab_nickName.Text;
            string shuoshuo = this.lab_shuoshuo.Text;
            // headimg =  this.img_list.Images[7];
            //int headindex = ; //获取自身头像的下标？？？
            string content = "LOGIN|" + nickname + "|" + shuoshuo + "|" + 1; //要改为自身头像的下标
            byte[] bytes = Encoding.Default.GetBytes(content);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
            udp.Send(bytes, bytes.Length, iep);
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
