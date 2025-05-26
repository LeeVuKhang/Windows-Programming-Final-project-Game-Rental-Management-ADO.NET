using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
