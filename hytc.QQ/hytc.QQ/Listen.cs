using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace hytc.QQ
{
    public class Listen
    {

        private Form1 mainfrm;


        public Listen(Form1 frm)
        {
            this.mainfrm = frm;
        }
        public string getip()
        {
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            return ipa.ToString();

        }

        public void ReceiveData()
        {
            UdpClient uc = new UdpClient(9527);
            while (true)
            {
                IPEndPoint iepclient = new IPEndPoint(IPAddress.Any, 0);
                //以字节发送，接受，阅读前转换为string
                byte[] receivestring = uc.Receive(ref iepclient);
                IPAddress opsiteip = iepclient.Address;
                string bytes = Encoding.Default.GetString(receivestring);
                string[] split = bytes.Split('|');
                string receidata = split[0];
                switch (receidata)
                {
                    case "LOGIN":
                        Friend friend = new Friend();
                        friend.NickName = split[1];
                        friend.ShuoShuo = split[2];
                        int curindex = Convert.ToInt32(split[3]);
                        if (curindex < 0 || curindex >= this.mainfrm.img_list.Images.Count)
                        {
                            friend.HeadImg = 1;
                        }
                        else
                        {
                            friend.HeadImg = curindex;
                        }
                        friend.ip = opsiteip;
                        object[] paras = new object[1];
                        paras[0] = friend;
                        hytc.QQ.Form1.UCdelegate d = new hytc.QQ.Form1.UCdelegate(this.mainfrm.AddFriend);
                        this.mainfrm.Invoke(d, paras);

                        //回发
                        UdpClient udp = new UdpClient();
                        string nickname = this.mainfrm.me.NickName;
                        string shuoshuo = this.mainfrm.me.ShuoShuo;
                        int headimg = this.mainfrm.me.HeadImg;
                        // headimg =  this.img_list.Images[7];
                        //int headindex = ; //获取自身头像的下标？？？
                        string content = "ALSOON|" + nickname + "|" + shuoshuo + "|" + headimg; //要改为自身头像的下标
                        byte[] alsoonbytes = Encoding.Default.GetBytes(content);
                        IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
                        udp.Send(alsoonbytes, alsoonbytes.Length, new IPEndPoint(IPAddress.Parse(this.getip()), 9527));
                        break;
                    case "ALSOON":
                        Friend forefriend = new Friend();
                        forefriend.NickName = split[1];
                        forefriend.ShuoShuo = split[2];
                        int index = Convert.ToInt32(split[3]);
                        if (index < 0 || index >= this.mainfrm.img_list.Images.Count)
                        {
                            forefriend.HeadImg = 1;
                        }
                        else
                        {
                            forefriend.HeadImg = index;
                        }
                        forefriend.ip = opsiteip;
                        object[] foreparas = new object[1];
                        foreparas[0] = forefriend;
                        hytc.QQ.Form1.UCdelegate fored = new hytc.QQ.Form1.UCdelegate(this.mainfrm.AddFriend);
                        this.mainfrm.Invoke(fored, foreparas);
                        break;
                    case "TALK":
                        // "Talk|" + this.txt_history.Text + "|" + mylisten.getip();
                        MessageBox.Show("发来新消息");
                        string talkcontent = split[1];
                        IPAddress hisip = IPAddress.Parse(split[2]);
                        ChatFrm hischat = new ChatFrm();
                        break;
                        
                    default:
                        break;
                }
            }
        }
    }
}
