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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Game_Rental_Management
{
    public partial class FrmBranchRevenueReport : UserControl
    {
        DBMain db = null;
        string err;
        DataTable dtBranchRevenue = null;
        BLBranch dbBranchRevenue = new BLBranch();
        public FrmBranchRevenueReport()
        {
            InitializeComponent();
            db = new DBMain();
            LoadBranches();
            dtpFromDate.Value = DateTime.Now.AddDays(-30);
        }


        private void LoadBranches()
        {
            try
            {
                DataSet ds = dbBranchRevenue.GetAllBranches(); 
                DataTable table = ds.Tables[0];

                DataRow allRow = table.NewRow();
                allRow["BranchID"] = DBNull.Value;
                allRow["BranchName"] = "All branches";
                table.Rows.InsertAt(allRow, 0);

                cboBranch.DataSource = table;
                cboBranch.DisplayMember = "BranchName";
                cboBranch.ValueMember = "BranchID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Không lấy được danh sách chi nhánh: {ex.Message}");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string branchID = cboBranch.SelectedValue == DBNull.Value || cboBranch.SelectedValue == null
            ? null
            : cboBranch.SelectedValue.ToString();
            dtBranchRevenue = new DataTable();
            dtBranchRevenue.Clear();
            DataSet ds = dbBranchRevenue.GetRevenueData(branchID, dtpFromDate.Value, dtpToDate.Value);
            dtBranchRevenue = ds.Tables[0];
            dgvREVENUE.DataSource = dtBranchRevenue;

            //DataGridView
            dgvREVENUE.AllowUserToAddRows = false;
            dgvREVENUE.ReadOnly = true;
            dgvREVENUE.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvREVENUE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvREVENUE.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvREVENUE.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvREVENUE.Columns[0].Width = 75;   // BranchID
            dgvREVENUE.Columns[1].Width = 150;  // BranchName
            dgvREVENUE.Columns[2].Width = 70;   // Revenue

            //Chart 
            chartRevenue.Series.Clear();
            chartRevenue.ChartAreas.Clear();

            ChartArea area = new ChartArea("RevenueChartArea");
            area.AxisX.LabelStyle.Angle = -30;
            area.AxisX.Interval = 1;
            area.AxisX.Title = "Branch";
            area.AxisY.Title = "Revenue";
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            chartRevenue.ChartAreas.Add(area);

            Series series = new Series("Revenue");
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "BranchName";
            series.YValueMembers = "Revenue";
            series.Color = Color.DodgerBlue;
            series["PixelPointWidth"] = "40";
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            chartRevenue.Series.Add(series);
            chartRevenue.Legends.Clear(); 

            chartRevenue.DataSource = dtBranchRevenue;
            chartRevenue.DataBind();
        }

    }
}
