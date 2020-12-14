using System;
using System.Windows.Forms;

namespace Project2C.UI {
    public partial class FrmSetPoleNum : DevComponents.DotNetBar.RibbonForm {

        public string StrPoleNum;
        public FrmSetPoleNum() {
            InitializeComponent();           
        }

        private void btnOk_Click(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(tbPoleNum.Text.Trim())) {
                MessageBox.Show( @"支柱号不能为空");
                return;
            }
            StrPoleNum = tbPoleNum.Text.Trim();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            StrPoleNum = "";
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSetPoleNum_Shown(object sender, EventArgs e) {
            tbPoleNum.Focus();
            tbPoleNum.SelectAll();
        }
    }
}
