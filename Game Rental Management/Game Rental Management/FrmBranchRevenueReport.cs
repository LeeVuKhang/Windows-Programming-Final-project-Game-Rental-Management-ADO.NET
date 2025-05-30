using Game_Rental_Management.BS_layer;
using Game_Rental_Management.DB_layer;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Game_Rental_Management
{
    public partial class FrmBranchRevenueReport : UserControl
    {
        DBMain db = null;
        string err;
        DataTable dtBranchRevenue = null;
        BLBranchRevenue dbBranchRevenue = new BLBranchRevenue();
        public FrmBranchRevenueReport()
        {
            InitializeComponent();
            db = new DBMain();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            dtBranchRevenue = new DataTable();
            dtBranchRevenue.Clear();
            DataSet ds = dbBranchRevenue.GetData(dtpFromDate.Value, dtpToDate.Value );
            dtBranchRevenue = ds.Tables[0];
            dgvREVENUE.DataSource = dtBranchRevenue;
            dgvREVENUE.Columns[0].Width = 80;  // BranchID
            dgvREVENUE.Columns[1].Width = 150;  // BranchName
            dgvREVENUE.Columns[2].Width = 80;  // Revenue
        }
    }
}
