using ComClassLib.core;
using ComClassLib.DB;
using DevComponents.DotNetBar;
using Microsoft.Reporting.WinForms;
using Project2C.config;
using Project2C.DB;
using Project2C.Dialog;

using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Project2C.ChildFrm {

    public partial class FrmReport : DevComponents.DotNetBar.OfficeForm {

        DataTable dtFault;
        StationInfo stationInfo;
        public FrmReport() {
            InitializeComponent();
            stationInfo = null;

        }

        /// <summary>
        /// 载入缺陷数据
        /// </summary>
        private void LoadFaultData() {
            dtFault = SqliteHelper.GetSqlite("imgDb").ExecuteDataTable("select f.*,p.cid,p.shootTime,p.poleNum,p.GPS,p.sId from FaultRecode as f LEFT JOIN picInfo AS p ON f.pid = p.pid", null);
            dtFault.Columns.Add("UName");
            dtFault.Columns.Add("FName");
            dtFault.Columns.Add("RealMemo");
           
            foreach (DataRow  row in dtFault.Rows) {
                FaultInfo faultInfo = FaultInfo.FromJson(row["memo"].ToString());
                row["UName"]= faultInfo.uName;
                row["FName"] = faultInfo.fName;
                row["RealMemo"] = faultInfo.memo;
            }
            BindData();


        }
        private void BindData() {
            if (dgvFault.InvokeRequired) {
                Action a = BindData;
                dgvFault.Invoke(a);
            }
            else {

                dgvFault.AutoGenerateColumns = false;
                dgvFault.DataSource = dtFault;
            }
        }

       
        private void dgvFault_DoubleClick(object sender, EventArgs e) {

        }

        private void dgvFault_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;
            int iFaultId = Convert.ToInt32(dtFault.Rows[e.RowIndex]["faultCamId"]);
            try {

                byte[] buffer = (byte[])dtFault.Rows[e.RowIndex]["ImgA"];
                MemoryStream ms = new MemoryStream(); //新建内存流
                ms.Write(buffer, 0, buffer.Length); //附值
                picBoxImgA.Image = Image.FromStream(ms); //读取流中内容
                picBoxImgA.Refresh();

                buffer = (byte[])dtFault.Rows[e.RowIndex]["ImgB"];
                ms = new MemoryStream(); //新建内存流
                ms.Write(buffer, 0, buffer.Length); //附值
                picBoxImgB.Image = Image.FromStream(ms); //读取流中内容
                picBoxImgB.Refresh();

                picBoxFault.Image = (iFaultId == 1) ? picBoxImgA.Image : picBoxImgB.Image;
                picBoxFault.Refresh();
            }
            catch (Exception ex) {
                MsgBox.Error("刷新错误\n" + ex.ToString());
            }
        }


        private void btnItemToWord_Click(object sender, EventArgs e) {
            ToOutPut(OutType.doc);
        }
        enum OutType {
            pdf,
            doc,
            excel
        }

        private void btnItemToExcel_Click(object sender, EventArgs e) {
            ToOutPut(OutType.pdf);
        }
        private void ToOutPut(OutType outType) {
            SaveFileDialog saveDialog = new SaveFileDialog();
            string sOutInfo = "";
            string sOutType = "";
            if (outType == OutType.pdf) {
                saveDialog.DefaultExt = "pdf";
                saveDialog.Filter = @"PDF(*.pdf)|*.pdf";
                sOutInfo = @"导出PDF报表...";
                sOutType = "pdf";
            }
            else if (outType == OutType.doc) {
                saveDialog.DefaultExt = "doc";
                saveDialog.Filter = @"DOC(*.doc)|*.doc";
                sOutInfo = @"导出WORD报表...";
                sOutType = "Word";
            }
            saveDialog.FileName =stationInfo.TaskName + "检测报告";
            if (saveDialog.ShowDialog() == DialogResult.OK) {
                var docFileName = saveDialog.FileName;
                if (docFileName.IndexOf(":") < 0) return; //被点了取消 

                progressBarItem1.Text = sOutInfo;
                progressBarItem1.Visible = true;
                progressBarItem1.Value = 0;
                this.Enabled = false;
                ReportViewer reportViewer1 = new ReportViewer();
                ReportDataSource rds = new ReportDataSource {
                    Name = "tb1",
                    Value = dtFault
                };
                progressBarItem1.Value = 10;
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = @".\Template\Report1.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("sName", stationInfo.LineName));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("taskDate", stationInfo.TaskDate.ToShortDateString()));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("updown", stationInfo.SType));
                reportViewer1.RefreshReport();
                progressBarItem1.Value = 30;
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = reportViewer1.LocalReport.Render(
                   sOutType, null, out mimeType, out encoding, out extension,
                   out streamids, out warnings);
                progressBarItem1.Value = 50;
                FileStream fs = new FileStream(docFileName, FileMode.Create);
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
                progressBarItem1.Text = @"检测报告导出成功!";
                progressBarItem1.Value = 100;
                this.Enabled = true;
                //MsgBox.Show("PDF检测报告导出成功！");

                //  MessageBox.Show("Report exported to output.pdf", "Info");
            }
        }

        private void buttonItem1_Click(object sender, EventArgs e) {
            var myReport = new Template.MyReport(dtFault);
            myReport.ShowDialog();
        }

        private void FrmReport_Shown(object sender, EventArgs e) {

            new Thread(LoadFaultData).Start();
        }

        private void FrmReport_ResizeEnd(object sender, EventArgs e) {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnItemDel_Click(object sender, EventArgs e) {
            if (dgvFault.CurrentRow == null) {
                return;
            }
            int iSelRowId = dgvFault.CurrentRow.Index;
            if (iSelRowId < 0) return;
            string tip = "是否删除缺陷：" + dgvFault.CurrentRow.Cells["ColUnitName"].Value + "\n" + dgvFault.CurrentRow.Cells["ColFaultName"].Value;
           if (MessageBox.Show(this, tip, "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes) {
                string sqlDel = "delete from FaultRecode where rid=" + dgvFault.CurrentRow.Cells["ColrId"].Value;
                SqliteHelper.GetSqlite("imgDb").ExecuteNonQuery(sqlDel, null);
                ToastNotification.Show(this, @"缺陷删除成功", null, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter);
                dgvFault.Rows.Remove(dgvFault.CurrentRow);
            }
        }
    }
}
