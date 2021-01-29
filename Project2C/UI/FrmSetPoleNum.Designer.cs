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
            this.btnCancel.Location = new System.Drawing.Point(289, 132);
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
            this.btnOK.Location = new System.Drawing.Point(215, 132);
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
            this.lblTip.Location = new System.Drawing.Point(17, 86);
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
            this.cbPoleName.DisplayMember = "Text";
            this.cbPoleName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPoleName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPoleName.FormattingEnabled = true;
            this.cbPoleName.ItemHeight = 16;
            this.cbPoleName.Location = new System.Drawing.Point(105, 85);
            this.cbPoleName.Name = "cbPoleName";
            this.cbPoleName.Size = new System.Drawing.Size(249, 22);
            this.cbPoleName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbPoleName.TabIndex = 8;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.labelX1.Location = new System.Drawing.Point(17, 30);
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
            this.labelX2.Location = new System.Drawing.Point(17, 58);
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
            this.lblStationRegion.Location = new System.Drawing.Point(105, 58);
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
            this.lblTunnel.Location = new System.Drawing.Point(105, 30);
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
            this.labelX4.Location = new System.Drawing.Point(17, 114);
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
            this.lblImgId.Location = new System.Drawing.Point(105, 115);
            this.lblImgId.Name = "lblImgId";
            this.lblImgId.Size = new System.Drawing.Size(49, 22);
            this.lblImgId.SymbolColor = System.Drawing.Color.RoyalBlue;
            this.lblImgId.SymbolSize = 10F;
            this.lblImgId.TabIndex = 7;
            this.lblImgId.Text = "图像ID";
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
            this.Controls.Add(this.lblImgId);
            this.Controls.Add(this.lblStationRegion);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
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
    }
}