namespace hytc.QQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pb_headImg = new System.Windows.Forms.PictureBox();
            this.lab_nickName = new System.Windows.Forms.Label();
            this.lab_shuoshuo = new System.Windows.Forms.Label();
            this.pn_friendlist = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.img_list = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb_headImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_headImg
            // 
            this.pb_headImg.Location = new System.Drawing.Point(12, 9);
            this.pb_headImg.Name = "pb_headImg";
            this.pb_headImg.Size = new System.Drawing.Size(80, 80);
            this.pb_headImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_headImg.TabIndex = 0;
            this.pb_headImg.TabStop = false;
            // 
            // lab_nickName
            // 
            this.lab_nickName.AutoSize = true;
            this.lab_nickName.Font = new System.Drawing.Font("宋体", 14F);
            this.lab_nickName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lab_nickName.Location = new System.Drawing.Point(98, 22);
            this.lab_nickName.Name = "lab_nickName";
            this.lab_nickName.Size = new System.Drawing.Size(47, 19);
            this.lab_nickName.TabIndex = 1;
            this.lab_nickName.Text = "温迪";
            // 
            // lab_shuoshuo
            // 
            this.lab_shuoshuo.AutoSize = true;
            this.lab_shuoshuo.Font = new System.Drawing.Font("宋体", 12F);
            this.lab_shuoshuo.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lab_shuoshuo.Location = new System.Drawing.Point(99, 53);
            this.lab_shuoshuo.Name = "lab_shuoshuo";
            this.lab_shuoshuo.Size = new System.Drawing.Size(48, 16);
            this.lab_shuoshuo.TabIndex = 2;
            this.lab_shuoshuo.Text = "Hello";
            // 
            // pn_friendlist
            // 
            this.pn_friendlist.AutoScroll = true;
            this.pn_friendlist.Location = new System.Drawing.Point(5, 104);
            this.pn_friendlist.Name = "pn_friendlist";
            this.pn_friendlist.Size = new System.Drawing.Size(233, 400);
            this.pn_friendlist.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(167, 22);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(62, 57);
            this.btn_login.TabIndex = 0;
            this.btn_login.Text = "登 录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // img_list
            // 
            this.img_list.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("img_list.ImageStream")));
            this.img_list.TransparentColor = System.Drawing.Color.Transparent;
            this.img_list.Images.SetKeyName(0, "getface_002.jpg");
            this.img_list.Images.SetKeyName(1, "getface_003.jpg");
            this.img_list.Images.SetKeyName(2, "getface_004.jpg");
            this.img_list.Images.SetKeyName(3, "getface_005.jpg");
            this.img_list.Images.SetKeyName(4, "getface_006.jpg");
            this.img_list.Images.SetKeyName(5, "getface_007.jpg");
            this.img_list.Images.SetKeyName(6, "getface_008.jpg");
            this.img_list.Images.SetKeyName(7, "getface_009.jpg");
            this.img_list.Images.SetKeyName(8, "getface_010.jpg");
            this.img_list.Images.SetKeyName(9, "getface_011.jpg");
            this.img_list.Images.SetKeyName(10, "getface_012.jpg");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 517);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.pn_friendlist);
            this.Controls.Add(this.lab_shuoshuo);
            this.Controls.Add(this.lab_nickName);
            this.Controls.Add(this.pb_headImg);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_headImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_headImg;
        private System.Windows.Forms.Label lab_nickName;
        private System.Windows.Forms.Label lab_shuoshuo;
        private System.Windows.Forms.Panel pn_friendlist;
        private System.Windows.Forms.Button btn_login;
        public System.Windows.Forms.ImageList img_list;
    }
}

