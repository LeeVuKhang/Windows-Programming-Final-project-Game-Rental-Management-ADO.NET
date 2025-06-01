using Game_Rental_Management.BS_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Game_Rental_Management
{
    public partial class FrmGame : UserControl
    {
        DataTable dtGame = null;
        bool Them; // Flag to indicate Add or Edit mode
        string err;
        BLGame dbGame = new BLGame();

        public FrmGame()
        {
            InitializeComponent();
            LoadData();
        }

        private void FrmGame_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dtGame = new DataTable();
                dtGame.Clear();

                DataSet ds = dbGame.GetGames();
                dtGame = ds.Tables[0];

                dgvGAME.DataSource = dtGame;
                dgvGAME.Columns[0].Width = 80;   // GameID
                dgvGAME.Columns[1].Width = 150;  // Title
                dgvGAME.Columns[2].Width = 100;  // Platform
                dgvGAME.Columns[3].Width = 120;  // Genre
                dgvGAME.Columns[4].Width = 100;  // PricePerDay
                dgvGAME.Columns[5].Width = 80;   // Status
                dgvGAME.Columns[6].Width = 80;   // BranchID

                // Reset input fields
                txtGameID.ResetText();
                txtTitle.ResetText();
                txtPlatform.ResetText();
                txtGenre.ResetText();
                txtPricePerDay.ResetText();
                chkStatus.Checked = false; ;
                txtBranchID.ResetText();

                // Disable Save/Cancel, enable action buttons
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

                var platforms = dtGame.AsEnumerable()
                                      .Select(row => row.Field<string>("Platform"))
                                      .Distinct()
                                      .OrderBy(p => p)
                                      .ToList();

                var genres = dtGame.AsEnumerable()
                                   .Select(row => row.Field<string>("Genre"))
                                   .Distinct()
                                   .OrderBy(g => g)
                                   .ToList();

                platforms.Insert(0, "All");
                genres.Insert(0, "All");

                cboPlatform.DataSource = platforms;
                cboGener.DataSource = genres;

                if (dgvGAME.CurrentRow != null)
                    dgvGAME_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu Game. Lỗi rồi!!!");
            }
        }

        private void dgvGAME_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGAME.CurrentRow != null && dgvGAME.Rows.Count > 0)
            {
                int r = dgvGAME.CurrentRow.Index;
                txtGameID.Text = dgvGAME.Rows[r].Cells["GameID"].Value?.ToString() ?? "";
                txtTitle.Text = dgvGAME.Rows[r].Cells["Title"].Value?.ToString() ?? "";
                txtPlatform.Text = dgvGAME.Rows[r].Cells["Platform"].Value?.ToString() ?? "";
                txtGenre.Text = dgvGAME.Rows[r].Cells["Genre"].Value?.ToString() ?? "";
                txtPricePerDay.Text = dgvGAME.Rows[r].Cells["PricePerDay"].Value?.ToString() ?? "";
                txtBranchID.Text = dgvGAME.Rows[r].Cells["BranchID"].Value?.ToString() ?? "";
                chkStatus.Checked = dgvGAME.Rows[r].Cells["Status"].Value != DBNull.Value &&
                                    Convert.ToBoolean(dgvGAME.Rows[r].Cells["Status"].Value);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;

            txtGameID.ResetText();
            txtTitle.ResetText();
            txtPlatform.ResetText();
            txtGenre.ResetText();
            txtPricePerDay.ResetText();
            chkStatus.Checked = false; ;
            txtBranchID.ResetText();

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            txtGameID.Enabled = true;
            txtGameID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Them = false;

            dgvGAME_CellClick(null, null);

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            txtGameID.Enabled = false;
            txtTitle.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameID.Text) || string.IsNullOrWhiteSpace(txtTitle.Text) ||
        string.IsNullOrWhiteSpace(txtPlatform.Text) || string.IsNullOrWhiteSpace(txtGenre.Text) ||
        string.IsNullOrWhiteSpace(txtPricePerDay.Text) || string.IsNullOrWhiteSpace(txtBranchID.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!decimal.TryParse(txtPricePerDay.Text, out decimal pricePerDay) || pricePerDay < 0)
            {
                MessageBox.Show("Giá thuê mỗi ngày phải là số không âm!");
                return;
            }

            try
            {
                if (Them)
                {
                    bool success = dbGame.AddGame(
                        txtGameID.Text,
                        txtTitle.Text,
                        txtPlatform.Text,
                        txtGenre.Text,
                        pricePerDay,
                        chkStatus.Checked ? 1 : 0,
                        txtBranchID.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm game mới!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi thêm game: {err}");
                    }
                }
                else
                {
                    bool success = dbGame.UpdateGame(
                        txtGameID.Text,
                        txtTitle.Text,
                        txtPlatform.Text,
                        txtGenre.Text,
                        pricePerDay,
                        chkStatus.Checked ? 1 : 0,
                        txtBranchID.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật thông tin game!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi cập nhật game: {err}");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi SQL: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGameID.ResetText();
            txtTitle.ResetText();
            txtPlatform.ResetText();
            txtGenre.ResetText();
            txtPricePerDay.ResetText();
            chkStatus.Checked = false; ;
            txtBranchID.ResetText();

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            dgvGAME_CellClick(null, null);
        }

        private void txtStatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().Replace("'", "''"); // xử lý dấu nháy đơn
            string platform = cboPlatform.SelectedItem?.ToString() ?? "All";
            string genre = cboGener.SelectedItem?.ToString() ?? "All";

            DataView dv = new DataView(dtGame);

            List<string> filters = new List<string>();

            // Filter theo keyword trên các cột chính (convert GameID nếu kiểu số)
            if (!string.IsNullOrEmpty(keyword))
            {
                filters.Add(
                    $"Convert(GameID, 'System.String') LIKE '%{keyword}%' OR " +
                    $"Title LIKE '%{keyword}%' OR " +
                    $"Platform LIKE '%{keyword}%' OR " +
                    $"Genre LIKE '%{keyword}%'"
                );
            }

            if (platform != "All")
            {
                filters.Add($"Platform = '{platform}'");
            }

            if (genre != "All")
            {
                filters.Add($"Genre = '{genre}'");
            }

            string finalFilter = string.Join(" AND ", filters);

            dv.RowFilter = finalFilter;

            dgvGAME.DataSource = dv;
        }

    }
}
