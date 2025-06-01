using Game_Rental_Management.BS_layer;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Rental_Management
{
    public partial class FrmBranchReport : Form
    {
        public FrmBranchReport()
        {
            InitializeComponent();
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
        }

        private void FrmBranchReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date;

            BLBranch branchBL = new BLBranch();
            DataTable dt = branchBL.GetBranchRevenueReport(fromDate, toDate);

            ReportDataSource rds = new ReportDataSource("BranchRevenueDataSet", dt);
            reportViewer1.LocalReport.ReportPath = "BranchRevenueReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            ReportParameter[] parameters = new ReportParameter[]
            {
        new ReportParameter("fromDate", fromDate.ToString("yyyy-MM-dd")),
        new ReportParameter("toDate", toDate.ToString("yyyy-MM-dd"))
            };
            reportViewer1.LocalReport.SetParameters(parameters);

            reportViewer1.RefreshReport();
        }
    }
}
