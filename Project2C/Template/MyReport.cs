using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project2C.Template {
    public partial class MyReport : Form {
        DataTable dt;
        public MyReport(DataTable _dt) {
            InitializeComponent();
            dt = _dt;
        }

        private void Report_Load(object sender, EventArgs e) {

            ReportDataSource rds = new ReportDataSource {
                Name = "tb1",
                Value = dt
            };
            
        //    ReportDataSource rdLine = new ReportDataSource {
        //        Name = "tb2",
        //        Value =   (DataTable)GetEntities("classname"); Core.StationInfo.GetInstance()
        //};
        
            reportViewer1.LocalReport.DataSources.Add(rds);

            //reportViewer1.LocalReport.ReportPath = @".\Template\Report1.rdlc";

            //reportViewer1.LocalReport.SetParameters(new ReportParameter("sName", Core.StationInfo.GetInstance().SName));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("taskDate", Core.StationInfo.GetInstance().TaskDate) );
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("updown", Core.StationInfo.GetInstance().UpDown));
            this.reportViewer1.RefreshReport();

             
        }
    }
}
