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
    internal class BLBranchRevenue
    {
        DBMain db = null;

        public BLBranchRevenue() 
        {
            db = new DBMain();
        }
        public DataSet GetData(DateTime FromDate, DateTime ToDate)
        {
            string query = @"
            SELECT 
                b.BranchID, 
                b.BranchName, 
                ISNULL(SUM(r.TotalCost), 0) AS Revenue
            FROM 
                Branch b
            LEFT JOIN 
                Rental r ON b.BranchID = r.BranchID 
                          AND r.RentalDate BETWEEN @FromDate AND @ToDate
            GROUP BY 
                b.BranchID, b.BranchName";


            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", FromDate),
                new SqlParameter("@ToDate", ToDate)
            };
            
            return db.ExecuteQueryDataSet(query, CommandType.Text, parameters);
        }
    }
}
