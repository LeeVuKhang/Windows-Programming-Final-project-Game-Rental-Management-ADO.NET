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

using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

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
                this.btnEdit.Enabled = true;
                //this.btnExit.Enabled = true;
                if (dgvBRANCH.CurrentRow != null)
                    dgvBRANCH_CellClick(null, null);
            }
            catch (SqlException)
            {
                MessageBox.Show("Failed to retrieve branch data. An error occurred!");
            }
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
                    MessageBox.Show("New branch added successfully!");

                }
                catch (SqlException)
                {
                    MessageBox.Show("Error occurred while adding data.");
                }
            }
            else
            {
                BLBranch blB = new BLBranch();
                blB.UpdateBranch(this.txtBranchID.Text, this.txtBranchName.Text,
                                  this.txtAddress.Text, this.txtPhone.Text, ref err);
                LoadData();
                MessageBox.Show("Branch updated successfully!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtBranchID.ResetText();
            this.txtBranchName.ResetText();
            this.txtAddress.ResetText();
            this.txtPhone.ResetText();

            this.btnAdd.Enabled = true;
            this.btnEdit.Enabled = true;

            this.btnSave.Enabled = false;
            this.btnCancel.Enabled = false;
            this.panel1.Enabled = false;
            dgvBRANCH_CellClick(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
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
            this.panel1.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;

            // Vô hiệu hóa các nút khác
            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;

            // Cho phép nhập ID mới
            this.txtBranchID.Enabled = true;
            this.txtBranchID.Focus();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Them = false;
            this.panel1.Enabled = true;
            dgvBRANCH_CellClick(null, null); // Gọi lại dữ liệu đang chọn vào textbox

            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;

            this.txtBranchID.Enabled = false; // Không cho sửa ID
            this.txtBranchName.Focus();
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
                    this.txtPhone.Text = dgvBRANCH.Rows[r].Cells["Phone"].Value.ToString();
                }
            }
        }

        private void dgvBRANCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvBRANCH.DataSource = dtBranch;
            }
            else
            {
                DataView dv = new DataView(dtBranch);

                dv.RowFilter = string.Format(
                    "Convert(BranchID, 'System.String') LIKE '%{0}%' OR " +
                    "BranchName LIKE '%{0}%' OR " +
                    "Address LIKE '%{0}%' OR " +
                    "Phone LIKE '%{0}%'",
                    keyword.Replace("'", "''")); 

                dgvBRANCH.DataSource = dv;
            }
        }

    }
}
