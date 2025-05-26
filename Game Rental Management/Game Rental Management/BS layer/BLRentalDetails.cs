using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLRentalDetails
    {
        DBMain db = null;

        public BLRentalDetails()
        {
            db = new DBMain();
        }

        public DataSet GetRentalDetails()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM RentalDetails", CommandType.Text);
        }

        public bool AddRentalDetail(string rentalDetailID, int rentalID, int gameID, int daysRented, decimal price, ref string err)
        {
            string sqlString = "INSERT INTO RentalDetails (RentalDetailID, RentalID, GameID, DaysRented, Price) VALUES (" +
                rentalDetailID + ", " + rentalID + ", " + gameID + ", " + daysRented + ", " + price + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool DeleteRentalDetail(ref string err, int rentalDetailID)
        {
            string sqlString = "DELETE FROM RentalDetails WHERE RentalDetailID = " + rentalDetailID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool UpdateRentalDetail(string rentalDetailID, int rentalID, int gameID, int daysRented, decimal price, ref string err)
        {
            string sqlString = "UPDATE RentalDetails SET " +
                "RentalID = " + rentalID + ", " +
                "GameID = " + gameID + ", " +
                "DaysRented = " + daysRented + ", " +
                "Price = " + price + " " +
                "WHERE RentalDetailID = " + rentalDetailID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }

}
