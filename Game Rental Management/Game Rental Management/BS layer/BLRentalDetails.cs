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

        public DataSet LayRentalDetails()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM RentalDetails", CommandType.Text);
        }

        public bool ThemRentalDetails(int rentalID, int gameID, int daysRented, decimal price, ref string err)
        {
            string sqlString = "INSERT INTO RentalDetails (RentalID, GameID, DaysRented, Price) VALUES (" +
                rentalID + ", " + gameID + ", " + daysRented + ", " + price + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaRentalDetails(ref string err, int rentalDetailID)
        {
            string sqlString = "DELETE FROM RentalDetails WHERE RentalDetailID = " + rentalDetailID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatRentalDetails(int rentalDetailID, int rentalID, int gameID, int daysRented, decimal price, ref string err)
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
