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
        public DataSet GetRevenueData(string branchID, DateTime FromDate, DateTime ToDate)
        {
            string query = @"
            SELECT 
                b.BranchID, 
                b.BranchName, 
                ISNULL(SUM(r.TotalCost), 0) AS Revenue
            FROM 
                Branch b
            LEFT JOIN 
                Rental r ON b.BranchID = r.BranchID 
                          AND r.RentalDate BETWEEN @FromDate AND @ToDate
            WHERE 
                (@BranchID IS NULL OR b.BranchID = @BranchID)
            GROUP BY 
                b.BranchID, b.BranchName";

            SqlParameter[] parameters = {
                new SqlParameter("@BranchID", (object)branchID ?? DBNull.Value),
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)
            };

            return db.ExecuteQueryDataSet(query, CommandType.Text, parameters);
        }

    }
}
