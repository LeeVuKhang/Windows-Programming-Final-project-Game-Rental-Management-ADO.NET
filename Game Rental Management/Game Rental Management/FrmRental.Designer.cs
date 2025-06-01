namespace Game_Rental_Management
{
    partial class FrmRental
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
            this.cboBID = new System.Windows.Forms.ComboBox();
            this.cboCID = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRENTAL = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RecalculateTotal = new System.Windows.Forms.Button();
            this.btnAddDetails = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRentalDate = new System.Windows.Forms.DateTimePicker();
            this.txtBranchID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtTotalCost = new System.Windows.Forms.TextBox();
            this.txtRentalID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboRID = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRENTAL)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cboRID);
            this.panel1.Controls.Add(this.cboBID);
            this.panel1.Controls.Add(this.cboCID);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgvRENTAL);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 315);
            this.panel1.TabIndex = 3;
            // 
            // cboBID
            // 
            this.cboBID.FormattingEnabled = true;
            this.cboBID.Location = new System.Drawing.Point(434, 57);
            this.cboBID.Name = "cboBID";
            this.cboBID.Size = new System.Drawing.Size(113, 21);
            this.cboBID.TabIndex = 27;
            // 
            // cboCID
            // 
            this.cboCID.FormattingEnabled = true;
            this.cboCID.Location = new System.Drawing.Point(267, 57);
            this.cboCID.Name = "cboCID";
            this.cboCID.Size = new System.Drawing.Size(105, 21);
            this.cboCID.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.Location = new System.Drawing.Point(555, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 27);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "RENTAL";
            // 
            // dgvRENTAL
            // 
            this.dgvRENTAL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRENTAL.Location = new System.Drawing.Point(19, 88);
            this.dgvRENTAL.Name = "dgvRENTAL";
            this.dgvRENTAL.RowHeadersWidth = 62;
            this.dgvRENTAL.Size = new System.Drawing.Size(615, 213);
            this.dgvRENTAL.TabIndex = 0;
            this.dgvRENTAL.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRENTAL_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.RecalculateTotal);
            this.panel2.Controls.Add(this.btnAddDetails);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpReturnDate);
            this.panel2.Controls.Add(this.dtpRentalDate);
            this.panel2.Controls.Add(this.txtBranchID);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnReload);
            this.panel2.Controls.Add(this.txtCustomerID);
            this.panel2.Controls.Add(this.txtTotalCost);
            this.panel2.Controls.Add(this.txtRentalID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(13, 334);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(644, 202);
            this.panel2.TabIndex = 5;
            // 
            // RecalculateTotal
            // 
            this.RecalculateTotal.BackColor = System.Drawing.SystemColors.Highlight;
            this.RecalculateTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RecalculateTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecalculateTotal.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RecalculateTotal.Location = new System.Drawing.Point(465, 119);
            this.RecalculateTotal.Margin = new System.Windows.Forms.Padding(2);
            this.RecalculateTotal.Name = "RecalculateTotal";
            this.RecalculateTotal.Size = new System.Drawing.Size(79, 32);
            this.RecalculateTotal.TabIndex = 27;
            this.RecalculateTotal.Text = "Recalculate";
            this.RecalculateTotal.UseVisualStyleBackColor = false;
            this.RecalculateTotal.Click += new System.EventHandler(this.RecalculateTotal_Click);
            // 
            // btnAddDetails
            // 
            this.btnAddDetails.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetails.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAddDetails.Location = new System.Drawing.Point(73, 121);
            this.btnAddDetails.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDetails.Name = "btnAddDetails";
            this.btnAddDetails.Size = new System.Drawing.Size(80, 30);
            this.btnAddDetails.TabIndex = 26;
            this.btnAddDetails.Text = "Add detail";
            this.btnAddDetails.UseVisualStyleBackColor = false;
            this.btnAddDetails.Click += new System.EventHandler(this.btnAddDetails_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(333, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Return date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 24;
            this.label4.Text = "Rental date:";
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Location = new System.Drawing.Point(417, 83);
            this.dtpReturnDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(135, 20);
            this.dtpReturnDate.TabIndex = 21;
            // 
            // dtpRentalDate
            // 
            this.dtpRentalDate.Location = new System.Drawing.Point(121, 83);
            this.dtpRentalDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpRentalDate.Name = "dtpRentalDate";
            this.dtpRentalDate.Size = new System.Drawing.Size(135, 20);
            this.dtpRentalDate.TabIndex = 20;
            // 
            // txtBranchID
            // 
            this.txtBranchID.Location = new System.Drawing.Point(417, 49);
            this.txtBranchID.Margin = new System.Windows.Forms.Padding(2);
            this.txtBranchID.Name = "txtBranchID";
            this.txtBranchID.Size = new System.Drawing.Size(197, 20);
            this.txtBranchID.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(343, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Branch ID:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnCancel.Location = new System.Drawing.Point(465, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 32);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.Location = new System.Drawing.Point(361, 156);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 32);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnEdit.Location = new System.Drawing.Point(263, 156);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 32);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdd.Location = new System.Drawing.Point(169, 156);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 32);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReload
            // 
            this.btnReload.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReload.Location = new System.Drawing.Point(73, 156);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(80, 32);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = false;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.Location = new System.Drawing.Point(417, 18);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(197, 22);
            this.txtCustomerID.TabIndex = 6;
            // 
            // txtTotalCost
            // 
            this.txtTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCost.Location = new System.Drawing.Point(121, 49);
            this.txtTotalCost.Name = "txtTotalCost";
            this.txtTotalCost.Size = new System.Drawing.Size(159, 22);
            this.txtTotalCost.TabIndex = 5;
            this.txtTotalCost.TextChanged += new System.EventHandler(this.txtTotalCost_TextChanged);
            // 
            // txtRentalID
            // 
            this.txtRentalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRentalID.Location = new System.Drawing.Point(121, 19);
            this.txtRentalID.Name = "txtRentalID";
            this.txtRentalID.Size = new System.Drawing.Size(159, 22);
            this.txtRentalID.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(324, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Customer ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total cost :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental ID: ";
            // 
            // cboRID
            // 
            this.cboRID.FormattingEnabled = true;
            this.cboRID.Location = new System.Drawing.Point(85, 56);
            this.cboRID.Name = "cboRID";
            this.cboRID.Size = new System.Drawing.Size(105, 21);
            this.cboRID.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Rental ID: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Customer ID: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(375, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Branch ID: ";
            // 
            // FrmRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmRental";
            this.Size = new System.Drawing.Size(675, 550);
            this.Load += new System.EventHandler(this.FrmRental_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRENTAL)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRENTAL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBranchID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtTotalCost;
        private System.Windows.Forms.TextBox txtRentalID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.DateTimePicker dtpRentalDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddDetails;
        private System.Windows.Forms.Button RecalculateTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboBID;
        private System.Windows.Forms.ComboBox cboCID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboRID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}