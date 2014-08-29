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
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress myip = ips[0];
            foreach (IPAddress ip in ips)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    myip = ip;
                }
            }
            return myip.ToString();
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
                        //"LOGIN|" + me.NickName + "|" + me.HeadImg + "|" + me.ShuoShuo
                        if (opsiteip.ToString() == this.getip())
                        {
                            continue;
                        }
                        else
                        {
                            Friend friend = new Friend();
                            friend.NickName = split[1];
                            friend.ShuoShuo = split[3];
                            int curindex = Convert.ToInt32(split[2]);
                            if (curindex < 0 || curindex >= this.mainfrm.img_list.Images.Count)
                            {
                                friend.HeadImg = 0;
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
                            string content = "ALSOON|" + nickname + "|" + headimg + "|" + shuoshuo; //要改为自身头像的下标
                            byte[] alsoonbytes = Encoding.Default.GetBytes(content);
                            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("255.255.255.255"), 9527);
                            udp.Send(alsoonbytes, alsoonbytes.Length, new IPEndPoint(opsiteip, 9527));
                        }
                        break;
                    case "ALSOON":
                        if (opsiteip.ToString() == this.getip())
                        {
                            continue;
                        }
                        else
                        {
                            Friend forefriend = new Friend();
                            forefriend.NickName = split[1];
                            forefriend.ShuoShuo = split[3];
                            int index = Convert.ToInt32(split[2]);
                            if (index < 0 || index >= this.mainfrm.img_list.Images.Count)
                            {
                                forefriend.HeadImg = 0;
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
                        }
                        break;
                    case "LOGOUT":
                        if (opsiteip.ToString() == this.getip())
                        {
                            return;
                        }
                        int logoutid = 0;
                        foreach(UC ucli in this.mainfrm.Pnlist.Controls)
                        {
                            if (opsiteip.ToString() == ucli.Friend.ip.ToString())
                            {
                                this.mainfrm.Pnlist.Controls.Remove(ucli);
                                break;
                            }
                            logoutid++;//最终得到移除控件的下标
                        }
                        //将在已移除的下方用户控件往上移动
                        for (int i = logoutid; i < this.mainfrm.Pnlist.Controls.Count; i++)
                        {
                            this.mainfrm.Pnlist.Controls[i].Top = i * this.mainfrm.Pnlist.Controls[i].Height;
                        }
                        break;
                    case "MSG":
                        // "MSG|" + this.txt_history.Text;
                        //MessageBox.Show("发来新消息");
                        for (int i = 0; i < this.mainfrm.listChatFrm.Count; i++)
                        {
                            if (opsiteip.ToString() == this.mainfrm.listChatFrm[i].curfriend.ip.ToString())
                            {
                                //找到对应ip，提示新消息//?打开对应聊天窗口
                                if (this.mainfrm.listChatFrm[i].isopen == true)
                                {
                                    this.mainfrm.listChatFrm[i].History += split[1] + "\r\n";
                                }
                                else
                                {
                                    this.mainfrm.listChatFrm[i].isopen = true;
                                    //this.mainfrm.listChatFrm[i].Visible = false;
                                    //this.mainfrm.listChatFrm[i].ShowInTaskbar = true;
                                    this.mainfrm.listChatFrm[i].Text = "[有新消息]" + this.mainfrm.listChatFrm[i].curfriend.NickName;
                                    this.mainfrm.listChatFrm[i].History += this.mainfrm.listChatFrm[i].curfriend.NickName + "说：" + split[1] + "\r\n";
                                    this.mainfrm.listChatFrm[i].Show();
                                }
                                
                                
                            }
                        }
                        break;
                        
                    default:
                        break;
                }
            }
        }
    }
}
