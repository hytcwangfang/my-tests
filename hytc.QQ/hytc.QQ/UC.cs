using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hytc.QQ
{
    public partial class UC : UserControl
    {
        public UC()
        {
            InitializeComponent();
        }

        private Form1 frm = new Form1();

        private Friend friend;

        public Friend Friend
        {
            get { return friend; }
            set 
            { 
                friend = value;
                this.lab_nickName.Text = value.NickName;
                this.lab_shuoshuo.Text = value.ShuoShuo;
                this.pb_headImg.Image = this.frm.img_list.Images[value.HeadImg];
            }
        }

        public event EventHandler myDBclick;

        

        private void UC_Load(object sender, EventArgs e)
        {
            //UC ucli = new UC();
            
        }

        private void lab_nickName_DoubleClick(object sender, EventArgs e)
        {
            this.myDBclick(this, e);
        }

        private void lab_shuoshuo_DoubleClick(object sender, EventArgs e)
        {
            this.myDBclick(this, e);
        }

        private void pb_headImg_DoubleClick(object sender, EventArgs e)
        {
            this.myDBclick(this, e);
        }

        private void UC_DoubleClick(object sender, EventArgs e)
        {
            this.myDBclick(sender, e);
        }
    }
}
