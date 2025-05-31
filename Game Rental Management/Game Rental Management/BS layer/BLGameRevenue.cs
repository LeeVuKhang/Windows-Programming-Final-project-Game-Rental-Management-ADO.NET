using Game_Rental_Management.DB_layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.BS_layer
{
    internal class BLGameRevenue
    {
        DBMain db = null;

        public BLGameRevenue()
        {
            db = new DBMain();
        }

        public DataSet GetData(string gameID, DateTime fromDate, DateTime toDate)
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
                    g.GameID = @GameID
                GROUP BY 
                    g.GameID, g.Title";

            SqlParameter[] parameters = {
                new SqlParameter("@GameID", gameID),
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return db.ExecuteQueryDataSet(query, CommandType.Text, parameters);
        }
    }
}
