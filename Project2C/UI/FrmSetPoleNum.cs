using System;
using System.Data;
using System.Windows.Forms;

namespace Project2C.UI {
    public partial class FrmSetPoleNum : DevComponents.DotNetBar.RibbonForm {

        public int selBaseDataId;
        private DataTable dtBaseData;
        private bool isChg;
        public FrmSetPoleNum() {
            InitializeComponent();
        }
        public FrmSetPoleNum(DataTable dt, int selPoleNameInd, int imgId) {

            isChg = true;
            dtBaseData = dt;
            InitializeComponent();

            LoadPoleName();
            lblImgId.Text = imgId.ToString();
            int selInd = selPoleNameInd < 0 ? 0 : selPoleNameInd;
            BindCtrlWithData(dt.Rows[selInd]);
            
            isChg = false;
        }
        /// <summary>
        /// 控件数据绑定
        /// </summary>
        /// <param name="dr"></param>
        private void BindCtrlWithData(DataRow dr) {
            cbPoleName.Text = dr["poleName"].ToString();
            lblStationRegion.Text = dr["stationRegion"].ToString();
            lblTunnel.Text = dr["tunnelName"].ToString();
            //---------------
            var oldImgId = dr["ImgId"];
            if (oldImgId == null || string.IsNullOrEmpty(oldImgId.ToString())) {
                lblCoverTip.Visible = false;
            } else {
                lblCoverTip.Text = $"原图像ID:{oldImgId}\n定位信息将被覆盖？";
                lblCoverTip.Visible = true;
            }
            //-------------
        }


            
        /// <summary>
        /// 初始化 下拉列表框控件
        /// </summary>
        private void LoadPoleName() {
            //for (int i = 0; i < dtBaseData.Rows.Count; i++) {
            //    var obj = dtBaseData.Rows[i]["PoleName"];
            //    if (obj == null) {
            //        continue;
            //    }
            //    cbPoleName.Items.Add(obj.ToString());
            //}
            cbPoleName.DataSource = dtBaseData.DefaultView;
            cbPoleName.DisplayMember = "poleName";
            cbPoleName.ValueMember = "id";
            cbPoleName.DropDownColumns = "poleName,id,stationRegion";
            cbPoleName.DropDownColumnsHeaders = "支柱号\r\n序号\r\n站区";
            cbPoleName.DropDownHeight = 200;
            lblId.DataBindings.Add("Text", dtBaseData.DefaultView, "id");

        }
        private void btnOk_Click(object sender, EventArgs e) {

            if (String.IsNullOrEmpty(cbPoleName.Text.Trim())) {
                MessageBox.Show(@"支柱号不能为空");
                return;
            }
            string sId = lblId.Text.Trim();
            if (String.IsNullOrEmpty(sId)) {
                MessageBox.Show(@"选择有误，请重新选择！");
                return;
            }
            selBaseDataId = Convert.ToInt32(sId);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            selBaseDataId = -1;
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmSetPoleNum_Shown(object sender, EventArgs e) {
            cbPoleName.Focus();
            cbPoleName.SelectAll();
        }

        private void cbPoleName_TextChanged(object sender, EventArgs e) {
            if (isChg) {
                return;
            }

            string poleName = cbPoleName.Text.Trim();
            if (!string.IsNullOrEmpty(poleName)) {

                DataRow dr = dtBaseData.Rows.Find(cbPoleName.SelectedValue);

                BindCtrlWithData(dr);
                //    cbPoleName.DataSource = dtBaseData.DefaultView;
                //    selBaseDataId= -1;
                //    lblId.Text = "-1";
                //    lblStationRegion.Text = "未选择";
                //    lblTunnel.Text = "未选择";
                //    return;
            }
            //dgViewLocal.Visible = true;
            //DataView dv = dtBaseData.DefaultView;
            //dv.RowFilter = $"poleName like '{cbPoleName.Text.Trim()}%'";
            ////dv.RowFilter = "Code LIKE '%" + strInput + "%'";
            //dgViewLocal.DataSource = dv;
            //dgViewLocal.Refresh();



            // cbPoleName.DataSource = dv;
            //lblId.DataBindings.Clear();
            //lblId.DataBindings.Add("Text", dv, "id");
            //cbPoleName.DroppedDown = true;


        }
    }
}
