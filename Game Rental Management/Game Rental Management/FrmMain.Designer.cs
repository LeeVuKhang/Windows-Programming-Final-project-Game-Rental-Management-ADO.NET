namespace Game_Rental_Management
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblExit = new System.Windows.Forms.Label();
            this.lblFormtxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCustomerReport = new System.Windows.Forms.Button();
            this.btnGameRevenue = new System.Windows.Forms.Button();
            this.btnBranchRevenue = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRentalDetails = new System.Windows.Forms.Button();
            this.btnRental = new System.Windows.Forms.Button();
            this.btnGame = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnBranch = new System.Windows.Forms.Button();
            this.frmRentalDetails1 = new Game_Rental_Management.FrmRentalDetails();
            this.frmRental1 = new Game_Rental_Management.FrmRental();
            this.frmGame1 = new Game_Rental_Management.FrmGame();
            this.frmCustomer1 = new Game_Rental_Management.FrmCustomer();
            this.frmBranch1 = new Game_Rental_Management.FrmBranch();
            this.frmGameRevenueReport1 = new Game_Rental_Management.FrmGameRevenueReport();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblExit);
            this.panel1.Controls.Add(this.lblFormtxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 40);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.Location = new System.Drawing.Point(862, 10);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(23, 23);
            this.lblExit.TabIndex = 1;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblFormtxt
            // 
            this.lblFormtxt.AutoSize = true;
            this.lblFormtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormtxt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblFormtxt.Location = new System.Drawing.Point(12, 12);
            this.lblFormtxt.Name = "lblFormtxt";
            this.lblFormtxt.Size = new System.Drawing.Size(200, 15);
            this.lblFormtxt.TabIndex = 0;
            this.lblFormtxt.Text = "Game Rental Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.panel2.Controls.Add(this.btnCustomerReport);
            this.panel2.Controls.Add(this.btnGameRevenue);
            this.panel2.Controls.Add(this.btnBranchRevenue);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnRentalDetails);
            this.panel2.Controls.Add(this.btnRental);
            this.panel2.Controls.Add(this.btnGame);
            this.panel2.Controls.Add(this.btnCustomer);
            this.panel2.Controls.Add(this.btnBranch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 535);
            this.panel2.TabIndex = 1;
            // 
            // btnCustomerReport
            // 
            this.btnCustomerReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnCustomerReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerReport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCustomerReport.Location = new System.Drawing.Point(-3, 400);
            this.btnCustomerReport.Name = "btnCustomerReport";
            this.btnCustomerReport.Size = new System.Drawing.Size(225, 40);
            this.btnCustomerReport.TabIndex = 8;
            this.btnCustomerReport.Text = "CUSTOMER REPORT";
            this.btnCustomerReport.UseVisualStyleBackColor = false;
            this.btnCustomerReport.Click += new System.EventHandler(this.btnCustomerReport_Click);
            // 
            // btnGameRevenue
            // 
            this.btnGameRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnGameRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGameRevenue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGameRevenue.Location = new System.Drawing.Point(-3, 360);
            this.btnGameRevenue.Name = "btnGameRevenue";
            this.btnGameRevenue.Size = new System.Drawing.Size(225, 40);
            this.btnGameRevenue.TabIndex = 7;
            this.btnGameRevenue.Text = "GAME REVENUE";
            this.btnGameRevenue.UseVisualStyleBackColor = false;
            this.btnGameRevenue.Click += new System.EventHandler(this.btnGameRevenue_Click);
            // 
            // btnBranchRevenue
            // 
            this.btnBranchRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnBranchRevenue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBranchRevenue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBranchRevenue.Location = new System.Drawing.Point(0, 320);
            this.btnBranchRevenue.Name = "btnBranchRevenue";
            this.btnBranchRevenue.Size = new System.Drawing.Size(225, 40);
            this.btnBranchRevenue.TabIndex = 6;
            this.btnBranchRevenue.Text = "BRANCH REVENUE";
            this.btnBranchRevenue.UseVisualStyleBackColor = false;
            this.btnBranchRevenue.Click += new System.EventHandler(this.btnBranchRevenue_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Game_Rental_Management.Properties.Resources.Logo1;
            this.pictureBox1.Location = new System.Drawing.Point(65, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnRentalDetails
            // 
            this.btnRentalDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnRentalDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRentalDetails.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRentalDetails.Location = new System.Drawing.Point(-3, 280);
            this.btnRentalDetails.Name = "btnRentalDetails";
            this.btnRentalDetails.Size = new System.Drawing.Size(225, 40);
            this.btnRentalDetails.TabIndex = 4;
            this.btnRentalDetails.Text = "RENTAL DETAILS";
            this.btnRentalDetails.UseVisualStyleBackColor = false;
            this.btnRentalDetails.Click += new System.EventHandler(this.btnRentalDetails_Click);
            // 
            // btnRental
            // 
            this.btnRental.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnRental.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRental.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRental.Location = new System.Drawing.Point(0, 240);
            this.btnRental.Name = "btnRental";
            this.btnRental.Size = new System.Drawing.Size(225, 40);
            this.btnRental.TabIndex = 3;
            this.btnRental.Text = "RENTAL";
            this.btnRental.UseVisualStyleBackColor = false;
            this.btnRental.Click += new System.EventHandler(this.btnRental_Click);
            // 
            // btnGame
            // 
            this.btnGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGame.Location = new System.Drawing.Point(-3, 200);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(225, 40);
            this.btnGame.TabIndex = 2;
            this.btnGame.Text = "GAME";
            this.btnGame.UseVisualStyleBackColor = false;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCustomer.Location = new System.Drawing.Point(0, 160);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(225, 40);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "CUSTOMER";
            this.btnCustomer.UseVisualStyleBackColor = false;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(31)))), ((int)(((byte)(63)))));
            this.btnBranch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBranch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBranch.Location = new System.Drawing.Point(0, 120);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(225, 40);
            this.btnBranch.TabIndex = 0;
            this.btnBranch.Text = "BRANCH";
            this.btnBranch.UseVisualStyleBackColor = false;
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // frmRentalDetails1
            // 
            this.frmRentalDetails1.Location = new System.Drawing.Point(223, 40);
            this.frmRentalDetails1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.frmRentalDetails1.Name = "frmRentalDetails1";
            this.frmRentalDetails1.Size = new System.Drawing.Size(675, 550);
            this.frmRentalDetails1.TabIndex = 6;
            this.frmRentalDetails1.Load += new System.EventHandler(this.frmRentalDetails1_Load);
            // 
            // frmRental1
            // 
            this.frmRental1.Location = new System.Drawing.Point(223, 40);
            this.frmRental1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.frmRental1.Name = "frmRental1";
            this.frmRental1.Size = new System.Drawing.Size(675, 550);
            this.frmRental1.TabIndex = 5;
            // 
            // frmGame1
            // 
            this.frmGame1.Location = new System.Drawing.Point(223, 40);
            this.frmGame1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.frmGame1.Name = "frmGame1";
            this.frmGame1.Size = new System.Drawing.Size(675, 550);
            this.frmGame1.TabIndex = 4;
            // 
            // frmCustomer1
            // 
            this.frmCustomer1.Location = new System.Drawing.Point(223, 40);
            this.frmCustomer1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.frmCustomer1.Name = "frmCustomer1";
            this.frmCustomer1.Size = new System.Drawing.Size(675, 550);
            this.frmCustomer1.TabIndex = 3;
            // 
            // frmBranch1
            // 
            this.frmBranch1.Location = new System.Drawing.Point(223, 40);
            this.frmBranch1.Margin = new System.Windows.Forms.Padding(4);
            this.frmBranch1.Name = "frmBranch1";
            this.frmBranch1.Size = new System.Drawing.Size(675, 550);
            this.frmBranch1.TabIndex = 2;
            // 
            // frmGameRevenueReport1
            // 
            this.frmGameRevenueReport1.Location = new System.Drawing.Point(223, 40);
            this.frmGameRevenueReport1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.frmGameRevenueReport1.Name = "frmGameRevenueReport1";
            this.frmGameRevenueReport1.Size = new System.Drawing.Size(675, 550);
            this.frmGameRevenueReport1.TabIndex = 8;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 575);
            this.Controls.Add(this.frmGameRevenueReport1);
            this.Controls.Add(this.frmRentalDetails1);
            this.Controls.Add(this.frmRental1);
            this.Controls.Add(this.frmGame1);
            this.Controls.Add(this.frmCustomer1);
            this.Controls.Add(this.frmBranch1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFormtxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRentalDetails;
        private System.Windows.Forms.Button btnRental;
        private System.Windows.Forms.Button btnGame;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnBranch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblExit;
        private FrmBranch frmBranch1;
        private FrmCustomer frmCustomer1;
        private FrmGame frmGame1;
        private FrmRental frmRental1;
        private FrmRentalDetails frmRentalDetails1;
        private System.Windows.Forms.Button btnBranchRevenue;
        private FrmGameRevenueReport frmGameRevenueReport1;
        private System.Windows.Forms.Button btnGameRevenue;
        private System.Windows.Forms.Button btnCustomerReport;
    }
}

