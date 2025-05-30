using Game_Rental_Management.DB_layer;
using System;
using System.Data;

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

        public bool AddRentalDetail(string rentalID, string gameID, int daysRented, decimal price, ref string err)
        {
            string sqlString = "INSERT INTO RentalDetails (RentalID, GameID, DaysRented, Price) VALUES (" +
                "'" + rentalID + "', " +
                "'" + gameID + "', " +
                daysRented + ", " +
                price + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Delete based on composite key RentalID and GameID
        public bool DeleteRentalDetail(ref string err, int rentalID, int gameID)
        {
            string sqlString = "DELETE FROM RentalDetails WHERE RentalID = " + rentalID + " AND GameID = " + gameID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        // Update based on composite key RentalID and GameID
        public bool UpdateRentalDetail(string rentalID, string gameID, int daysRented, decimal price, ref string err)
        {
            string sqlString = "UPDATE RentalDetails SET " +
                "DaysRented = " + daysRented + ", " +
                "Price = " + price + " " +
                "WHERE RentalID = '" + rentalID + "' AND GameID = '" + gameID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public decimal GetTotalCostByRentalID(string rentalID)
        {
            string sql = $"SELECT SUM(Price) AS TotalCost FROM RentalDetails WHERE RentalID = '{rentalID}'";
            var ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["TotalCost"] != DBNull.Value)
                return Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalCost"]);
            return 0;
        }
    }
}
