using Microsoft.Reporting.WinForms;
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
    public partial class FrmCustomerReport : Form
    {
        public FrmCustomerReport()
        {
            InitializeComponent();
        }

        private void FrmCustomerReport_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=GameRentalDB;Integrated Security=True";

            // Truy vấn lấy tất cả khách hàng cùng chi tiết thuê game
            string query = @"
                SELECT 
                    C.CustomerID,
                    C.Name AS CustomerName,
                    C.Phone AS CustomerPhone,
                    C.Email,
                    C.Address,
                    TotalGame.TotalGamesRented,

                    R.RentalID,
                    R.RentalDate,
                    R.ReturnDate,

                    G.Title AS GameTitle,
                    G.Platform,
                    G.Genre,
                    RD.DaysRented,
                    RD.Price
                FROM Customer C
                JOIN (
                    SELECT 
                        C2.CustomerID, 
                        COUNT(RD3.GameID) AS TotalGamesRented
                    FROM Customer C2
                    JOIN Rental R2 ON C2.CustomerID = R2.CustomerID
                    JOIN RentalDetails RD3 ON R2.RentalID = RD3.RentalID
                    GROUP BY C2.CustomerID
                ) AS TotalGame ON C.CustomerID = TotalGame.CustomerID
                JOIN Rental R ON C.CustomerID = R.CustomerID
                JOIN RentalDetails RD ON R.RentalID = RD.RentalID
                JOIN Game G ON RD.GameID = G.GameID
                ORDER BY C.CustomerID, R.RentalDate";

            DataTable dtReport = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dtReport);
            }

            // Gán dữ liệu vào ReportViewer
            reportViewer1.LocalReport.ReportPath = @"CustomerRentalReport.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CustomerRentalDataSet", dtReport));
            // Lưu ý: "CustomerRentalDataSet" phải trùng tên DataSet trong report của bạn

            reportViewer1.RefreshReport();
        }
    }
}
