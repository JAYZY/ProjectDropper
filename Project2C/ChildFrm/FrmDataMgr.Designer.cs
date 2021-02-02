namespace Project2C.ChildFrm {
    partial class FrmDataMgr {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDataMgr));
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lblDBPath = new System.Windows.Forms.LinkLabel();
            this.btnTaskOk = new DevComponents.DotNetBar.ButtonX();
            this.btnOpenDir = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cbHasBaseData = new System.Windows.Forms.CheckBox();
            this.cbBoxUpDown = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.btnLoadBaseData = new DevComponents.DotNetBar.ButtonX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dateTimeInput = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbEndStation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbStartStation = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbStationName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblStationName1 = new DevComponents.DotNetBar.LabelX();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBarX2 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.lblProcessA = new System.Windows.Forms.Label();
            this.lblProcessB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblDbFilesNumA = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDbFilesNumB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblIndexImgNumA = new System.Windows.Forms.Label();
            this.lblIndexImgNumB = new System.Windows.Forms.Label();
            this.lblIndexTaskDir = new System.Windows.Forms.LinkLabel();
            this.btnProcessDb = new DevComponents.DotNetBar.ButtonX();
            this.btnSelIndexTaskDir = new DevComponents.DotNetBar.ButtonX();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput)).BeginInit();
            this.superTabControlPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Location = new System.Drawing.Point(420, 293);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("等线", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(724, 299);
            this.superTabControl1.TabFont = new System.Drawing.Font("等线", 10F);
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem1});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.CanvasColor = System.Drawing.SystemColors.ControlDarkDark;
            this.superTabControlPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.superTabControlPanel2.Controls.Add(this.lblDBPath);
            this.superTabControlPanel2.Controls.Add(this.btnTaskOk);
            this.superTabControlPanel2.Controls.Add(this.btnOpenDir);
            this.superTabControlPanel2.Controls.Add(this.groupPanel1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Font = new System.Drawing.Font("等线", 10F);
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(724, 273);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // lblDBPath
            // 
            this.lblDBPath.AutoSize = true;
            this.lblDBPath.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDBPath.Location = new System.Drawing.Point(174, 23);
            this.lblDBPath.Name = "lblDBPath";
            this.lblDBPath.Size = new System.Drawing.Size(70, 19);
            this.lblDBPath.TabIndex = 21;
            this.lblDBPath.TabStop = true;
            this.lblDBPath.Text = "linkLabel1";
            this.lblDBPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDBPath_LinkClicked);
            // 
            // btnTaskOk
            // 
            this.btnTaskOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaskOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTaskOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskOk.Location = new System.Drawing.Point(573, 223);
            this.btnTaskOk.Name = "btnTaskOk";
            this.btnTaskOk.Size = new System.Drawing.Size(91, 38);
            this.btnTaskOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTaskOk.TabIndex = 20;
            this.btnTaskOk.Text = "选择确定";
            this.btnTaskOk.Click += new System.EventHandler(this.btnTaskOk_Click);
            // 
            // btnOpenDir
            // 
            this.btnOpenDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOpenDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOpenDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenDir.Location = new System.Drawing.Point(68, 15);
            this.btnOpenDir.Name = "btnOpenDir";
            this.btnOpenDir.Size = new System.Drawing.Size(100, 33);
            this.btnOpenDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOpenDir.TabIndex = 8;
            this.btnOpenDir.Text = "任务目录选择";
            this.btnOpenDir.Click += new System.EventHandler(this.btnOpenDir_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cbHasBaseData);
            this.groupPanel1.Controls.Add(this.cbBoxUpDown);
            this.groupPanel1.Controls.Add(this.btnLoadBaseData);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.dateTimeInput);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.tbEndStation);
            this.groupPanel1.Controls.Add(this.tbStartStation);
            this.groupPanel1.Controls.Add(this.tbStationName);
            this.groupPanel1.Controls.Add(this.lblStationName1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(66, 59);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(598, 158);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 18;
            this.groupPanel1.Text = "任务信息";
            // 
            // cbHasBaseData
            // 
            this.cbHasBaseData.AutoSize = true;
            this.cbHasBaseData.Enabled = false;
            this.cbHasBaseData.Location = new System.Drawing.Point(10, 105);
            this.cbHasBaseData.Name = "cbHasBaseData";
            this.cbHasBaseData.Size = new System.Drawing.Size(110, 18);
            this.cbHasBaseData.TabIndex = 20;
            this.cbHasBaseData.Text = "基础线路数据";
            this.cbHasBaseData.UseVisualStyleBackColor = true;
            // 
            // cbBoxUpDown
            // 
            this.cbBoxUpDown.DisplayMember = "Text";
            this.cbBoxUpDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxUpDown.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbBoxUpDown.FormattingEnabled = true;
            this.cbBoxUpDown.ItemHeight = 19;
            this.cbBoxUpDown.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cbBoxUpDown.Location = new System.Drawing.Point(409, 65);
            this.cbBoxUpDown.Name = "cbBoxUpDown";
            this.cbBoxUpDown.Size = new System.Drawing.Size(121, 25);
            this.cbBoxUpDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxUpDown.TabIndex = 19;
            this.cbBoxUpDown.Text = "上行";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "上行";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "下行";
            // 
            // btnLoadBaseData
            // 
            this.btnLoadBaseData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoadBaseData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoadBaseData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadBaseData.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadBaseData.Image")));
            this.btnLoadBaseData.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnLoadBaseData.Location = new System.Drawing.Point(132, 96);
            this.btnLoadBaseData.Name = "btnLoadBaseData";
            this.btnLoadBaseData.Size = new System.Drawing.Size(48, 34);
            this.btnLoadBaseData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLoadBaseData.TabIndex = 8;
            this.btnLoadBaseData.Tooltip = "载入线路基础数据库";
            this.btnLoadBaseData.Click += new System.EventHandler(this.btnLoadBaseData_Click);
            // 
            // labelX5
            // 
            this.labelX5.AutoSize = true;
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.ForeColor = System.Drawing.Color.Black;
            this.labelX5.Location = new System.Drawing.Point(337, 37);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(18, 23);
            this.labelX5.TabIndex = 14;
            this.labelX5.Text = "~";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.ForeColor = System.Drawing.Color.Black;
            this.labelX3.Location = new System.Drawing.Point(11, 38);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(74, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "站区(间)：";
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.ForeColor = System.Drawing.Color.Black;
            this.labelX2.Location = new System.Drawing.Point(11, 1);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(79, 23);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "线路信息：";
            // 
            // dateTimeInput
            // 
            // 
            // 
            // 
            this.dateTimeInput.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dateTimeInput.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dateTimeInput.ButtonDropDown.Visible = true;
            this.dateTimeInput.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimeInput.IsPopupCalendarOpen = false;
            this.dateTimeInput.Location = new System.Drawing.Point(94, 66);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dateTimeInput.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dateTimeInput.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.DisplayMonth = new System.DateTime(2019, 7, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dateTimeInput.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dateTimeInput.MonthCalendar.TodayButtonVisible = true;
            this.dateTimeInput.Name = "dateTimeInput";
            this.dateTimeInput.Size = new System.Drawing.Size(249, 25);
            this.dateTimeInput.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dateTimeInput.TabIndex = 18;
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.Color.Black;
            this.labelX1.Location = new System.Drawing.Point(360, 67);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(50, 23);
            this.labelX1.TabIndex = 9;
            this.labelX1.Text = "行别：";
            // 
            // labelX4
            // 
            this.labelX4.AutoSize = true;
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.ForeColor = System.Drawing.Color.Black;
            this.labelX4.Location = new System.Drawing.Point(10, 67);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(79, 23);
            this.labelX4.TabIndex = 9;
            this.labelX4.Text = "检测时间：";
            // 
            // tbEndStation
            // 
            // 
            // 
            // 
            this.tbEndStation.Border.Class = "TextBoxBorder";
            this.tbEndStation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbEndStation.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbEndStation.Location = new System.Drawing.Point(409, 35);
            this.tbEndStation.Name = "tbEndStation";
            this.tbEndStation.PreventEnterBeep = true;
            this.tbEndStation.Size = new System.Drawing.Size(179, 25);
            this.tbEndStation.TabIndex = 17;
            // 
            // tbStartStation
            // 
            // 
            // 
            // 
            this.tbStartStation.Border.Class = "TextBoxBorder";
            this.tbStartStation.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbStartStation.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbStartStation.Location = new System.Drawing.Point(94, 35);
            this.tbStartStation.Name = "tbStartStation";
            this.tbStartStation.PreventEnterBeep = true;
            this.tbStartStation.Size = new System.Drawing.Size(179, 25);
            this.tbStartStation.TabIndex = 16;
            // 
            // tbStationName
            // 
            // 
            // 
            // 
            this.tbStationName.Border.Class = "TextBoxBorder";
            this.tbStationName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbStationName.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbStationName.Location = new System.Drawing.Point(94, -1);
            this.tbStationName.Name = "tbStationName";
            this.tbStationName.PreventEnterBeep = true;
            this.tbStationName.Size = new System.Drawing.Size(494, 25);
            this.tbStationName.TabIndex = 15;
            // 
            // lblStationName1
            // 
            this.lblStationName1.BackColor = System.Drawing.Color.Gray;
            // 
            // 
            // 
            this.lblStationName1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblStationName1.Location = new System.Drawing.Point(94, 3);
            this.lblStationName1.Name = "lblStationName1";
            this.lblStationName1.Size = new System.Drawing.Size(497, 23);
            this.lblStationName1.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.lblStationName1.TabIndex = 11;
            this.lblStationName1.Text = "站区(间):";
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "离线数据分析";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.groupBox2);
            this.superTabControlPanel1.Controls.Add(this.groupBox1);
            this.superTabControlPanel1.Controls.Add(this.lblIndexTaskDir);
            this.superTabControlPanel1.Controls.Add(this.btnProcessDb);
            this.superTabControlPanel1.Controls.Add(this.btnSelIndexTaskDir);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 26);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(724, 263);
            this.superTabControlPanel1.TabIndex = 0;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBarX2);
            this.groupBox2.Controls.Add(this.progressBarX1);
            this.groupBox2.Controls.Add(this.lblProcessA);
            this.groupBox2.Controls.Add(this.lblProcessB);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(358, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 136);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "索引任务数据";
            // 
            // progressBarX2
            // 
            // 
            // 
            // 
            this.progressBarX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.progressBarX2.BackgroundStyle.TextColor = System.Drawing.Color.White;
            this.progressBarX2.ForeColor = System.Drawing.Color.White;
            this.progressBarX2.Location = new System.Drawing.Point(33, 98);
            this.progressBarX2.Name = "progressBarX2";
            this.progressBarX2.Size = new System.Drawing.Size(258, 23);
            this.progressBarX2.TabIndex = 21;
            this.progressBarX2.Text = "progressBarX1";
            this.progressBarX2.TextVisible = true;
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.progressBarX1.BackgroundStyle.TextColor = System.Drawing.SystemColors.Info;
            this.progressBarX1.ForeColor = System.Drawing.Color.White;
            this.progressBarX1.Location = new System.Drawing.Point(33, 52);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.Size = new System.Drawing.Size(258, 23);
            this.progressBarX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.progressBarX1.TabIndex = 21;
            this.progressBarX1.Text = "progressBarX1";
            this.progressBarX1.TextVisible = true;
            // 
            // lblProcessA
            // 
            this.lblProcessA.AutoSize = true;
            this.lblProcessA.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessA.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblProcessA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblProcessA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProcessA.ImageKey = "button-red.png";
            this.lblProcessA.Location = new System.Drawing.Point(296, 54);
            this.lblProcessA.Name = "lblProcessA";
            this.lblProcessA.Size = new System.Drawing.Size(17, 20);
            this.lblProcessA.TabIndex = 19;
            this.lblProcessA.Text = "0";
            this.lblProcessA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProcessB
            // 
            this.lblProcessB.AutoSize = true;
            this.lblProcessB.BackColor = System.Drawing.Color.Transparent;
            this.lblProcessB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblProcessB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblProcessB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProcessB.ImageKey = "button-red.png";
            this.lblProcessB.Location = new System.Drawing.Point(297, 98);
            this.lblProcessB.Name = "lblProcessB";
            this.lblProcessB.Size = new System.Drawing.Size(17, 20);
            this.lblProcessB.TabIndex = 20;
            this.lblProcessB.Text = "0";
            this.lblProcessB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.ImageKey = "button-red.png";
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "索引相机一图像：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.ImageKey = "button-red.png";
            this.label6.Location = new System.Drawing.Point(6, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "索引相机二图像：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.lblDbFilesNumA);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDbFilesNumB);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblIndexImgNumA);
            this.groupBox1.Controls.Add(this.lblIndexImgNumB);
            this.groupBox1.Location = new System.Drawing.Point(30, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 136);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "任务数据信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.ImageKey = "button-red.png";
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "已经索引的图像数量(相机一):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label25.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label25.ImageKey = "button-red.png";
            this.label25.Location = new System.Drawing.Point(76, 23);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(120, 20);
            this.label25.TabIndex = 16;
            this.label25.Text = "数据文件(相机一):";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbFilesNumA
            // 
            this.lblDbFilesNumA.AutoSize = true;
            this.lblDbFilesNumA.BackColor = System.Drawing.Color.Transparent;
            this.lblDbFilesNumA.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblDbFilesNumA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblDbFilesNumA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbFilesNumA.ImageKey = "button-red.png";
            this.lblDbFilesNumA.Location = new System.Drawing.Point(198, 23);
            this.lblDbFilesNumA.Name = "lblDbFilesNumA";
            this.lblDbFilesNumA.Size = new System.Drawing.Size(17, 20);
            this.lblDbFilesNumA.TabIndex = 16;
            this.lblDbFilesNumA.Text = "0";
            this.lblDbFilesNumA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImageKey = "button-red.png";
            this.label1.Location = new System.Drawing.Point(76, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "数据文件(相机二):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDbFilesNumB
            // 
            this.lblDbFilesNumB.AutoSize = true;
            this.lblDbFilesNumB.BackColor = System.Drawing.Color.Transparent;
            this.lblDbFilesNumB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblDbFilesNumB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblDbFilesNumB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDbFilesNumB.ImageKey = "button-red.png";
            this.lblDbFilesNumB.Location = new System.Drawing.Point(198, 49);
            this.lblDbFilesNumB.Name = "lblDbFilesNumB";
            this.lblDbFilesNumB.Size = new System.Drawing.Size(17, 20);
            this.lblDbFilesNumB.TabIndex = 16;
            this.lblDbFilesNumB.Text = "0";
            this.lblDbFilesNumB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImageKey = "button-red.png";
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "已经索引的图像数量(相机二):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIndexImgNumA
            // 
            this.lblIndexImgNumA.AutoSize = true;
            this.lblIndexImgNumA.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexImgNumA.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblIndexImgNumA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblIndexImgNumA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIndexImgNumA.ImageKey = "button-red.png";
            this.lblIndexImgNumA.Location = new System.Drawing.Point(198, 75);
            this.lblIndexImgNumA.Name = "lblIndexImgNumA";
            this.lblIndexImgNumA.Size = new System.Drawing.Size(17, 20);
            this.lblIndexImgNumA.TabIndex = 16;
            this.lblIndexImgNumA.Text = "0";
            this.lblIndexImgNumA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIndexImgNumB
            // 
            this.lblIndexImgNumB.AutoSize = true;
            this.lblIndexImgNumB.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexImgNumB.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblIndexImgNumB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblIndexImgNumB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblIndexImgNumB.ImageKey = "button-red.png";
            this.lblIndexImgNumB.Location = new System.Drawing.Point(198, 101);
            this.lblIndexImgNumB.Name = "lblIndexImgNumB";
            this.lblIndexImgNumB.Size = new System.Drawing.Size(17, 20);
            this.lblIndexImgNumB.TabIndex = 16;
            this.lblIndexImgNumB.Text = "0";
            this.lblIndexImgNumB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblIndexTaskDir
            // 
            this.lblIndexTaskDir.AutoSize = true;
            this.lblIndexTaskDir.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexTaskDir.Location = new System.Drawing.Point(133, 27);
            this.lblIndexTaskDir.Name = "lblIndexTaskDir";
            this.lblIndexTaskDir.Size = new System.Drawing.Size(23, 20);
            this.lblIndexTaskDir.TabIndex = 17;
            this.lblIndexTaskDir.TabStop = true;
            this.lblIndexTaskDir.Text = "D:";
            this.lblIndexTaskDir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblIndexTaskDir_LinkClicked);
            // 
            // btnProcessDb
            // 
            this.btnProcessDb.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnProcessDb.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnProcessDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcessDb.Location = new System.Drawing.Point(603, 204);
            this.btnProcessDb.Name = "btnProcessDb";
            this.btnProcessDb.Size = new System.Drawing.Size(100, 38);
            this.btnProcessDb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnProcessDb.TabIndex = 10;
            this.btnProcessDb.Text = "索引数据";
            this.btnProcessDb.Click += new System.EventHandler(this.btnProcessDb_Click);
            // 
            // btnSelIndexTaskDir
            // 
            this.btnSelIndexTaskDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelIndexTaskDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelIndexTaskDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelIndexTaskDir.Location = new System.Drawing.Point(30, 21);
            this.btnSelIndexTaskDir.Name = "btnSelIndexTaskDir";
            this.btnSelIndexTaskDir.Size = new System.Drawing.Size(100, 33);
            this.btnSelIndexTaskDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSelIndexTaskDir.TabIndex = 10;
            this.btnSelIndexTaskDir.Text = "任务目录选择";
            this.btnSelIndexTaskDir.Click += new System.EventHandler(this.btnSelIndexTaskDir_Click);
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "索引离线数据";
            // 
            // FrmDataMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1247, 688);
            this.Controls.Add(this.superTabControl1);
            this.DoubleBuffered = true;
            this.Name = "FrmDataMgr";
            this.Text = "数据管理";
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateTimeInput)).EndInit();
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.ButtonX btnTaskOk;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblStationName1;
        private DevComponents.DotNetBar.ButtonX btnOpenDir;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbStationName;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dateTimeInput;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxUpDown;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.ButtonX btnSelIndexTaskDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIndexImgNumB;
        private System.Windows.Forms.Label lblIndexImgNumA;
        private System.Windows.Forms.Label lblDbFilesNumB;
        private System.Windows.Forms.Label lblDbFilesNumA;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.LinkLabel lblIndexTaskDir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnProcessDb;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private System.Windows.Forms.Label lblProcessA;
        private System.Windows.Forms.Label lblProcessB;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX2;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbEndStation;
        private DevComponents.DotNetBar.Controls.TextBoxX tbStartStation;
        private System.Windows.Forms.LinkLabel lblDBPath;
        private System.Windows.Forms.CheckBox cbHasBaseData;
        private DevComponents.DotNetBar.ButtonX btnLoadBaseData;
    }
}