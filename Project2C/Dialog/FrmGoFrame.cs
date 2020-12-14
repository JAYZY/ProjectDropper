using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2C.Dialog {
    public partial class FrmGoFrame : DevComponents.DotNetBar.RibbonForm {

        public int iGoFrame=0;
        public FrmGoFrame() {
            InitializeComponent();
            iInputFrame.Focus();            
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            iGoFrame = -1;
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            iGoFrame = iInputFrame.Value;
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
