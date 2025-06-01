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
        private readonly BLGame dbGame = new BLGame();
        private DataTable dtGameRevenue = new DataTable();

        public FrmGameRevenueReport()
        {
            InitializeComponent();
            LoadGames();
        }

        private void LoadGames()
        {
            try
            {
                DataSet ds = dbGame.GetGames();
                DataTable table = ds.Tables[0];

                DataRow allRow = table.NewRow();
                allRow["GameID"] = DBNull.Value;    
                allRow["Title"] = "All games";
                table.Rows.InsertAt(allRow, 0);

                cboGame.DataSource = table;
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

            string gameID = cboGame.SelectedValue == DBNull.Value || cboGame.SelectedValue == null
                ? null
                : cboGame.SelectedValue.ToString();

            dtGameRevenue = dbGame.GetRevenueData(gameID, dtpFromDate.Value, dtpToDate.Value).Tables[0];
            dgvGameRevenue.DataSource = dtGameRevenue;

            ConfigureGrid();
            ConfigureChart();
        }


        private void ConfigureGrid()
        {
            dgvGameRevenue.AllowUserToAddRows = false;
            dgvGameRevenue.ReadOnly = true;
            dgvGameRevenue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGameRevenue.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGameRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgvGameRevenue.Columns.Count >= 3)
            {
                dgvGameRevenue.Columns[0].Width = 75;   // GameID
                dgvGameRevenue.Columns[1].Width = 150;  // Title
                dgvGameRevenue.Columns[2].Width = 70;   // Revenue
                dgvGameRevenue.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void ConfigureChart()
        {
            chartGameRevenue.Series.Clear();
            chartGameRevenue.ChartAreas.Clear();

            var area = new ChartArea("GameRevenueChartArea")
            {
                AxisX =
                {
                    LabelStyle = { Angle = -30, Font = new Font("Segoe UI", 8), Interval = 1 },
                    Title = "Game"
                },
                AxisY =
                {
                    Title = "Revenue",
                    LabelStyle = { Font = new Font("Segoe UI", 8) }
                }
            };
            chartGameRevenue.ChartAreas.Add(area);

            var series = new Series("Revenue")
            {
                ChartType = SeriesChartType.Column,
                XValueMember = "Title",
                YValueMembers = "Revenue",
                Color = Color.DodgerBlue,
                Font = new Font("Segoe UI", 8)
            };
            series["PixelPointWidth"] = "40";

            chartGameRevenue.Series.Add(series);
            chartGameRevenue.Legends.Clear();
            chartGameRevenue.DataSource = dtGameRevenue;
            chartGameRevenue.DataBind();
        }
    }
}
