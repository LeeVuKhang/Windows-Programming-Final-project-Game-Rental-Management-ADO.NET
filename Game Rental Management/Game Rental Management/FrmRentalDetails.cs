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
        BLRentalDetails dbRentalDetail = new BLRentalDetails();

        public FrmRentalDetails()
        {
            InitializeComponent();
            LoadData();
        }

        private void dgvRENTALDETAIL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRENTALDETAIL.CurrentRow != null)
            {
                int r = dgvRENTALDETAIL.CurrentRow.Index;
                if (r >= 0)
                {
                    txtRentalID.Text = dgvRENTALDETAIL.Rows[r].Cells["RentalID"].Value.ToString();
                    txtGameID.Text = dgvRENTALDETAIL.Rows[r].Cells["GameID"].Value.ToString();
                    txtDaysRented.Text = dgvRENTALDETAIL.Rows[r].Cells["DaysRented"].Value.ToString();
                    txtPrice.Text = dgvRENTALDETAIL.Rows[r].Cells["Price"].Value.ToString();
                }
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

                // Remove txtRentalDetailID.ResetText();
                txtRentalID.ResetText();
                txtGameID.ResetText();
                txtDaysRented.ResetText();
                txtPrice.ResetText();

                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

                if (dgvRENTALDETAIL.CurrentRow != null)
                    dgvRENTALDETAIL_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu chi tiết thuê. Lỗi rồi!");
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
            txtRentalID.Focus();
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
            if (Them)
            {
                try
                {
                    dbRentalDetail.AddRentalDetail(
                        int.Parse(txtRentalID.Text),
                        int.Parse(txtGameID.Text),
                        int.Parse(txtDaysRented.Text),
                        decimal.Parse(txtPrice.Text),
                        ref err
                    );
                    LoadData();
                    MessageBox.Show("Đã thêm chi tiết thuê mới!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết thuê.");
                }
            }
            else
            {
                try
                {
                    dbRentalDetail.UpdateRentalDetail(
                        int.Parse(txtRentalID.Text),
                        int.Parse(txtGameID.Text),
                        int.Parse(txtDaysRented.Text),
                        decimal.Parse(txtPrice.Text),
                        ref err
                    );
                    LoadData();
                    MessageBox.Show("Đã cập nhật chi tiết thuê!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi cập nhật chi tiết thuê.");
                }
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
    }
}
