using Game_Rental_Management.BS_layer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Game_Rental_Management
{
    public partial class FrmRental : UserControl
    {
        DataTable dtRental = null;
        bool Them;
        string err;
        BLRental dbRental = new BLRental();
        public FrmRental()
        {
            InitializeComponent();
            LoadData();
        }

        private void FrmRental_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvRENTAL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRENTAL.CurrentRow != null && dgvRENTAL.Rows.Count > 0)
            {
                int r = dgvRENTAL.CurrentRow.Index;
                txtRentalID.Text = dgvRENTAL.Rows[r].Cells["RentalID"].Value?.ToString() ?? "";
                txtCustomerID.Text = dgvRENTAL.Rows[r].Cells["CustomerID"].Value?.ToString() ?? "";
                dtpRentalDate.Value = Convert.ToDateTime(dgvRENTAL.Rows[r].Cells["RentalDate"].Value ?? DateTime.Now);
                dtpReturnDate.Value = Convert.ToDateTime(dgvRENTAL.Rows[r].Cells["ReturnDate"].Value ?? DateTime.Now);
                txtTotalCost.Text = dgvRENTAL.Rows[r].Cells["TotalCost"].Value?.ToString() ?? "";
                txtBranchID.Text = dgvRENTAL.Rows[r].Cells["BranchID"].Value?.ToString() ?? "";
            }
        }
        void LoadData()
        {
            try
            {
                dtRental = new DataTable();
                dtRental.Clear();

                DataSet ds = dbRental.GetRentals();
                dtRental = ds.Tables[0];

                dgvRENTAL.DataSource = dtRental;
                dgvRENTAL.Columns[0].Width = 80;   // RentalID
                dgvRENTAL.Columns[1].Width = 100;  // CustomerID
                dgvRENTAL.Columns[2].Width = 120;  // RentalDate
                dgvRENTAL.Columns[3].Width = 120;  // ReturnDate
                dgvRENTAL.Columns[4].Width = 100;  // TotalCost
                dgvRENTAL.Columns[5].Width = 100;  // BranchID

                // Reset fields
                txtRentalID.ResetText();
                txtCustomerID.ResetText();
                dtpRentalDate.Value = DateTime.Now;
                dtpReturnDate.Value = DateTime.Now;
                txtTotalCost.ResetText();
                txtBranchID.ResetText();

                // Toggle buttons
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

                if (dgvRENTAL.CurrentRow != null && dgvRENTAL.Rows.Count > 0)
                    dgvRENTAL_CellClick(null, null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Không lấy được dữ liệu Rental: {ex.Message}");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;

            txtRentalID.ResetText();
            txtCustomerID.ResetText();
            dtpRentalDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
            txtTotalCost.ResetText();
            txtBranchID.ResetText();

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            txtRentalID.Enabled = true;
            txtRentalID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Them = false;
            dgvRENTAL_CellClick(null, null);

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            txtRentalID.Enabled = false;
            txtCustomerID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentalID.Text) || string.IsNullOrWhiteSpace(txtCustomerID.Text) ||
                 string.IsNullOrWhiteSpace(txtTotalCost.Text) || string.IsNullOrWhiteSpace(txtBranchID.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!decimal.TryParse(txtTotalCost.Text, out decimal totalCost) || totalCost < 0)
            {
                MessageBox.Show("Tổng chi phí phải là số không âm!");
                return;
            }

            if (dtpReturnDate.Value < dtpRentalDate.Value)
            {
                MessageBox.Show("Ngày trả phải sau ngày thuê!");
                return;
            }

            try
            {
                if (Them)
                {
                    bool success = dbRental.AddRental(
                        txtRentalID.Text,
                        txtCustomerID.Text,
                        dtpRentalDate.Value,
                        dtpReturnDate.Value,
                        totalCost,
                        txtBranchID.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm đơn thuê mới!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi thêm đơn thuê: {err}");
                    }
                }
                else
                {
                    bool success = dbRental.UpdateRental(
                        txtRentalID.Text,
                        txtCustomerID.Text,
                        dtpRentalDate.Value,
                        dtpReturnDate.Value,
                        totalCost,
                        txtBranchID.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật thông tin đơn thuê!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi cập nhật đơn thuê: {err}");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtRentalID.ResetText();
            txtCustomerID.ResetText();
            dtpRentalDate.Value = DateTime.Now;
            dtpReturnDate.Value = DateTime.Now;
            txtTotalCost.ResetText();
            txtBranchID.ResetText();

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            dgvRENTAL_CellClick(null, null);
        }
    }
}
