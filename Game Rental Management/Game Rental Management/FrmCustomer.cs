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
    public partial class FrmCustomer : UserControl
    {
        DataTable dtCustomer = null;
        bool Them; // Flag to indicate Add or Edit mode
        string err;
        BLCustomer dbCustomer = new BLCustomer();


        public FrmCustomer()
        {
            InitializeComponent();
            LoadData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void LoadData()
        {
            try
            {
                dtCustomer = new DataTable();
                dtCustomer.Clear();

                DataSet ds = dbCustomer.GetCustomers();
                dtCustomer = ds.Tables[0];

                dgvCUSTOMER.DataSource = dtCustomer;
                dgvCUSTOMER.Columns[0].Width = 80;   // CustomerID
                dgvCUSTOMER.Columns[1].Width = 150;  // Name
                dgvCUSTOMER.Columns[2].Width = 120;  // Phone
                dgvCUSTOMER.Columns[3].Width = 200;  // Email
                dgvCUSTOMER.Columns[4].Width = 200;  // Address

                // Reset input fields
                txtCustomerID.ResetText();
                txtCustomerName.ResetText();
                txtEmail.ResetText();
                txtPhone.ResetText();
                txtAddress.ResetText();

                // Disable Save/Cancel, enable action buttons
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;

                if (dgvCUSTOMER.CurrentRow != null)
                    dgvCUSTOMER_CellClick(null, null);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Cannot retrieve Customer data: {ex.Message}");
            }
        }
        private void dgvCUSTOMER_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCUSTOMER.CurrentRow != null && dgvCUSTOMER.Rows.Count > 0)
            {
                int r = dgvCUSTOMER.CurrentRow.Index;
                txtCustomerID.Text = dgvCUSTOMER.Rows[r].Cells["CustomerID"].Value?.ToString() ?? "";
                txtCustomerName.Text = dgvCUSTOMER.Rows[r].Cells["Name"].Value?.ToString() ?? "";
                txtEmail.Text = dgvCUSTOMER.Rows[r].Cells["Email"].Value?.ToString() ?? "";
                txtPhone.Text = dgvCUSTOMER.Rows[r].Cells["Phone"].Value?.ToString() ?? "";
                txtAddress.Text = dgvCUSTOMER.Rows[r].Cells["Address"].Value?.ToString() ?? "";
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them = true;

            txtCustomerID.ResetText();
            txtCustomerName.ResetText();
            txtEmail.ResetText();
            txtPhone.ResetText();
            txtAddress.ResetText();

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;


            txtCustomerID.Enabled = true;
            txtCustomerID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Them = false;

            dgvCUSTOMER_CellClick(null, null);

            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            txtCustomerID.Enabled = false;
            txtCustomerName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text) || string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all required information!");
                return;
            }

            try
            {
                if (Them)
                {
                    bool success = dbCustomer.AddCustomer(
                        txtCustomerID.Text,
                        txtCustomerName.Text,
                        txtPhone.Text,
                        txtEmail.Text,
                        txtAddress.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("New customer added successfully!");
                    }
                    else
                    {
                        MessageBox.Show($"Error while adding customer: {err}");
                    }
                }
                else
                {
                    bool success = dbCustomer.UpdateCustomer(
                        txtCustomerID.Text,
                        txtCustomerName.Text,
                        txtPhone.Text,
                        txtEmail.Text,
                        txtAddress.Text,
                        ref err
                    );
                    if (success)
                    {
                        LoadData();
                        MessageBox.Show("Customer information updated successfully!");
                    }
                    else
                    {
                        MessageBox.Show($"Error while updating customer: {err}");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtCustomerID.ResetText();
            txtCustomerName.ResetText();
            txtEmail.ResetText();
            txtPhone.ResetText();
            txtAddress.ResetText();

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;

            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            dgvCUSTOMER_CellClick(null, null);
        }



        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                dgvCUSTOMER.DataSource = dtCustomer;
            }
            else
            {
                DataView dv = new DataView(dtCustomer);

                dv.RowFilter = string.Format(
                    "Convert(CustomerID, 'System.String') LIKE '%{0}%' OR " +
                    "Name LIKE '%{0}%' OR " +
                    "Phone LIKE '%{0}%' OR " +
                    "Email LIKE '%{0}%'",
                    keyword.Replace("'", "''"));

                dgvCUSTOMER.DataSource = dv;
            }
        }
    }
}
