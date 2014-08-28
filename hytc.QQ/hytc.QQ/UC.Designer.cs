namespace hytc.QQ
{
    partial class UC
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC));
            this.pb_headImg = new System.Windows.Forms.PictureBox();
            this.lab_nickName = new System.Windows.Forms.Label();
            this.lab_shuoshuo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_headImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_headImg
            // 
            this.pb_headImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("pb_headImg.InitialImage")));
            this.pb_headImg.Location = new System.Drawing.Point(0, 3);
            this.pb_headImg.Name = "pb_headImg";
            this.pb_headImg.Size = new System.Drawing.Size(60, 60);
            this.pb_headImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_headImg.TabIndex = 0;
            this.pb_headImg.TabStop = false;
            this.pb_headImg.DoubleClick += new System.EventHandler(this.pb_headImg_DoubleClick);
            // 
            // lab_nickName
            // 
            this.lab_nickName.AutoSize = true;
            this.lab_nickName.Location = new System.Drawing.Point(80, 15);
            this.lab_nickName.Name = "lab_nickName";
            this.lab_nickName.Size = new System.Drawing.Size(41, 12);
            this.lab_nickName.TabIndex = 1;
            this.lab_nickName.Text = "label1";
            this.lab_nickName.DoubleClick += new System.EventHandler(this.lab_nickName_DoubleClick);
            // 
            // lab_shuoshuo
            // 
            this.lab_shuoshuo.AutoSize = true;
            this.lab_shuoshuo.Location = new System.Drawing.Point(80, 42);
            this.lab_shuoshuo.Name = "lab_shuoshuo";
            this.lab_shuoshuo.Size = new System.Drawing.Size(41, 12);
            this.lab_shuoshuo.TabIndex = 2;
            this.lab_shuoshuo.Text = "label2";
            this.lab_shuoshuo.DoubleClick += new System.EventHandler(this.lab_shuoshuo_DoubleClick);
            // 
            // UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lab_shuoshuo);
            this.Controls.Add(this.lab_nickName);
            this.Controls.Add(this.pb_headImg);
            this.Location = new System.Drawing.Point(3, 0);
            this.Name = "UC";
            this.Size = new System.Drawing.Size(210, 66);
            this.Load += new System.EventHandler(this.UC_Load);
            this.DoubleClick += new System.EventHandler(this.UC_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pb_headImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_headImg;
        private System.Windows.Forms.Label lab_nickName;
        private System.Windows.Forms.Label lab_shuoshuo;
    }
}
