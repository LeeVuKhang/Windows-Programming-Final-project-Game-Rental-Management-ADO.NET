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
    public partial class FrmBranch : UserControl
    {
        DataTable dtBranch = null;
        bool Them; // Biến kiểm tra thêm hay sửa
        string err;
        BLBranch dbBranch = new BLBranch();
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

                DataSet ds = dbBranch.LayBranch();
                dtBranch = ds.Tables[0];

                dgvBRANCH.DataSource = dtBranch;   // dgvBranch là DataGridView trên Form

                dgvBRANCH.AutoResizeColumns();

                // Xóa trống TextBox (ví dụ: txtBranchID, txtBranchName, txtAddress)
                this.txtBranchID.ResetText();
                this.txtBranchName.ResetText();
                this.txtAddress.ResetText();
                this.txtPhone.ResetText();


                // Không cho thao tác nút Lưu/Hủy
                this.btnSave.Enabled = false;
                this.btnCancel.Enabled = false;

                // Cho phép thao tác nút Thêm/Sửa/Xóa/Thoát
                this.btnAdd.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
                //this.btnExit.Enabled = true;

                // Load dữ liệu lên form (nếu có dòng được chọn)
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
    }
}
