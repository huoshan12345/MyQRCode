namespace DES
{
    partial class DESForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DESForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.cipherKeyText = new System.Windows.Forms.TextBox();
            this.ClearKey = new System.Windows.Forms.Button();
            this.plainLabel = new System.Windows.Forms.Label();
            this.plainText = new System.Windows.Forms.TextBox();
            this.plainClear = new System.Windows.Forms.Button();
            this.cipherLabel = new System.Windows.Forms.Label();
            this.cipherText = new System.Windows.Forms.TextBox();
            this.cipherClear = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.clearAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.打开ToolStripMenuItem.Text = "文件";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.文件ToolStripMenuItem.Text = "打开";
            this.文件ToolStripMenuItem.Click += new System.EventHandler(this.文件ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入密钥(8个字符或4个汉字)：";
            // 
            // cipherKeyText
            // 
            this.cipherKeyText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cipherKeyText.Location = new System.Drawing.Point(12, 56);
            this.cipherKeyText.Multiline = true;
            this.cipherKeyText.Name = "cipherKeyText";
            this.cipherKeyText.Size = new System.Drawing.Size(295, 21);
            this.cipherKeyText.TabIndex = 2;
            // 
            // ClearKey
            // 
            this.ClearKey.Location = new System.Drawing.Point(313, 55);
            this.ClearKey.Name = "ClearKey";
            this.ClearKey.Size = new System.Drawing.Size(75, 23);
            this.ClearKey.TabIndex = 4;
            this.ClearKey.Text = "清空密钥";
            this.ClearKey.UseVisualStyleBackColor = true;
            this.ClearKey.Click += new System.EventHandler(this.ClearKey_Click);
            // 
            // plainLabel
            // 
            this.plainLabel.AutoSize = true;
            this.plainLabel.Location = new System.Drawing.Point(12, 109);
            this.plainLabel.Name = "plainLabel";
            this.plainLabel.Size = new System.Drawing.Size(41, 12);
            this.plainLabel.TabIndex = 5;
            this.plainLabel.Text = "明文：";
            // 
            // plainText
            // 
            this.plainText.Location = new System.Drawing.Point(56, 109);
            this.plainText.Multiline = true;
            this.plainText.Name = "plainText";
            this.plainText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.plainText.Size = new System.Drawing.Size(101, 137);
            this.plainText.TabIndex = 6;
            // 
            // plainClear
            // 
            this.plainClear.Location = new System.Drawing.Point(12, 136);
            this.plainClear.Name = "plainClear";
            this.plainClear.Size = new System.Drawing.Size(37, 23);
            this.plainClear.TabIndex = 7;
            this.plainClear.Text = "清空";
            this.plainClear.UseVisualStyleBackColor = true;
            this.plainClear.Click += new System.EventHandler(this.plainClear_Click);
            // 
            // cipherLabel
            // 
            this.cipherLabel.AutoSize = true;
            this.cipherLabel.Location = new System.Drawing.Point(245, 109);
            this.cipherLabel.Name = "cipherLabel";
            this.cipherLabel.Size = new System.Drawing.Size(41, 12);
            this.cipherLabel.TabIndex = 8;
            this.cipherLabel.Text = "密文：";
            // 
            // cipherText
            // 
            this.cipherText.Location = new System.Drawing.Point(292, 112);
            this.cipherText.Multiline = true;
            this.cipherText.Name = "cipherText";
            this.cipherText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cipherText.Size = new System.Drawing.Size(100, 134);
            this.cipherText.TabIndex = 9;
            // 
            // cipherClear
            // 
            this.cipherClear.Location = new System.Drawing.Point(247, 135);
            this.cipherClear.Name = "cipherClear";
            this.cipherClear.Size = new System.Drawing.Size(39, 23);
            this.cipherClear.TabIndex = 10;
            this.cipherClear.Text = "清空";
            this.cipherClear.UseVisualStyleBackColor = true;
            this.cipherClear.Click += new System.EventHandler(this.cipherClear_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(164, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "加密->";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(164, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "<-解密";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(313, 26);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(75, 23);
            this.clearAll.TabIndex = 13;
            this.clearAll.Text = "清空全部";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 258);
            this.Controls.Add(this.clearAll);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cipherClear);
            this.Controls.Add(this.cipherText);
            this.Controls.Add(this.cipherLabel);
            this.Controls.Add(this.plainClear);
            this.Controls.Add(this.plainText);
            this.Controls.Add(this.plainLabel);
            this.Controls.Add(this.ClearKey);
            this.Controls.Add(this.cipherKeyText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DES演示小工具";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cipherKeyText;
        private System.Windows.Forms.Button ClearKey;
        private System.Windows.Forms.Label plainLabel;
        private System.Windows.Forms.TextBox plainText;
        private System.Windows.Forms.Button plainClear;
        private System.Windows.Forms.Label cipherLabel;
        private System.Windows.Forms.TextBox cipherText;
        private System.Windows.Forms.Button cipherClear;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button clearAll;
    }
}

