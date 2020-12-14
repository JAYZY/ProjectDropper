namespace Project2C.UI {
    partial class FrmLogin {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtB_LoginID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtB_PWD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.lblInfo = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.Controls.Add(this.txtB_LoginID);
            this.panelEx1.Controls.Add(this.txtB_PWD);
            this.panelEx1.Controls.Add(this.btnOk);
            this.panelEx1.Controls.Add(this.lblInfo);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(395, 160);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 33;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(82, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // txtB_LoginID
            // 
            this.txtB_LoginID.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtB_LoginID.Border.Class = "TextBoxBorder";
            this.txtB_LoginID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtB_LoginID.DisabledBackColor = System.Drawing.Color.White;
            this.txtB_LoginID.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB_LoginID.ForeColor = System.Drawing.Color.Black;
            this.txtB_LoginID.Location = new System.Drawing.Point(136, 28);
            this.txtB_LoginID.Name = "txtB_LoginID";
            this.txtB_LoginID.PreventEnterBeep = true;
            this.txtB_LoginID.Size = new System.Drawing.Size(192, 26);
            this.txtB_LoginID.TabIndex = 0;
            this.txtB_LoginID.WatermarkText = "输入姓名/登陆编号";
            // 
            // txtB_PWD
            // 
            this.txtB_PWD.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtB_PWD.Border.Class = "TextBoxBorder";
            this.txtB_PWD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtB_PWD.DisabledBackColor = System.Drawing.Color.White;
            this.txtB_PWD.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB_PWD.ForeColor = System.Drawing.Color.Black;
            this.txtB_PWD.Location = new System.Drawing.Point(136, 57);
            this.txtB_PWD.Name = "txtB_PWD";
            this.txtB_PWD.PasswordChar = '*';
            this.txtB_PWD.PreventEnterBeep = true;
            this.txtB_PWD.Size = new System.Drawing.Size(192, 26);
            this.txtB_PWD.TabIndex = 1;
            this.txtB_PWD.WatermarkText = "输入密码";
            this.txtB_PWD.TextChanged += new System.EventHandler(this.txtB_PWD_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(136, 97);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(192, 33);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.Symbol = "";
            this.btnOk.SymbolColor = System.Drawing.Color.Purple;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "登录";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            // 
            // 
            // 
            this.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(172, 139);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 0);
            this.lblInfo.TabIndex = 22;
            this.lblInfo.Click += new System.EventHandler(this.lblInfo_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 160);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLogin_FormClosed);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_LoginID;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_PWD;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private DevComponents.DotNetBar.LabelX lblInfo;
    }
}