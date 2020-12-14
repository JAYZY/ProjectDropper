namespace Project2C.UI {
    partial class FrmFault {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFault));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgViewFault = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgViewUnit = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtxtDemo = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbFault = new System.Windows.Forms.TextBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbUnitName = new System.Windows.Forms.TextBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblStationName = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.advTreeFault = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector2 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle3 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.advTreeUnit = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyle2 = new DevComponents.DotNetBar.ElementStyle();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.tbPoleNum = new System.Windows.Forms.TextBox();
            this.cbFaultRateC = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbFaultRateB = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.cbFaultRateA = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.columnHeader1 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader2 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader3 = new DevComponents.AdvTree.ColumnHeader();
            this.columnHeader4 = new DevComponents.AdvTree.ColumnHeader();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewFault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUnit)).BeginInit();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeFault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // dgViewFault
            // 
            this.dgViewFault.AllowUserToAddRows = false;
            this.dgViewFault.AllowUserToDeleteRows = false;
            this.dgViewFault.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewFault.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewFault.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewFault.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            resources.ApplyResources(this.dgViewFault, "dgViewFault");
            this.dgViewFault.MultiSelect = false;
            this.dgViewFault.Name = "dgViewFault";
            this.dgViewFault.ReadOnly = true;
            this.dgViewFault.RowHeadersVisible = false;
            this.dgViewFault.RowTemplate.Height = 23;
            this.dgViewFault.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewFault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgViewFault_KeyDown);
            this.dgViewFault.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgViewFault_MouseDoubleClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dgViewUnit
            // 
            this.dgViewUnit.AllowUserToAddRows = false;
            this.dgViewUnit.AllowUserToDeleteRows = false;
            this.dgViewUnit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewUnit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgViewUnit.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgViewUnit.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            resources.ApplyResources(this.dgViewUnit, "dgViewUnit");
            this.dgViewUnit.MultiSelect = false;
            this.dgViewUnit.Name = "dgViewUnit";
            this.dgViewUnit.ReadOnly = true;
            this.dgViewUnit.RowHeadersVisible = false;
            this.dgViewUnit.RowTemplate.Height = 23;
            this.dgViewUnit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgView_KeyDown);
            this.dgViewUnit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgViewUnit_MouseDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Code";
            resources.ApplyResources(this.Column1, "Column1");
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            resources.ApplyResources(this.Column2, "Column2");
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // rtxtDemo
            // 
            // 
            // 
            // 
            this.rtxtDemo.BackgroundStyle.Class = "RichTextBoxBorder";
            this.rtxtDemo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.rtxtDemo, "rtxtDemo");
            this.rtxtDemo.Name = "rtxtDemo";
            this.rtxtDemo.Rtf = "{\\rtf1\\ansi\\ansicpg936\\deff0\\deflang1033\\deflangfe2052{\\fonttbl{\\f0\\fnil\\fcharset" +
    "134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\uc1\\pard\\lang2052\\f0\\fs18\\par\r\n}\r\n";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelX7
            // 
            resources.ApplyResources(this.labelX7, "labelX7");
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Name = "labelX7";
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // labelX6
            // 
            resources.ApplyResources(this.labelX6, "labelX6");
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Name = "labelX6";
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // tbFault
            // 
            this.tbFault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tbFault, "tbFault");
            this.tbFault.Name = "tbFault";
            this.toolTip1.SetToolTip(this.tbFault, resources.GetString("tbFault.ToolTip"));
            this.tbFault.TextChanged += new System.EventHandler(this.tbFault_TextChanged);
            this.tbFault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFault_KeyDown);
            // 
            // labelX5
            // 
            resources.ApplyResources(this.labelX5, "labelX5");
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Name = "labelX5";
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // tbUnitName
            // 
            this.tbUnitName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.tbUnitName, "tbUnitName");
            this.tbUnitName.Name = "tbUnitName";
            this.toolTip1.SetToolTip(this.tbUnitName, resources.GetString("tbUnitName.ToolTip"));
            this.tbUnitName.TextChanged += new System.EventHandler(this.tbPartName_TextChanged);
            this.tbUnitName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPartName_KeyDown);
            // 
            // labelX3
            // 
            resources.ApplyResources(this.labelX3, "labelX3");
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Name = "labelX3";
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // labelX4
            // 
            resources.ApplyResources(this.labelX4, "labelX4");
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Name = "labelX4";
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // lblStationName
            // 
            // 
            // 
            // 
            this.lblStationName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            resources.ApplyResources(this.lblStationName, "lblStationName");
            this.lblStationName.Name = "lblStationName";
            // 
            // labelX1
            // 
            resources.ApplyResources(this.labelX1, "labelX1");
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Name = "labelX1";
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.buttonX1);
            this.panelEx2.Controls.Add(this.advTreeFault);
            this.panelEx2.Controls.Add(this.advTreeUnit);
            this.panelEx2.Controls.Add(this.btnOk);
            this.panelEx2.Controls.Add(this.dgViewFault);
            this.panelEx2.Controls.Add(this.textBox1);
            this.panelEx2.Controls.Add(this.tbPoleNum);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.dgViewUnit);
            this.panelEx2.Controls.Add(this.lblStationName);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.rtxtDemo);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.btnCancel);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.tbUnitName);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.tbFault);
            this.panelEx2.Controls.Add(this.cbFaultRateC);
            this.panelEx2.Controls.Add(this.cbFaultRateB);
            this.panelEx2.Controls.Add(this.cbFaultRateA);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.panelEx2, "panelEx2");
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            resources.ApplyResources(this.buttonX1, "buttonX1");
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // advTreeFault
            // 
            this.advTreeFault.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeFault.AllowDrop = true;
            this.advTreeFault.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeFault.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeFault.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeFault.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            resources.ApplyResources(this.advTreeFault, "advTreeFault");
            this.advTreeFault.Name = "advTreeFault";
            this.advTreeFault.NodesConnector = this.nodeConnector2;
            this.advTreeFault.NodeStyle = this.elementStyle3;
            this.advTreeFault.NodeStyleExpanded = this.elementStyle4;
            this.advTreeFault.PathSeparator = ";";
            this.advTreeFault.Styles.Add(this.elementStyle3);
            this.advTreeFault.Styles.Add(this.elementStyle4);
            this.advTreeFault.DoubleClick += new System.EventHandler(this.advTree_DoubleClick);
            // 
            // nodeConnector2
            // 
            this.nodeConnector2.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle3
            // 
            this.elementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle3.Name = "elementStyle3";
            this.elementStyle3.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle4
            // 
            this.elementStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.elementStyle4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            this.elementStyle4.BackColorGradientAngle = 90;
            this.elementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderBottomWidth = 1;
            this.elementStyle4.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderLeftWidth = 1;
            this.elementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderRightWidth = 1;
            this.elementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle4.BorderTopWidth = 1;
            this.elementStyle4.CornerDiameter = 4;
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Description = "Purple";
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.PaddingBottom = 1;
            this.elementStyle4.PaddingLeft = 1;
            this.elementStyle4.PaddingRight = 1;
            this.elementStyle4.PaddingTop = 1;
            this.elementStyle4.TextColor = System.Drawing.Color.Black;
            // 
            // advTreeUnit
            // 
            this.advTreeUnit.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advTreeUnit.AllowDrop = true;
            this.advTreeUnit.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.advTreeUnit.BackgroundStyle.Class = "TreeBorderKey";
            this.advTreeUnit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advTreeUnit.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle;
            resources.ApplyResources(this.advTreeUnit, "advTreeUnit");
            this.advTreeUnit.Name = "advTreeUnit";
            this.advTreeUnit.NodesConnector = this.nodeConnector1;
            this.advTreeUnit.NodeStyle = this.elementStyle1;
            this.advTreeUnit.NodeStyleExpanded = this.elementStyle2;
            this.advTreeUnit.PathSeparator = ";";
            this.advTreeUnit.Styles.Add(this.elementStyle1);
            this.advTreeUnit.Styles.Add(this.elementStyle2);
            this.advTreeUnit.DoubleClick += new System.EventHandler(this.advTree_DoubleClick);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle2
            // 
            this.elementStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(227)))), ((int)(((byte)(245)))));
            this.elementStyle2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(158)))), ((int)(((byte)(222)))));
            this.elementStyle2.BackColorGradientAngle = 90;
            this.elementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderBottomWidth = 1;
            this.elementStyle2.BorderColor = System.Drawing.Color.DarkGray;
            this.elementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderLeftWidth = 1;
            this.elementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderRightWidth = 1;
            this.elementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.elementStyle2.BorderTopWidth = 1;
            this.elementStyle2.CornerDiameter = 4;
            this.elementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle2.Description = "Purple";
            this.elementStyle2.Name = "elementStyle2";
            this.elementStyle2.PaddingBottom = 1;
            this.elementStyle2.PaddingLeft = 1;
            this.elementStyle2.PaddingRight = 1;
            this.elementStyle2.PaddingTop = 1;
            this.elementStyle2.TextColor = System.Drawing.Color.Black;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbPoleNum
            // 
            this.tbPoleNum.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.tbPoleNum, "tbPoleNum");
            this.tbPoleNum.ForeColor = System.Drawing.Color.Red;
            this.tbPoleNum.Name = "tbPoleNum";
            this.tbPoleNum.TabStop = false;
            // 
            // cbFaultRateC
            // 
            resources.ApplyResources(this.cbFaultRateC, "cbFaultRateC");
            // 
            // 
            // 
            this.cbFaultRateC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFaultRateC.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbFaultRateC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFaultRateC.Name = "cbFaultRateC";
            this.cbFaultRateC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFaultRateC.TabStop = false;
            this.cbFaultRateC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFaultRate_KeyDown);
            // 
            // cbFaultRateB
            // 
            resources.ApplyResources(this.cbFaultRateB, "cbFaultRateB");
            // 
            // 
            // 
            this.cbFaultRateB.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFaultRateB.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbFaultRateB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFaultRateB.Name = "cbFaultRateB";
            this.cbFaultRateB.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFaultRateB.TabStop = false;
            this.cbFaultRateB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFaultRate_KeyDown);
            // 
            // cbFaultRateA
            // 
            resources.ApplyResources(this.cbFaultRateA, "cbFaultRateA");
            // 
            // 
            // 
            this.cbFaultRateA.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbFaultRateA.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton;
            this.cbFaultRateA.Checked = true;
            this.cbFaultRateA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFaultRateA.CheckValue = "Y";
            this.cbFaultRateA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbFaultRateA.Name = "cbFaultRateA";
            this.cbFaultRateA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbFaultRateA.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFaultRate_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            this.columnHeader1.Width.Absolute = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Name = "columnHeader2";
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            this.columnHeader2.Width.Absolute = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 3;
            this.columnHeader3.Name = "columnHeader3";
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            this.columnHeader3.Width.Absolute = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Name = "columnHeader4";
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            this.columnHeader4.Width.Absolute = 150;
            // 
            // labelX2
            // 
            resources.ApplyResources(this.labelX2, "labelX2");
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Name = "labelX2";
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Name = "textBox1";
            this.textBox1.TabStop = false;
            // 
            // FrmFault
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEx2);
            this.DoubleBuffered = true;
            this.Name = "FrmFault";
            ((System.ComponentModel.ISupportInitialize)(this.dgViewFault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewUnit)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.panelEx2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeFault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advTreeUnit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.Controls.RichTextBoxEx rtxtDemo;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.TextBox tbFault;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.TextBox tbUnitName;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblStationName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgViewUnit;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgViewFault;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private System.Windows.Forms.TextBox tbPoleNum;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFaultRateC;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFaultRateB;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbFaultRateA;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.AdvTree.ColumnHeader columnHeader1;
        private DevComponents.AdvTree.ColumnHeader columnHeader2;
        private DevComponents.AdvTree.ColumnHeader columnHeader3;
        private DevComponents.AdvTree.ColumnHeader columnHeader4;
        private DevComponents.AdvTree.AdvTree advTreeUnit;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ElementStyle elementStyle2;
        private DevComponents.AdvTree.NodeConnector nodeConnector2;
        private DevComponents.DotNetBar.ElementStyle elementStyle3;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.AdvTree.AdvTree advTreeFault;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.TextBox textBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
    }
}