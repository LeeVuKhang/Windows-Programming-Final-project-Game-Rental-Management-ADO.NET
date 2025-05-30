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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnBranch.BackColor = Color.RoyalBlue;
            frmBranch1.Show();
            frmGame1.Hide();
            frmCustomer1.Hide();
            frmRentalDetails1.Hide();
            frmRental1.Hide();
            frmBranchRevenueReport1.Hide();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnCustomer.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor = btnGame.BackColor = btnRental.BackColor = btnBranchRevenue.BackColor =
                 btnGame.BackColor = btnBranch.BackColor = Color.FromArgb(0, 31, 63);

            frmBranch1.Hide();
            frmGame1.Hide();
            frmCustomer1.Show();
            frmRentalDetails1.Hide();
            frmRental1.Hide();
            frmBranchRevenueReport1.Hide();
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            btnGame.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor  = btnRental.BackColor = btnBranchRevenue.BackColor =
                 btnBranch.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);

            frmBranch1.Hide();
            frmGame1.Show();
            frmCustomer1.Hide();
            frmRentalDetails1.Hide();
            frmRental1.Hide();
            frmBranchRevenueReport1.Hide();
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            btnRental.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor  = btnBranch.BackColor = btnBranchRevenue.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);

            frmBranch1.Hide();
            frmGame1.Hide();
            frmCustomer1.Hide();
            frmRentalDetails1.Hide();
            frmRental1.Show();
            frmBranchRevenueReport1.Hide();
        }

        private void btnRentalDetails_Click(object sender, EventArgs e)
        {
            btnRentalDetails.BackColor = Color.RoyalBlue;
            btnBranch.BackColor  = btnRental.BackColor = btnBranchRevenue.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);

            frmBranch1.Hide();
            frmGame1.Hide();
            frmCustomer1.Hide();
            frmRentalDetails1.Show();
            frmRental1.Hide();
            frmBranchRevenueReport1.Hide();
        }
           //skibidi
        private void btnBranch_Click(object sender, EventArgs e)
        {
            btnBranch.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor = btnRental.BackColor = btnBranchRevenue.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);

            frmBranch1.Show();
            frmGame1.Hide();
            frmCustomer1.Hide();
            frmRentalDetails1.Hide();
            frmRental1.Hide();
            frmBranchRevenueReport1.Hide();
        }
        private void btnBranchRevenue_Click(object sender, EventArgs e)
        {
            btnBranchRevenue.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor = btnRental.BackColor = btnBranch.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);

            frmBranchRevenueReport1.Show();
            frmBranch1.Hide();
            frmGame1.Hide();
            frmCustomer1.Hide();
            frmRentalDetails1.Hide();
            frmRental1.Hide();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void frmGame1_Load(object sender, EventArgs e)
        {

        }

        private void frmRentalDetails1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void OpenRentalDetailsWithContext(string rentalID, DateTime rentalDate, DateTime returnDate)
        {
            // Optional: Highlight the correct button
            btnRentalDetails_Click(null, null); // Simulate navigation

            // Pass the context
            frmRentalDetails1.LoadRentalContext(rentalID, rentalDate, returnDate);
        }

     
    }
}
