using DevComponents.AdvTree;
using System;
using System.Data;

namespace Project2C.ChildFrm {
    public partial class FrmSet : DevComponents.DotNetBar.OfficeForm {
        private DataTable dtUnits, dtFault;
        public FrmSet() {
            InitializeComponent();
            dgViewUnit.AutoGenerateColumns = false;
            dgViewUnit.DataSource = dtUnits = config.ConfigInfo.GetInstance().GetConfigInfo().Tables["InfoB"];
            dgViewFault.AutoGenerateColumns = false;
            dgViewFault.DataSource = dtFault = config.ConfigInfo.GetInstance().GetConfigInfo().Tables["Info"];

            LoadUnitTreeInfo();
            iniParam();

        }
        private void iniParam() {

        }


        private void LoadUnitTreeInfo() {

            foreach (DataRow row in dtUnits.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == 0) {
                    Node root = new Node();
                    root.Name = row["UnitID"].ToString();
                    root.Text = row["Name"].ToString();
                    root.Tag = row["Code"].ToString();
                    advTreeUnit.Nodes.Add(root);
                    AddTreeNode(dtUnits, root, Convert.ToInt32(root.Name));
                }

            }
        }
        //递归添加 子节点 
        private void AddTreeNode(DataTable dtOrgan, Node upNode, int pId) {
            foreach (DataRow row in dtOrgan.Rows) {
                if (Convert.ToInt32(row["ParentID"]) == pId) {
                    Node tn = new Node();
                    tn.Name = row["UnitID"].ToString();
                    tn.Text = row["Name"].ToString();
                    tn.Tag = row["Code"].ToString();
                    upNode.Nodes.Add(tn);
                    AddTreeNode(dtOrgan, tn, Convert.ToInt32(row["UnitID"]));//递归，查询list中apid=aid的子节点，并添加到tn中
                }
            }//foreach循环完了，就到出口啦～
        }
    }
}
