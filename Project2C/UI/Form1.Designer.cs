namespace Project2C.UI {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imgView = new FVIL.Forms.CFviImageView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imgView
            // 
            this.imgView.BackColor = System.Drawing.Color.Transparent;
            this.imgView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgView.Display = ((FVIL.GDI.CFviDisplay)(resources.GetObject("imgView.Display")));
            this.imgView.EnableMouseGrip = true;
            this.imgView.Location = new System.Drawing.Point(115, 36);
            this.imgView.Name = "imgView";
            this.imgView.Size = new System.Drawing.Size(813, 616);
            this.imgView.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 548);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 60;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 686);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imgView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private FVIL.Forms.CFviImageView imgView;
        private System.Windows.Forms.Button button1;
    }
}