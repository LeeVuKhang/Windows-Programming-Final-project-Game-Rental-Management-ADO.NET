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
    class BLRental
    {
        DBMain db = null;

        public BLRental()
        {
            db = new DBMain();
        }

        public DataSet GetRentals()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Rental", CommandType.Text);
        }

        public bool AddRental(string rentalID, string customerID, DateTime rentalDate, DateTime returnDate, decimal totalCost, string branchID, ref string err)
        {
            string sqlString = "INSERT INTO Rental (RentalID, CustomerID, RentalDate, ReturnDate, TotalCost, BranchID) VALUES (" +
                "'" + rentalID + "', " +
                "'" + customerID + "', " +
                "'" + rentalDate.ToString("yyyy-MM-dd") + "', " +
                "'" + returnDate.ToString("yyyy-MM-dd") + "', " +
                totalCost + ", " +
                "'" + branchID + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool DeleteRental(ref string err, string rentalID)
        {
            string sqlString = "DELETE FROM Rental WHERE RentalID = " + rentalID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool UpdateRental(string rentalID, string customerID, DateTime rentalDate, DateTime returnDate, decimal totalCost, string branchID, ref string err)
        {
            string sqlString = "UPDATE Rental SET " +
                "CustomerID = '" + customerID + "', " +
                "RentalDate = '" + rentalDate.ToString("yyyy-MM-dd") + "', " +
                "ReturnDate = '" + returnDate.ToString("yyyy-MM-dd") + "', " +
                "TotalCost = " + totalCost.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", " +
                "BranchID = '" + branchID + "' " +
                "WHERE RentalID = '" + rentalID + "'";

            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }

}
