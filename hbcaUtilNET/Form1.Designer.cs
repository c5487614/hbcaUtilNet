namespace hbcaUtilNET
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.btn_exportPublicKey = new System.Windows.Forms.Button();
			this.btn_verify = new System.Windows.Forms.Button();
			this.btn_signData = new System.Windows.Forms.Button();
			this.btn_getCertProp = new System.Windows.Forms.Button();
			this.btn_getCertIssuer = new System.Windows.Forms.Button();
			this.btn_createContainer = new System.Windows.Forms.Button();
			this.btn_deleteContainer = new System.Windows.Forms.Button();
			this.btn_getCert = new System.Windows.Forms.Button();
			this.btn_createHash = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.btn_test = new System.Windows.Forms.Button();
			this.tbox_result = new System.Windows.Forms.RichTextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tree_list = new System.Windows.Forms.TreeView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tbox_container = new System.Windows.Forms.TextBox();
			this.btn_getContainerList = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.btn_encrypt_3DES = new System.Windows.Forms.Button();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.btn_hash_sha1 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(635, 394);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.splitContainer1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(627, 368);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btn_exportPublicKey);
			this.splitContainer1.Panel1.Controls.Add(this.btn_verify);
			this.splitContainer1.Panel1.Controls.Add(this.btn_signData);
			this.splitContainer1.Panel1.Controls.Add(this.btn_getCertProp);
			this.splitContainer1.Panel1.Controls.Add(this.btn_getCertIssuer);
			this.splitContainer1.Panel1.Controls.Add(this.btn_createContainer);
			this.splitContainer1.Panel1.Controls.Add(this.btn_deleteContainer);
			this.splitContainer1.Panel1.Controls.Add(this.btn_getCert);
			this.splitContainer1.Panel1.Controls.Add(this.btn_createHash);
			this.splitContainer1.Panel1.Controls.Add(this.button1);
			this.splitContainer1.Panel1.Controls.Add(this.btn_test);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tbox_result);
			this.splitContainer1.Size = new System.Drawing.Size(621, 362);
			this.splitContainer1.SplitterDistance = 218;
			this.splitContainer1.TabIndex = 0;
			// 
			// btn_exportPublicKey
			// 
			this.btn_exportPublicKey.Location = new System.Drawing.Point(96, 178);
			this.btn_exportPublicKey.Name = "btn_exportPublicKey";
			this.btn_exportPublicKey.Size = new System.Drawing.Size(75, 23);
			this.btn_exportPublicKey.TabIndex = 9;
			this.btn_exportPublicKey.Text = "导出公钥";
			this.btn_exportPublicKey.UseVisualStyleBackColor = true;
			this.btn_exportPublicKey.Click += new System.EventHandler(this.btn_exportPublicKey_Click);
			// 
			// btn_verify
			// 
			this.btn_verify.Location = new System.Drawing.Point(5, 207);
			this.btn_verify.Name = "btn_verify";
			this.btn_verify.Size = new System.Drawing.Size(75, 23);
			this.btn_verify.TabIndex = 8;
			this.btn_verify.Text = "验签";
			this.btn_verify.UseVisualStyleBackColor = true;
			this.btn_verify.Click += new System.EventHandler(this.btn_verify_Click);
			// 
			// btn_signData
			// 
			this.btn_signData.Location = new System.Drawing.Point(5, 178);
			this.btn_signData.Name = "btn_signData";
			this.btn_signData.Size = new System.Drawing.Size(75, 23);
			this.btn_signData.TabIndex = 7;
			this.btn_signData.Text = "签名";
			this.btn_signData.UseVisualStyleBackColor = true;
			this.btn_signData.Click += new System.EventHandler(this.btn_signData_Click);
			// 
			// btn_getCertProp
			// 
			this.btn_getCertProp.Location = new System.Drawing.Point(5, 117);
			this.btn_getCertProp.Name = "btn_getCertProp";
			this.btn_getCertProp.Size = new System.Drawing.Size(95, 23);
			this.btn_getCertProp.TabIndex = 1;
			this.btn_getCertProp.Text = "获取证书属性";
			this.btn_getCertProp.UseVisualStyleBackColor = true;
			this.btn_getCertProp.Click += new System.EventHandler(this.btn_getCertProp_Click);
			// 
			// btn_getCertIssuer
			// 
			this.btn_getCertIssuer.Location = new System.Drawing.Point(5, 88);
			this.btn_getCertIssuer.Name = "btn_getCertIssuer";
			this.btn_getCertIssuer.Size = new System.Drawing.Size(107, 23);
			this.btn_getCertIssuer.TabIndex = 6;
			this.btn_getCertIssuer.Text = "获取证书颁发者";
			this.btn_getCertIssuer.UseVisualStyleBackColor = true;
			this.btn_getCertIssuer.Click += new System.EventHandler(this.btn_getCertIssuer_Click);
			// 
			// btn_createContainer
			// 
			this.btn_createContainer.Location = new System.Drawing.Point(5, 299);
			this.btn_createContainer.Name = "btn_createContainer";
			this.btn_createContainer.Size = new System.Drawing.Size(75, 23);
			this.btn_createContainer.TabIndex = 5;
			this.btn_createContainer.Text = "创建容器";
			this.btn_createContainer.UseVisualStyleBackColor = true;
			this.btn_createContainer.Click += new System.EventHandler(this.btn_createContainer_Click);
			// 
			// btn_deleteContainer
			// 
			this.btn_deleteContainer.Location = new System.Drawing.Point(5, 328);
			this.btn_deleteContainer.Name = "btn_deleteContainer";
			this.btn_deleteContainer.Size = new System.Drawing.Size(75, 23);
			this.btn_deleteContainer.TabIndex = 4;
			this.btn_deleteContainer.Text = "删除容器";
			this.btn_deleteContainer.UseVisualStyleBackColor = true;
			this.btn_deleteContainer.Click += new System.EventHandler(this.btn_deleteContainer_Click);
			// 
			// btn_getCert
			// 
			this.btn_getCert.Location = new System.Drawing.Point(5, 61);
			this.btn_getCert.Name = "btn_getCert";
			this.btn_getCert.Size = new System.Drawing.Size(95, 23);
			this.btn_getCert.TabIndex = 3;
			this.btn_getCert.Text = "获取证书主题";
			this.btn_getCert.UseVisualStyleBackColor = true;
			this.btn_getCert.Click += new System.EventHandler(this.btn_getCert_Click);
			// 
			// btn_createHash
			// 
			this.btn_createHash.Location = new System.Drawing.Point(5, 270);
			this.btn_createHash.Name = "btn_createHash";
			this.btn_createHash.Size = new System.Drawing.Size(75, 23);
			this.btn_createHash.TabIndex = 2;
			this.btn_createHash.Text = "创建HASH";
			this.btn_createHash.UseVisualStyleBackColor = true;
			this.btn_createHash.Click += new System.EventHandler(this.btn_createHash_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(5, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "获取容器名";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btn_test
			// 
			this.btn_test.Location = new System.Drawing.Point(5, 3);
			this.btn_test.Name = "btn_test";
			this.btn_test.Size = new System.Drawing.Size(75, 23);
			this.btn_test.TabIndex = 0;
			this.btn_test.Text = "测试";
			this.btn_test.UseVisualStyleBackColor = true;
			this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
			// 
			// tbox_result
			// 
			this.tbox_result.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbox_result.Location = new System.Drawing.Point(0, 0);
			this.tbox_result.Name = "tbox_result";
			this.tbox_result.Size = new System.Drawing.Size(399, 362);
			this.tbox_result.TabIndex = 0;
			this.tbox_result.Text = "";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.tree_list);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(627, 368);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "获取容器列表";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tree_list
			// 
			this.tree_list.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tree_list.Location = new System.Drawing.Point(3, 3);
			this.tree_list.Name = "tree_list";
			this.tree_list.Size = new System.Drawing.Size(621, 362);
			this.tree_list.TabIndex = 1;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tbox_container);
			this.tabPage3.Controls.Add(this.btn_getContainerList);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(627, 368);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "容器相关";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tbox_container
			// 
			this.tbox_container.Location = new System.Drawing.Point(11, 47);
			this.tbox_container.Multiline = true;
			this.tbox_container.Name = "tbox_container";
			this.tbox_container.Size = new System.Drawing.Size(430, 301);
			this.tbox_container.TabIndex = 5;
			// 
			// btn_getContainerList
			// 
			this.btn_getContainerList.Location = new System.Drawing.Point(42, 18);
			this.btn_getContainerList.Name = "btn_getContainerList";
			this.btn_getContainerList.Size = new System.Drawing.Size(106, 23);
			this.btn_getContainerList.TabIndex = 4;
			this.btn_getContainerList.Text = "获取容器列表";
			this.btn_getContainerList.UseVisualStyleBackColor = true;
			this.btn_getContainerList.Click += new System.EventHandler(this.btn_getContainerList_Click_1);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.btn_encrypt_3DES);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(627, 368);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "加解密";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// btn_encrypt_3DES
			// 
			this.btn_encrypt_3DES.Location = new System.Drawing.Point(22, 18);
			this.btn_encrypt_3DES.Name = "btn_encrypt_3DES";
			this.btn_encrypt_3DES.Size = new System.Drawing.Size(75, 23);
			this.btn_encrypt_3DES.TabIndex = 0;
			this.btn_encrypt_3DES.Text = "加密";
			this.btn_encrypt_3DES.UseVisualStyleBackColor = true;
			this.btn_encrypt_3DES.Click += new System.EventHandler(this.btn_encrypt_3DES_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.btn_hash_sha1);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(627, 368);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "哈希";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// btn_hash_sha1
			// 
			this.btn_hash_sha1.Location = new System.Drawing.Point(34, 30);
			this.btn_hash_sha1.Name = "btn_hash_sha1";
			this.btn_hash_sha1.Size = new System.Drawing.Size(75, 23);
			this.btn_hash_sha1.TabIndex = 0;
			this.btn_hash_sha1.Text = "SHA256";
			this.btn_hash_sha1.UseVisualStyleBackColor = true;
			this.btn_hash_sha1.Click += new System.EventHandler(this.btn_hash_sha1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(635, 394);
			this.Controls.Add(this.tabControl1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.tabControl1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tree_list;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.RichTextBox tbox_result;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_createHash;
        private System.Windows.Forms.Button btn_getCert;
        private System.Windows.Forms.Button btn_deleteContainer;
        private System.Windows.Forms.Button btn_createContainer;
        private System.Windows.Forms.Button btn_getCertIssuer;
		private System.Windows.Forms.Button btn_getCertProp;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox tbox_container;
		private System.Windows.Forms.Button btn_getContainerList;
		private System.Windows.Forms.Button btn_signData;
		private System.Windows.Forms.Button btn_verify;
		private System.Windows.Forms.Button btn_exportPublicKey;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Button btn_encrypt_3DES;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_hash_sha1;
    }
}

