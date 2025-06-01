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
    public partial class FrmCustomerReport : Form
    {
        DataTable dtCustomerReport = null;
        string err;
        BLCustomer dbCustomer = new BLCustomer();
        public FrmCustomerReport()
        {
            InitializeComponent();
        }

        private void FrmCustomerReport_Load(object sender, EventArgs e)
        {
            
            dtCustomerReport = dbCustomer.GetCustomerReport();

            reportViewer1.LocalReport.ReportPath = @"CustomerRentalReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CustomerRentalDataSet", dtCustomerReport));
            

            reportViewer1.RefreshReport();
        }
    }
}
