namespace GD3100Debugger
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Status1", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Status2", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Status3", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "描述",
            "VCCOV",
            "VCCREGUV",
            "VSUPOV",
            "OTSD_IC",
            "OTSD",
            "OTW",
            "CLAMP",
            "DESAT",
            "SC",
            "OC"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("HU");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("HV");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("HW");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("LU");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("LV");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("LW");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "描述",
            "BIST_FAIL",
            "VDD_UVOV",
            "DTFLT",
            "SPIERR",
            "CONFCRCERR",
            "VGE_FLT",
            "WDOG_FLT",
            "COMERR",
            "VREF_UV",
            "VEE"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("HU");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("HV");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("HW");
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("LU");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("LV");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("LW");
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "描述",
            "-",
            "-",
            "-",
            "FSISO",
            "PWM",
            "PWMALT",
            "FSSTATE",
            "FSENB",
            "INTB",
            "VGE"}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("HU");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("HV");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("HW");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("LU");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("LV");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("LW");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LabelStopBit = new System.Windows.Forms.Label();
            this.LabelComPort = new System.Windows.Forms.Label();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.cbxStopBit = new System.Windows.Forms.ComboBox();
            this.LabelBaud = new System.Windows.Forms.Label();
            this.cbxBoud = new System.Windows.Forms.ComboBox();
            this.cbxComPort = new System.Windows.Forms.ComboBox();
            this.LabelVerify = new System.Windows.Forms.Label();
            this.cbxVerify = new System.Windows.Forms.ComboBox();
            this.GBoxMessageView = new System.Windows.Forms.GroupBox();
            this.btnClearData = new System.Windows.Forms.Button();
            this.checkBoxShowSend = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoNewLine = new System.Windows.Forms.CheckBox();
            this.tbxData = new System.Windows.Forms.RichTextBox();
            this.checkBoxShowInHex = new System.Windows.Forms.CheckBox();
            this.tbxReceiveCount = new System.Windows.Forms.TextBox();
            this.LabelReceiveCount = new System.Windows.Forms.Label();
            this.tbxSendCount = new System.Windows.Forms.TextBox();
            this.LabelSendCount = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.checkBoxCfgAllEn = new System.Windows.Forms.CheckBox();
            this.checkedListBoxCfgEn = new System.Windows.Forms.CheckedListBox();
            this.btnCfgMskReg = new System.Windows.Forms.Button();
            this.btnCfgCfgReg = new System.Windows.Forms.Button();
            this.btnCfgModeReg = new System.Windows.Forms.Button();
            this.btnCfgAllReg = new System.Windows.Forms.Button();
            this.tabPageSendData = new System.Windows.Forms.TabPage();
            this.btnStopSendFile = new System.Windows.Forms.Button();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.LabelProtocol = new System.Windows.Forms.Label();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.cbxProtocol = new System.Windows.Forms.ComboBox();
            this.tbxSend = new System.Windows.Forms.TextBox();
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.tbxCycle = new System.Windows.Forms.TextBox();
            this.checkBoxSendNewLine = new System.Windows.Forms.CheckBox();
            this.checkBoxSendHex = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.checkBoxSendRegular = new System.Windows.Forms.CheckBox();
            this.pgrsBarSendPgrs = new System.Windows.Forms.ProgressBar();
            this.LabelCycle = new System.Windows.Forms.Label();
            this.tabControlSendMode = new System.Windows.Forms.TabControl();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.StatusRegName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusRegBit0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GBoxUartSet = new System.Windows.Forms.GroupBox();
            this.GBoxMessageView.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tabPageSendData.SuspendLayout();
            this.tabControlSendMode.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.GBoxUartSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelStopBit
            // 
            this.LabelStopBit.AutoSize = true;
            this.LabelStopBit.Location = new System.Drawing.Point(6, 93);
            this.LabelStopBit.Name = "LabelStopBit";
            this.LabelStopBit.Size = new System.Drawing.Size(53, 12);
            this.LabelStopBit.TabIndex = 2;
            this.LabelStopBit.Text = "停止位：";
            // 
            // LabelComPort
            // 
            this.LabelComPort.AutoSize = true;
            this.LabelComPort.Location = new System.Drawing.Point(6, 23);
            this.LabelComPort.Name = "LabelComPort";
            this.LabelComPort.Size = new System.Drawing.Size(53, 12);
            this.LabelComPort.TabIndex = 0;
            this.LabelComPort.Text = "串口号：";
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCom.Location = new System.Drawing.Point(123, 142);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(67, 28);
            this.btnOpenCom.TabIndex = 10;
            this.btnOpenCom.Text = "打开串口";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // cbxStopBit
            // 
            this.cbxStopBit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopBit.FormattingEnabled = true;
            this.cbxStopBit.Location = new System.Drawing.Point(77, 90);
            this.cbxStopBit.Name = "cbxStopBit";
            this.cbxStopBit.Size = new System.Drawing.Size(113, 20);
            this.cbxStopBit.TabIndex = 5;
            this.cbxStopBit.SelectedIndexChanged += new System.EventHandler(this.cbxStopBit_SelectedIndexChanged);
            // 
            // LabelBaud
            // 
            this.LabelBaud.AutoSize = true;
            this.LabelBaud.Location = new System.Drawing.Point(6, 67);
            this.LabelBaud.Name = "LabelBaud";
            this.LabelBaud.Size = new System.Drawing.Size(53, 12);
            this.LabelBaud.TabIndex = 1;
            this.LabelBaud.Text = "波特率：";
            // 
            // cbxBoud
            // 
            this.cbxBoud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxBoud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBoud.FormattingEnabled = true;
            this.cbxBoud.Location = new System.Drawing.Point(77, 64);
            this.cbxBoud.Name = "cbxBoud";
            this.cbxBoud.Size = new System.Drawing.Size(113, 20);
            this.cbxBoud.TabIndex = 4;
            this.cbxBoud.SelectedIndexChanged += new System.EventHandler(this.cbxBoud_SelectedIndexChanged);
            this.cbxBoud.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbxBoud_KeyDown);
            this.cbxBoud.Leave += new System.EventHandler(this.cbxBoud_Leave);
            // 
            // cbxComPort
            // 
            this.cbxComPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxComPort.FormattingEnabled = true;
            this.cbxComPort.Location = new System.Drawing.Point(8, 38);
            this.cbxComPort.Name = "cbxComPort";
            this.cbxComPort.Size = new System.Drawing.Size(182, 20);
            this.cbxComPort.TabIndex = 3;
            this.cbxComPort.DropDown += new System.EventHandler(this.cbxComPort_DropDown);
            this.cbxComPort.SelectedIndexChanged += new System.EventHandler(this.cbxComPort_SelectedIndexChanged);
            // 
            // LabelVerify
            // 
            this.LabelVerify.AutoSize = true;
            this.LabelVerify.Location = new System.Drawing.Point(6, 119);
            this.LabelVerify.Name = "LabelVerify";
            this.LabelVerify.Size = new System.Drawing.Size(65, 12);
            this.LabelVerify.TabIndex = 6;
            this.LabelVerify.Text = "奇偶校验：";
            // 
            // cbxVerify
            // 
            this.cbxVerify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxVerify.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVerify.FormattingEnabled = true;
            this.cbxVerify.Location = new System.Drawing.Point(77, 116);
            this.cbxVerify.Name = "cbxVerify";
            this.cbxVerify.Size = new System.Drawing.Size(113, 20);
            this.cbxVerify.TabIndex = 8;
            this.cbxVerify.SelectedIndexChanged += new System.EventHandler(this.cbxVerify_SelectedIndexChanged);
            // 
            // GBoxMessageView
            // 
            this.GBoxMessageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBoxMessageView.Controls.Add(this.btnClearData);
            this.GBoxMessageView.Controls.Add(this.checkBoxShowSend);
            this.GBoxMessageView.Controls.Add(this.checkBoxAutoNewLine);
            this.GBoxMessageView.Controls.Add(this.tbxData);
            this.GBoxMessageView.Controls.Add(this.checkBoxShowInHex);
            this.GBoxMessageView.Controls.Add(this.tbxReceiveCount);
            this.GBoxMessageView.Controls.Add(this.LabelReceiveCount);
            this.GBoxMessageView.Controls.Add(this.tbxSendCount);
            this.GBoxMessageView.Controls.Add(this.LabelSendCount);
            this.GBoxMessageView.Location = new System.Drawing.Point(12, 12);
            this.GBoxMessageView.Name = "GBoxMessageView";
            this.GBoxMessageView.Size = new System.Drawing.Size(494, 233);
            this.GBoxMessageView.TabIndex = 0;
            this.GBoxMessageView.TabStop = false;
            this.GBoxMessageView.Text = "数据显示";
            // 
            // btnClearData
            // 
            this.btnClearData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearData.Location = new System.Drawing.Point(413, 198);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 28);
            this.btnClearData.TabIndex = 0;
            this.btnClearData.Text = "清空数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // checkBoxShowSend
            // 
            this.checkBoxShowSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowSend.AutoSize = true;
            this.checkBoxShowSend.Checked = true;
            this.checkBoxShowSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSend.Location = new System.Drawing.Point(156, 205);
            this.checkBoxShowSend.Name = "checkBoxShowSend";
            this.checkBoxShowSend.Size = new System.Drawing.Size(72, 16);
            this.checkBoxShowSend.TabIndex = 31;
            this.checkBoxShowSend.Text = "显示发送";
            this.checkBoxShowSend.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoNewLine
            // 
            this.checkBoxAutoNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxAutoNewLine.AutoSize = true;
            this.checkBoxAutoNewLine.Location = new System.Drawing.Point(78, 205);
            this.checkBoxAutoNewLine.Name = "checkBoxAutoNewLine";
            this.checkBoxAutoNewLine.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoNewLine.TabIndex = 30;
            this.checkBoxAutoNewLine.Text = "自动换行";
            this.checkBoxAutoNewLine.UseVisualStyleBackColor = true;
            this.checkBoxAutoNewLine.CheckedChanged += new System.EventHandler(this.checkBoxAutoNewLine_CheckedChanged);
            // 
            // tbxData
            // 
            this.tbxData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxData.CausesValidation = false;
            this.tbxData.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxData.Location = new System.Drawing.Point(6, 20);
            this.tbxData.Name = "tbxData";
            this.tbxData.ReadOnly = true;
            this.tbxData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbxData.Size = new System.Drawing.Size(482, 172);
            this.tbxData.TabIndex = 29;
            this.tbxData.Text = "";
            // 
            // checkBoxShowInHex
            // 
            this.checkBoxShowInHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowInHex.AutoSize = true;
            this.checkBoxShowInHex.Location = new System.Drawing.Point(6, 205);
            this.checkBoxShowInHex.Name = "checkBoxShowInHex";
            this.checkBoxShowInHex.Size = new System.Drawing.Size(66, 16);
            this.checkBoxShowInHex.TabIndex = 28;
            this.checkBoxShowInHex.Text = "Hex显示";
            this.checkBoxShowInHex.UseVisualStyleBackColor = true;
            this.checkBoxShowInHex.CheckedChanged += new System.EventHandler(this.checkBoxShowInHex_CheckedChanged);
            // 
            // tbxReceiveCount
            // 
            this.tbxReceiveCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxReceiveCount.CausesValidation = false;
            this.tbxReceiveCount.Location = new System.Drawing.Point(358, 203);
            this.tbxReceiveCount.Name = "tbxReceiveCount";
            this.tbxReceiveCount.ReadOnly = true;
            this.tbxReceiveCount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxReceiveCount.Size = new System.Drawing.Size(48, 21);
            this.tbxReceiveCount.TabIndex = 27;
            // 
            // LabelReceiveCount
            // 
            this.LabelReceiveCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelReceiveCount.AutoSize = true;
            this.LabelReceiveCount.ForeColor = System.Drawing.Color.Blue;
            this.LabelReceiveCount.Location = new System.Drawing.Point(323, 206);
            this.LabelReceiveCount.Name = "LabelReceiveCount";
            this.LabelReceiveCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelReceiveCount.Size = new System.Drawing.Size(29, 12);
            this.LabelReceiveCount.TabIndex = 26;
            this.LabelReceiveCount.Text = "接收";
            // 
            // tbxSendCount
            // 
            this.tbxSendCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxSendCount.CausesValidation = false;
            this.tbxSendCount.Location = new System.Drawing.Point(269, 203);
            this.tbxSendCount.Name = "tbxSendCount";
            this.tbxSendCount.ReadOnly = true;
            this.tbxSendCount.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSendCount.Size = new System.Drawing.Size(48, 21);
            this.tbxSendCount.TabIndex = 25;
            // 
            // LabelSendCount
            // 
            this.LabelSendCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelSendCount.AutoSize = true;
            this.LabelSendCount.ForeColor = System.Drawing.Color.OrangeRed;
            this.LabelSendCount.Location = new System.Drawing.Point(234, 206);
            this.LabelSendCount.Name = "LabelSendCount";
            this.LabelSendCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelSendCount.Size = new System.Drawing.Size(29, 12);
            this.LabelSendCount.TabIndex = 24;
            this.LabelSendCount.Text = "发送";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.AutoScroll = true;
            this.tabPageConfig.Controls.Add(this.checkBoxCfgAllEn);
            this.tabPageConfig.Controls.Add(this.checkedListBoxCfgEn);
            this.tabPageConfig.Controls.Add(this.btnCfgMskReg);
            this.tabPageConfig.Controls.Add(this.btnCfgCfgReg);
            this.tabPageConfig.Controls.Add(this.btnCfgModeReg);
            this.tabPageConfig.Controls.Add(this.btnCfgAllReg);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(692, 130);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "配置参数";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // checkBoxCfgAllEn
            // 
            this.checkBoxCfgAllEn.AutoSize = true;
            this.checkBoxCfgAllEn.Location = new System.Drawing.Point(152, 6);
            this.checkBoxCfgAllEn.Name = "checkBoxCfgAllEn";
            this.checkBoxCfgAllEn.Size = new System.Drawing.Size(132, 16);
            this.checkBoxCfgAllEn.TabIndex = 6;
            this.checkBoxCfgAllEn.Text = "使能所有GD3100配置";
            this.checkBoxCfgAllEn.UseVisualStyleBackColor = true;
            this.checkBoxCfgAllEn.Click += new System.EventHandler(this.CheckBoxCfgAllEn_Click);
            // 
            // checkedListBoxCfgEn
            // 
            this.checkedListBoxCfgEn.CheckOnClick = true;
            this.checkedListBoxCfgEn.FormattingEnabled = true;
            this.checkedListBoxCfgEn.Items.AddRange(new object[] {
            "使能HU配置",
            "使能HV配置",
            "使能HW配置",
            "使能LU配置",
            "使能LV配置",
            "使能LW配置"});
            this.checkedListBoxCfgEn.Location = new System.Drawing.Point(152, 23);
            this.checkedListBoxCfgEn.Name = "checkedListBoxCfgEn";
            this.checkedListBoxCfgEn.Size = new System.Drawing.Size(133, 100);
            this.checkedListBoxCfgEn.TabIndex = 5;
            this.checkedListBoxCfgEn.SelectedIndexChanged += new System.EventHandler(this.CheckedListBoxCfgEn_SelectedIndexChanged);
            // 
            // btnCfgMskReg
            // 
            this.btnCfgMskReg.Location = new System.Drawing.Point(7, 94);
            this.btnCfgMskReg.Name = "btnCfgMskReg";
            this.btnCfgMskReg.Size = new System.Drawing.Size(106, 23);
            this.btnCfgMskReg.TabIndex = 3;
            this.btnCfgMskReg.Text = "Mask寄存器";
            this.btnCfgMskReg.UseVisualStyleBackColor = true;
            // 
            // btnCfgCfgReg
            // 
            this.btnCfgCfgReg.Location = new System.Drawing.Point(7, 65);
            this.btnCfgCfgReg.Name = "btnCfgCfgReg";
            this.btnCfgCfgReg.Size = new System.Drawing.Size(106, 23);
            this.btnCfgCfgReg.TabIndex = 2;
            this.btnCfgCfgReg.Text = "Config寄存器";
            this.btnCfgCfgReg.UseVisualStyleBackColor = true;
            // 
            // btnCfgModeReg
            // 
            this.btnCfgModeReg.Location = new System.Drawing.Point(7, 36);
            this.btnCfgModeReg.Name = "btnCfgModeReg";
            this.btnCfgModeReg.Size = new System.Drawing.Size(106, 23);
            this.btnCfgModeReg.TabIndex = 1;
            this.btnCfgModeReg.Text = "Mode寄存器";
            this.btnCfgModeReg.UseVisualStyleBackColor = true;
            // 
            // btnCfgAllReg
            // 
            this.btnCfgAllReg.Location = new System.Drawing.Point(7, 7);
            this.btnCfgAllReg.Name = "btnCfgAllReg";
            this.btnCfgAllReg.Size = new System.Drawing.Size(106, 23);
            this.btnCfgAllReg.TabIndex = 0;
            this.btnCfgAllReg.Text = "所有寄存器";
            this.btnCfgAllReg.UseVisualStyleBackColor = true;
            this.btnCfgAllReg.Click += new System.EventHandler(this.BtnCfgAllReg_Click);
            // 
            // tabPageSendData
            // 
            this.tabPageSendData.Controls.Add(this.btnStopSendFile);
            this.tabPageSendData.Controls.Add(this.btnSendFile);
            this.tabPageSendData.Controls.Add(this.btnOpenFile);
            this.tabPageSendData.Controls.Add(this.LabelProgress);
            this.tabPageSendData.Controls.Add(this.LabelProtocol);
            this.tabPageSendData.Controls.Add(this.btnClearSend);
            this.tabPageSendData.Controls.Add(this.cbxProtocol);
            this.tabPageSendData.Controls.Add(this.tbxSend);
            this.tabPageSendData.Controls.Add(this.textBoxFileName);
            this.tabPageSendData.Controls.Add(this.tbxCycle);
            this.tabPageSendData.Controls.Add(this.checkBoxSendNewLine);
            this.tabPageSendData.Controls.Add(this.checkBoxSendHex);
            this.tabPageSendData.Controls.Add(this.btnSend);
            this.tabPageSendData.Controls.Add(this.checkBoxSendRegular);
            this.tabPageSendData.Controls.Add(this.pgrsBarSendPgrs);
            this.tabPageSendData.Controls.Add(this.LabelCycle);
            this.tabPageSendData.Location = new System.Drawing.Point(4, 22);
            this.tabPageSendData.Name = "tabPageSendData";
            this.tabPageSendData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSendData.Size = new System.Drawing.Size(692, 130);
            this.tabPageSendData.TabIndex = 0;
            this.tabPageSendData.Text = "数据发送";
            this.tabPageSendData.UseVisualStyleBackColor = true;
            // 
            // btnStopSendFile
            // 
            this.btnStopSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopSendFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStopSendFile.Location = new System.Drawing.Point(611, 71);
            this.btnStopSendFile.Name = "btnStopSendFile";
            this.btnStopSendFile.Size = new System.Drawing.Size(75, 28);
            this.btnStopSendFile.TabIndex = 20;
            this.btnStopSendFile.Text = "停止发送";
            this.btnStopSendFile.UseVisualStyleBackColor = true;
            this.btnStopSendFile.Click += new System.EventHandler(this.btnStopSendFile_Click);
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSendFile.Location = new System.Drawing.Point(530, 72);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 28);
            this.btnSendFile.TabIndex = 19;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOpenFile.Location = new System.Drawing.Point(449, 72);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 28);
            this.btnOpenFile.TabIndex = 18;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // LabelProgress
            // 
            this.LabelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelProgress.AutoSize = true;
            this.LabelProgress.Location = new System.Drawing.Point(449, 109);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelProgress.Size = new System.Drawing.Size(17, 12);
            this.LabelProgress.TabIndex = 22;
            this.LabelProgress.Text = "0%";
            // 
            // LabelProtocol
            // 
            this.LabelProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelProtocol.AutoSize = true;
            this.LabelProtocol.Location = new System.Drawing.Point(472, 109);
            this.LabelProtocol.Name = "LabelProtocol";
            this.LabelProtocol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelProtocol.Size = new System.Drawing.Size(41, 12);
            this.LabelProtocol.TabIndex = 23;
            this.LabelProtocol.Text = "协议：";
            // 
            // btnClearSend
            // 
            this.btnClearSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClearSend.Location = new System.Drawing.Point(611, 38);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(75, 28);
            this.btnClearSend.TabIndex = 2;
            this.btnClearSend.Text = "清除发送";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // cbxProtocol
            // 
            this.cbxProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProtocol.FormattingEnabled = true;
            this.cbxProtocol.Location = new System.Drawing.Point(519, 106);
            this.cbxProtocol.Name = "cbxProtocol";
            this.cbxProtocol.Size = new System.Drawing.Size(167, 20);
            this.cbxProtocol.TabIndex = 13;
            this.cbxProtocol.SelectedIndexChanged += new System.EventHandler(this.cbxProtocol_SelectedIndexChanged);
            // 
            // tbxSend
            // 
            this.tbxSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSend.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxSend.Location = new System.Drawing.Point(6, 6);
            this.tbxSend.Multiline = true;
            this.tbxSend.Name = "tbxSend";
            this.tbxSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxSend.Size = new System.Drawing.Size(599, 60);
            this.tbxSend.TabIndex = 0;
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFileName.Location = new System.Drawing.Point(173, 76);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.ReadOnly = true;
            this.textBoxFileName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFileName.Size = new System.Drawing.Size(270, 21);
            this.textBoxFileName.TabIndex = 17;
            this.textBoxFileName.Text = "请打开文件";
            // 
            // tbxCycle
            // 
            this.tbxCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCycle.CausesValidation = false;
            this.tbxCycle.Location = new System.Drawing.Point(119, 103);
            this.tbxCycle.MaxLength = 10;
            this.tbxCycle.Name = "tbxCycle";
            this.tbxCycle.Size = new System.Drawing.Size(48, 21);
            this.tbxCycle.TabIndex = 16;
            this.tbxCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbxCycle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxCycle_KeyPress);
            this.tbxCycle.Leave += new System.EventHandler(this.tbxCycle_Leave);
            // 
            // checkBoxSendNewLine
            // 
            this.checkBoxSendNewLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSendNewLine.AutoSize = true;
            this.checkBoxSendNewLine.Location = new System.Drawing.Point(86, 78);
            this.checkBoxSendNewLine.Name = "checkBoxSendNewLine";
            this.checkBoxSendNewLine.Size = new System.Drawing.Size(72, 16);
            this.checkBoxSendNewLine.TabIndex = 25;
            this.checkBoxSendNewLine.Text = "发送新行";
            this.checkBoxSendNewLine.UseVisualStyleBackColor = true;
            this.checkBoxSendNewLine.CheckedChanged += new System.EventHandler(this.checkBoxSendNewLine_CheckedChanged);
            // 
            // checkBoxSendHex
            // 
            this.checkBoxSendHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSendHex.AutoSize = true;
            this.checkBoxSendHex.Location = new System.Drawing.Point(6, 78);
            this.checkBoxSendHex.Name = "checkBoxSendHex";
            this.checkBoxSendHex.Size = new System.Drawing.Size(66, 16);
            this.checkBoxSendHex.TabIndex = 24;
            this.checkBoxSendHex.Text = "Hex发送";
            this.checkBoxSendHex.UseVisualStyleBackColor = true;
            this.checkBoxSendHex.CheckedChanged += new System.EventHandler(this.checkBoxSendHex_CheckedChanged);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSend.Location = new System.Drawing.Point(611, 6);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 28);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // checkBoxSendRegular
            // 
            this.checkBoxSendRegular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSendRegular.AutoSize = true;
            this.checkBoxSendRegular.Location = new System.Drawing.Point(6, 105);
            this.checkBoxSendRegular.Name = "checkBoxSendRegular";
            this.checkBoxSendRegular.Size = new System.Drawing.Size(72, 16);
            this.checkBoxSendRegular.TabIndex = 26;
            this.checkBoxSendRegular.Text = "定时发送";
            this.checkBoxSendRegular.UseVisualStyleBackColor = true;
            this.checkBoxSendRegular.CheckedChanged += new System.EventHandler(this.checkBoxSendRegular_CheckedChanged);
            // 
            // pgrsBarSendPgrs
            // 
            this.pgrsBarSendPgrs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgrsBarSendPgrs.Location = new System.Drawing.Point(173, 103);
            this.pgrsBarSendPgrs.Name = "pgrsBarSendPgrs";
            this.pgrsBarSendPgrs.Size = new System.Drawing.Size(270, 21);
            this.pgrsBarSendPgrs.Step = 1;
            this.pgrsBarSendPgrs.TabIndex = 21;
            // 
            // LabelCycle
            // 
            this.LabelCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelCycle.AutoSize = true;
            this.LabelCycle.Location = new System.Drawing.Point(84, 106);
            this.LabelCycle.Name = "LabelCycle";
            this.LabelCycle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelCycle.Size = new System.Drawing.Size(29, 12);
            this.LabelCycle.TabIndex = 15;
            this.LabelCycle.Text = "周期";
            // 
            // tabControlSendMode
            // 
            this.tabControlSendMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSendMode.Controls.Add(this.tabPageSendData);
            this.tabControlSendMode.Controls.Add(this.tabPageConfig);
            this.tabControlSendMode.Controls.Add(this.tabPageStatus);
            this.tabControlSendMode.Location = new System.Drawing.Point(12, 251);
            this.tabControlSendMode.Name = "tabControlSendMode";
            this.tabControlSendMode.SelectedIndex = 0;
            this.tabControlSendMode.Size = new System.Drawing.Size(700, 156);
            this.tabControlSendMode.TabIndex = 1;
            this.tabControlSendMode.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlSendMode_Selecting);
            this.tabControlSendMode.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlSendMode_Selected);
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.listView1);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Size = new System.Drawing.Size(692, 130);
            this.tabPageStatus.TabIndex = 2;
            this.tabPageStatus.Text = "状态监控";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StatusRegName,
            this.StatusRegBit9,
            this.StatusRegBit8,
            this.StatusRegBit7,
            this.StatusRegBit6,
            this.StatusRegBit5,
            this.StatusRegBit4,
            this.StatusRegBit3,
            this.StatusRegBit2,
            this.StatusRegBit1,
            this.StatusRegBit0});
            this.listView1.FullRowSelect = true;
            listViewGroup1.Header = "Status1";
            listViewGroup1.Name = "listViewGroupStatus1";
            listViewGroup1.Tag = "Status1";
            listViewGroup2.Header = "Status2";
            listViewGroup2.Name = "listViewGroupStatus2";
            listViewGroup2.Tag = "Status2";
            listViewGroup3.Header = "Status3";
            listViewGroup3.Name = "listViewGroupStatus3";
            listViewGroup3.Tag = "Status3";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.listView1.HideSelection = false;
            this.listView1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup1;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            listViewItem5.Group = listViewGroup1;
            listViewItem6.Group = listViewGroup1;
            listViewItem7.Group = listViewGroup1;
            listViewItem8.Group = listViewGroup2;
            listViewItem9.Group = listViewGroup2;
            listViewItem10.Group = listViewGroup2;
            listViewItem11.Group = listViewGroup2;
            listViewItem12.Group = listViewGroup2;
            listViewItem13.Group = listViewGroup2;
            listViewItem14.Group = listViewGroup2;
            listViewItem15.Group = listViewGroup3;
            listViewItem16.Group = listViewGroup3;
            listViewItem17.Group = listViewGroup3;
            listViewItem18.Group = listViewGroup3;
            listViewItem19.Group = listViewGroup3;
            listViewItem20.Group = listViewGroup3;
            listViewItem21.Group = listViewGroup3;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14,
            listViewItem15,
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21});
            this.listView1.Location = new System.Drawing.Point(4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(682, 122);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // StatusRegName
            // 
            this.StatusRegName.Text = "寄存器";
            // 
            // StatusRegBit9
            // 
            this.StatusRegBit9.Text = "bit9";
            this.StatusRegBit9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit8
            // 
            this.StatusRegBit8.Text = "bit8";
            this.StatusRegBit8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit7
            // 
            this.StatusRegBit7.Text = "bit7";
            this.StatusRegBit7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit6
            // 
            this.StatusRegBit6.Text = "bit6";
            this.StatusRegBit6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit5
            // 
            this.StatusRegBit5.Text = "bit5";
            this.StatusRegBit5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit4
            // 
            this.StatusRegBit4.Text = "bit4";
            this.StatusRegBit4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit3
            // 
            this.StatusRegBit3.Text = "bit3";
            this.StatusRegBit3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit2
            // 
            this.StatusRegBit2.Text = "bit2";
            this.StatusRegBit2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit1
            // 
            this.StatusRegBit1.Text = "bit1";
            this.StatusRegBit1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusRegBit0
            // 
            this.StatusRegBit0.Text = "bit0";
            this.StatusRegBit0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GBoxUartSet
            // 
            this.GBoxUartSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GBoxUartSet.Controls.Add(this.LabelStopBit);
            this.GBoxUartSet.Controls.Add(this.LabelComPort);
            this.GBoxUartSet.Controls.Add(this.cbxBoud);
            this.GBoxUartSet.Controls.Add(this.cbxVerify);
            this.GBoxUartSet.Controls.Add(this.LabelBaud);
            this.GBoxUartSet.Controls.Add(this.btnOpenCom);
            this.GBoxUartSet.Controls.Add(this.cbxComPort);
            this.GBoxUartSet.Controls.Add(this.LabelVerify);
            this.GBoxUartSet.Controls.Add(this.cbxStopBit);
            this.GBoxUartSet.Location = new System.Drawing.Point(512, 12);
            this.GBoxUartSet.Name = "GBoxUartSet";
            this.GBoxUartSet.Size = new System.Drawing.Size(196, 233);
            this.GBoxUartSet.TabIndex = 32;
            this.GBoxUartSet.TabStop = false;
            this.GBoxUartSet.Text = "串口设置";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 411);
            this.Controls.Add(this.GBoxUartSet);
            this.Controls.Add(this.tabControlSendMode);
            this.Controls.Add(this.GBoxMessageView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 450);
            this.Name = "Form1";
            this.Text = "GD3100 Debugger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GBoxMessageView.ResumeLayout(false);
            this.GBoxMessageView.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tabPageSendData.ResumeLayout(false);
            this.tabPageSendData.PerformLayout();
            this.tabControlSendMode.ResumeLayout(false);
            this.tabPageStatus.ResumeLayout(false);
            this.GBoxUartSet.ResumeLayout(false);
            this.GBoxUartSet.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.GroupBox GBoxMessageView;
		private System.Windows.Forms.ComboBox cbxComPort;
		private System.Windows.Forms.Label LabelStopBit;
		private System.Windows.Forms.Label LabelBaud;
		private System.Windows.Forms.Label LabelComPort;
		private System.Windows.Forms.ComboBox cbxStopBit;
		private System.Windows.Forms.ComboBox cbxBoud;
		private System.Windows.Forms.Button btnOpenCom;
		private System.Windows.Forms.ComboBox cbxVerify;
		private System.Windows.Forms.Label LabelVerify;
		private System.Windows.Forms.Button btnClearData;
		private System.Windows.Forms.TextBox tbxReceiveCount;
		private System.Windows.Forms.Label LabelReceiveCount;
		private System.Windows.Forms.TextBox tbxSendCount;
		private System.Windows.Forms.Label LabelSendCount;
		private System.Windows.Forms.CheckBox checkBoxShowInHex;
		private System.Windows.Forms.RichTextBox tbxData;
		private System.IO.Ports.SerialPort serialPort1;
		private System.Windows.Forms.CheckBox checkBoxAutoNewLine;
		private System.Windows.Forms.TabPage tabPageConfig;
		private System.Windows.Forms.TabPage tabPageSendData;
		private System.Windows.Forms.Button btnStopSendFile;
		private System.Windows.Forms.Button btnSendFile;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Label LabelProgress;
		private System.Windows.Forms.Label LabelProtocol;
		private System.Windows.Forms.Button btnClearSend;
		private System.Windows.Forms.ComboBox cbxProtocol;
		private System.Windows.Forms.TextBox tbxSend;
		private System.Windows.Forms.TextBox textBoxFileName;
		private System.Windows.Forms.CheckBox checkBoxSendNewLine;
		private System.Windows.Forms.CheckBox checkBoxSendHex;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.CheckBox checkBoxSendRegular;
		private System.Windows.Forms.ProgressBar pgrsBarSendPgrs;
		private System.Windows.Forms.Label LabelCycle;
		private System.Windows.Forms.TabControl tabControlSendMode;
		private System.Windows.Forms.CheckBox checkBoxShowSend;
        private System.Windows.Forms.TextBox tbxCycle;
        private System.Windows.Forms.GroupBox GBoxUartSet;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader StatusRegName;
        private System.Windows.Forms.ColumnHeader StatusRegBit9;
        private System.Windows.Forms.ColumnHeader StatusRegBit8;
        private System.Windows.Forms.ColumnHeader StatusRegBit7;
        private System.Windows.Forms.ColumnHeader StatusRegBit6;
        private System.Windows.Forms.ColumnHeader StatusRegBit5;
        private System.Windows.Forms.ColumnHeader StatusRegBit4;
        private System.Windows.Forms.ColumnHeader StatusRegBit3;
        private System.Windows.Forms.ColumnHeader StatusRegBit2;
        private System.Windows.Forms.ColumnHeader StatusRegBit1;
        private System.Windows.Forms.ColumnHeader StatusRegBit0;
        private System.Windows.Forms.Button btnCfgModeReg;
        private System.Windows.Forms.Button btnCfgAllReg;
        private System.Windows.Forms.Button btnCfgCfgReg;
        private System.Windows.Forms.CheckedListBox checkedListBoxCfgEn;
        private System.Windows.Forms.Button btnCfgMskReg;
        private System.Windows.Forms.CheckBox checkBoxCfgAllEn;
    }
}

