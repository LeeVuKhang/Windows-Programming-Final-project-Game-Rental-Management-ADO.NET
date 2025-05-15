using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataSet LayGame()
        {
            return db.ExecuteQueryDataSet("SELECT * FROM Game", CommandType.Text);
        }

        public bool ThemGame(string title, string platform, string genre, decimal pricePerDay, int status, int branchID, ref string err)
        {
            string sqlString = "INSERT INTO Game (Title, Platform, Genre, PricePerDay, Status, BranchID) VALUES (N'" +
                title + "', N'" + platform + "', N'" + genre + "', " + pricePerDay + ", " + status + ", " + branchID + ")";
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool XoaGame(ref string err, int gameID)
        {
            string sqlString = "DELETE FROM Game WHERE GameID = " + gameID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }

        public bool CapNhatGame(int gameID, string title, string platform, string genre, decimal pricePerDay, int status, int branchID, ref string err)
        {
            string sqlString = "UPDATE Game SET " +
                "Title = N'" + title + "', " +
                "Platform = N'" + platform + "', " +
                "Genre = N'" + genre + "', " +
                "PricePerDay = " + pricePerDay + ", " +
                "Status = " + status + ", " +
                "BranchID = " + branchID + " " +
                "WHERE GameID = " + gameID;
            return db.MyExecuteNonQuery(sqlString, CommandType.Text, ref err);
        }
    }

}
