using Game_Rental_Management.BS_layer;
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
    public partial class FrmRentalDetails : UserControl
    {
        DataTable dtRentalDetail = null;
        bool Them;
        string err;
        BLGame gameBL = new BLGame();
        DateTime rentalDate;
        DateTime returnDate;
        BLRentalDetails dbRentalDetail = new BLRentalDetails();

        public FrmRentalDetails()
        {
            InitializeComponent();
            LoadData();
        }
        public FrmRentalDetails(string rentalID, DateTime rentalDate, DateTime returnDate)
        {
            InitializeComponent();
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;

            txtRentalID.Text = rentalID;
            txtRentalID.Enabled = true;

            LoadData();
        }
        public void LoadRentalContext(string rentalID, DateTime rentalDate, DateTime returnDate)
        {
            txtRentalID.Text = rentalID;
            txtRentalID.Enabled = true;

            int days = (returnDate - rentalDate).Days;
            if (days < 1) days = 1;

            txtDaysRented.Text = days.ToString();

            // Store for later if needed
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;
        }
        public void SetRentalDates(DateTime rentalDate, DateTime returnDate)
        {
            this.rentalDate = rentalDate;
            this.returnDate = returnDate;
        }

        private void dgvRENTALDETAIL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRENTALDETAIL.CurrentRow != null && dgvRENTALDETAIL.Rows.Count > 0)
            {
                int r = dgvRENTALDETAIL.CurrentRow.Index;
                txtRentalID.Text = dgvRENTALDETAIL.Rows[r].Cells["RentalID"].Value?.ToString() ?? "";
                txtGameID.Text = dgvRENTALDETAIL.Rows[r].Cells["GameID"].Value?.ToString() ?? "";
                txtDaysRented.Text = dgvRENTALDETAIL.Rows[r].Cells["DaysRented"].Value?.ToString() ?? "";
                txtPrice.Text = dgvRENTALDETAIL.Rows[r].Cells["Price"].Value?.ToString() ?? "";
            }
        }
        void LoadData()
        {
            try
            {
                dtRentalDetail = new DataTable();
                dtRentalDetail.Clear();

                DataSet ds = dbRentalDetail.GetRentalDetails();
                dtRentalDetail = ds.Tables[0];

                dgvRENTALDETAIL.DataSource = dtRentalDetail;
                dgvRENTALDETAIL.Columns[0].Width = 100; // RentalID
                dgvRENTALDETAIL.Columns[1].Width = 100; // GameID
                dgvRENTALDETAIL.Columns[2].Width = 100; // DaysRented
                dgvRENTALDETAIL.Columns[3].Width = 100; // Price

                txtRentalID.ResetText();
                txtGameID.ResetText();
                txtDaysRented.ResetText();
                txtPrice.ResetText();

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

                if (dgvRENTALDETAIL.CurrentRow != null && dgvRENTALDETAIL.Rows.Count > 0)
                    dgvRENTALDETAIL_CellClick(null, null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Không lấy được dữ liệu chi tiết thuê: {ex.Message}");
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;

            // Removed RentalDetailID reset
            txtRentalID.ResetText();
            txtGameID.ResetText();
            txtDaysRented.ResetText();
            txtPrice.ResetText();

            
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            // Removed txtRentalDetailID.Enabled and Focus
            //txtRentalID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Them = false;

            dgvRENTALDETAIL_CellClick(null, null);

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            // No RentalDetailID to disable
            txtRentalID.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRentalID.Text) || string.IsNullOrWhiteSpace(txtGameID.Text) ||
                 string.IsNullOrWhiteSpace(txtDaysRented.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtDaysRented.Text, out int daysRented) || daysRented <= 0)
            {
                MessageBox.Show("Số ngày thuê phải là số nguyên dương!");
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Giá phải là số không âm!");
                return;
            }

            try
            {
                if (Them)
                {
                    bool success = dbRentalDetail.AddRentalDetail(
                        txtRentalID.Text,
                        txtGameID.Text,
                        daysRented,
                        price,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã thêm chi tiết thuê mới!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi thêm chi tiết thuê: {err}");
                    }
                }
                else
                {
                    bool success = dbRentalDetail.UpdateRentalDetail(
                        txtRentalID.Text,
                        txtGameID.Text,
                        daysRented,
                        price,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Đã cập nhật chi tiết thuê!");
                    }
                    else
                    {
                        MessageBox.Show($"Lỗi khi cập nhật chi tiết thuê: {err}");
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
            txtGameID.ResetText();
            txtDaysRented.ResetText();
            txtPrice.ResetText();

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            dgvRENTALDETAIL_CellClick(null, null);
        }

        private void FrmRentalDetails_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtGameID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGameID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGameID.Text)) return;

            decimal pricePerDay = gameBL.GetPricePerDay(txtGameID.Text);
            int days = (returnDate - rentalDate).Days;
            if (days <= 0) days = 1;

            decimal price = days * pricePerDay;

            txtDaysRented.Text = days.ToString();
            txtPrice.Text = price.ToString("0.00");
        }

    }
}
