namespace AES
{
    partial class AESForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AESForm));
            this.KeyLabel = new System.Windows.Forms.Label();
            this.KeyText = new System.Windows.Forms.TextBox();
            this.PlianLabel = new System.Windows.Forms.Label();
            this.PlainText = new System.Windows.Forms.TextBox();
            this.CipherLabel = new System.Windows.Forms.Label();
            this.CipherText = new System.Windows.Forms.TextBox();
            this.ClearPlain = new System.Windows.Forms.Button();
            this.ClearCipher = new System.Windows.Forms.Button();
            this.ClearKey = new System.Windows.Forms.Button();
            this.EncryptionBtn = new System.Windows.Forms.Button();
            this.DecryptionBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ClearAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioBtn3 = new System.Windows.Forms.RadioButton();
            this.radioBtn2 = new System.Windows.Forms.RadioButton();
            this.radioBtn1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Location = new System.Drawing.Point(10, 122);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(77, 12);
            this.KeyLabel.TabIndex = 3;
            this.KeyLabel.Text = "请输入密钥：";
            // 
            // KeyText
            // 
            this.KeyText.AllowDrop = true;
            this.KeyText.Location = new System.Drawing.Point(85, 119);
            this.KeyText.Multiline = true;
            this.KeyText.Name = "KeyText";
            this.KeyText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.KeyText.Size = new System.Drawing.Size(235, 21);
            this.KeyText.TabIndex = 4;
            // 
            // PlianLabel
            // 
            this.PlianLabel.AutoSize = true;
            this.PlianLabel.Location = new System.Drawing.Point(15, 152);
            this.PlianLabel.Name = "PlianLabel";
            this.PlianLabel.Size = new System.Drawing.Size(35, 12);
            this.PlianLabel.TabIndex = 6;
            this.PlianLabel.Text = "明文:";
            // 
            // PlainText
            // 
            this.PlainText.AllowDrop = true;
            this.PlainText.Location = new System.Drawing.Point(64, 152);
            this.PlainText.Multiline = true;
            this.PlainText.Name = "PlainText";
            this.PlainText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.PlainText.Size = new System.Drawing.Size(113, 133);
            this.PlainText.TabIndex = 9;
            // 
            // CipherLabel
            // 
            this.CipherLabel.AutoSize = true;
            this.CipherLabel.Location = new System.Drawing.Point(298, 152);
            this.CipherLabel.Name = "CipherLabel";
            this.CipherLabel.Size = new System.Drawing.Size(35, 12);
            this.CipherLabel.TabIndex = 10;
            this.CipherLabel.Text = "密文:";
            // 
            // CipherText
            // 
            this.CipherText.AllowDrop = true;
            this.CipherText.Location = new System.Drawing.Point(339, 152);
            this.CipherText.Multiline = true;
            this.CipherText.Name = "CipherText";
            this.CipherText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.CipherText.Size = new System.Drawing.Size(115, 133);
            this.CipherText.TabIndex = 11;
            // 
            // ClearPlain
            // 
            this.ClearPlain.Location = new System.Drawing.Point(12, 176);
            this.ClearPlain.Name = "ClearPlain";
            this.ClearPlain.Size = new System.Drawing.Size(38, 23);
            this.ClearPlain.TabIndex = 12;
            this.ClearPlain.Text = "清空";
            this.ClearPlain.UseVisualStyleBackColor = true;
            this.ClearPlain.Click += new System.EventHandler(this.ClearPlain_Click);
            // 
            // ClearCipher
            // 
            this.ClearCipher.Location = new System.Drawing.Point(290, 176);
            this.ClearCipher.Name = "ClearCipher";
            this.ClearCipher.Size = new System.Drawing.Size(43, 23);
            this.ClearCipher.TabIndex = 13;
            this.ClearCipher.Text = "清空";
            this.ClearCipher.UseVisualStyleBackColor = true;
            this.ClearCipher.Click += new System.EventHandler(this.ClearCipher_Click);
            // 
            // ClearKey
            // 
            this.ClearKey.Location = new System.Drawing.Point(401, 117);
            this.ClearKey.Name = "ClearKey";
            this.ClearKey.Size = new System.Drawing.Size(62, 23);
            this.ClearKey.TabIndex = 14;
            this.ClearKey.Text = "清空密钥";
            this.ClearKey.UseVisualStyleBackColor = true;
            this.ClearKey.Click += new System.EventHandler(this.ClearKey_Click);
            // 
            // EncryptionBtn
            // 
            this.EncryptionBtn.Location = new System.Drawing.Point(191, 176);
            this.EncryptionBtn.Name = "EncryptionBtn";
            this.EncryptionBtn.Size = new System.Drawing.Size(75, 23);
            this.EncryptionBtn.TabIndex = 15;
            this.EncryptionBtn.Text = "加密→";
            this.EncryptionBtn.UseVisualStyleBackColor = true;
            this.EncryptionBtn.Click += new System.EventHandler(this.EncryptionBtn_Click);
            // 
            // DecryptionBtn
            // 
            this.DecryptionBtn.Location = new System.Drawing.Point(191, 252);
            this.DecryptionBtn.Name = "DecryptionBtn";
            this.DecryptionBtn.Size = new System.Drawing.Size(75, 23);
            this.DecryptionBtn.TabIndex = 16;
            this.DecryptionBtn.Text = "←解密";
            this.DecryptionBtn.UseVisualStyleBackColor = true;
            this.DecryptionBtn.Click += new System.EventHandler(this.DecryptionBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(476, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "请选择密钥长度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 24;
            // 
            // ClearAll
            // 
            this.ClearAll.Location = new System.Drawing.Point(400, 56);
            this.ClearAll.Name = "ClearAll";
            this.ClearAll.Size = new System.Drawing.Size(63, 23);
            this.ClearAll.TabIndex = 25;
            this.ClearAll.Text = "清空全部";
            this.ClearAll.UseVisualStyleBackColor = true;
            this.ClearAll.Click += new System.EventHandler(this.ClearAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtn3);
            this.panel1.Controls.Add(this.radioBtn2);
            this.panel1.Controls.Add(this.radioBtn1);
            this.panel1.Location = new System.Drawing.Point(12, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 28);
            this.panel1.TabIndex = 26;
            // 
            // radioBtn3
            // 
            this.radioBtn3.AutoSize = true;
            this.radioBtn3.Location = new System.Drawing.Point(210, 4);
            this.radioBtn3.Name = "radioBtn3";
            this.radioBtn3.Size = new System.Drawing.Size(65, 16);
            this.radioBtn3.TabIndex = 2;
            this.radioBtn3.Text = "256bits";
            this.radioBtn3.UseVisualStyleBackColor = true;
            this.radioBtn3.CheckedChanged += new System.EventHandler(this.radioBtn3_CheckedChanged);
            // 
            // radioBtn2
            // 
            this.radioBtn2.AutoSize = true;
            this.radioBtn2.Location = new System.Drawing.Point(100, 4);
            this.radioBtn2.Name = "radioBtn2";
            this.radioBtn2.Size = new System.Drawing.Size(65, 16);
            this.radioBtn2.TabIndex = 1;
            this.radioBtn2.Text = "192bits";
            this.radioBtn2.UseVisualStyleBackColor = true;
            this.radioBtn2.CheckedChanged += new System.EventHandler(this.radioBtn2_CheckedChanged);
            // 
            // radioBtn1
            // 
            this.radioBtn1.AutoSize = true;
            this.radioBtn1.Checked = true;
            this.radioBtn1.Location = new System.Drawing.Point(4, 4);
            this.radioBtn1.Name = "radioBtn1";
            this.radioBtn1.Size = new System.Drawing.Size(65, 16);
            this.radioBtn1.TabIndex = 0;
            this.radioBtn1.TabStop = true;
            this.radioBtn1.Text = "128bits";
            this.radioBtn1.UseVisualStyleBackColor = true;
            this.radioBtn1.CheckedChanged += new System.EventHandler(this.radioBtn1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "密钥长度为16个字符或8个汉字";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ClearAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptionBtn);
            this.Controls.Add(this.EncryptionBtn);
            this.Controls.Add(this.ClearKey);
            this.Controls.Add(this.ClearCipher);
            this.Controls.Add(this.ClearPlain);
            this.Controls.Add(this.CipherText);
            this.Controls.Add(this.CipherLabel);
            this.Controls.Add(this.PlainText);
            this.Controls.Add(this.PlianLabel);
            this.Controls.Add(this.KeyText);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AES加解密演示";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.TextBox KeyText;
        private System.Windows.Forms.Label PlianLabel;
        private System.Windows.Forms.TextBox PlainText;
        private System.Windows.Forms.Label CipherLabel;
        private System.Windows.Forms.TextBox CipherText;
        private System.Windows.Forms.Button ClearPlain;
        private System.Windows.Forms.Button ClearCipher;
        private System.Windows.Forms.Button ClearKey;
        private System.Windows.Forms.Button EncryptionBtn;
        private System.Windows.Forms.Button DecryptionBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ClearAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioBtn3;
        private System.Windows.Forms.RadioButton radioBtn2;
        private System.Windows.Forms.RadioButton radioBtn1;
        private System.Windows.Forms.Label label2;
    }
}

