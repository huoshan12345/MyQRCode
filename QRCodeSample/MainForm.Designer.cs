namespace QRCodeSample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseSimplifiedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.tabMain = new QRCodeSample.NewTabControl();
            this.tabEncode = new System.Windows.Forms.TabPage();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.txtEncodeData = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picEncode = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.cboCorrectionLevel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.cboEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtEncodeKey = new System.Windows.Forms.TextBox();
            this.cboEncryptAlgo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabDecode = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtComManager = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtBusinessScope = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtComName = new System.Windows.Forms.TextBox();
            this.txtComCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.txtDecodedData = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.picDecode = new System.Windows.Forms.PictureBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cboDecryptAlgo = new System.Windows.Forms.ComboBox();
            this.txtDecodeKey = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSelectPath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listFileFounded = new QRCodeSample.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.txtQRCodePath = new System.Windows.Forms.TextBox();
            this.btnOpen2 = new System.Windows.Forms.Button();
            this.tabBatchEncode = new System.Windows.Forms.TabPage();
            this.btnCreate = new System.Windows.Forms.Button();
            this.listFileReaded = new QRCodeSample.DoubleBufferListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label18 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnOpen3 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabEncode.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEncode)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabDecode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDecode)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tabSearch.SuspendLayout();
            this.tabBatchEncode.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.chineseSimplifiedToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage_Click);
            // 
            // chineseSimplifiedToolStripMenuItem
            // 
            this.chineseSimplifiedToolStripMenuItem.Name = "chineseSimplifiedToolStripMenuItem";
            resources.ApplyResources(this.chineseSimplifiedToolStripMenuItem, "chineseSimplifiedToolStripMenuItem");
            this.chineseSimplifiedToolStripMenuItem.Click += new System.EventHandler(this.ChangeLanguage_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabEncode);
            this.tabMain.Controls.Add(this.tabDecode);
            this.tabMain.Controls.Add(this.tabSearch);
            this.tabMain.Controls.Add(this.tabBatchEncode);
            resources.ApplyResources(this.tabMain, "tabMain");
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.ShowStatusLabel);
            // 
            // tabEncode
            // 
            this.tabEncode.Controls.Add(this.btnPrint);
            this.tabEncode.Controls.Add(this.btnSave);
            this.tabEncode.Controls.Add(this.btnEncode);
            this.tabEncode.Controls.Add(this.groupBox1);
            this.tabEncode.Controls.Add(this.groupBox2);
            this.tabEncode.Controls.Add(this.groupBox6);
            this.tabEncode.Controls.Add(this.groupBox7);
            resources.ApplyResources(this.tabEncode, "tabEncode");
            this.tabEncode.Name = "tabEncode";
            this.tabEncode.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEncode
            // 
            resources.ApplyResources(this.btnEncode, "btnEncode");
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFormat);
            this.groupBox1.Controls.Add(this.txtEncodeData);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // btnFormat
            // 
            resources.ApplyResources(this.btnFormat, "btnFormat");
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // txtEncodeData
            // 
            this.txtEncodeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtEncodeData, "txtEncodeData");
            this.txtEncodeData.Name = "txtEncodeData";
            this.txtEncodeData.TextChanged += new System.EventHandler(this.ShowStatusLabel);
            this.txtEncodeData.Enter += new System.EventHandler(this.ShowStatusLabel);
            this.txtEncodeData.Leave += new System.EventHandler(this.ShowStatusLabel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picEncode);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // picEncode
            // 
            this.picEncode.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.picEncode, "picEncode");
            this.picEncode.Name = "picEncode";
            this.picEncode.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.txtSize);
            this.groupBox6.Controls.Add(this.cboCorrectionLevel);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.cboVersion);
            this.groupBox6.Controls.Add(this.cboEncoding);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtSize
            // 
            this.txtSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSize, "txtSize");
            this.txtSize.Name = "txtSize";
            // 
            // cboCorrectionLevel
            // 
            this.cboCorrectionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboCorrectionLevel, "cboCorrectionLevel");
            this.cboCorrectionLevel.FormattingEnabled = true;
            this.cboCorrectionLevel.Items.AddRange(new object[] {
            resources.GetString("cboCorrectionLevel.Items"),
            resources.GetString("cboCorrectionLevel.Items1"),
            resources.GetString("cboCorrectionLevel.Items2"),
            resources.GetString("cboCorrectionLevel.Items3")});
            this.cboCorrectionLevel.Name = "cboCorrectionLevel";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cboVersion
            // 
            this.cboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboVersion, "cboVersion");
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Items.AddRange(new object[] {
            resources.GetString("cboVersion.Items"),
            resources.GetString("cboVersion.Items1"),
            resources.GetString("cboVersion.Items2"),
            resources.GetString("cboVersion.Items3"),
            resources.GetString("cboVersion.Items4"),
            resources.GetString("cboVersion.Items5"),
            resources.GetString("cboVersion.Items6"),
            resources.GetString("cboVersion.Items7"),
            resources.GetString("cboVersion.Items8"),
            resources.GetString("cboVersion.Items9"),
            resources.GetString("cboVersion.Items10"),
            resources.GetString("cboVersion.Items11"),
            resources.GetString("cboVersion.Items12"),
            resources.GetString("cboVersion.Items13"),
            resources.GetString("cboVersion.Items14"),
            resources.GetString("cboVersion.Items15"),
            resources.GetString("cboVersion.Items16"),
            resources.GetString("cboVersion.Items17"),
            resources.GetString("cboVersion.Items18"),
            resources.GetString("cboVersion.Items19"),
            resources.GetString("cboVersion.Items20"),
            resources.GetString("cboVersion.Items21"),
            resources.GetString("cboVersion.Items22"),
            resources.GetString("cboVersion.Items23"),
            resources.GetString("cboVersion.Items24"),
            resources.GetString("cboVersion.Items25"),
            resources.GetString("cboVersion.Items26"),
            resources.GetString("cboVersion.Items27"),
            resources.GetString("cboVersion.Items28"),
            resources.GetString("cboVersion.Items29"),
            resources.GetString("cboVersion.Items30"),
            resources.GetString("cboVersion.Items31"),
            resources.GetString("cboVersion.Items32"),
            resources.GetString("cboVersion.Items33"),
            resources.GetString("cboVersion.Items34"),
            resources.GetString("cboVersion.Items35"),
            resources.GetString("cboVersion.Items36"),
            resources.GetString("cboVersion.Items37"),
            resources.GetString("cboVersion.Items38"),
            resources.GetString("cboVersion.Items39"),
            resources.GetString("cboVersion.Items40")});
            this.cboVersion.Name = "cboVersion";
            // 
            // cboEncoding
            // 
            this.cboEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboEncoding, "cboEncoding");
            this.cboEncoding.FormattingEnabled = true;
            this.cboEncoding.Items.AddRange(new object[] {
            resources.GetString("cboEncoding.Items"),
            resources.GetString("cboEncoding.Items1"),
            resources.GetString("cboEncoding.Items2")});
            this.cboEncoding.Name = "cboEncoding";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtEncodeKey);
            this.groupBox7.Controls.Add(this.cboEncryptAlgo);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // txtEncodeKey
            // 
            this.txtEncodeKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtEncodeKey, "txtEncodeKey");
            this.txtEncodeKey.Name = "txtEncodeKey";
            // 
            // cboEncryptAlgo
            // 
            this.cboEncryptAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboEncryptAlgo, "cboEncryptAlgo");
            this.cboEncryptAlgo.FormattingEnabled = true;
            this.cboEncryptAlgo.Items.AddRange(new object[] {
            resources.GetString("cboEncryptAlgo.Items"),
            resources.GetString("cboEncryptAlgo.Items1"),
            resources.GetString("cboEncryptAlgo.Items2"),
            resources.GetString("cboEncryptAlgo.Items3")});
            this.cboEncryptAlgo.Name = "cboEncryptAlgo";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tabDecode
            // 
            this.tabDecode.Controls.Add(this.groupBox5);
            this.tabDecode.Controls.Add(this.btnOpen);
            this.tabDecode.Controls.Add(this.btnDecode);
            this.tabDecode.Controls.Add(this.groupBox3);
            this.tabDecode.Controls.Add(this.groupBox4);
            this.tabDecode.Controls.Add(this.groupBox8);
            resources.ApplyResources(this.tabDecode, "tabDecode");
            this.tabDecode.Name = "tabDecode";
            this.tabDecode.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtComManager);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.txtBusinessScope);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txtComName);
            this.groupBox5.Controls.Add(this.txtComCode);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // txtComManager
            // 
            this.txtComManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtComManager, "txtComManager");
            this.txtComManager.Name = "txtComManager";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // txtBusinessScope
            // 
            this.txtBusinessScope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtBusinessScope, "txtBusinessScope");
            this.txtBusinessScope.Name = "txtBusinessScope";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtComName
            // 
            this.txtComName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtComName, "txtComName");
            this.txtComName.Name = "txtComName";
            // 
            // txtComCode
            // 
            this.txtComCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtComCode, "txtComCode");
            this.txtComCode.Name = "txtComCode";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnOpen
            // 
            resources.ApplyResources(this.btnOpen, "btnOpen");
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDecode
            // 
            resources.ApplyResources(this.btnDecode, "btnDecode");
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnIdentify);
            this.groupBox3.Controls.Add(this.txtDecodedData);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // btnIdentify
            // 
            resources.ApplyResources(this.btnIdentify, "btnIdentify");
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // txtDecodedData
            // 
            this.txtDecodedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtDecodedData, "txtDecodedData");
            this.txtDecodedData.Name = "txtDecodedData";
            this.txtDecodedData.TextChanged += new System.EventHandler(this.ShowStatusLabel);
            this.txtDecodedData.Enter += new System.EventHandler(this.ShowStatusLabel);
            this.txtDecodedData.Leave += new System.EventHandler(this.ShowStatusLabel);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.picDecode);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // picDecode
            // 
            this.picDecode.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.picDecode, "picDecode");
            this.picDecode.Name = "picDecode";
            this.picDecode.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cboDecryptAlgo);
            this.groupBox8.Controls.Add(this.txtDecodeKey);
            this.groupBox8.Controls.Add(this.label10);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // cboDecryptAlgo
            // 
            this.cboDecryptAlgo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cboDecryptAlgo, "cboDecryptAlgo");
            this.cboDecryptAlgo.FormattingEnabled = true;
            this.cboDecryptAlgo.Items.AddRange(new object[] {
            resources.GetString("cboDecryptAlgo.Items"),
            resources.GetString("cboDecryptAlgo.Items1"),
            resources.GetString("cboDecryptAlgo.Items2"),
            resources.GetString("cboDecryptAlgo.Items3")});
            this.cboDecryptAlgo.Name = "cboDecryptAlgo";
            // 
            // txtDecodeKey
            // 
            this.txtDecodeKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtDecodeKey, "txtDecodeKey");
            this.txtDecodeKey.Name = "txtDecodeKey";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.txtSearch);
            this.tabSearch.Controls.Add(this.btnRemove);
            this.tabSearch.Controls.Add(this.label17);
            this.tabSearch.Controls.Add(this.label15);
            this.tabSearch.Controls.Add(this.label14);
            this.tabSearch.Controls.Add(this.btnSelectPath);
            this.tabSearch.Controls.Add(this.label12);
            this.tabSearch.Controls.Add(this.txtSelectPath);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Controls.Add(this.listFileFounded);
            this.tabSearch.Controls.Add(this.label11);
            this.tabSearch.Controls.Add(this.txtQRCodePath);
            this.tabSearch.Controls.Add(this.btnOpen2);
            resources.ApplyResources(this.tabSearch, "tabSearch");
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSearch, "txtSearch");
            this.txtSearch.Name = "txtSearch";
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // btnSelectPath
            // 
            resources.ApplyResources(this.btnSelectPath, "btnSelectPath");
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtSelectPath
            // 
            this.txtSelectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSelectPath, "txtSelectPath");
            this.txtSelectPath.Name = "txtSelectPath";
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listFileFounded
            // 
            this.listFileFounded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFileFounded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listFileFounded.FullRowSelect = true;
            this.listFileFounded.GridLines = true;
            resources.ApplyResources(this.listFileFounded, "listFileFounded");
            this.listFileFounded.MultiSelect = false;
            this.listFileFounded.Name = "listFileFounded";
            this.listFileFounded.UseCompatibleStateImageBehavior = false;
            this.listFileFounded.View = System.Windows.Forms.View.Details;
            this.listFileFounded.SelectedIndexChanged += new System.EventHandler(this.listFileFounded_SelectedIndexChanged);
            this.listFileFounded.DoubleClick += new System.EventHandler(this.listFileFounded_DoubleClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtQRCodePath
            // 
            this.txtQRCodePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtQRCodePath, "txtQRCodePath");
            this.txtQRCodePath.Name = "txtQRCodePath";
            // 
            // btnOpen2
            // 
            resources.ApplyResources(this.btnOpen2, "btnOpen2");
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // tabBatchEncode
            // 
            this.tabBatchEncode.Controls.Add(this.btnCreate);
            this.tabBatchEncode.Controls.Add(this.listFileReaded);
            this.tabBatchEncode.Controls.Add(this.label18);
            this.tabBatchEncode.Controls.Add(this.txtFilePath);
            this.tabBatchEncode.Controls.Add(this.btnOpen3);
            resources.ApplyResources(this.tabBatchEncode, "tabBatchEncode");
            this.tabBatchEncode.Name = "tabBatchEncode";
            this.tabBatchEncode.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // listFileReaded
            // 
            this.listFileReaded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listFileReaded.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listFileReaded.FullRowSelect = true;
            this.listFileReaded.GridLines = true;
            resources.ApplyResources(this.listFileReaded, "listFileReaded");
            this.listFileReaded.MultiSelect = false;
            this.listFileReaded.Name = "listFileReaded";
            this.listFileReaded.UseCompatibleStateImageBehavior = false;
            this.listFileReaded.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // txtFilePath
            // 
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtFilePath, "txtFilePath");
            this.txtFilePath.Name = "txtFilePath";
            // 
            // btnOpen3
            // 
            resources.ApplyResources(this.btnOpen3, "btnOpen3");
            this.btnOpen3.Name = "btnOpen3";
            this.btnOpen3.UseVisualStyleBackColor = true;
            this.btnOpen3.Click += new System.EventHandler(this.btnOpen3_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.frmSample_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabEncode.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEncode)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabDecode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDecode)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            this.tabBatchEncode.ResumeLayout(false);
            this.tabBatchEncode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NewTabControl tabMain;
        private System.Windows.Forms.TabPage tabEncode;
        private System.Windows.Forms.TabPage tabDecode;
        private System.Windows.Forms.PictureBox picEncode;
        private System.Windows.Forms.TextBox txtEncodeData;
        private System.Windows.Forms.ComboBox cboCorrectionLevel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEncoding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.TextBox txtDecodedData;
        private System.Windows.Forms.PictureBox picDecode;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chineseSimplifiedToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtComName;
        private System.Windows.Forms.TextBox txtComCode;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.ComboBox cboEncryptAlgo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEncodeKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDecodeKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboDecryptAlgo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.Button btnOpen2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQRCodePath;
        public DoubleBufferListView listFileFounded;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSelectPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtBusinessScope;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage tabBatchEncode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnOpen3;
        public System.Windows.Forms.Button btnCreate;
        public DoubleBufferListView listFileReaded;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox txtComManager;
        private System.Windows.Forms.Label label19;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        public System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtSearch;
    }
}

