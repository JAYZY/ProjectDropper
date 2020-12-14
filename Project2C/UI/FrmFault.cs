using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.AdvTree;
using Project2C.config;
using Project2C.DB;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Project2C.UI {
    public partial class FrmFault : Form {

        DataTable dtUnits = null;
        DataTable dtFault = null;
        DataRow curDataInfo, drFaultDataInfo;
        private bool isInputUnitInfo = false;
        private bool isInputFaultInfo = false;
        private bool isTreeState = false;
        private bool isModify = false;
        private Rectangle rect;
        private string strPoleNum;
        private byte[] imgA, imgB;


        public bool ModifyPoleNum { get; set; }
        private bool IsFaultCamA { get; set; }
        //插入数据后返回 最后一条异常数据的rid
        public int LastInsertRid { get; set; }
        //返回插入的数据
        public DataRow DrNewFault { get; set; }

        private StationInfo stationInfo;
        public FrmFault(DataRow _curDataInfo, Rectangle _rect, byte[] _faultImgA, byte[] _faultImgB, bool _isCamA) {
            curDataInfo = _curDataInfo;
            drFaultDataInfo = null;
            rect = _rect;

            imgA = _faultImgA;
            imgB = _faultImgB;
            IsFaultCamA = _isCamA;

            InitializeComponent();

            isModify = false;
            IniInfo();

            DataTable DtCurFault = new DataTable();
            DtCurFault.Columns.Add("rId"); DtCurFault.Columns.Add("fId"); DtCurFault.Columns.Add("uId"); DtCurFault.Columns.Add("fName"); DtCurFault.Columns.Add("uName");
            DtCurFault.Columns.Add("fLevel"); DtCurFault.Columns.Add("rMemo");
            DrNewFault = DtCurFault.NewRow();
            stationInfo = null;
        }

        /// <summary>
        /// 修改状态，传入
        /// </summary>
        /// <param name="_curDataInfo"></param>
        public FrmFault(DataRow _drFaultData, DataRow _curDataInfo) {
            curDataInfo = _curDataInfo;
            drFaultDataInfo = _drFaultData;
            imgA = null;
            imgB = null;

            InitializeComponent();            
            isModify = true;
            IniInfo();       
      
        }
        private void IniInfo() {
            ModifyPoleNum = false;
            tbPoleNum.Text = strPoleNum = curDataInfo["poleNum"] == null ? "" : curDataInfo["poleNum"].ToString();
            if (isModify && drFaultDataInfo != null) {
                tbFault.Tag = drFaultDataInfo["fId"]; tbFault.Text = drFaultDataInfo["fName"].ToString();
                tbUnitName.Tag = drFaultDataInfo["uId"]; tbUnitName.Text = drFaultDataInfo["uName"].ToString();
                rtxtDemo.Text = drFaultDataInfo["rMemo"].ToString();
                switch (drFaultDataInfo["fLevel"].ToString()) {
                    case "A":
                        cbFaultRateA.Checked = true; break;
                    case "B":
                        cbFaultRateB.Checked = true; break;
                    case "C":
                        cbFaultRateC.Checked = true; break;
                }
            }
            LoadDtInfo();
            LoadTreeInfo();
        }

        //讀取XML文件读取相应数据
        private void LoadDtInfo() {
            if (stationInfo == null) return;
            lblStationName.Text = stationInfo.LineName;

            dgViewUnit.Visible = false;
            dtUnits = config.ConfigInfo.GetInstance().GetConfigInfo().Tables["InfoB"];
            dgViewUnit.AutoGenerateColumns = false;
            dgViewUnit.DataSource = dtUnits;
            dgViewUnit.Location = new Point(tbUnitName.Left, tbUnitName.Top + tbUnitName.Height);

            dgViewFault.Visible = false;
            dtFault = config.ConfigInfo.GetInstance().GetConfigInfo().Tables["Info"];
            dgViewFault.AutoGenerateColumns = false;
            dgViewFault.DataSource = dtFault;
            dgViewFault.Location = new Point(tbFault.Left, tbFault.Top + tbFault.Height);
        }


        private void LoadTreeInfo() {
            advTreeUnit.Visible = false;
            foreach (DataRow row in dtUnits.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == 0) {
                    Node root = new Node();
                    root.Name = row["UnitID"].ToString();
                    root.Text = row["Name"].ToString();
                    root.Tag = row["Code"].ToString();
                    advTreeUnit.Nodes.Add(root);
                    AddTreeUnitNode(root, Convert.ToInt32(root.Name));
                }
            }
            advTreeUnit.Location = new Point(tbUnitName.Left, tbUnitName.Top + tbUnitName.Height);

            advTreeFault.Visible = false;
            foreach (DataRow row in dtFault.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == 0) {
                    Node root = new Node();
                    root.Name = row["FaultID"].ToString();
                    root.Text = row["Name"].ToString();
                    root.Tag = row["Code"].ToString();
                    advTreeFault.Nodes.Add(root);
                    AddTreeFaultNode(root, Convert.ToInt32(root.Name));
                }
            }
            advTreeFault.Location = new Point(tbFault.Left, tbFault.Top + tbFault.Height);

        }
        /// <summary>
        /// tree鼠标事件 - 部件/缺陷 树节点选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advTree_DoubleClick(object sender, EventArgs e) {
            AdvTree curTree = (AdvTree)sender;
            if (curTree.SelectedNode == null)
                return;
            Node selNode = curTree.SelectedNode;

            string name = selNode.Text;
            selNode = selNode.Parent;
            while (selNode != null) {
                name = selNode.Text + "-" + name;
                selNode = selNode.Parent;
            }
            if (curTree == advTreeUnit) {
                tbUnitName.Tag = curTree.SelectedNode.Name;
                tbUnitName.Text = name;
                isInputUnitInfo = true;
            }
            else if (curTree == advTreeFault) {
                tbFault.Tag = curTree.SelectedNode.Name;
                tbFault.Text = name;
                isInputFaultInfo = true;
            }
            isTreeState = true;
            advTreeUnit.Visible = false;
            // isTreeState = false;
        }

        #region 部件输入
        /// <summary>
        /// textbox事件 - 根据输入内容改变文本提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPartName_TextChanged(object sender, EventArgs e) {

            string strInput = tbUnitName.Text;
            if (strInput == " ") {
                advTreeUnit.Visible = true;
                isTreeState = true;
                return;
            }
            if (isTreeState) {
                isTreeState = false;
                advTreeUnit.Visible = false;
                return;
            }
            advTreeUnit.Visible = false;
            if (String.IsNullOrEmpty(strInput)) {
                dgViewUnit.Visible = false;
                return;
            }
            if (dtUnits == null) return;
            isInputUnitInfo = false;
            dgViewUnit.Visible = true;
            DataView dv = dtUnits.DefaultView;
            dv.RowFilter = "Code LIKE '%" + strInput + "%'";
            dgViewUnit.DataSource = dv;
            dgViewUnit.Refresh();
        }
        /// <summary>
        /// textBox键盘事件 - 键盘向下，选择内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPartName_KeyDown(object sender, KeyEventArgs e) {

            if (!dgViewUnit.Visible)
                return;
            if (e.KeyCode == Keys.Down) {
                dgViewUnit.Focus();
            }
            else if (e.KeyCode == Keys.Enter) {
                dgView_KeyDown(sender, e);
            }

        }
        /// <summary>
        /// dvView键盘事件 - 部件提示信息选择
        /// </summary>
        private void dgView_KeyDown(object sender, KeyEventArgs e) {
            if (dgViewUnit.CurrentRow == null)
                return;
            if (e.KeyCode == Keys.Enter) {
                UnitSel();
            }
            else if (Char.IsLetter((char)e.KeyCode) || Char.IsNumber((char)e.KeyCode)) {
                tbUnitName.Text += (char)e.KeyCode;
                tbUnitName.Focus();
            }
        }
        /// <summary>
        /// dgView鼠标事件 - 部件提示信息选择
        /// </summary>
        private void dgViewUnit_MouseDoubleClick(object sender, MouseEventArgs e) {
            UnitSel();
        }

        /// <summary>
        /// 部件提示信息选定
        /// </summary>
        private void UnitSel() {
            if (dgViewUnit.CurrentRow == null)
                return;
            DataView dv = (DataView)dgViewUnit.DataSource;
            int ind = dgViewUnit.CurrentRow.Index;
            string ParentID = (dv[ind]["ParentID"].ToString());
            string name = (dv[ind]["Name"].ToString());
            string uintId = dv[ind]["UnitID"].ToString();
            while (ParentID != "0") {
                DataRow[] drs = dtUnits.Select("UnitID='" + ParentID + "'");
                ParentID = (drs[0]["ParentID"].ToString());
                name = (drs[0]["Name"].ToString()) + "-" + name;
            }
            tbUnitName.Text = name;
            tbUnitName.Tag = uintId;
            dgViewUnit.Visible = false;
            isInputUnitInfo = true;
            tbFault.Focus();
        }


        /// <summary>
        /// 递归添加部件树 子节点 
        /// </summary>
        /// <param name="upNode"></param>
        /// <param name="pId"></param>
        private void AddTreeUnitNode(Node upNode, int pId) {
            foreach (DataRow row in dtUnits.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == pId) {
                    Node tn = new Node();
                    tn.Name = row["UnitID"].ToString();
                    tn.Text = row["Name"].ToString();
                    tn.Tag = row["Code"].ToString();
                    upNode.Nodes.Add(tn);
                    AddTreeUnitNode(tn, Convert.ToInt32(row["UnitID"]));//递归，查询list中apid=aid的子节点，并添加到tn中
                }
            }
        }



        #endregion

        #region 缺陷输入
        /// <summary>
        /// textbox事件 - 根据输入内容改变文本提示
        /// </summary>     
        private void tbFault_TextChanged(object sender, EventArgs e) {
            string strInput = tbFault.Text;

            if (strInput == " ") {
                advTreeFault.Visible = true;
                isTreeState = true;
                return;
            }
            if (isTreeState) {
                isTreeState = false;
                advTreeFault.Visible = false;
                return;
            }
            if (String.IsNullOrEmpty(strInput)) {
                dgViewFault.Visible = false;
                return;
            }
            if (dtFault == null) return;
            isInputFaultInfo = false;
            dgViewFault.Visible = true;
            DataView dv = dtFault.DefaultView;
            dv.RowFilter = "Code LIKE '%" + strInput + "%'";
            dgViewFault.DataSource = dv;
            dgViewFault.Refresh();
        }
        /// <summary>
        /// textbox键盘事件 - 键盘向下，选择内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbFault_KeyDown(object sender, KeyEventArgs e) {
            if (!dgViewFault.Visible)
                return;
            if (e.KeyCode == Keys.Down) {
                dgViewFault.Focus();
            }
            else if (e.KeyCode == Keys.Enter) {
                dgViewFault_KeyDown(sender, e);
            }
        }
        /// <summary>
        /// dgview键盘事件 -  缺陷信息选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewFault_KeyDown(object sender, KeyEventArgs e) {
            if (dgViewFault.CurrentRow == null)
                return;
            if (e.KeyCode == Keys.Enter) {
                FaultInfoSel();
            }
            else if (Char.IsLetter((char)e.KeyCode) || Char.IsNumber((char)e.KeyCode)) {
                tbFault.Text += e.KeyCode;
                tbFault.Focus();
            }

        }
        /// <summary>
        ///  dgview鼠标事件 - 双击缺陷信息选择
        /// </summary>        
        private void dgViewFault_MouseDoubleClick(object sender, MouseEventArgs e) {
            FaultInfoSel();
        }
        /// <summary>
        /// 缺陷信息选择
        /// </summary>
        private void FaultInfoSel() {
            if (dgViewFault.CurrentRow == null)
                return;
            DataView dv = (DataView)dgViewFault.DataSource;
            int ind = dgViewFault.CurrentRow.Index;
            string ParentID = (dv[ind]["ParentID"].ToString());
            string name = (dv[ind]["Name"].ToString());
            string faultId = dv[ind]["FaultID"].ToString();
            while (ParentID != "0") {
                DataRow[] drs = dtFault.Select("FaultID='" + ParentID + "'");
                ParentID = (drs[0]["ParentID"].ToString());
                name = (drs[0]["Name"].ToString()) + "-" + name;
            }
            tbFault.Text = name;
            tbFault.Tag = faultId;
            dgViewFault.Visible = false;
            isInputFaultInfo = true;
            cbFaultRateA.Focus();
        }

        /// <summary>
        /// 递归添加缺陷树 子节点 
        /// </summary>
        /// <param name="upNode"></param>
        /// <param name="pId"></param>
        private void AddTreeFaultNode(Node upNode, int pId) {
            foreach (DataRow row in dtFault.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == pId) {
                    Node tn = new Node();
                    tn.Name = row["FaultID"].ToString();
                    tn.Text = row["Name"].ToString();
                    tn.Tag = row["Code"].ToString();
                    upNode.Nodes.Add(tn);
                    AddTreeFaultNode(tn, Convert.ToInt32(row["FaultID"]));//递归，查询list中apid=aid的子节点，并添加到tn中
                }
            }
        }

        #endregion


        #region 缺陷等级输入
        /// <summary>
        /// 缺陷等级选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFaultRate_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.A)
                cbFaultRateA.Checked = true;
            else if (e.KeyCode == Keys.B)
                cbFaultRateB.Checked = true;
            else if (e.KeyCode == Keys.C)
                cbFaultRateC.Checked = true;
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e) {
            if (!isModify) {
                if (string.IsNullOrEmpty(tbPoleNum.Text.Trim())) {
                    MessageBox.Show(this, "请输入支柱号", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPoleNum.Focus();
                    return;
                }
                else if (!isInputUnitInfo || string.IsNullOrEmpty(tbUnitName.Text.Trim())) {
                    MessageBox.Show(this, "请输入部件", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbUnitName.Focus();
                    return;
                }
                else if (!isInputFaultInfo || string.IsNullOrEmpty(tbFault.Text.Trim())) {
                    MessageBox.Show(this, "请输入异常信息", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbFault.Focus();
                    return;
                }
            }
            
                string pid = curDataInfo["pId"].ToString();
                //对支柱号进行判断
                if (tbPoleNum.Text != strPoleNum) {
                    string strUpdate = String.Format("update picInfo set poleNum='{0}' where pid={1}", tbPoleNum.Text.Trim(), pid);
                    SqliteHelper.GetSqlite("imgDb").ExecuteNonQuery(strUpdate, null);
                    ModifyPoleNum = true;
                } 
                //写数据库
                if (isModify) { MoidfyFaultInfo(); }
                else {
                    InsertFaultInfo(pid);
                }

           

        }
        private void InsertFaultInfo(string pid) {
            string fLevel = cbFaultRateA.Checked ? cbFaultRateA.Text : (cbFaultRateB.Checked ? cbFaultRateB.Text : cbFaultRateC.Text);
            //string date = DateTime.Now.ToString("yyyy/MM/dd");
            //MessageBox.Show(date);
            string strJson = (new FaultInfo(tbUnitName.Text.Trim(), tbFault.Text.Trim(), rtxtDemo.Text.Trim())).GetJson();
            //" create TABLE FaultRecode(rid INTEGER primary key AUTOINCREMENT,pid INTEGER,uid INTEGER,fid INTEGER,fLevel char(10),
            //analyzeDate DATETIME,comfirmDate DATETIME,OffsetX INTEGER NOT NULL,OffsetY INTEGER NOT NULL,width INTEGER NOT NULL,height INTEGER NOT NULL,memo text, faultCamId INTEGER,ImgA BLOB,ImgB BLOB);";

            string strSql = "insert into FaultRecode(pid,uid,fid,fLevel,analyzeDate,comfirmDate,OffsetX,OffsetY,width,height,memo,faultCamId,ImgA,ImgB) " +
                " values(@pid,@uid,@fid,@fLevel,@analyzeDate,@comfirmDate,@OffsetX,@OffsetY,@width,@height,@memo,@faultCamId,@ImgA,@ImgB )";

            SQLiteParameter[] sqlParm = {
                 new SQLiteParameter("@pid",DbType.Int32),
                 new SQLiteParameter("@uid", DbType.Int32),
                 new SQLiteParameter("@fid", DbType.Int32),
                 new SQLiteParameter("@fLevel", DbType.String),
                 new SQLiteParameter("@analyzeDate", DbType.DateTime),
                 new SQLiteParameter("@comfirmDate", DbType.DateTime  ),
                 new SQLiteParameter("@OffsetX", DbType.Int32),
                 new SQLiteParameter("@OffsetY", DbType.Int32),
                 new SQLiteParameter("@width", DbType.Int32 ),
                 new SQLiteParameter("@height", DbType.Int32),
                 new SQLiteParameter("@memo", DbType.String),
                 new SQLiteParameter("@faultCamId", DbType.Byte),
                 new SQLiteParameter("@ImgA", DbType.Binary),
                new SQLiteParameter("@ImgB", DbType.Binary)     };
            sqlParm[0].Value = pid;
            sqlParm[1].Value = tbUnitName.Tag.ToString();
            sqlParm[2].Value = tbFault.Tag.ToString();
            sqlParm[3].Value = fLevel;
            sqlParm[4].Value = DateTime.Now;
            sqlParm[5].Value = DateTime.Now;
            sqlParm[6].Value = rect.X;
            sqlParm[7].Value = rect.Y;
            sqlParm[8].Value = rect.Width;
            sqlParm[9].Value = rect.Height;
            sqlParm[10].Value = strJson;
            sqlParm[11].Value = IsFaultCamA ? 1 : 0;
            sqlParm[12].Value = imgA;
            sqlParm[13].Value = imgB;
           // SqliteHelper.GetSqlite("imgDb").ExecuteNonQuery(strSql, sqlParm);

           LastInsertRid = Convert.ToInt32(SqliteHelper.GetSqlite("imgDb").ExecuteScalar(strSql + ";select last_insert_rowid();", sqlParm));

            //得到新的数据row
            DrNewFault["rId"] = 1; DrNewFault["fId"] = tbFault.Tag; DrNewFault["uId"] = tbUnitName.Tag;
            DrNewFault["fLevel"] = fLevel; DrNewFault["fName"] = tbFault.Text.Trim(); DrNewFault["uName"] = tbUnitName.Text.Trim();
            DrNewFault["rMemo"] = rtxtDemo.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void MoidfyFaultInfo() {

            if (!isModify) return;//没有修改
            string fLevel = cbFaultRateA.Checked ? cbFaultRateA.Text : (cbFaultRateB.Checked ? cbFaultRateB.Text : cbFaultRateC.Text);
            
            
            string strJson = (new FaultInfo(tbUnitName.Text.Trim(), tbFault.Text.Trim(), rtxtDemo.Text.Trim())).GetJson();
            string strSql = "update FaultRecode set uid=@uid,fid=@fid,fLevel=@fLevel,comfirmDate=@comfirmDate,memo=@memo where rId=@rId";

            SQLiteParameter[] sqlParm = {
                 new SQLiteParameter("@uid", DbType.Int32),
                 new SQLiteParameter("@fid", DbType.Int32),
                 new SQLiteParameter("@fLevel", DbType.String),
                 new SQLiteParameter("@comfirmDate", DbType.DateTime  ),
                 new SQLiteParameter("@memo", DbType.String),
                 new SQLiteParameter("@rId", DbType.Int32)     };
            sqlParm[0].Value = tbUnitName.Tag.ToString();
            sqlParm[1].Value = tbFault.Tag.ToString();
            sqlParm[2].Value = fLevel;
            sqlParm[3].Value = DateTime.Now; 
            sqlParm[4].Value = strJson;
            sqlParm[5].Value = drFaultDataInfo["rId"];
            SqliteHelper.GetSqlite("imgDb").ExecuteNonQuery(strSql, sqlParm);

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
        private void btnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void advTreeUnit_Click(object sender, EventArgs e) {

        }
    }
}
