namespace ControlCenter {
    partial class FrmMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.btnStopTask = new DevComponents.DotNetBar.ButtonX();
            this.btnStartTask = new DevComponents.DotNetBar.ButtonX();
            this.btnTaskConfig = new DevComponents.DotNetBar.ButtonX();
            this.lblTaskInfo = new DevComponents.DotNetBar.LabelX();
            this.label10 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rTbTaskMsg = new System.Windows.Forms.RichTextBox();
            this.lblDelNum = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.lblServMem = new DevComponents.DotNetBar.LabelX();
            this.lblSaveImgNum = new DevComponents.DotNetBar.LabelX();
            this.labelX36 = new DevComponents.DotNetBar.LabelX();
            this.btnItemMin = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel7.SuspendLayout();
            this.panel10.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(239, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 32);
            this.label9.TabIndex = 48;
            this.label9.Text = "开启任务";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(446, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 32);
            this.label3.TabIndex = 48;
            this.label3.Text = "停止任务";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(637, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 32);
            this.label5.TabIndex = 48;
            this.label5.Text = "隐藏系统";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.btnStopTask);
            this.panel7.Controls.Add(this.btnStartTask);
            this.panel7.Controls.Add(this.btnTaskConfig);
            this.panel7.Controls.Add(this.lblTaskInfo);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel7.Size = new System.Drawing.Size(803, 378);
            this.panel7.TabIndex = 52;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.AutoExpandOnClick = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnClose.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnClose.Location = new System.Drawing.Point(643, 139);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 51);
            this.btnClose.TabIndex = 53;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStopTask
            // 
            this.btnStopTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopTask.AutoExpandOnClick = true;
            this.btnStopTask.BackColor = System.Drawing.Color.Transparent;
            this.btnStopTask.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnStopTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStopTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnStopTask.Image = ((System.Drawing.Image)(resources.GetObject("btnStopTask.Image")));
            this.btnStopTask.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnStopTask.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStopTask.Location = new System.Drawing.Point(452, 139);
            this.btnStopTask.Name = "btnStopTask";
            this.btnStopTask.Size = new System.Drawing.Size(99, 51);
            this.btnStopTask.TabIndex = 52;
            this.btnStopTask.Click += new System.EventHandler(this.btnStopTask_Click);
            // 
            // btnStartTask
            // 
            this.btnStartTask.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartTask.AutoExpandOnClick = true;
            this.btnStartTask.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTask.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnStartTask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnStartTask.Image = ((System.Drawing.Image)(resources.GetObject("btnStartTask.Image")));
            this.btnStartTask.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnStartTask.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnStartTask.Location = new System.Drawing.Point(245, 139);
            this.btnStartTask.Name = "btnStartTask";
            this.btnStartTask.Size = new System.Drawing.Size(99, 51);
            this.btnStartTask.TabIndex = 51;
            this.btnStartTask.Click += new System.EventHandler(this.btnStartTask_Click);
            // 
            // btnTaskConfig
            // 
            this.btnTaskConfig.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTaskConfig.AutoExpandOnClick = true;
            this.btnTaskConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnTaskConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnTaskConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaskConfig.Font = new System.Drawing.Font("Microsoft JhengHei UI", 16F);
            this.btnTaskConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskConfig.Image")));
            this.btnTaskConfig.ImageFixedSize = new System.Drawing.Size(124, 77);
            this.btnTaskConfig.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTaskConfig.Location = new System.Drawing.Point(62, 139);
            this.btnTaskConfig.Name = "btnTaskConfig";
            this.btnTaskConfig.Size = new System.Drawing.Size(99, 51);
            this.btnTaskConfig.TabIndex = 50;
            this.btnTaskConfig.Tooltip = "任务配置-04";
            this.btnTaskConfig.Click += new System.EventHandler(this.btnTaskConfig_Click);
            // 
            // lblTaskInfo
            // 
            this.lblTaskInfo.AutoSize = true;
            // 
            // 
            // 
            this.lblTaskInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTaskInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 37.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskInfo.ForeColor = System.Drawing.Color.White;
            this.lblTaskInfo.Location = new System.Drawing.Point(3, 36);
            this.lblTaskInfo.Name = "lblTaskInfo";
            this.lblTaskInfo.Size = new System.Drawing.Size(644, 84);
            this.lblTaskInfo.TabIndex = 49;
            this.lblTaskInfo.Text = "_ _ _  _ _  _ _ _-_ _ _";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(56, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 32);
            this.label10.TabIndex = 48;
            this.label10.Text = "任务配置";
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(91)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.panel10.Controls.Add(this.groupPanel1);
            this.panel10.Controls.Add(this.lblDelNum);
            this.panel10.Controls.Add(this.labelX6);
            this.panel10.Controls.Add(this.lblServMem);
            this.panel10.Controls.Add(this.lblSaveImgNum);
            this.panel10.Controls.Add(this.labelX36);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 233);
            this.panel10.Margin = new System.Windows.Forms.Padding(10);
            this.panel10.Name = "panel10";
            this.panel10.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.panel10.Size = new System.Drawing.Size(803, 145);
            this.panel10.TabIndex = 53;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rTbTaskMsg);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 54);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(798, 86);
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
            this.groupPanel1.TabIndex = 36;
            this.groupPanel1.Text = "实时信息";
            // 
            // rTbTaskMsg
            // 
            this.rTbTaskMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rTbTaskMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTbTaskMsg.Location = new System.Drawing.Point(0, 0);
            this.rTbTaskMsg.Name = "rTbTaskMsg";
            this.rTbTaskMsg.Size = new System.Drawing.Size(792, 56);
            this.rTbTaskMsg.TabIndex = 0;
            this.rTbTaskMsg.Text = "";
            // 
            // lblDelNum
            // 
            this.lblDelNum.AutoSize = true;
            this.lblDelNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblDelNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDelNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblDelNum.Location = new System.Drawing.Point(42, 288);
            this.lblDelNum.Name = "lblDelNum";
            this.lblDelNum.Size = new System.Drawing.Size(0, 0);
            this.lblDelNum.TabIndex = 35;
            // 
            // labelX6
            // 
            this.labelX6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX6.AutoSize = true;
            this.labelX6.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX6.ForeColor = System.Drawing.Color.White;
            this.labelX6.Location = new System.Drawing.Point(582, 9);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(178, 37);
            this.labelX6.TabIndex = 35;
            this.labelX6.Text = "数据服务器内存";
            // 
            // lblServMem
            // 
            this.lblServMem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServMem.AutoSize = true;
            this.lblServMem.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblServMem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblServMem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblServMem.FontBold = true;
            this.lblServMem.ForeColor = System.Drawing.Color.Yellow;
            this.lblServMem.Location = new System.Drawing.Point(764, 9);
            this.lblServMem.Name = "lblServMem";
            this.lblServMem.Size = new System.Drawing.Size(48, 37);
            this.lblServMem.TabIndex = 35;
            this.lblServMem.Text = "0M";
            // 
            // lblSaveImgNum
            // 
            this.lblSaveImgNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaveImgNum.AutoSize = true;
            this.lblSaveImgNum.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblSaveImgNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblSaveImgNum.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.lblSaveImgNum.FontBold = true;
            this.lblSaveImgNum.ForeColor = System.Drawing.Color.Yellow;
            this.lblSaveImgNum.Location = new System.Drawing.Point(237, 9);
            this.lblSaveImgNum.Name = "lblSaveImgNum";
            this.lblSaveImgNum.Size = new System.Drawing.Size(49, 37);
            this.lblSaveImgNum.TabIndex = 35;
            this.lblSaveImgNum.Text = "0张";
            // 
            // labelX36
            // 
            this.labelX36.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelX36.AutoSize = true;
            this.labelX36.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX36.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX36.Font = new System.Drawing.Font("Microsoft JhengHei UI", 14F);
            this.labelX36.ForeColor = System.Drawing.Color.White;
            this.labelX36.Location = new System.Drawing.Point(43, 9);
            this.labelX36.Name = "labelX36";
            this.labelX36.Size = new System.Drawing.Size(178, 37);
            this.labelX36.TabIndex = 35;
            this.labelX36.Text = "持久化图片数量";
            // 
            // btnItemMin
            // 
            this.btnItemMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnItemMin.ForeColor = System.Drawing.Color.White;
            this.btnItemMin.Image = ((System.Drawing.Image)(resources.GetObject("btnItemMin.Image")));
            this.btnItemMin.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.btnItemMin.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.btnItemMin.Name = "btnItemMin";
            this.btnItemMin.Text = "最小化";
            this.btnItemMin.Tooltip = "最小化总控平台";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem1.ForeColor = System.Drawing.Color.White;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.buttonItem1.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "最小化";
            this.buttonItem1.Tooltip = "最小化总控平台";
            // 
            // buttonItem2
            // 
            this.buttonItem2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonItem2.ForeColor = System.Drawing.Color.White;
            this.buttonItem2.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem2.Image")));
            this.buttonItem2.ImageFixedSize = new System.Drawing.Size(32, 32);
            this.buttonItem2.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.Text = "最小化";
            this.buttonItem2.Tooltip = "最小化总控平台";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "吊弦系统总控平台";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 378);
            this.ControlBox = false;
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel7);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "# 数据管理模块";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.DotNetBar.ButtonX btnStopTask;
        private DevComponents.DotNetBar.ButtonX btnStartTask;
        private DevComponents.DotNetBar.ButtonX btnTaskConfig;
        private DevComponents.DotNetBar.LabelX lblTaskInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel10;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.RichTextBox rTbTaskMsg;
        private DevComponents.DotNetBar.LabelX lblDelNum;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX lblServMem;
        private DevComponents.DotNetBar.LabelX lblSaveImgNum;
        private DevComponents.DotNetBar.LabelX labelX36;
        private DevComponents.DotNetBar.ButtonItem btnItemMin;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

