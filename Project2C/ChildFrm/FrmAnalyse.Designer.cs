namespace Project2C.ChildFrm {
    partial class FrmAnalyse {
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnalyse));
            this.exPanelLeft = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgViewDataInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPoleNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exPanelCurFault = new DevComponents.DotNetBar.ExpandablePanel();
            this.dgViewCurFault = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDel = new DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn();
            this.ColRid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.cbBoxStation = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnGoPoleNum = new DevComponents.DotNetBar.ButtonX();
            this.tbPoleNum = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cFviImageView4 = new FVIL.Forms.CFviImageView();
            this.cFviImageView1 = new FVIL.Forms.CFviImageView();
            this.cFviImageView3 = new FVIL.Forms.CFviImageView();
            this.cFviImageView2 = new FVIL.Forms.CFviImageView();
            this.ImageView2 = new FVIL.Forms.CFviImageView();
            this.timerPlay = new System.Windows.Forms.Timer(this.components);
            this.ImageView = new FVIL.Forms.CFviImageView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barPlayControl = new DevComponents.DotNetBar.Bar();
            this.iInputFrameSet = new DevComponents.Editors.IntegerInput();
            this.btnItemPrev = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemSlower = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemPlay = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemFaster = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemNext = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.btnItemFrameSet = new DevComponents.DotNetBar.ButtonItem();
            this.progressBarItem = new DevComponents.DotNetBar.ProgressBarItem();
            this.btnFrameNo = new DevComponents.DotNetBar.ButtonItem();
            this.lblTotalFrame = new DevComponents.DotNetBar.LabelItem();
            this.imgView = new FVIL.Forms.CFviImageView();
            this.panelMain = new DevComponents.DotNetBar.PanelEx();
            this.panelView = new System.Windows.Forms.Panel();
            this.lblRecShow = new DevComponents.DotNetBar.LabelX();
            this.bar2 = new DevComponents.DotNetBar.Bar();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.lblItemUpDown = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.lblItemStationInfo = new DevComponents.DotNetBar.LabelItem();
            this.labelItem10 = new DevComponents.DotNetBar.LabelItem();
            this.lblItemShootTime = new DevComponents.DotNetBar.LabelItem();
            this.labelItem12 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem13 = new DevComponents.DotNetBar.LabelItem();
            this.sBtnItemCamera = new DevComponents.DotNetBar.SwitchButtonItem();
            this.btnItemRecord = new DevComponents.DotNetBar.ButtonItem();
            this.btnItemPoleNumSet = new DevComponents.DotNetBar.ButtonItem();
            this.btnSave = new DevComponents.DotNetBar.ButtonItem();
            this.exPanelJHCS = new DevComponents.DotNetBar.ExpandablePanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tChartdg = new Steema.TeeChart.TChart();
            this.line1 = new Steema.TeeChart.Styles.Line();
            this.line2 = new Steema.TeeChart.Styles.Line();
            this.line3 = new Steema.TeeChart.Styles.Line();
            this.line4 = new Steema.TeeChart.Styles.Line();
            this.points1 = new Steema.TeeChart.Styles.Points();
            this.tChartlcz = new Steema.TeeChart.TChart();
            this.lczLine1 = new Steema.TeeChart.Styles.Line();
            this.lczLine2 = new Steema.TeeChart.Styles.Line();
            this.lczLine3 = new Steema.TeeChart.Styles.Line();
            this.lczLine4 = new Steema.TeeChart.Styles.Line();
            this.lczPoints = new Steema.TeeChart.Styles.Points();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.exPanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewDataInfo)).BeginInit();
            this.exPanelCurFault.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCurFault)).BeginInit();
            this.panelEx4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barPlayControl)).BeginInit();
            this.barPlayControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iInputFrameSet)).BeginInit();
            this.panelMain.SuspendLayout();
            this.panelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).BeginInit();
            this.exPanelJHCS.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exPanelLeft
            // 
            this.exPanelLeft.CanvasColor = System.Drawing.SystemColors.Control;
            this.exPanelLeft.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.RightToLeft;
            this.exPanelLeft.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exPanelLeft.Controls.Add(this.dgViewDataInfo);
            this.exPanelLeft.Controls.Add(this.exPanelCurFault);
            this.exPanelLeft.Controls.Add(this.panelEx4);
            this.exPanelLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exPanelLeft.DisabledBackColor = System.Drawing.Color.Empty;
            this.exPanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.exPanelLeft.Expanded = false;
            this.exPanelLeft.ExpandedBounds = new System.Drawing.Rectangle(0, 0, 226, 524);
            this.exPanelLeft.Font = new System.Drawing.Font("等线", 10F);
            this.exPanelLeft.HideControlsWhenCollapsed = true;
            this.exPanelLeft.Location = new System.Drawing.Point(0, 0);
            this.exPanelLeft.Name = "exPanelLeft";
            this.exPanelLeft.Size = new System.Drawing.Size(30, 524);
            this.exPanelLeft.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelLeft.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelLeft.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelLeft.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exPanelLeft.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exPanelLeft.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exPanelLeft.Style.GradientAngle = 90;
            this.exPanelLeft.TabIndex = 30;
            this.exPanelLeft.TitleHeight = 30;
            this.exPanelLeft.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelLeft.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelLeft.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelLeft.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.exPanelLeft.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exPanelLeft.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exPanelLeft.TitleStyle.GradientAngle = 90;
            this.exPanelLeft.TitleText = "支柱信息";
            // 
            // dgViewDataInfo
            // 
            this.dgViewDataInfo.AllowUserToAddRows = false;
            this.dgViewDataInfo.AllowUserToDeleteRows = false;
            this.dgViewDataInfo.AllowUserToResizeColumns = false;
            this.dgViewDataInfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("等线", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewDataInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgViewDataInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewDataInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCId,
            this.ColPoleNum,
            this.ColStation});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("等线", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewDataInfo.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgViewDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewDataInfo.EnableHeadersVisualStyles = false;
            this.dgViewDataInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgViewDataInfo.Location = new System.Drawing.Point(0, 95);
            this.dgViewDataInfo.MultiSelect = false;
            this.dgViewDataInfo.Name = "dgViewDataInfo";
            this.dgViewDataInfo.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("等线", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewDataInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgViewDataInfo.RowHeadersVisible = false;
            this.dgViewDataInfo.RowTemplate.Height = 23;
            this.dgViewDataInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewDataInfo.Size = new System.Drawing.Size(30, 273);
            this.dgViewDataInfo.TabIndex = 26;
            this.dgViewDataInfo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgViewDataInfo_RowStateChanged);
            this.dgViewDataInfo.DoubleClick += new System.EventHandler(this.dgViewDataInfo_DoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "pId";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Width = 45;
            // 
            // colCId
            // 
            this.colCId.DataPropertyName = "cId";
            this.colCId.HeaderText = "相机";
            this.colCId.Name = "colCId";
            this.colCId.ReadOnly = true;
            this.colCId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCId.Width = 45;
            // 
            // ColPoleNum
            // 
            this.ColPoleNum.DataPropertyName = "poleNum";
            this.ColPoleNum.HeaderText = "支柱号";
            this.ColPoleNum.Name = "ColPoleNum";
            this.ColPoleNum.ReadOnly = true;
            this.ColPoleNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColPoleNum.Width = 66;
            // 
            // ColStation
            // 
            this.ColStation.DataPropertyName = "sName";
            this.ColStation.HeaderText = "站区间";
            this.ColStation.Name = "ColStation";
            this.ColStation.ReadOnly = true;
            this.ColStation.Width = 120;
            // 
            // exPanelCurFault
            // 
            this.exPanelCurFault.CanvasColor = System.Drawing.SystemColors.Control;
            this.exPanelCurFault.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.TopToBottom;
            this.exPanelCurFault.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exPanelCurFault.Controls.Add(this.dgViewCurFault);
            this.exPanelCurFault.DisabledBackColor = System.Drawing.Color.Empty;
            this.exPanelCurFault.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanelCurFault.HideControlsWhenCollapsed = true;
            this.exPanelCurFault.Location = new System.Drawing.Point(0, 368);
            this.exPanelCurFault.Name = "exPanelCurFault";
            this.exPanelCurFault.Size = new System.Drawing.Size(30, 156);
            this.exPanelCurFault.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelCurFault.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelCurFault.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelCurFault.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exPanelCurFault.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exPanelCurFault.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exPanelCurFault.Style.GradientAngle = 90;
            this.exPanelCurFault.TabIndex = 32;
            this.exPanelCurFault.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelCurFault.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelCurFault.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelCurFault.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.exPanelCurFault.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exPanelCurFault.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exPanelCurFault.TitleStyle.GradientAngle = 90;
            this.exPanelCurFault.TitleText = "缺陷列表";
            // 
            // dgViewCurFault
            // 
            this.dgViewCurFault.AllowUserToAddRows = false;
            this.dgViewCurFault.AllowUserToDeleteRows = false;
            this.dgViewCurFault.AllowUserToResizeRows = false;
            this.dgViewCurFault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewCurFault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.ColDel,
            this.ColRid});
            this.dgViewCurFault.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("等线", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewCurFault.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgViewCurFault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgViewCurFault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgViewCurFault.Location = new System.Drawing.Point(0, 26);
            this.dgViewCurFault.Name = "dgViewCurFault";
            this.dgViewCurFault.ReadOnly = true;
            this.dgViewCurFault.RowHeadersVisible = false;
            this.dgViewCurFault.RowTemplate.Height = 23;
            this.dgViewCurFault.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewCurFault.Size = new System.Drawing.Size(30, 130);
            this.dgViewCurFault.TabIndex = 31;
            this.dgViewCurFault.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgViewCurFault_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "uName";
            this.Column1.HeaderText = "部件名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fName";
            this.Column2.HeaderText = "缺陷类型";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 120;
            // 
            // ColDel
            // 
            this.ColDel.HeaderText = "删除";
            this.ColDel.Image = ((System.Drawing.Image)(resources.GetObject("ColDel.Image")));
            this.ColDel.Name = "ColDel";
            this.ColDel.ReadOnly = true;
            this.ColDel.Text = null;
            this.ColDel.Width = 40;
            // 
            // ColRid
            // 
            this.ColRid.DataPropertyName = "rId";
            this.ColRid.HeaderText = "rId";
            this.ColRid.Name = "ColRid";
            this.ColRid.ReadOnly = true;
            this.ColRid.Visible = false;
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.cbBoxStation);
            this.panelEx4.Controls.Add(this.btnGoPoleNum);
            this.panelEx4.Controls.Add(this.tbPoleNum);
            this.panelEx4.Controls.Add(this.labelX2);
            this.panelEx4.Controls.Add(this.labelX1);
            this.panelEx4.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx4.Location = new System.Drawing.Point(0, 30);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(30, 65);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 27;
            // 
            // cbBoxStation
            // 
            this.cbBoxStation.DisplayMember = "Text";
            this.cbBoxStation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBoxStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoxStation.FormattingEnabled = true;
            this.cbBoxStation.ItemHeight = 15;
            this.cbBoxStation.Location = new System.Drawing.Point(68, 11);
            this.cbBoxStation.Name = "cbBoxStation";
            this.cbBoxStation.Size = new System.Drawing.Size(148, 21);
            this.cbBoxStation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBoxStation.TabIndex = 4;
            // 
            // btnGoPoleNum
            // 
            this.btnGoPoleNum.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGoPoleNum.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGoPoleNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoPoleNum.Font = new System.Drawing.Font("等线", 10F);
            this.btnGoPoleNum.Location = new System.Drawing.Point(181, 33);
            this.btnGoPoleNum.Name = "btnGoPoleNum";
            this.btnGoPoleNum.Size = new System.Drawing.Size(39, 24);
            this.btnGoPoleNum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGoPoleNum.TabIndex = 8;
            this.btnGoPoleNum.Text = "跳转";
            this.btnGoPoleNum.Click += new System.EventHandler(this.btnGoPoleNum_Click);
            // 
            // tbPoleNum
            // 
            // 
            // 
            // 
            this.tbPoleNum.Border.Class = "TextBoxBorder";
            this.tbPoleNum.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPoleNum.DisabledBackColor = System.Drawing.Color.Black;
            this.tbPoleNum.Location = new System.Drawing.Point(68, 35);
            this.tbPoleNum.Name = "tbPoleNum";
            this.tbPoleNum.PreventEnterBeep = true;
            this.tbPoleNum.Size = new System.Drawing.Size(106, 21);
            this.tbPoleNum.TabIndex = 7;
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(18, 37);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(62, 18);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "支柱号：";
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(18, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(62, 18);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "站区间：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cFviImageView4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cFviImageView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cFviImageView3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cFviImageView2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1498, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(172, 759);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Visible = false;
            // 
            // cFviImageView4
            // 
            this.cFviImageView4.BackColor = System.Drawing.Color.Transparent;
            this.cFviImageView4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cFviImageView4.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("cFviImageView4.Display")));
            this.cFviImageView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFviImageView4.EnableMouseGrip = true;
            this.cFviImageView4.EnableMouseWheel = false;
            this.cFviImageView4.EnableScrollBar = false;
            this.cFviImageView4.Location = new System.Drawing.Point(5, 569);
            this.cFviImageView4.Name = "cFviImageView4";
            this.cFviImageView4.Size = new System.Drawing.Size(162, 185);
            this.cFviImageView4.TabIndex = 24;
            // 
            // cFviImageView1
            // 
            this.cFviImageView1.BackColor = System.Drawing.Color.Transparent;
            this.cFviImageView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cFviImageView1.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("cFviImageView1.Display")));
            this.cFviImageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFviImageView1.EnableMouseGrip = true;
            this.cFviImageView1.EnableMouseWheel = false;
            this.cFviImageView1.EnableScrollBar = false;
            this.cFviImageView1.Location = new System.Drawing.Point(5, 5);
            this.cFviImageView1.Name = "cFviImageView1";
            this.cFviImageView1.Size = new System.Drawing.Size(162, 182);
            this.cFviImageView1.TabIndex = 22;
            // 
            // cFviImageView3
            // 
            this.cFviImageView3.BackColor = System.Drawing.Color.Transparent;
            this.cFviImageView3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cFviImageView3.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("cFviImageView3.Display")));
            this.cFviImageView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFviImageView3.EnableMouseGrip = true;
            this.cFviImageView3.EnableMouseWheel = false;
            this.cFviImageView3.EnableScrollBar = false;
            this.cFviImageView3.Location = new System.Drawing.Point(5, 381);
            this.cFviImageView3.Name = "cFviImageView3";
            this.cFviImageView3.Size = new System.Drawing.Size(162, 182);
            this.cFviImageView3.TabIndex = 23;
            // 
            // cFviImageView2
            // 
            this.cFviImageView2.BackColor = System.Drawing.Color.Transparent;
            this.cFviImageView2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cFviImageView2.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("cFviImageView2.Display")));
            this.cFviImageView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cFviImageView2.EnableMouseGrip = true;
            this.cFviImageView2.EnableMouseWheel = false;
            this.cFviImageView2.EnableScrollBar = false;
            this.cFviImageView2.Location = new System.Drawing.Point(5, 193);
            this.cFviImageView2.Name = "cFviImageView2";
            this.cFviImageView2.Size = new System.Drawing.Size(162, 182);
            this.cFviImageView2.TabIndex = 23;
            // 
            // ImageView2
            // 
            this.ImageView2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ImageView2.BackColor = System.Drawing.Color.Transparent;
            this.ImageView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageView2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImageView2.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("ImageView2.Display")));
            this.ImageView2.EnableMouseGrip = true;
            this.ImageView2.EnableMouseWheel = false;
            this.ImageView2.EnableScrollBar = false;
            this.ImageView2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ImageView2.Location = new System.Drawing.Point(1185, 244);
            this.ImageView2.Name = "ImageView2";
            this.ImageView2.Size = new System.Drawing.Size(280, 210);
            this.ImageView2.TabIndex = 23;
            this.ImageView2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ImageView2_MouseUp);
            // 
            // timerPlay
            // 
            this.timerPlay.Tick += new System.EventHandler(this.timerPlay_Tick);
            // 
            // ImageView
            // 
            this.ImageView.BackColor = System.Drawing.Color.Transparent;
            this.ImageView.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("ImageView.Display")));
            this.ImageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageView.EnableMouseGrip = true;
            this.ImageView.EnableMouseWheel = false;
            this.ImageView.Location = new System.Drawing.Point(0, 0);
            this.ImageView.Margin = new System.Windows.Forms.Padding(0);
            this.ImageView.Name = "ImageView";
            this.ImageView.Size = new System.Drawing.Size(1468, 457);
            this.ImageView.TabIndex = 49;
            this.ImageView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ImageView_MouseDown);
            this.ImageView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ImageView_MouseMove);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "StatusAnnotations_Play_32xLG_color.png");
            this.imageList1.Images.SetKeyName(1, "StatusAnnotations_Pause_32xLG_color.png");
            // 
            // barPlayControl
            // 
            this.barPlayControl.AntiAlias = true;
            this.barPlayControl.Controls.Add(this.iInputFrameSet);
            this.barPlayControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barPlayControl.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.barPlayControl.DockTabStripHeight = 30;
            this.barPlayControl.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.barPlayControl.Images = this.imageList1;
            this.barPlayControl.IsMaximized = false;
            this.barPlayControl.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnItemPrev,
            this.btnItemSlower,
            this.btnItemPlay,
            this.btnItemFaster,
            this.btnItemNext,
            this.controlContainerItem1,
            this.btnItemFrameSet,
            this.progressBarItem,
            this.btnFrameNo,
            this.lblTotalFrame});
            this.barPlayControl.Location = new System.Drawing.Point(0, 491);
            this.barPlayControl.Name = "barPlayControl";
            this.barPlayControl.Size = new System.Drawing.Size(1468, 33);
            this.barPlayControl.Stretch = true;
            this.barPlayControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.barPlayControl.TabIndex = 57;
            this.barPlayControl.TabStop = false;
            // 
            // iInputFrameSet
            // 
            // 
            // 
            // 
            this.iInputFrameSet.BackgroundStyle.Class = "DateTimeInputBackground";
            this.iInputFrameSet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.iInputFrameSet.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.iInputFrameSet.Location = new System.Drawing.Point(198, 4);
            this.iInputFrameSet.MaxValue = 35;
            this.iInputFrameSet.MinValue = 5;
            this.iInputFrameSet.Name = "iInputFrameSet";
            this.iInputFrameSet.ShowUpDown = true;
            this.iInputFrameSet.Size = new System.Drawing.Size(48, 23);
            this.iInputFrameSet.TabIndex = 1;
            this.iInputFrameSet.Value = 5;
            // 
            // btnItemPrev
            // 
            this.btnItemPrev.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnItemPrev.Image")));
            this.btnItemPrev.Name = "btnItemPrev";
            this.btnItemPrev.Text = "上一帧";
            this.btnItemPrev.Click += new System.EventHandler(this.btnItemPrev_Click);
            // 
            // btnItemSlower
            // 
            this.btnItemSlower.Image = ((System.Drawing.Image)(resources.GetObject("btnItemSlower.Image")));
            this.btnItemSlower.ImagePosition = DevComponents.DotNetBar.eImagePosition.Bottom;
            this.btnItemSlower.Name = "btnItemSlower";
            this.btnItemSlower.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnItemSlower.Tooltip = "慢放";
            this.btnItemSlower.Click += new System.EventHandler(this.btnItemSlower_Click);
            // 
            // btnItemPlay
            // 
            this.btnItemPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemPlay.ImageFixedSize = new System.Drawing.Size(24, 24);
            this.btnItemPlay.ImageIndex = 0;
            this.btnItemPlay.ImagePaddingHorizontal = 0;
            this.btnItemPlay.ImagePaddingVertical = 0;
            this.btnItemPlay.Name = "btnItemPlay";
            this.btnItemPlay.Text = "播放";
            this.btnItemPlay.Click += new System.EventHandler(this.btnItemPlay_Click);
            // 
            // btnItemFaster
            // 
            this.btnItemFaster.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemFaster.Image = ((System.Drawing.Image)(resources.GetObject("btnItemFaster.Image")));
            this.btnItemFaster.Name = "btnItemFaster";
            this.btnItemFaster.Tooltip = "加速";
            this.btnItemFaster.Click += new System.EventHandler(this.btnItemFaster_Click);
            // 
            // btnItemNext
            // 
            this.btnItemNext.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemNext.Image = ((System.Drawing.Image)(resources.GetObject("btnItemNext.Image")));
            this.btnItemNext.Name = "btnItemNext";
            this.btnItemNext.Text = "下一帧";
            this.btnItemNext.Click += new System.EventHandler(this.btnItemNext_Click);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.iInputFrameSet;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // btnItemFrameSet
            // 
            this.btnItemFrameSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemFrameSet.Name = "btnItemFrameSet";
            this.btnItemFrameSet.Text = "帧/秒";
            this.btnItemFrameSet.Click += new System.EventHandler(this.btnItemFrameSet_Click);
            // 
            // progressBarItem
            // 
            // 
            // 
            // 
            this.progressBarItem.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarItem.ChunkGradientAngle = 0F;
            this.progressBarItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.progressBarItem.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.progressBarItem.Name = "progressBarItem";
            this.progressBarItem.RecentlyUsed = false;
            this.progressBarItem.Stretch = true;
            this.progressBarItem.Width = 200;
            this.progressBarItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.progressBarItem_MouseUp);
            this.progressBarItem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.progressBarItem_MouseMove);
            // 
            // btnFrameNo
            // 
            this.btnFrameNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFrameNo.FixedSize = new System.Drawing.Size(50, 0);
            this.btnFrameNo.Name = "btnFrameNo";
            this.btnFrameNo.Text = "0";
            this.btnFrameNo.Click += new System.EventHandler(this.btnFrameNo_Click);
            // 
            // lblTotalFrame
            // 
            this.lblTotalFrame.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFrame.Name = "lblTotalFrame";
            this.lblTotalFrame.Text = "帧";
            // 
            // imgView
            // 
            this.imgView.BackColor = System.Drawing.Color.Transparent;
            this.imgView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgView.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("imgView.Display")));
            this.imgView.EnableMouseGrip = true;
            this.imgView.EnableMouseWheel = false;
            this.imgView.EnableScrollBar = false;
            this.imgView.Location = new System.Drawing.Point(161, 43);
            this.imgView.Name = "imgView";
            this.imgView.Size = new System.Drawing.Size(300, 248);
            this.imgView.TabIndex = 58;
            this.imgView.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelMain.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelMain.Controls.Add(this.panelView);
            this.panelMain.Controls.Add(this.bar2);
            this.panelMain.Controls.Add(this.barPlayControl);
            this.panelMain.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(30, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1468, 524);
            this.panelMain.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelMain.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelMain.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelMain.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelMain.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelMain.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelMain.Style.GradientAngle = 90;
            this.panelMain.TabIndex = 59;
            this.panelMain.Text = "panelEx2";
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.lblRecShow);
            this.panelView.Controls.Add(this.ImageView2);
            this.panelView.Controls.Add(this.imgView);
            this.panelView.Controls.Add(this.ImageView);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 34);
            this.panelView.Margin = new System.Windows.Forms.Padding(0);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(1468, 457);
            this.panelView.TabIndex = 66;
            // 
            // lblRecShow
            // 
            // 
            // 
            // 
            this.lblRecShow.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblRecShow.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecShow.ForeColor = System.Drawing.Color.Red;
            this.lblRecShow.Location = new System.Drawing.Point(3, 3);
            this.lblRecShow.Name = "lblRecShow";
            this.lblRecShow.SingleLineColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblRecShow.Size = new System.Drawing.Size(75, 23);
            this.lblRecShow.TabIndex = 59;
            this.lblRecShow.Text = "REC";
            this.lblRecShow.Visible = false;
            // 
            // bar2
            // 
            this.bar2.AntiAlias = true;
            this.bar2.BackColor = System.Drawing.Color.Black;
            this.bar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar2.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.bar2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.bar2.IsMaximized = false;
            this.bar2.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem1,
            this.lblItemUpDown,
            this.labelItem4,
            this.labelItem3,
            this.lblItemStationInfo,
            this.labelItem10,
            this.lblItemShootTime,
            this.labelItem12,
            this.labelItem13,
            this.sBtnItemCamera,
            this.btnItemRecord,
            this.btnItemPoleNumSet,
            this.btnSave});
            this.bar2.Location = new System.Drawing.Point(0, 0);
            this.bar2.Name = "bar2";
            this.bar2.Size = new System.Drawing.Size(1468, 34);
            this.bar2.Stretch = true;
            this.bar2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar2.TabIndex = 65;
            this.bar2.TabStop = false;
            this.bar2.Text = "bar2";
            // 
            // labelItem1
            // 
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "行别：";
            // 
            // lblItemUpDown
            // 
            this.lblItemUpDown.Name = "lblItemUpDown";
            this.lblItemUpDown.Text = "上行";
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            this.labelItem4.Text = "|";
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            this.labelItem3.Text = "站区间：";
            // 
            // lblItemStationInfo
            // 
            this.lblItemStationInfo.ForeColor = System.Drawing.Color.Red;
            this.lblItemStationInfo.Name = "lblItemStationInfo";
            this.lblItemStationInfo.Text = "labelItem5";
            // 
            // labelItem10
            // 
            this.labelItem10.Name = "labelItem10";
            this.labelItem10.Text = "拍摄时间:";
            // 
            // lblItemShootTime
            // 
            this.lblItemShootTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblItemShootTime.Name = "lblItemShootTime";
            this.lblItemShootTime.Text = "2019-01-01";
            // 
            // labelItem12
            // 
            this.labelItem12.Name = "labelItem12";
            this.labelItem12.Text = "GPS：";
            // 
            // labelItem13
            // 
            this.labelItem13.ForeColor = System.Drawing.Color.Yellow;
            this.labelItem13.Name = "labelItem13";
            this.labelItem13.PaddingRight = 10;
            this.labelItem13.Text = "30.696657, 104.054574";
            // 
            // sBtnItemCamera
            // 
            this.sBtnItemCamera.ButtonWidth = 88;
            this.sBtnItemCamera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sBtnItemCamera.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center;
            this.sBtnItemCamera.Name = "sBtnItemCamera";
            this.sBtnItemCamera.OffBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.sBtnItemCamera.OffText = "相机2";
            this.sBtnItemCamera.OnText = "相机1";
            this.sBtnItemCamera.Tooltip = "主相机切换-(主:相机1,次:相机2）";
            this.sBtnItemCamera.Value = true;
            this.sBtnItemCamera.ValueChanging += new System.EventHandler(this.sBtnItemCamera_ValueChanging);
            // 
            // btnItemRecord
            // 
            this.btnItemRecord.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemRecord.EnableImageAnimation = true;
            this.btnItemRecord.ForeColor = System.Drawing.Color.White;
            this.btnItemRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnItemRecord.Image")));
            this.btnItemRecord.Name = "btnItemRecord";
            this.btnItemRecord.PopupAnimation = DevComponents.DotNetBar.ePopupAnimation.Random;
            this.btnItemRecord.PressedImage = ((System.Drawing.Image)(resources.GetObject("btnItemRecord.PressedImage")));
            this.btnItemRecord.Symbol = "57419";
            this.btnItemRecord.SymbolColor = System.Drawing.Color.DodgerBlue;
            this.btnItemRecord.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material;
            this.btnItemRecord.SymbolSize = 16F;
            this.btnItemRecord.Text = "视频段录制";
            this.btnItemRecord.Click += new System.EventHandler(this.btnItemRecord_Click);
            // 
            // btnItemPoleNumSet
            // 
            this.btnItemPoleNumSet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnItemPoleNumSet.Enabled = false;
            this.btnItemPoleNumSet.ForeColor = System.Drawing.Color.White;
            this.btnItemPoleNumSet.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnItemPoleNumSet.Name = "btnItemPoleNumSet";
            this.btnItemPoleNumSet.Symbol = "";
            this.btnItemPoleNumSet.Text = "修改支柱号(F2)";
            this.btnItemPoleNumSet.Click += new System.EventHandler(this.btnItemPoleNumSet_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Name = "btnSave";
            this.btnSave.Text = "保存图像(Ctrl+S)";
            this.btnSave.Tooltip = "保存当前图像";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // exPanelJHCS
            // 
            this.exPanelJHCS.CanvasColor = System.Drawing.SystemColors.Control;
            this.exPanelJHCS.CollapseDirection = DevComponents.DotNetBar.eCollapseDirection.TopToBottom;
            this.exPanelJHCS.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.exPanelJHCS.Controls.Add(this.tableLayoutPanel2);
            this.exPanelJHCS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exPanelJHCS.DisabledBackColor = System.Drawing.Color.Empty;
            this.exPanelJHCS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exPanelJHCS.ExpandOnTitleClick = true;
            this.exPanelJHCS.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exPanelJHCS.HideControlsWhenCollapsed = true;
            this.exPanelJHCS.Location = new System.Drawing.Point(0, 527);
            this.exPanelJHCS.Margin = new System.Windows.Forms.Padding(2);
            this.exPanelJHCS.Name = "exPanelJHCS";
            this.exPanelJHCS.Size = new System.Drawing.Size(1498, 232);
            this.exPanelJHCS.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelJHCS.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelJHCS.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelJHCS.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.exPanelJHCS.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.exPanelJHCS.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.exPanelJHCS.Style.GradientAngle = 90;
            this.exPanelJHCS.TabIndex = 83;
            this.exPanelJHCS.TitleHeight = 21;
            this.exPanelJHCS.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.exPanelJHCS.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.exPanelJHCS.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.exPanelJHCS.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.exPanelJHCS.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.exPanelJHCS.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.exPanelJHCS.TitleStyle.GradientAngle = 90;
            this.exPanelJHCS.TitleText = "几何参数曲线";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tChartdg, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tChartlcz, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1498, 211);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tChartdg
            // 
            // 
            // 
            // 
            this.tChartdg.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            this.tChartdg.Axes.Left.Title.Caption = "导高(mm)";
            this.tChartdg.Axes.Left.Title.Lines = new string[] {
        "导高(mm)"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.tChartdg.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartdg.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartdg.Legend.Title.Pen.Visible = false;
            this.tChartdg.Legend.Visible = false;
            this.tChartdg.Location = new System.Drawing.Point(3, 108);
            this.tChartdg.Name = "tChartdg";
            this.tChartdg.Series.Add(this.line1);
            this.tChartdg.Series.Add(this.line2);
            this.tChartdg.Series.Add(this.line3);
            this.tChartdg.Series.Add(this.line4);
            this.tChartdg.Series.Add(this.points1);
            this.tChartdg.Size = new System.Drawing.Size(1492, 100);
            this.tChartdg.TabIndex = 17;
            // 
            // line1
            // 
            // 
            // 
            // 
            this.line1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.line1.ColorEach = false;
            // 
            // 
            // 
            this.line1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line1.Marks.Callout.Distance = 0;
            this.line1.Marks.Callout.Draw3D = false;
            this.line1.Marks.Callout.Length = 10;
            this.line1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line1.Title = "line1";
            // 
            // 
            // 
            this.line1.XValues.DataMember = "X";
            this.line1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line1.YValues.DataMember = "Y";
            // 
            // line2
            // 
            // 
            // 
            // 
            this.line2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.line2.ColorEach = false;
            // 
            // 
            // 
            this.line2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(78)))), ((int)(((byte)(26)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line2.Marks.Callout.Distance = 0;
            this.line2.Marks.Callout.Draw3D = false;
            this.line2.Marks.Callout.Length = 10;
            this.line2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line2.Title = "line2";
            // 
            // 
            // 
            this.line2.XValues.DataMember = "X";
            this.line2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line2.YValues.DataMember = "Y";
            // 
            // line3
            // 
            // 
            // 
            // 
            this.line3.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.line3.ColorEach = false;
            // 
            // 
            // 
            this.line3.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(38)))), ((int)(((byte)(10)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line3.Marks.Callout.Distance = 0;
            this.line3.Marks.Callout.Draw3D = false;
            this.line3.Marks.Callout.Length = 10;
            this.line3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line3.Title = "line3";
            // 
            // 
            // 
            this.line3.XValues.DataMember = "X";
            this.line3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line3.YValues.DataMember = "Y";
            // 
            // line4
            // 
            // 
            // 
            // 
            this.line4.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(168)))));
            this.line4.ColorEach = false;
            // 
            // 
            // 
            this.line4.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(84)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.line4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.line4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.line4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.line4.Marks.Callout.Distance = 0;
            this.line4.Marks.Callout.Draw3D = false;
            this.line4.Marks.Callout.Length = 10;
            this.line4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.line4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.line4.Title = "line4";
            // 
            // 
            // 
            this.line4.XValues.DataMember = "X";
            this.line4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.line4.YValues.DataMember = "Y";
            // 
            // points1
            // 
            this.points1.ColorEach = false;
            // 
            // 
            // 
            this.points1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.points1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.points1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.points1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.points1.Marks.Callout.Distance = 0;
            this.points1.Marks.Callout.Draw3D = false;
            this.points1.Marks.Callout.Length = 0;
            this.points1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.points1.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(64)))), ((int)(((byte)(107)))));
            // 
            // 
            // 
            this.points1.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(64)))), ((int)(((byte)(107)))));
            this.points1.Pointer.HorizSize = 2;
            // 
            // 
            // 
            this.points1.Pointer.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.points1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.points1.Pointer.VertSize = 2;
            this.points1.Pointer.Visible = true;
            this.points1.Title = "points1";
            // 
            // 
            // 
            this.points1.XValues.DataMember = "X";
            this.points1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.points1.YValues.DataMember = "Y";
            // 
            // tChartlcz
            // 
            // 
            // 
            // 
            this.tChartlcz.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.Bottom.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.Depth.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.DepthTop.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.Left.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            this.tChartlcz.Axes.Left.Title.Caption = "拉出值(mm)";
            this.tChartlcz.Axes.Left.Title.Lines = new string[] {
        "拉出值(mm)"};
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.Right.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Axes.Top.Grid.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            this.tChartlcz.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChartlcz.Header.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChartlcz.Legend.Title.Pen.Visible = false;
            this.tChartlcz.Legend.Visible = false;
            this.tChartlcz.Location = new System.Drawing.Point(3, 3);
            this.tChartlcz.Name = "tChartlcz";
            this.tChartlcz.Series.Add(this.lczLine1);
            this.tChartlcz.Series.Add(this.lczLine2);
            this.tChartlcz.Series.Add(this.lczLine3);
            this.tChartlcz.Series.Add(this.lczLine4);
            this.tChartlcz.Series.Add(this.lczPoints);
            this.tChartlcz.Size = new System.Drawing.Size(1492, 99);
            this.tChartlcz.TabIndex = 16;
            // 
            // lczLine1
            // 
            // 
            // 
            // 
            this.lczLine1.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(102)))), ((int)(((byte)(163)))));
            this.lczLine1.ColorEach = false;
            // 
            // 
            // 
            this.lczLine1.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczLine1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lczLine1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lczLine1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lczLine1.Marks.Callout.Distance = 0;
            this.lczLine1.Marks.Callout.Draw3D = false;
            this.lczLine1.Marks.Callout.Length = 10;
            this.lczLine1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lczLine1.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lczLine1.Title = "line1";
            // 
            // 
            // 
            this.lczLine1.XValues.DataMember = "X";
            this.lczLine1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lczLine1.YValues.DataMember = "Y";
            // 
            // lczLine2
            // 
            // 
            // 
            // 
            this.lczLine2.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(156)))), ((int)(((byte)(53)))));
            this.lczLine2.ColorEach = false;
            // 
            // 
            // 
            this.lczLine2.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(78)))), ((int)(((byte)(26)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczLine2.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lczLine2.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lczLine2.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lczLine2.Marks.Callout.Distance = 0;
            this.lczLine2.Marks.Callout.Draw3D = false;
            this.lczLine2.Marks.Callout.Length = 10;
            this.lczLine2.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lczLine2.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lczLine2.Title = "line2";
            // 
            // 
            // 
            this.lczLine2.XValues.DataMember = "X";
            this.lczLine2.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lczLine2.YValues.DataMember = "Y";
            // 
            // lczLine3
            // 
            // 
            // 
            // 
            this.lczLine3.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(76)))), ((int)(((byte)(20)))));
            this.lczLine3.ColorEach = false;
            // 
            // 
            // 
            this.lczLine3.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(38)))), ((int)(((byte)(10)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczLine3.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lczLine3.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lczLine3.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lczLine3.Marks.Callout.Distance = 0;
            this.lczLine3.Marks.Callout.Draw3D = false;
            this.lczLine3.Marks.Callout.Length = 10;
            this.lczLine3.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lczLine3.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lczLine3.Title = "line3";
            // 
            // 
            // 
            this.lczLine3.XValues.DataMember = "X";
            this.lczLine3.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lczLine3.YValues.DataMember = "Y";
            // 
            // lczLine4
            // 
            // 
            // 
            // 
            this.lczLine4.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(151)))), ((int)(((byte)(168)))));
            this.lczLine4.ColorEach = false;
            // 
            // 
            // 
            this.lczLine4.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(76)))), ((int)(((byte)(84)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczLine4.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lczLine4.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lczLine4.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lczLine4.Marks.Callout.Distance = 0;
            this.lczLine4.Marks.Callout.Draw3D = false;
            this.lczLine4.Marks.Callout.Length = 10;
            this.lczLine4.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            this.lczLine4.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lczLine4.Title = "line4";
            // 
            // 
            // 
            this.lczLine4.XValues.DataMember = "X";
            this.lczLine4.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lczLine4.YValues.DataMember = "Y";
            // 
            // lczPoints
            // 
            this.lczPoints.ColorEach = false;
            // 
            // 
            // 
            this.lczPoints.LinePen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczPoints.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.lczPoints.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.lczPoints.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.lczPoints.Marks.Callout.Distance = 0;
            this.lczPoints.Marks.Callout.Draw3D = false;
            this.lczPoints.Marks.Callout.Length = 0;
            this.lczPoints.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.lczPoints.Pointer.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(64)))), ((int)(((byte)(107)))));
            // 
            // 
            // 
            this.lczPoints.Pointer.Brush.Gradient.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(64)))), ((int)(((byte)(107)))));
            this.lczPoints.Pointer.HorizSize = 2;
            // 
            // 
            // 
            this.lczPoints.Pointer.Pen.Color = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.lczPoints.Pointer.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            this.lczPoints.Pointer.VertSize = 2;
            this.lczPoints.Pointer.Visible = true;
            this.lczPoints.Title = "points1";
            // 
            // 
            // 
            this.lczPoints.XValues.DataMember = "X";
            this.lczPoints.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.lczPoints.YValues.DataMember = "Y";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 524);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1498, 3);
            this.splitter1.TabIndex = 84;
            this.splitter1.TabStop = false;
            // 
            // FrmAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1670, 759);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.exPanelLeft);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.exPanelJHCS);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("等线", 10F);
            this.KeyPreview = true;
            this.Name = "FrmAnalyse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAnalyse";
            this.Load += new System.EventHandler(this.FrmAnalyse_Load);
            this.Shown += new System.EventHandler(this.FrmAnalyse_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmAnalyse_KeyUp);
            this.exPanelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewDataInfo)).EndInit();
            this.exPanelCurFault.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewCurFault)).EndInit();
            this.panelEx4.ResumeLayout(false);
            this.panelEx4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.barPlayControl)).EndInit();
            this.barPlayControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iInputFrameSet)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bar2)).EndInit();
            this.exPanelJHCS.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private FVIL.Forms.CFviImageView cFviImageView1;
        private FVIL.Forms.CFviImageView cFviImageView2;
        private FVIL.Forms.CFviImageView cFviImageView3;
        private FVIL.Forms.CFviImageView ImageView2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgViewDataInfo;
        private DevComponents.DotNetBar.ExpandablePanel exPanelLeft;
        private DevComponents.DotNetBar.PanelEx panelEx4;
        private System.Windows.Forms.Timer timerPlay;
        private FVIL.Forms.CFviImageView ImageView;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnGoPoleNum;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPoleNum;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbBoxStation;
        private DevComponents.DotNetBar.Bar barPlayControl;
        private DevComponents.DotNetBar.ButtonItem btnItemPrev;
        private DevComponents.DotNetBar.ButtonItem btnItemPlay;
        private DevComponents.DotNetBar.ButtonItem btnItemNext;
        private DevComponents.DotNetBar.ButtonItem btnItemFrameSet;
        private DevComponents.DotNetBar.ProgressBarItem progressBarItem;
        private DevComponents.Editors.IntegerInput iInputFrameSet;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private FVIL.Forms.CFviImageView imgView;
        private DevComponents.DotNetBar.PanelEx panelMain;
        private DevComponents.DotNetBar.LabelItem lblTotalFrame;
        private FVIL.Forms.CFviImageView cFviImageView4;
        private DevComponents.DotNetBar.Bar bar2;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem lblItemUpDown;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem lblItemStationInfo;
        private DevComponents.DotNetBar.LabelItem labelItem10;
        private DevComponents.DotNetBar.LabelItem lblItemShootTime;
        private DevComponents.DotNetBar.LabelItem labelItem12;
        private DevComponents.DotNetBar.LabelItem labelItem13;
        private DevComponents.DotNetBar.ButtonItem btnItemPoleNumSet;
        private System.Windows.Forms.Panel panelView;
        private DevComponents.DotNetBar.SwitchButtonItem sBtnItemCamera;
        private DevComponents.DotNetBar.ButtonItem btnSave;
        private DevComponents.DotNetBar.ButtonItem btnItemRecord;
        private DevComponents.DotNetBar.LabelX lblRecShow;
        private DevComponents.DotNetBar.ButtonItem btnItemSlower;
        private DevComponents.DotNetBar.ButtonItem btnItemFaster;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPoleNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStation;
        private DevComponents.DotNetBar.ExpandablePanel exPanelCurFault;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgViewCurFault;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn ColDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRid;
        private DevComponents.DotNetBar.ButtonItem btnFrameNo;
        private DevComponents.DotNetBar.ExpandablePanel exPanelJHCS;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Splitter splitter1;
        private Steema.TeeChart.TChart tChartdg;
        private Steema.TeeChart.Styles.Line line1;
        private Steema.TeeChart.Styles.Line line2;
        private Steema.TeeChart.Styles.Line line3;
        private Steema.TeeChart.Styles.Line line4;
        private Steema.TeeChart.Styles.Points points1;
        private Steema.TeeChart.TChart tChartlcz;
        private Steema.TeeChart.Styles.Line lczLine1;
        private Steema.TeeChart.Styles.Line lczLine2;
        private Steema.TeeChart.Styles.Line lczLine3;
        private Steema.TeeChart.Styles.Line lczLine4;
        private Steema.TeeChart.Styles.Points lczPoints;
    }
}