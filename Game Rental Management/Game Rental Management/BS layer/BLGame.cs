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
    class BLGame
    {
        DBMain db = null;

        public BLGame()
        {
            db = new DBMain();
        }

        public DataSet GetGames()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Game", CommandType.Text);
        }

        public bool AddGame(string gameID, string title, string platform, string genre, decimal pricePerDay, int status, string branchID, ref string err)
        {
            string sqlString = "INSERT INTO Game (GameID, Title, Platform, Genre, PricePerDay, Status, BranchID) VALUES (" +
                "'" + gameID + "', N'" + title + "', N'" + platform + "', N'" + genre + "', " + pricePerDay + ", " + status + ", '" + branchID + "')";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool DeleteGame(ref string err, string gameID)
        {
            string sqlString = "DELETE FROM Game WHERE GameID = " + gameID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool UpdateGame(string gameID, string title, string platform, string genre, decimal pricePerDay, int status, string branchID, ref string err)
        {
            string sqlString = "UPDATE Game SET " +
                "Title = N'" + title + "', " +
                "Platform = N'" + platform + "', " +
                "Genre = N'" + genre + "', " +
                "PricePerDay = " + pricePerDay + ", " +
                "Status = " + status + ", " +
                "BranchID = '" + branchID + "' " +
                "WHERE GameID = '" + gameID + "'";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
        public decimal GetPricePerDay(string gameID)
        {
            string sql = $"SELECT PricePerDay FROM Game WHERE GameID = '{gameID}'";
            var ds = db.ExecuteQueryDataSet(sql, CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0)
                return Convert.ToDecimal(ds.Tables[0].Rows[0]["PricePerDay"]);
            return 0;
        }
        public DataSet GetRevenueData(string gameID, DateTime fromDate, DateTime toDate)
        {
            string query = @"
            SELECT 
                g.GameID, 
                g.Title, 
                ISNULL(SUM(rd.Price), 0) AS Revenue
            FROM 
                Game g
            LEFT JOIN 
                RentalDetails rd ON g.GameID = rd.GameID
            LEFT JOIN 
                Rental r ON rd.RentalID = r.RentalID 
                          AND r.RentalDate BETWEEN @FromDate AND @ToDate
            WHERE 
                (@GameID IS NULL OR g.GameID = @GameID)
            GROUP BY 
                g.GameID, g.Title";

            SqlParameter[] parameters = {
                new SqlParameter("@GameID", (object)gameID ?? DBNull.Value),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return db.ExecuteQueryDataSet(query, CommandType.Text, parameters);
        }

    }


}
