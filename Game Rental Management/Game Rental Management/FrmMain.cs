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
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            btnCustomer.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor = btnGame.BackColor = btnRental.BackColor =
                 btnGame.BackColor = btnBranch.BackColor = Color.FromArgb(0, 31, 63);
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            btnGame.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor  = btnRental.BackColor =
                 btnBranch.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);
        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            btnRental.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor  = btnBranch.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);
        }

        private void btnRentalDetails_Click(object sender, EventArgs e)
        {
            btnRentalDetails.BackColor = Color.RoyalBlue;
            btnBranch.BackColor  = btnRental.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);
        }
           //skibidi
        private void btnBranch_Click(object sender, EventArgs e)
        {
            btnBranch.BackColor = Color.RoyalBlue;
            btnRentalDetails.BackColor = btnRental.BackColor =
                 btnGame.BackColor = btnCustomer.BackColor = Color.FromArgb(0, 31, 63);
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
    }
}
