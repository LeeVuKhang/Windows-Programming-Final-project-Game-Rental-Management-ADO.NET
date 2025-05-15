using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLRental
    {
        DBMain db = null;

        public BLRental()
        {
            db = new DBMain();
        }

        public DataSet LayRental()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Rental", CommandType.Text);
        }

        public bool ThemRental(int customerID, DateTime rentalDate, DateTime returnDate, decimal totalCost, int branchID, ref string err)
        {
            string sqlString = "INSERT INTO Rental (CustomerID, RentalDate, ReturnDate, TotalCost, BranchID) VALUES (" +
                customerID + ", '" + rentalDate.ToString("yyyy-MM-dd") + "', '" + returnDate.ToString("yyyy-MM-dd") + "', " +
                totalCost + ", " + branchID + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaRental(ref string err, int rentalID)
        {
            string sqlString = "DELETE FROM Rental WHERE RentalID = " + rentalID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatRental(int rentalID, int customerID, DateTime rentalDate, DateTime returnDate, decimal totalCost, int branchID, ref string err)
        {
            string sqlString = "UPDATE Rental SET " +
                "CustomerID = " + customerID + ", " +
                "RentalDate = '" + rentalDate.ToString("yyyy-MM-dd") + "', " +
                "ReturnDate = '" + returnDate.ToString("yyyy-MM-dd") + "', " +
                "TotalCost = " + totalCost + ", " +
                "BranchID = " + branchID + " " +
                "WHERE RentalID = " + rentalID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }
}
