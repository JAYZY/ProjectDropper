namespace ComClassLib {
    partial class CtrlView {
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlView));
            this.imgView = new FVIL.Forms.CFviImageView();
            this.lblTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imgView
            // 
            this.imgView.AutoSize = true;
            this.imgView.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("imgView.Display")));
            this.imgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgView.EnableMouseGrip = true;
            this.imgView.Font = new System.Drawing.Font("苹方 常规", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.imgView.Location = new System.Drawing.Point(0, 0);
            this.imgView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.imgView.Name = "imgView";
            this.imgView.Size = new System.Drawing.Size(490, 456);
            this.imgView.TabIndex = 3;
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.BackColor = System.Drawing.Color.Transparent;
            this.lblTip.Font = new System.Drawing.Font("苹方 中等", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTip.ForeColor = System.Drawing.Color.Red;
            this.lblTip.Location = new System.Drawing.Point(13, 0);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(42, 17);
            this.lblTip.TabIndex = 4;
            this.lblTip.Text = "label1";
            this.lblTip.Visible = false;
            // 
            // CtrlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.imgView);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CtrlView";
            this.Size = new System.Drawing.Size(490, 456);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FVIL.Forms.CFviImageView imgView;
        private System.Windows.Forms.Label lblTip;
    }
}
