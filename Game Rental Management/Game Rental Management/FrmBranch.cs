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
using Game_Rental_Management.BS_layer;

namespace Game_Rental_Management
{
    public partial class FrmBranch : UserControl
    {
        DataTable dtBranch = null;
        bool Them; // Biến kiểm tra thêm hay sửa
        string err;
        BLBranch dbBranch = new BLBranch();
        private TabControl _mainTabControl;

        public FrmBranch(TabControl mainTabControl)
        {
            InitializeComponent();
            _mainTabControl = mainTabControl;
        }
        public FrmBranch()
        {
            InitializeComponent();
            LoadData();
        }



        void LoadData()
        {
            try
            {
                dtBranch = new DataTable();
                dtBranch.Clear();

                DataSet ds = dbBranch.GetAllBranches();
                dtBranch = ds.Tables[0];

                dgvBRANCH.DataSource = dtBranch;
                dgvBRANCH.Columns[0].Width = 80;  // BranchID
                dgvBRANCH.Columns[1].Width = 150;  // BranchName
                dgvBRANCH.Columns[2].Width = 220;  // Location
                dgvBRANCH.Columns[3].Width = 122;  // Phone

                this.txtBranchID.ResetText();
                this.txtBranchName.ResetText();
                this.txtAddress.ResetText();
                this.txtPhone.ResetText();


                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;

                this.btnAdd.Enabled = true;
                this.btnUpdate.Enabled = true;
                this.btnDelete.Enabled = true;
                //this.btnExit.Enabled = true;

                if (dgvBRANCH.CurrentRow != null)
                    dgvBRANCH_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Không lấy được dữ liệu Branch. Lỗi rồi!!!");
            }
        }

        private void dgvBRANCH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBRANCH.CurrentRow != null)
            {
                int r = dgvBRANCH.CurrentRow.Index;
                if (r >= 0)
                {
                    this.txtBranchID.Text = dgvBRANCH.Rows[r].Cells["BranchID"].Value.ToString();
                    this.txtBranchName.Text = dgvBRANCH.Rows[r].Cells["BranchName"].Value.ToString();
                    this.txtAddress.Text = dgvBRANCH.Rows[r].Cells["Address"].Value.ToString();
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
            // Reset các textbox
            this.txtBranchID.ResetText();
            this.txtBranchName.ResetText();
            this.txtAddress.ResetText();
            this.txtPhone.ResetText();

            // Bật Panel và các nút thao tác lưu/hủy

            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;

            // Vô hiệu hóa các nút khác
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;

            // Cho phép nhập ID mới
            this.txtBranchID.Enabled = true;
            this.txtBranchID.Focus();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    BLBranch blB = new BLBranch();
                    blB.AddBranch(this.txtBranchID.Text, this.txtBranchName.Text,
                                   this.txtAddress.Text, this.txtPhone.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã thêm chi nhánh mới!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Lỗi khi thêm dữ liệu.");
                }
            }
            else
            {
                BLBranch blB = new BLBranch();
                blB.UpdateBranch(this.txtBranchID.Text, this.txtBranchName.Text,
                                  this.txtAddress.Text, this.txtPhone.Text, ref err);
                LoadData();
                MessageBox.Show("Đã cập nhật chi nhánh!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtBranchID.ResetText();
            this.txtBranchName.ResetText();
            this.txtAddress.ResetText();
            this.txtPhone.ResetText();

            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;

            dgvBRANCH_CellClick(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvBRANCH.CurrentCell.RowIndex;
                string strBranchID = dgvBRANCH.Rows[r].Cells[0].Value.ToString();

                DialogResult traloi = MessageBox.Show("Bạn chắc chắn muốn xóa chi nhánh này?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == DialogResult.Yes)
                {
                    dbBranch.DeleteBranch(ref err, strBranchID);
                    LoadData();
                    MessageBox.Show("Đã xóa chi nhánh!");
                }
                else
                {
                    MessageBox.Show("Không xóa chi nhánh.");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Lỗi khi xóa chi nhánh.");
            }
        }

        private void dgvBRANCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {

        }
    }
}
