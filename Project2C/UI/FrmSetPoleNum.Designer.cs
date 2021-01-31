namespace Project2C.UI {
    partial class FrmSetPoleNum {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetPoleNum));
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lblTip = new DevComponents.DotNetBar.LabelX();
            this.cbPoleName = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblStationRegion = new DevComponents.DotNetBar.LabelX();
            this.lblTunnel = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblImgId = new DevComponents.DotNetBar.LabelX();
            this.lbltxt = new DevComponents.DotNetBar.LabelX();
            this.lblId = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.lblCoverTip = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(312, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 28);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(238, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 28);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblTip
            // 
            // 
            // 
            // 
            this.lblTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTip.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblTip.Location = new System.Drawing.Point(17, 108);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(92, 22);
            this.lblTip.Symbol = "";
            this.lblTip.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblTip.SymbolSize = 10F;
            this.lblTip.TabIndex = 7;
            this.lblTip.Text = "支柱号：";
            // 
            // cbPoleName
            // 
            this.cbPoleName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbPoleName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPoleName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbPoleName.DisplayMember = "Text";
            this.cbPoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPoleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPoleName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoleName.FormattingEnabled = true;
            this.cbPoleName.ItemHeight = 16;
            this.cbPoleName.Location = new System.Drawing.Point(105, 107);
            this.cbPoleName.Name = "cbPoleName";
            this.cbPoleName.Size = new System.Drawing.Size(249, 22);
            this.cbPoleName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPoleName.TabIndex = 8;
            this.cbPoleName.TextChanged += new System.EventHandler(this.cbPoleName_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelX1.Location = new System.Drawing.Point(17, 52);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(92, 22);
            this.labelX1.Symbol = "";
            this.labelX1.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.labelX1.SymbolSize = 10F;
            this.labelX1.TabIndex = 7;
            this.labelX1.Text = "隧道名：";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelX2.Location = new System.Drawing.Point(17, 80);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(92, 22);
            this.labelX2.Symbol = "";
            this.labelX2.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.labelX2.SymbolSize = 10F;
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "站区间：";
            // 
            // lblStationRegion
            // 
            this.lblStationRegion.AutoSize = true;
            // 
            // 
            // 
            this.lblStationRegion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblStationRegion.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblStationRegion.Location = new System.Drawing.Point(105, 80);
            this.lblStationRegion.Name = "lblStationRegion";
            this.lblStationRegion.Size = new System.Drawing.Size(48, 22);
            this.lblStationRegion.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblStationRegion.SymbolSize = 10F;
            this.lblStationRegion.TabIndex = 7;
            this.lblStationRegion.Text = "站区间";
            // 
            // lblTunnel
            // 
            this.lblTunnel.AutoSize = true;
            // 
            // 
            // 
            this.lblTunnel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTunnel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblTunnel.Location = new System.Drawing.Point(105, 52);
            this.lblTunnel.Name = "lblTunnel";
            this.lblTunnel.Size = new System.Drawing.Size(48, 22);
            this.lblTunnel.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblTunnel.SymbolSize = 10F;
            this.lblTunnel.TabIndex = 7;
            this.lblTunnel.Text = "隧道名";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelX4.Location = new System.Drawing.Point(217, 24);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(92, 22);
            this.labelX4.Symbol = "";
            this.labelX4.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.labelX4.SymbolSize = 10F;
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "图像ID:";
            // 
            // lblImgId
            // 
            this.lblImgId.AutoSize = true;
            // 
            // 
            // 
            this.lblImgId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblImgId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblImgId.Location = new System.Drawing.Point(305, 24);
            this.lblImgId.Name = "lblImgId";
            this.lblImgId.Size = new System.Drawing.Size(49, 22);
            this.lblImgId.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblImgId.SymbolSize = 10F;
            this.lblImgId.TabIndex = 7;
            this.lblImgId.Text = "图像ID";
            // 
            // lbltxt
            // 
            // 
            // 
            // 
            this.lbltxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lbltxt.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lbltxt.Location = new System.Drawing.Point(17, 24);
            this.lbltxt.Name = "lbltxt";
            this.lbltxt.Size = new System.Drawing.Size(92, 22);
            this.lbltxt.Symbol = "";
            this.lbltxt.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lbltxt.SymbolSize = 10F;
            this.lbltxt.TabIndex = 7;
            this.lbltxt.Text = "序    号：";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            // 
            // 
            // 
            this.lblId.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblId.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblId.Location = new System.Drawing.Point(105, 24);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(49, 22);
            this.lblId.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblId.SymbolSize = 10F;
            this.lblId.TabIndex = 7;
            this.lblId.Text = "序号ID";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelX3.FontBold = true;
            this.labelX3.ForeColor = System.Drawing.Color.Gray;
            this.labelX3.Location = new System.Drawing.Point(181, 24);
            this.labelX3.Name = "labelX3";
            this.labelX3.SingleLineColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX3.Size = new System.Drawing.Size(12, 22);
            this.labelX3.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.labelX3.SymbolSize = 10F;
            this.labelX3.TabIndex = 7;
            this.labelX3.Text = "|";
            // 
            // lblCoverTip
            // 
            this.lblCoverTip.AutoSize = true;
            // 
            // 
            // 
            this.lblCoverTip.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCoverTip.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblCoverTip.ForeColor = System.Drawing.Color.Crimson;
            this.lblCoverTip.Location = new System.Drawing.Point(217, 52);
            this.lblCoverTip.Name = "lblCoverTip";
            this.lblCoverTip.Size = new System.Drawing.Size(135, 39);
            this.lblCoverTip.Symbol = "";
            this.lblCoverTip.SymbolColor = System.Drawing.Color.Crimson;
            this.lblCoverTip.SymbolSize = 15F;
            this.lblCoverTip.TabIndex = 7;
            this.lblCoverTip.Text = "原图像ID: 1234\r\n请确定后覆盖？";
            this.lblCoverTip.Visible = false;
            // 
            // FrmSetPoleNum
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(403, 184);
            this.Controls.Add(this.cbPoleName);
            this.Controls.Add(this.lblTunnel);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.lblImgId);
            this.Controls.Add(this.lblStationRegion);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.lbltxt);
            this.Controls.Add(this.lblCoverTip);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSetPoleNum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置/修改支柱号";
            this.Shown += new System.EventHandler(this.FrmSetPoleNum_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.LabelX lblTip;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbPoleName;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblStationRegion;
        private DevComponents.DotNetBar.LabelX lblTunnel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblImgId;
        private DevComponents.DotNetBar.LabelX lbltxt;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX lblId;
        private DevComponents.DotNetBar.LabelX lblCoverTip;
    }
}