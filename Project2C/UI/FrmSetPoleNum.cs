using System;
using System.Data;
using System.Windows.Forms;

namespace Project2C.UI {
    public partial class FrmSetPoleNum : DevComponents.DotNetBar.RibbonForm {

        public string StrPoleNum;
        private DataTable dtBaseData;
        public FrmSetPoleNum() {
            InitializeComponent();           
        }
        public FrmSetPoleNum(DataTable dt,Int64 selPoleNameInd) {
            dtBaseData = dt;
            InitializeComponent();
            LoadPoleName();
            int selInd=(int)selPoleNameInd-1;
            cbPoleName.SelectedIndex = selInd;
            lblImgId.Text = selPoleNameInd.ToString();
            lblStationRegion.Text = dt.Rows[selInd]["stationRegion"].ToString();
            lblTunnel.Text = dt.Rows[selInd]["tunnelName"].ToString();

        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadPoleName() {
            for (int i = 0; i < dtBaseData.Rows.Count; i++) {
                var obj = dtBaseData.Rows[i]["PoleName"];
                if (obj == null) {
                    continue;
                }
                cbPoleName.Items.Add(obj.ToString());
            }
            
            
        }
        private void btnOk_Click(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(cbPoleName.Text.Trim())) {
                MessageBox.Show( @"支柱号不能为空");
                return;
            }
            StrPoleNum = cbPoleName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            StrPoleNum = "";
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSetPoleNum_Shown(object sender, EventArgs e) {
            cbPoleName.Focus();
            cbPoleName.SelectAll();
        }
    }
}
