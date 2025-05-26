using Game_Rental_Management.BS_layer;
using System;
using System.Data;
using System.Data.SqlClient;
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
                txtStatus.ResetText();
                txtBranchID.ResetText();

                // Disable Save/Cancel, enable action buttons
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

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
            if (dgvGAME.CurrentRow != null)
            {
                int r = dgvGAME.CurrentRow.Index;
                if (r >= 0)
                {
                    txtGameID.Text = dgvGAME.Rows[r].Cells["GameID"].Value.ToString();
                    txtTitle.Text = dgvGAME.Rows[r].Cells["Title"].Value.ToString();
                    txtPlatform.Text = dgvGAME.Rows[r].Cells["Platform"].Value.ToString();
                    txtGenre.Text = dgvGAME.Rows[r].Cells["Genre"].Value.ToString();
                    txtPricePerDay.Text = dgvGAME.Rows[r].Cells["PricePerDay"].Value.ToString();
                    txtStatus.Text = dgvGAME.Rows[r].Cells["Status"].Value.ToString();
                    txtBranchID.Text = dgvGAME.Rows[r].Cells["BranchID"].Value.ToString();
                }
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
            txtStatus.ResetText();
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
            if (Them)
            {
                try
                {
                    dbGame.AddGame(
                        txtGameID.Text,
                        txtTitle.Text,
                        txtPlatform.Text,
                        txtGenre.Text,
                        decimal.Parse(txtPricePerDay.Text),
                        int.Parse(txtStatus.Text),
                        txtBranchID.Text,
                        ref err
                    );
                    LoadData();
                    MessageBox.Show("Đã thêm game mới!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi thêm game.");
                }
            }
            else
            {
                try
                {
                    dbGame.UpdateGame(
                        txtGameID.Text,
                        txtTitle.Text,
                        txtPlatform.Text,
                        txtGenre.Text,
                        decimal.Parse(txtPricePerDay.Text),
                        int.Parse(txtStatus.Text),
                        txtBranchID.Text,
                        ref err
                    );
                    LoadData();
                    MessageBox.Show("Đã cập nhật thông tin game!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi cập nhật game.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtGameID.ResetText();
            txtTitle.ResetText();
            txtPlatform.ResetText();
            txtGenre.ResetText();
            txtPricePerDay.ResetText();
            txtStatus.ResetText();
            txtBranchID.ResetText();

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            dgvGAME_CellClick(null, null);
        }
    }
}
