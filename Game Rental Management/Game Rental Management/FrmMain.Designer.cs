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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRentalDetails = new System.Windows.Forms.Button();
            this.btnRental = new System.Windows.Forms.Button();
            this.btnGame = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnBranch = new System.Windows.Forms.Button();
            this.frmBranch1 = new Game_Rental_Management.FrmBranch();
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
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.Location = new System.Drawing.Point(862, 10);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(17, 18);
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
            this.panel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnRentalDetails);
            this.panel2.Controls.Add(this.btnRental);
            this.panel2.Controls.Add(this.btnGame);
            this.panel2.Controls.Add(this.btnCustomer);
            this.panel2.Controls.Add(this.btnBranch);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 550);
            this.panel2.TabIndex = 1;
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
            this.btnRentalDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentalDetails.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRentalDetails.Location = new System.Drawing.Point(15, 342);
            this.btnRentalDetails.Name = "btnRentalDetails";
            this.btnRentalDetails.Size = new System.Drawing.Size(197, 39);
            this.btnRentalDetails.TabIndex = 4;
            this.btnRentalDetails.Text = "RENTAL DETAILS";
            this.btnRentalDetails.UseVisualStyleBackColor = true;
            this.btnRentalDetails.Click += new System.EventHandler(this.btnRentalDetails_Click);
            // 
            // btnRental
            // 
            this.btnRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRental.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnRental.Location = new System.Drawing.Point(15, 292);
            this.btnRental.Name = "btnRental";
            this.btnRental.Size = new System.Drawing.Size(197, 39);
            this.btnRental.TabIndex = 3;
            this.btnRental.Text = "RENTAL";
            this.btnRental.UseVisualStyleBackColor = true;
            this.btnRental.Click += new System.EventHandler(this.btnRental_Click);
            // 
            // btnGame
            // 
            this.btnGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGame.Location = new System.Drawing.Point(15, 242);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(197, 39);
            this.btnGame.TabIndex = 2;
            this.btnGame.Text = "GAME";
            this.btnGame.UseVisualStyleBackColor = true;
            this.btnGame.Click += new System.EventHandler(this.btnGame_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCustomer.Location = new System.Drawing.Point(15, 192);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(197, 39);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "CUSTOMER";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnBranch
            // 
            this.btnBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBranch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBranch.Location = new System.Drawing.Point(15, 142);
            this.btnBranch.Name = "btnBranch";
            this.btnBranch.Size = new System.Drawing.Size(197, 39);
            this.btnBranch.TabIndex = 0;
            this.btnBranch.Text = "BRANCH";
            this.btnBranch.UseVisualStyleBackColor = true;
            this.btnBranch.Click += new System.EventHandler(this.btnBranch_Click);
            // 
            // frmBranch1
            // 
            this.frmBranch1.Location = new System.Drawing.Point(225, 40);
            this.frmBranch1.Name = "frmBranch1";
            this.frmBranch1.Size = new System.Drawing.Size(675, 550);
            this.frmBranch1.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 590);
            this.Controls.Add(this.frmBranch1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
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
    }
}

