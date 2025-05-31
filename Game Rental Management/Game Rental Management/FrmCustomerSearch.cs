using Game_Rental_Management.BS_layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Rental_Management
{
    public partial class FrmCustomerSearch : Form
    {
        BLCustomer customerBL = new BLCustomer();
        public FrmCustomerSearch()
        {
            InitializeComponent();
        }

        private void FrmCustomerSearch_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text.Trim();
            if (string.IsNullOrWhiteSpace(customerID))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
                return;
            }

            DataSet ds = customerBL.GetCustomerRentalHistory(customerID);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lịch sử thuê.");
                dgvResults.DataSource = null;
            }
            else
            {
                dgvResults.DataSource = ds.Tables[0];
            }
        }
    }
}
