﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDropper.UI {
    public partial class ExitWarning : Form {
        public ExitWarning(string sMsgTip) {
            InitializeComponent();
            lblTip.Text = $"{sMsgTip}";
            tbPwd.Focus();
            tbPwd.SelectAll();

        }


        private void btnExit_Click(object sender, EventArgs e) {
            if (tbPwd.Text.Equals("666")) {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else {
                ComClassLib.MsgBox.Error("指令输入错误，请重试！");
                tbPwd.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

      
    }
}
