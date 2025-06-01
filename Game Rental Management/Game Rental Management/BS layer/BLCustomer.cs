using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    class BLCustomer
    {
        DBMain db = null;

        public BLCustomer()
        {
            db = new DBMain();
        }

        public DataSet GetCustomers()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Customer", CommandType.Text);
        }

        public bool AddCustomer(string customerID, string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "INSERT INTO Customer (CustomerID, Name, Phone, Email, Address) VALUES (" +
                "'" + customerID + "', N'" + name + "', N'" + phone + "', N'" + email + "', N'" + address + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool DeleteCustomer(ref string err, string customerID)
        {
            string sqlString = "DELETE FROM Customer WHERE CustomerID = '" + customerID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool UpdateCustomer(string customerID, string name, string phone, string email, string address, ref string err)
        {
            string sqlString = "UPDATE Customer SET " +
                "Name = N'" + name + "', " +
                "Phone = N'" + phone + "', " +
                "Email = N'" + email + "', " +
                "Address = N'" + address + "' " +
                "WHERE CustomerID = '" + customerID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public DataSet GetCustomerRentalHistory(string customerID)
        {
            string sql = $@"
        SELECT 
            R.RentalID,
            G.Title AS GameTitle,
            R.RentalDate,
            R.ReturnDate,
            RD.DaysRented,
            RD.Price
        FROM Rental R
        INNER JOIN RentalDetails RD ON R.RentalID = RD.RentalID
        INNER JOIN Game G ON RD.GameID = G.GameID
        WHERE R.CustomerID = '{customerID}'
        ORDER BY R.RentalDate DESC";

            return db.ExecuteQueryDataSet(sql, CommandType.Text);
        }
        public DataTable GetCustomerReport()
        {
            string sql = @"
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

            return db.ExecuteQuery(sql, CommandType.Text, null);
        }
    }

}
