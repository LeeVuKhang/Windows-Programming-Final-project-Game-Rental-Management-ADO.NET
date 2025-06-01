using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLBranch
    {
        DBMain db = null;

        public BLBranch()
        {
            db = new DBMain();
        }

        // Get all branches
        public DataSet GetAllBranches()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Branch", CommandType.Text);
        }

        // Add new branch
        public bool AddBranch(string branchID, string branchName, string address, string phone, ref string err)
        {
            string sqlString = "INSERT INTO Branch (BranchID, BranchName, Address, Phone) VALUES (" +
                "'" + branchID + "', " +
                "N'" + branchName + "', " +
                "N'" + address + "', " +
                "'" + phone + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Delete branch by BranchID
        public bool DeleteBranch(ref string err, string branchID)
        {
            string sqlString = "DELETE FROM Branch WHERE BranchID = '" + branchID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Update branch information by BranchID
        public bool UpdateBranch(string branchID, string branchName, string address, string phone, ref string err)
        {
            string sqlString = "UPDATE Branch SET " +
                "BranchName = N'" + branchName + "', " +
                "Address = N'" + address + "', " +
                "Phone = '" + phone + "' " +
                "WHERE BranchID = '" + branchID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataTable GetBranchRevenueReport(DateTime fromDate, DateTime toDate)
        {
            string query = @"
        SELECT 
            B.BranchID,
            B.BranchName,
            COUNT(DISTINCT R.RentalID) AS RentalsCount,
            ISNULL(SUM(R.TotalCost), 0) AS TotalRevenue,
            COUNT(RD.GameID) AS TotalGamesRented
        FROM Branch B
        LEFT JOIN Rental R ON R.BranchID = B.BranchID AND R.RentalDate BETWEEN @FromDate AND @ToDate
        LEFT JOIN RentalDetails RD ON R.RentalID = RD.RentalID
        GROUP BY B.BranchID, B.BranchName
        ORDER BY TotalRevenue DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@FromDate", fromDate),
        new SqlParameter("@ToDate", toDate)
            };

            return db.ExecuteQuery(query, CommandType.Text, parameters);
        }


    }
}
