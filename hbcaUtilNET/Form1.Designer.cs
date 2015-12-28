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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tree_list = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btn_getCert = new System.Windows.Forms.Button();
            this.btn_createHash = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.tbox_result = new System.Windows.Forms.RichTextBox();
            this.btn_deleteContainer = new System.Windows.Forms.Button();
            this.btn_createContainer = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tree_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(627, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
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
            this.splitContainer1.SplitterDistance = 255;
            this.splitContainer1.TabIndex = 0;
            // 
            // btn_getCert
            // 
            this.btn_getCert.Location = new System.Drawing.Point(5, 61);
            this.btn_getCert.Name = "btn_getCert";
            this.btn_getCert.Size = new System.Drawing.Size(75, 23);
            this.btn_getCert.TabIndex = 3;
            this.btn_getCert.Text = "获取公钥证书";
            this.btn_getCert.UseVisualStyleBackColor = true;
            this.btn_getCert.Click += new System.EventHandler(this.btn_getCert_Click);
            // 
            // btn_createHash
            // 
            this.btn_createHash.Location = new System.Drawing.Point(5, 117);
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
            this.tbox_result.Size = new System.Drawing.Size(362, 362);
            this.tbox_result.TabIndex = 0;
            this.tbox_result.Text = "";
            // 
            // btn_deleteContainer
            // 
            this.btn_deleteContainer.Location = new System.Drawing.Point(5, 214);
            this.btn_deleteContainer.Name = "btn_deleteContainer";
            this.btn_deleteContainer.Size = new System.Drawing.Size(75, 23);
            this.btn_deleteContainer.TabIndex = 4;
            this.btn_deleteContainer.Text = "删除容器";
            this.btn_deleteContainer.UseVisualStyleBackColor = true;
            this.btn_deleteContainer.Click += new System.EventHandler(this.btn_deleteContainer_Click);
            // 
            // btn_createContainer
            // 
            this.btn_createContainer.Location = new System.Drawing.Point(5, 185);
            this.btn_createContainer.Name = "btn_createContainer";
            this.btn_createContainer.Size = new System.Drawing.Size(75, 23);
            this.btn_createContainer.TabIndex = 5;
            this.btn_createContainer.Text = "创建容器";
            this.btn_createContainer.UseVisualStyleBackColor = true;
            this.btn_createContainer.Click += new System.EventHandler(this.btn_createContainer_Click);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}

