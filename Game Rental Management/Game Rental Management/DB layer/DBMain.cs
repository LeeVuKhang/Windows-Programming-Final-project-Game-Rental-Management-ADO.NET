using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Rental_Management.DB_layer
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class DBMain
    {
        string ConnStr = "Data Source =DESKTOP-DSFVLOV\\SQLEXPRESS;" +
 "Initial Catalog=GameRentalDB;" +
 "Integrated Security=True";

        SqlConnection conn = null;
        SqlCommand comm = null;
        SqlDataAdapter da = null;

        public DBMain()
        {
            conn = new SqlConnection(ConnStr);
            comm = conn.CreateCommand();
        }

        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            comm.CommandText = strSQL;
            comm.CommandType = ct;

            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();

            da.Fill(ds);
            conn.Close(); 
            return ds;
        }
        //Query with parameter
        public DataSet ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] parameters)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            comm.Parameters.Clear(); // Xóa tham số cũ nếu có
            comm.CommandText = strSQL;
            comm.CommandType = ct;
            comm.Connection = conn;

            if (parameters != null)
                comm.Parameters.AddRange(parameters);

            da = new SqlDataAdapter(comm);
            DataSet ds = new DataSet();
            da.Fill(ds);

            conn.Close();
            return ds;
        }


        public bool MyExecuteNonQuery(string strSQL, CommandType ct, ref string error)
        {
            bool success = false;

            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();

            comm.CommandText = strSQL;
            comm.CommandType = ct;

            try
            {
                comm.ExecuteNonQuery();
                success = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return success;
        }
        public bool MyExecuteNonQuery(string strSQL, CommandType ct, SqlParameter[] parameters, ref string error)
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(ConnStr))
            using (SqlCommand comm = conn.CreateCommand())
            {
                conn.Open();
                comm.CommandText = strSQL;
                comm.CommandType = ct;
                if (parameters != null)
                    comm.Parameters.AddRange(parameters);
                try
                {
                    comm.ExecuteNonQuery();
                    success = true;
                }
                catch (SqlException ex)
                {
                    error = ex.Message;
                }
            }
            return success;
        }
    }
}
