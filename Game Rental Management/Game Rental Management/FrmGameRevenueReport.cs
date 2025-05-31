using Game_Rental_Management.BS_layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Game_Rental_Management
{
    public partial class FrmGameRevenueReport : UserControl
    {
        private BLGame dbGame; 
        private BLGameRevenue dbGameRevenue; 
        private DataTable dtGameRevenue;
        public FrmGameRevenueReport()
        {
            InitializeComponent();
            dbGame = new BLGame(); 
            dbGameRevenue = new BLGameRevenue(); 
            dtGameRevenue = new DataTable(); 
            LoadGames();
        }
        private void LoadGames()
        {
            try
            {
                DataSet ds = dbGame.GetGames();
                cboGame.DataSource = ds.Tables[0];
                cboGame.DisplayMember = "Title"; 
                cboGame.ValueMember = "GameID";  
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Không lấy được danh sách game: {ex.Message}");
            }
        }

        private void FrmGameRevenueReport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddDays(-30); 
            dtpToDate.Value = DateTime.Now;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboGame.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn một game!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string gameID = cboGame.SelectedValue.ToString();
            dtGameRevenue = new DataTable();
            dtGameRevenue.Clear();
            DataSet ds = dbGameRevenue.GetData(gameID, dtpFromDate.Value, dtpToDate.Value);
            dtGameRevenue = ds.Tables[0];
            dgvGameRevenue.DataSource = dtGameRevenue;

            // Cấu hình DataGridView
            dgvGameRevenue.AllowUserToAddRows = false;
            dgvGameRevenue.ReadOnly = true;
            dgvGameRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGameRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGameRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGameRevenue.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvGameRevenue.Columns[0].Width = 75;   // GameID
            dgvGameRevenue.Columns[1].Width = 150;  // Title
            dgvGameRevenue.Columns[2].Width = 70;   // Revenue

            // Cấu hình Chart
            chartGameRevenue.Series.Clear();
            chartGameRevenue.ChartAreas.Clear();

            ChartArea area = new ChartArea("GameRevenueChartArea");
            area.AxisX.LabelStyle.Angle = -30;
            area.AxisX.Interval = 1;
            area.AxisX.Title = "Game";
            area.AxisY.Title = "Doanh thu";
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            chartGameRevenue.ChartAreas.Add(area);

            Series series = new Series("Revenue");
            series.ChartType = SeriesChartType.Column;
            series.XValueMember = "Title";
            series.YValueMembers = "Revenue";
            series.Color = Color.DodgerBlue;
            series["PixelPointWidth"] = "40";
            series.Font = new Font("Segoe UI", 8, FontStyle.Regular);

            chartGameRevenue.Series.Add(series);
            chartGameRevenue.Legends.Clear();
            chartGameRevenue.DataSource = dtGameRevenue;
            chartGameRevenue.DataBind();
        }
    }
}
