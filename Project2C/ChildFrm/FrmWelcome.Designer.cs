namespace Project2C.ChildFrm {
    partial class FrmWelcome {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWelcome));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtB_LoginID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtB_PWD = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblInfo = new DevComponents.DotNetBar.LabelX();
            this.picBoxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 91);
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
            this.txtB_LoginID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB_LoginID.ForeColor = System.Drawing.Color.Black;
            this.txtB_LoginID.Location = new System.Drawing.Point(159, 50);
            this.txtB_LoginID.Name = "txtB_LoginID";
            this.txtB_LoginID.PreventEnterBeep = true;
            this.txtB_LoginID.Size = new System.Drawing.Size(192, 29);
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
            this.txtB_PWD.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtB_PWD.ForeColor = System.Drawing.Color.Black;
            this.txtB_PWD.Location = new System.Drawing.Point(159, 94);
            this.txtB_PWD.Name = "txtB_PWD";
            this.txtB_PWD.PasswordChar = '*';
            this.txtB_PWD.PreventEnterBeep = true;
            this.txtB_PWD.Size = new System.Drawing.Size(192, 29);
            this.txtB_PWD.TabIndex = 1;
            this.txtB_PWD.WatermarkText = "输入密码";
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(159, 137);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(192, 44);
            this.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOk.Symbol = "";
            this.btnOk.SymbolColor = System.Drawing.Color.Purple;
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "登录";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(200)))), ((int)(((byte)(115)))));
            this.panelLogin.Controls.Add(this.picBoxExit);
            this.panelLogin.Controls.Add(this.lblInfo);
            this.panelLogin.Controls.Add(this.pictureBox1);
            this.panelLogin.Controls.Add(this.txtB_LoginID);
            this.panelLogin.Controls.Add(this.btnOk);
            this.panelLogin.Controls.Add(this.txtB_PWD);
            this.panelLogin.Location = new System.Drawing.Point(406, 275);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(413, 207);
            this.panelLogin.TabIndex = 38;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInfo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblInfo.ForeColor = System.Drawing.Color.Red;
            this.lblInfo.Location = new System.Drawing.Point(120, 16);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(197, 20);
            this.lblInfo.TabIndex = 28;
            this.lblInfo.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // picBoxExit
            // 
            this.picBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.picBoxExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("picBoxExit.Image")));
            this.picBoxExit.Location = new System.Drawing.Point(370, 3);
            this.picBoxExit.Name = "picBoxExit";
            this.picBoxExit.Size = new System.Drawing.Size(33, 33);
            this.picBoxExit.TabIndex = 30;
            this.picBoxExit.TabStop = false;
            this.picBoxExit.Click += new System.EventHandler(this.picBoxExit_Click);
            // 
            // FrmWelcome
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1130, 647);
            this.Controls.Add(this.panelLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmWelcome";
            this.Text = "FrmWelcome";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWelcome_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWelcome_FormClosed);
            this.Shown += new System.EventHandler(this.FrmWelcome_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_LoginID;
        private DevComponents.DotNetBar.Controls.TextBoxX txtB_PWD;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Panel panelLogin;
        private DevComponents.DotNetBar.LabelX lblInfo;
        private System.Windows.Forms.PictureBox picBoxExit;
    }
}